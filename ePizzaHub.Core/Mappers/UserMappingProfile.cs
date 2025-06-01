using AutoMapper;
using ePizzaHub.Models.ApiModels.Request;
using ePizzHub.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Core.Mappers
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
        }
    }
}
