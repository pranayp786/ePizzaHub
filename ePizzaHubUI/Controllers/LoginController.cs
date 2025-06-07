using ePizzaHubUI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using ePizzaHubUI.Models.APiModels.Response;
using ePizzaHubUI.Models.APiModels.Request;

namespace ePizzaHubUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient("ePizzaAPI");

                var userDetails = await client.GetFromJsonAsync<ValidateUserResponse>(
                                            $"Auth?userName={request.EmailAddress}&password={request.Password}");

                if (userDetails is not null)
                {
                    List<Claim> claims = [new Claim(ClaimTypes.Name, "sample@123")];
                    await GenerateTicket(claims);
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel request)
        {
            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient("ePizzaAPI");

                var userRequest
                     = new CreateUserRequestModel()
                     {
                         Email = request.Email,
                         Name = request.UserName,
                         Password = request.Password,
                         PhoneNumber = request.PhoneNumber
                     };

                HttpResponseMessage? userDetails = await client.PostAsJsonAsync<CreateUserRequestModel>("User", userRequest);
                userDetails.EnsureSuccessStatusCode();


            }
            return View();
        }


        private async Task GenerateTicket(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties()
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                });
        }

    }
}
