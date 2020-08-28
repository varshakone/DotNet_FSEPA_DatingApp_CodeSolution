using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Controllers;
using DatingApp.BusinessLayer.Service;
using DatingApp.Entities;
using DatingApp.BusinessLayer.Interface;
using DatingApp.BusinessLayer.Service.Repository;
using DatingApp.Tests.Utility;
using DatingApp.DataLayer;

namespace DatingApp.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public  class FunctionalTest
    {
        // private references declaration
        static FileUtility fileUtility;
            
        private IUserService _userService;
        private IUserRepository _userRepository;
        private readonly UserController _userController;
        private User _user;
        private Profile _profile;
        private string testResult;
        private MongoDBContext context;
        public FunctionalTest()
        {
            MongoDBUtility mongoDBUtility = new MongoDBUtility();
            context = mongoDBUtility.MongoDBContext;
            _userRepository = new UserRepository(context);
            _userService = new UserService(_userRepository);

            
            _userController = new UserController(_userService);
           _user = new User
            {
               UserName = "pradnya",
               Password= "Joshi",
               Email = "pradnya@gmail.com",
               MobileNumber =9876543423
                
            };
            _profile = new Profile
            {
                FirstName = "pradnya",
                LastName = "Joshi",
                AlternateEmail = "pradnya@yahoo.com",
                MobileNumber = 2565987456,
                Occupation = "Student",
                Gender = "Female"
            };
        }
        static FunctionalTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_revised.txt";
            fileUtility.CreateTextFile();
        }

        //Test methods for User Controller
        [Fact]
        public async Task TestFor_CreateNewUser()
        {
            try
            {


                var result =await  _userController.CreateNewUser(_user);
                            
                if (result != null)
                {
                    testResult = "TestFor_CreateNewUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.NotNull( result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_CreateNewUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_VerifyUser()
        {
            try
            {
                
                
                var result =await _userController.ValidateUser(_user.UserName,_user.Password);
                
                if (result != null)
                {
                    testResult = "TestFor_VerifyUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_VerifyUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_ListOfMembers()
        {
            try
            {

                var rslt = await _userService.CreateNewUser(_user);
                var result = await _userController.GetAllUsers();
                if (result != null)
                {
                    testResult = "TestFor_ListOfMembers=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_ListOfMembers=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        //Test Methods for User Controller

        [Fact]
        public async Task TestFor_AddProfile()
        {
            try
            {
               
                var result =await _userController.CreateProfile(_profile);
                if (result != null)
                {
                    testResult = "TestFor_AddProfile=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_AddProfile=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_ChangePassword()
        {
            try
            {

                var result = await _userController.ChangePassword(_user.UserName,"abc");
                if (result.Value == "User Password Changed")
                {
                    testResult = "TestFor_ChangePassword=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }

                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_ChangePassword=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }
        [Fact]
        public async Task TestFor_SuspendUser()
        {
            try
            {
                var rslt = await _userService.CreateNewUser(_user);
                var result = await _userController.SuspendUser(_user.UserName, UserStatus.Suspended);
                if (result.Value == "User Suspended")
                {
                    testResult = "TestFor_SuspendUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }
                else
                {
                    Assert.Equal("User Suspended", result.Value);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_SuspendUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }
    }
}
