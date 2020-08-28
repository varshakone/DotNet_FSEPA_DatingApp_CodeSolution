using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.BusinessLayer.Interface;
using DatingApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Inject User service object
        /// </summary>
        /// <param name="userService"></param>

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// post api to create new user by calling User service method
        /// Post api/user/newuser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("newuser")]
        [HttpPost]
        public async Task<ActionResult<string>> CreateNewUser(User user)
        {
            //business logic goes here
            try
            {
                var result =await _userService.CreateNewUser(user);
                return result;
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
        }

        /// <summary>
        /// post api to verify existing user by calling User service method
        /// Post api/user/login
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<User>> ValidateUser(String UserName, String Password)
        {
            //business logic goes here
            try
            {
                var result = await _userService.VerifyUser(UserName, Password);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        /// <summary>
        /// post api to create profile for existing user by calling User service method
        /// Post api/user/newprofile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [Route("newprofile")]
        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProfile(Profile profile)
        {
            //business logic goes here
            try
            {
                var result = await _userService.AddProfile(profile);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }


        /// <summary>
        /// Get api to retrieve all existing user by calling User service method
        /// Get api/user/allusers
        /// </summary>
        /// <returns></returns>
        [Route("allusers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            //business logic goes here
            try
            {
                var result = await _userService.ListOfMembers();
                return result.ToList();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        /// <summary>
        /// PUT api to update user password by calling User service method
        /// PUT api/user/changepassword
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        [Route("changepassword")]
        [HttpPut]
        public async Task<ActionResult<String>> ChangePassword(String UserName, String NewPassword)
        {
            //business logic goes here
            try
            {
                var result = await _userService.ChangePassword(UserName, NewPassword);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }


        /// <summary>
        /// PUT api to suspend user by calling User service method
        /// PUT api/user/suspenduser
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        [Route("suspenduser")]
        [HttpPut]
        public async Task<ActionResult<String>> SuspendUser(String UserName, UserStatus userStatus)
        {
            //business logic goes here
            try
            {
                var result = await _userService.SuspendUser(UserName, userStatus);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    }
}
