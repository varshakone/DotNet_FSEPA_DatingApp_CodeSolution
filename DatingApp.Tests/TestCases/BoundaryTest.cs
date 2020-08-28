

using DatingApp.BusinessLayer.Interface;
using DatingApp.BusinessLayer.Service;
using DatingApp.BusinessLayer.Service.Repository;
using DatingApp.DataLayer;
using DatingApp.Entities;
using DatingApp.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
namespace DatingApp.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public   class BoundaryTest
    {
        // private references
        static FileUtility fileUtility;


        private MongoDBContext context;
        readonly User _user;

        private IUserRepository _userRepository;
        
        private IUserService _userService;
       
        String testResult;


        public BoundaryTest()
        {

            MongoDBUtility mongoDBUtility = new MongoDBUtility();
            context = mongoDBUtility.MongoDBContext;


            _user = new User
            {

                UserName = "Dnyati",
                Password = "Dube",
                Email = "dnyati@gmail.com",
                MobileNumber = 9685744263,
            };
            _userRepository = new UserRepository(context);
            _userService = new UserService(_userRepository);


            
        }
        static BoundaryTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_boundary_revised.txt";
            fileUtility.CreateTextFile();
        }



        // Test methods for User Service

        [Fact]
        public async Task TestFor_ValidEmail()
        {
            try
            {
                bool isEmail = false;
            if (_user.Email != "")
                {
                    Regex regex = new Regex(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$");
                     isEmail = regex.IsMatch(_user.Email);
                    if (isEmail == true)
                    {
                        var result = await _userService.CreateNewUser(_user);
                        testResult = "TestFor_ValidEmail=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        
                    }
                }
                else
                {
                    Assert.True(isEmail);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_ValidEmail=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }
        [Fact]
        public async Task TestFor_ValidMobileNumberLength()
        {
            try
            {
                bool isMobile = false;
               
                if (_user.MobileNumber != 0)
                {
                    if (_user.MobileNumber.ToString().Length == 10)
                    {
                        isMobile = true ;
                     }
                    if (isMobile == true)
                    {
                        var result = await _userService.CreateNewUser(_user);
                        testResult = "TestFor_ValidMobileNumberLength=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        
                    }
                }
                else
                {
                    Assert.True(isMobile);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_ValidMobileNumberLength=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }
        [Fact]
        public async Task TestFor_ValidUserNameAndPassword()
        {
            try
            {
                bool isFirstNameValid = true;
                bool isLastNameValid = true;
               
                if (_user.UserName != "" && _user.Password != "")
                {
                    long f;
                    long l;
                    isFirstNameValid = long.TryParse(_user.UserName, out f);
                    isLastNameValid = long.TryParse(_user.Password, out l);
                    if (isFirstNameValid == false && isLastNameValid == false)
                    {
                         var result = await _userService.CreateNewUser(_user);
                        testResult = "TestFor_ValidUserNameAndPassword=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        
                    }
                }
                else
                {
                    Assert.False(isFirstNameValid);
                    Assert.False(isLastNameValid);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_ValidUserNameAndPassword=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }


        


    }


}
