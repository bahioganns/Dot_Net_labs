using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

using DTO;
using BLL.Contracts;
using Domain;
using Domain.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private IMapper Mapper { get; }
        private IUserCreateService UserCreateService { get; }
        private IUserGetService UserGetService { get; }
        private IUserUpdateService UserUpdateService { get; }
        private IUserDeleteService UserDeleteService { get; }

        public UserController(ILogger<UserController> logger, IMapper mapper, IUserCreateService userCreateService, IUserGetService userGetService, IUserUpdateService userUpdateService, IUserDeleteService userDeleteService)
        {
            _logger = logger;

            this.Mapper = mapper;
            this.UserCreateService = userCreateService;
            this.UserGetService = userGetService;
            this.UserUpdateService = userUpdateService;
            this.UserDeleteService = userDeleteService;
        }

        [HttpPost]
        public UserDTO CreateUser(UserDTO user)
        {
            var updateModel = Mapper.Map<UserUpdateModel>(user);

            UserCreateService.ValidateUser(updateModel);
            User res = UserCreateService.CreateUser(updateModel);

            return Mapper.Map<UserDTO>(res);
        }

        [HttpGet("{id}")]
        public UserDTO GetUser(int id)
        {
            return Mapper.Map<UserDTO>(UserGetService.GetUser(new UserIdentityModel(id)));
        }

        [HttpPut("{id}")]
        public UserDTO UpdateUser(int id, UserDTO user)
        {
            var identityModel = new UserIdentityModel(id);
            var updateModel = Mapper.Map<UserUpdateModel>(user);

            User res = UserUpdateService.UpdateUser(identityModel, updateModel);

            return Mapper.Map<UserDTO>(res);
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            var identityModel = new UserIdentityModel(id);
            UserDeleteService.DeleteUser(identityModel);
        }
    }
}
