
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
    [Collection("parallel")]
    public  class BusinessLogicTest
    {
        // private reference declaration

        
        static FileUtility fileUtility;
       
        private readonly DateDetails _date;
        readonly User _user;
        readonly Profile _profile;
        private  IUserService _userService;
        private  IDateService _dateService;
        String testResult;

        private IUserRepository _userRepository;
        private IDateRepository _dateRepository;
        private MongoDBContext context;

        public BusinessLogicTest()
        {
         

            _profile = new Profile
            {
                FirstName = "pragati",
                LastName = "patil",
                AlternateEmail = "pragari@yahoo.com",
                MobileNumber = 2565987456,
                Occupation = "Student",
                Gender = "Female"
            };

            _user = new User
            {               
                UserName = "pragati",
                Password = "patil",
                Email = "pragati@gmail.com",
                MobileNumber = 9685744263,
                UserStatus= UserStatus.Active
             };

            MongoDBUtility mongoDBUtility = new MongoDBUtility();
            context = mongoDBUtility.MongoDBContext;
            _userRepository = new UserRepository(context);
            _userService = new UserService(_userRepository);

            _dateRepository = new DateRepository(context);
            _dateService = new DateService(_dateRepository);
           
        }
        static BusinessLogicTest()
        {
            fileUtility = new FileUtility
            {
                FilePath = "../../../../output_business_revised.txt"
            };
            fileUtility.CreateTextFile();
        }
        [Fact]
        public async Task TestFor_CreateNewUser()
        {
            try
            {
                var result = await _userService.CreateNewUser(_user);
                if (result == "New User Registered")
                {
                    testResult = "TestFor_CreateNewUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);

                }
                else
                {
                    Assert.Equal("New User Registered", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_CreateNewUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
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
                var result = await _userService.ListOfMembers();
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
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_ListOfMembers=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_VerifyUser()
        {
            try
            {
                
                
                 var result = await _userService.VerifyUser(_user.UserName,_user.Password);
                if (result.UserName == _user.UserName && result.Password == _user.Password)
                {
                    testResult = "TestFor_VerifyUser=" + "True"; 
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Equal(_user, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_VerifyUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_AddProfile()
        {
            try
            {
               var result = await _userService.AddProfile(_profile);
                if (result !=null)
                {
                    testResult = "TestFor_AddProfile=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                                
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_AddProfile=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
               
            }
        }

        //Test Methods for User Service

        [Fact]
        public async Task TestFor_ChangePassword()
        {
            try
            {
              var result = await _userService.ChangePassword(_user.UserName,"xyz");
                if(result == "User Password Changed")
                {
                    testResult = "TestFor_ChangePassword=" + "True";
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
                testResult = "TestFor_ChangePassword=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }
        [Fact]
        public async Task TestFor_SuspendUser()
        {
            try
            {
                var result = await _userService.SuspendUser(_user.UserName,UserStatus.Suspended);
                if (result == "User Suspended")
                {
                    testResult = "TestFor_SuspendUser=" + "True";
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
                testResult = "TestFor_SuspendUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);

            }
        }

    }
}
