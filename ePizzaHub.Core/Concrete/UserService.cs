using AutoMapper;
using ePizzaHub.Core.Contracts;
using ePizzaHub.Models.ApiModels.Request;
using ePizzaHub.Repositories.Contracts;
using ePizzHub.Infrastructure.Models;

namespace ePizzaHub.Core.Concrete
{

    public class UserService : IUserService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRoleRepository roleRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<bool> CreateUserRequestAsync(CreateUserRequest createUserRequest)
        {

            var rolesDetails =
                _roleRepository.GetAll().Where(x => x.Name == "User").FirstOrDefault();

            if (rolesDetails != null)
            {
                var user = _mapper.Map<User>(createUserRequest);

                user.Roles.Add(rolesDetails);

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                await _userRepository.AddAsync(user);

                int rowsInserted = await _userRepository.CommitAsync();

                return rowsInserted > 0;
            }
            return false;
        }
    }
}

