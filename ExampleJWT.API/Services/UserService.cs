using ExampleJWT.Models.Models;
using System;
using System.Collections.Generic;

namespace ExampleJWT.API.Services
{
    public class UserService
    {
        public List<User> Users;

        public UserService()
        {
            Users = new List<User>() {
                new() { UserId = 1, FistName = "Edwin", LastName = "Lozano", Email = "edwin@gmail.com", Password = "Test123" },
                new() { UserId = 2, FistName = "Dan", LastName = "Siegel", Email = "dan@gmail.com", Password = "Test123" },
                new() { UserId = 2, FistName = "Juan", LastName = "Callejas", Email = "juan@gmail.com", Password = "Test123" },
                new() { UserId = 2, FistName = "Adilene", LastName = "Estrada", Email = "adilene@gmail.com", Password = "Test123" },
                new() { UserId = 2, FistName = "Yitzhak", LastName = "Alfonso", Email = "yitzhak@gmail.com", Password = "Test123" }
            };
        }

        /// <summary>
        /// Gets a user by user id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>User</returns>
        public User Get(int userId)
        {
            try
            {
                return Users.Find(x => x.UserId == userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
