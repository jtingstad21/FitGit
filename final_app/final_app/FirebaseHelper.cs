using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;
using final_app;
using final_app.Models;

namespace final_app_Firebase
{
    class FirebaseHelper
    {
        FirebaseClient myfirebase = new FirebaseClient("https://fitgit-e60fb.firebaseio.com/");
        private async Task<List<User>> GetAllUsers()
        {
            return (await myfirebase.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                UserName = item.Object.UserName,
                Password = item.Object.Password,
                DOB = item.Object.DOB,
                Weight = item.Object.Weight,
            }).ToList();
        }

        
        public async Task<bool> UserExists(string UserName)
        {
            var allusers = await GetAllUsers();
            await myfirebase.Child("Users").OnceAsync<User>();
            if(allusers.Where(a => a.UserName == UserName).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> getUser(string UserName)
        {
            return (await myfirebase.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                UserName = item.Object.UserName,
                Password = item.Object.Password,
                DOB = item.Object.DOB,
                Weight = item.Object.Weight,
            }).Where(a => a.UserName == UserName).FirstOrDefault();
        }

        
        public async Task<bool> isCorrectpWUn(string UserName, string Password)
        {
            var allusers = await GetAllUsers();
            await myfirebase.Child("Users").OnceAsync<User>();
            if (allusers.Where(a => a.UserName == UserName && a.Password == Password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddUser(string password, string user_name, string dob, double weight)
        {
            await myfirebase.Child("Users").PostAsync<User>(new User()
            {
                Password = password,
                UserName = user_name,
                DOB = dob,
                Weight = weight,
            });            
        }

        public async Task UpdateUser(string password, string user_name, string dob, double weight, List<Exercise> EX_hist, List<Exercise> EX_list)
        {
            var keyUser = (await myfirebase
                        .Child("Users").OnceAsync<User>())
                        .Where(a => a.Object.UserName == user_name && a.Object.Password == password)
                        .FirstOrDefault();

            await myfirebase
                .Child("Users")
                .Child(keyUser.Key).PutAsync(new User() { DOB = dob, Password = password, UserName = user_name, Weight = weight, ex_hist = EX_hist, ex_list = EX_list });
        }

        public async Task DeleteUser(string user_name, string password)
        {
            var keyUser = (await myfirebase
                            .Child("Users")
                            .OnceAsync<User>())
                            .Where(a => a.Object.UserName == user_name && a.Object.Password == password).FirstOrDefault();

            await myfirebase
                .Child("Users")
                .Child(keyUser.Key)
                .DeleteAsync();
        }
    }
}
