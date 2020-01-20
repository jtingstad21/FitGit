using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;
using final_app;

namespace final_app_Firebase
{
    class FirebaseHelper
    {
        FirebaseClient myfirebase = new FirebaseClient("https://fitgit-e60fb.firebaseio.com/");

        //List<List<string>> Exercise_List;

        //public bool UserExists(string U_Name)
        //{
        //    if ((myfirebase.Child("Users").OnceAsync<User>()).Select)
        //    {

        //    }
        //}

        private async Task<List<User>> GetAllUsers()
        {
            return (await myfirebase.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                UserName = item.Object.UserName,
                Password = item.Object.Password,
                DOB = item.Object.DOB,
                Weight = item.Object.Weight
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
            var allusers = await GetAllUsers();
            await myfirebase.Child("Users").OnceAsync<User>();
            return allusers.Where(a => a.UserName == UserName).FirstOrDefault();
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
            await myfirebase.Child("Users").PostAsync<User>(new User() { Password = password, UserName = user_name, DOB = dob, Weight = weight });
        }
    }
}
