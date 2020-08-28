using Dating.BusinessLayer.Interface;
using DatingApp.BusinessLayer.Interface;
using DatingApp.BusinessLayer.Service;
using DatingApp.BusinessLayer.Service.Repository;
using DatingApp.DataLayer;
using DatingApp.Entities;
using DatingApp.Tests.Utility;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DatingApp.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public  class ExceptionTest
    {
        // private reference declaration
 
        static FileUtility fileUtility;
         private  DateDetails _date;
         User _user;
         Profile _profile;
        private IUserService _userService;
        private IDateService _dateService;
        String testResult;

        private IUserRepository _userRepository;
        private IDateRepository _dateRepository;
        private MongoDBContext context;

        public ExceptionTest()
        {
            MongoDBUtility mongoDBUtility = new MongoDBUtility();
            context = mongoDBUtility.MongoDBContext;

            _profile = new Profile
            {
                FirstName = "aniha",
                LastName = "patil",
                AlternateEmail = "aniha@gmail.com",
                MobileNumber = 2565987456,
                Occupation = "Student",
                Gender = "Female"
            };

            _user = new User
            {
                UserName = "Dnyati",
                Password = "Dube",
                Email = "dnyati@gmail.com",
                MobileNumber = 9685744263,
            };
            _userRepository = new UserRepository(context);
            _userService = new UserService(_userRepository);

            _dateRepository = new DateRepository(context);
            _dateService = new DateService(_dateRepository);

        }
        static ExceptionTest()
        {
            fileUtility = new FileUtility
            {
                FilePath = "../../../../output_exception_revised.txt"
            };
            fileUtility.CreateTextFile();
        }


        /// <summary>
        /// Test methods for User Service
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestFor_ListOfMembers()
        {
            try
            {
                _user = null;
               
                var result1 = await _userService.ListOfMembers();
                if ((result1 as List<User>).Count == 1 )
                {
                    testResult = "TestFor_ListOfMembers=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                }
                else
                {
                    Assert.Empty(result1);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_ListOfMembers=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }

        [Fact]
        public async Task TestFor_VerifyUser()
        {
            try
            {
                _user.UserName = string.Empty; _user.Password = string.Empty;
                 var result = await _userService.VerifyUser(_user.UserName, _user.Password);
                if (result.UserName == _user.UserName && result.Password == _user.Password)
                {
                    testResult = "TestFor_VerifyUser=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }
                else
                {
                    Assert.NotEqual(_user.UserName, result.UserName);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_VerifyUser=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }

        [Fact]
        public async Task TestFor_AddProfile()
        {
            try 
            {         
                _profile = null;
                var result = await _userService.AddProfile(_profile);
                if (result != null)
                {
                    testResult = "TestFor_AddProfile=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }
                else
                {
                    Assert.Null(result);
                        
  }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_AddProfile=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }

        //Test Methods for User Service

        [Fact]
        public async Task TestFor_CreateNewUser()
        {
            try
            {
                _user = null;
                var result = await _userService.CreateNewUser(_user);
                if (result == "New User Registered")
                {
                    testResult = "TestFor_CreateNewUser=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }
                else
                {
                    Assert.NotEqual("New User Registered", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_CreateNewUser=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }
        [Fact]
        public async Task TestFor_ChangePassword()
        {
            try
            {
                _user.UserName = "";
                var result = await _userService.ChangePassword(_user.UserName, "xyz");
                if (result == "User Password Changed")
                {
                    testResult = "TestFor_ChangePassword=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }
                else
                {
                    Assert.Equal("User Password Changed", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_ChangePassword=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }
        [Fact]
        public async Task TestFor_SuspendUser()
        {
            try
            {
                _user.UserName = string.Empty;
                var result = await _userService.SuspendUser(_user.UserName,UserStatus.Active);
                if (result == "User Suspended")
                {
                    testResult = "TestFor_SuspendUser=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }
                else
                {
                    Assert.Equal("User Suspended", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_SuspendUser=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }
    }
}
