using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using DatingApp.Entities;
using DatingApp.BusinessLayer.Service.Repository;
using DatingApp.BusinessLayer.Interface;
using DatingApp.BusinessLayer.Service;

namespace DatingApp.Tests.Utility
{
   public  class FileUtility
    {
        private  static FileStream stream;
        private static XmlSerializer serialize;
        private String filePath;
    

      
       

        public string FilePath { get => filePath; set => filePath = value; }

        
        
        public  void WriteTestCaseResuItInText(String testresult)
        {
            try
            {
                File.AppendAllText(FilePath,  testresult + "\n");
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public  void CreateTextFile()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    File.Create(FilePath).Dispose();
                }

                else
                {
                    File.Delete(FilePath);
                    File.Create(FilePath).Dispose();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //public   void TestData(User user)
        //{
        //    try
        //    {
        //        MongoDBUtility mongoDBUtility = new MongoDBUtility();
        //        UserRepository userRepository = new UserRepository(mongoDBUtility.MongoDBContext);
        //        IUserService userService = new UserService(userRepository);

        //        var result = userRepository.ValidateUserExist(user);
        //        if (result == "User Exist")
        //        {
        //            var rr = userService.RemoveUser(user.FirstName, user.LastName).Result;

                   
        //            var lst = userService.GetAllUsers();
        //            if (rr ==1)
        //            {
        //                result =userService.CreateNewUser(user).Result;
        //            }
                  
        //        }
        //        else
        //        {
        //             result =  userService.CreateNewUser(user).Result;
        //        }
               
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}
        //public void ValidateUser(User user)
        //{
        //    try
        //    {
        //        MongoDBUtility mongoDBUtility = new MongoDBUtility();
        //        UserRepository userRepository = new UserRepository(mongoDBUtility.MongoDBContext);
        //        IUserService userService = new UserService(userRepository);
        //        var result = userRepository.ValidateUserExist(user);
        //        if(result == "User Exist")
        //        {
        //            userService.RemoveUser(user.FirstName, user.LastName);
        //        }
               
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}


    }
}
