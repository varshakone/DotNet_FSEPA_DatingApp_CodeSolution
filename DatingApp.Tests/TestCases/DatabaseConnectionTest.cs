using DatingApp.Entities;
using DatingApp.Tests.Utility;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DatingApp.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public class DatabaseConnectionTest
    {
       
        static FileUtility fileUtility;
        MongoDBUtility MongoDBUtility;
       

        public DatabaseConnectionTest()
        {
            MongoDBUtility = new MongoDBUtility();
           
        }

        static DatabaseConnectionTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_batabase_revised.txt";
            fileUtility.CreateTextFile();
        }
        [Fact]
        public void MongoDBContext_Constructor()
        {
            try
            {
                                        //Action
                var context = MongoDBUtility.MongoDBContext ;
                if (context != null)
                {
                    string testResult = "MongoDBContext_Constructor=" + "True";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);



                }
                //Assert 
                Assert.NotNull(context);
            }
            catch (Exception ex)
            {
                string testResult = "MongoDBContext_Constructor=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
                var res =ex.Message;
            }
        }


        [Fact]
        public void MongoDBContext_GetCollection()
        {
            try
            {
                //Arrange
                        

               // _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDB.Object);

                // Action
                var context =MongoDBUtility.MongoDBContext;
              var skillCollection = context.GetCollection<DateDetails>("DateDetails");
                var userCollection = context.GetCollection<User>("Users");
                if (skillCollection != null && userCollection !=null)
                {
                    string testResult = "MongoDBContext_GetCollection=" + "True";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);
                }
                //Assert 
                Assert.NotNull(skillCollection);
                Assert.NotNull(userCollection);
            }
            catch (Exception ex)
            {
                string testResult = "MongoDBContext_GetCollection=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
                var res = ex.Message;
            }
        }
    }
}

