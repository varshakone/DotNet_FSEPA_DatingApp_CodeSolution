using DatingApp.DataLayer;
using DatingApp.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DatingApp.BusinessLayer.Service.Repository
{
   public class UserRepository : IUserRepository
    {
        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<User> _mongoCollection;
        private readonly IMongoCollection<Profile> _mongoCollectionProfile;


        /// <summary>
        /// Inject IMongoDBContext object
        /// </summary>
        public UserRepository(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<User>(typeof(User).Name);
            _mongoCollectionProfile = _mongoDBContext.GetCollection<Profile>(typeof(Profile).Name);

        }
        /// <summary>
        /// MongoDB logic to add user profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public async Task<Profile> AddProfile(Profile profile)
        {
            try
            {
                String message = string.Empty;
                 await _mongoCollectionProfile.InsertOneAsync(profile);
                 return profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MongoDB logic to update user password
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        public async Task<string> ChangePassword(string UserName, string NewPassword)
        {
            try
            {
                int count = 0;
                string message = string.Empty;
                var UserNameCriteria = Builders<User>.Filter.Eq("UserName", UserName);


                var updateElements = Builders<User>.Update.Set("Password", NewPassword);
                var updateResult = await _mongoCollection.UpdateManyAsync(UserNameCriteria, updateElements, null);

                if (updateResult.IsAcknowledged)
                {
                    count = (int)updateResult.ModifiedCount;
                }
                if (count == 1)
                {
                    message = "User Password Changed";
                }
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MongoDB logic to create new user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> CreateNewUser(User user)
        {
            try
            {
                String message = string.Empty;
                await _mongoCollection.InsertOneAsync(user);
        
                message = "New User Registered";
              
                return message; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MongoDB logic to return list of users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> ListOfMembers()
        {
            try
            {
                
                var result =await _mongoCollection.FindAsync(FilterDefinition<User>.Empty);
                               
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MongoDB logic to update user status as suspend
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        public async Task<String> SuspendUser(string UserName, UserStatus userStatus)
        {
            try
            {
                int count = 0;
                string message = string.Empty;
                var UserNameCriteria = Builders<User>.Filter.Eq("UserName", UserName);


                var updateElements = Builders<User>.Update.Set("UserStatus", userStatus);
                var updateResult = await _mongoCollection.UpdateManyAsync(UserNameCriteria, updateElements, null);
                
                if (updateResult.IsAcknowledged)
                {
                    count = (int)updateResult.ModifiedCount;
                }
                if(count >= 1)
                {
                    message = "User Suspended";
                }
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MongoDB logic to verify user exist or not
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<User> VerifyUser(string UserName, string Password)
        {
            try
            {
                
                var userNameCriteria = Builders<User>.Filter.Eq("UserName", UserName);
                var passwordCriteria = Builders<User>.Filter.Eq("Password", Password);
                


                var filterCriteria = Builders<User>.Filter.And(userNameCriteria, passwordCriteria);
                var userFind =await _mongoCollection.FindAsync(filterCriteria);
                return userFind.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
