﻿using System;
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
                ex_hist = item.Object.ex_hist,
                ex_list = item.Object.ex_list
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
                ex_list = item.Object.ex_list,
                ex_hist = item.Object.ex_hist
            }).Where(a => a.UserName == UserName).FirstOrDefault();
        }

        public async Task<User> getUser(User user)
        {
            return (await myfirebase.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                UserName = item.Object.UserName,
                Password = item.Object.Password,
                DOB = item.Object.DOB,
                Weight = item.Object.Weight,
                ex_list = item.Object.ex_list,
                ex_hist = item.Object.ex_hist
            }).Where(a => a.UserName == user.UserName && a.Password == user.Password && a.DOB == user.DOB).FirstOrDefault();
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
            List<Exercise> ex_List = new List<Exercise>();
            ex_List.Add(new Exercise("Aerobics", 3.5));
            ex_List.Add(new Exercise("Backpacking", 7.8));
            ex_List.Add(new Exercise("Badminton", 5.5));
            ex_List.Add(new Exercise("Baseball", 4));
            ex_List.Add(new Exercise("Basketball", 6.5));
            ex_List.Add(new Exercise("Biking", 8));
            ex_List.Add(new Exercise("Biking (Mountain)", 14));
            ex_List.Add(new Exercise("Biking (Stationary)", 6.8));
            ex_List.Add(new Exercise("Bowling", 4.8));
            ex_List.Add(new Exercise("Boxing", 12.8));
            ex_List.Add(new Exercise("Callisthenics", 3));
            ex_List.Add(new Exercise("Canoeing/Kyaking", 5));
            ex_List.Add(new Exercise("Cardio", 4));
            ex_List.Add(new Exercise("Conditioning Circuit", 8));
            ex_List.Add(new Exercise("Dancing (Ballet)", 5));
            ex_List.Add(new Exercise("Dancing (Ballroom)", 3));
            ex_List.Add(new Exercise("Dancing (Disco)", 7.8));
            ex_List.Add(new Exercise("Dancing (Line)", 7.8));
            ex_List.Add(new Exercise("Dancing (Swing)", 7.8));
            ex_List.Add(new Exercise("Elliptical", 5));
            ex_List.Add(new Exercise("Football", 4));
            ex_List.Add(new Exercise("Frisbee", 8));
            ex_List.Add(new Exercise("Gardening", 3.8));
            ex_List.Add(new Exercise("Golfing (No Cart)", 4.3));
            ex_List.Add(new Exercise("Handball", 8));
            ex_List.Add(new Exercise("Hiking", 7.3));
            ex_List.Add(new Exercise("Horseback Riding", 5.5));
            ex_List.Add(new Exercise("Ice Hockey", 8));
            ex_List.Add(new Exercise("Ice Skating", 7));
            ex_List.Add(new Exercise("Jogging", 9.8));
            ex_List.Add(new Exercise("Karate", 10.3));
            ex_List.Add(new Exercise("Kickboxing", 10.3));
            ex_List.Add(new Exercise("Lacrosse", 8));
            ex_List.Add(new Exercise("Mopping", 2.5));
            ex_List.Add(new Exercise("Pilates", 3));
            ex_List.Add(new Exercise("Ping Pong", 4));
            ex_List.Add(new Exercise("Racquetball", 7));
            ex_List.Add(new Exercise("Raking", 4));
            ex_List.Add(new Exercise("Rock Climbing", 6));
            ex_List.Add(new Exercise("Roller Blading", 7));
            ex_List.Add(new Exercise("Rope Jumping", 12.3));
            ex_List.Add(new Exercise("Rowing", 6));
            ex_List.Add(new Exercise("Rugby", 6.3));
            ex_List.Add(new Exercise("Running", 19));
            ex_List.Add(new Exercise("Shoveling Snow", 5.3));
            ex_List.Add(new Exercise("Skiing (Downhill)", 5.3));
            ex_List.Add(new Exercise("Skiing (Cross Country", 9));
            ex_List.Add(new Exercise("Sledding", 5));
            ex_List.Add(new Exercise("Soccer", 4));
            ex_List.Add(new Exercise("Softball", 4));
            ex_List.Add(new Exercise("Stacking Firewood", 4));
            ex_List.Add(new Exercise("Stair Climber", 9));
            ex_List.Add(new Exercise("Stair Climbing", 8));
            ex_List.Add(new Exercise("Surfing", 3));
            ex_List.Add(new Exercise("Sweeping", 3.3));
            ex_List.Add(new Exercise("Swimming", 6.6));
            ex_List.Add(new Exercise("Tae Kwon Do", 10.3));
            ex_List.Add(new Exercise("Tai Chi", 3));
            ex_List.Add(new Exercise("Tennis", 8));
            ex_List.Add(new Exercise("Volleyball", 4));
            ex_List.Add(new Exercise("Walking", 3.3));
            ex_List.Add(new Exercise("Walking The Dog", 4));
            ex_List.Add(new Exercise("Walking While Pushing A Stroller", 4.3));
            ex_List.Add(new Exercise("Washing Windows", 3.2));
            ex_List.Add(new Exercise("Water Aerobics", 5.3));
            ex_List.Add(new Exercise("Water Polo", 10));
            ex_List.Add(new Exercise("Water Skiing", 6));
            ex_List.Add(new Exercise("Weightlifting", 5));
            ex_List.Add(new Exercise("Whitewater Rafting", 5));
            ex_List.Add(new Exercise("Yoga", 2.5));
            await myfirebase.Child("Users").PostAsync<User>(new User()
            {
                Password = password,
                UserName = user_name,
                DOB = dob,
                Weight = weight,
                ex_list = ex_List
            });            
        }

        public async Task UpdateUser(string password, string user_name, string dob, double weight, List<Exercise> EX_hist, List<Exercise> ex_List)
        {
            var keyUser = (await myfirebase
                        .Child("Users").OnceAsync<User>())
                        .Where(a => a.Object.UserName == user_name && a.Object.Password == password)
                        .FirstOrDefault();


            await myfirebase
                .Child("Users")
                .Child(keyUser.Key).PutAsync(new User { DOB = dob, Password = password, UserName = user_name, Weight = weight, ex_hist = EX_hist, ex_list = ex_List });
        }

        public async Task UpdateUserNanHist(string password, string user_name, string dob, double weight, List<Exercise> ex_List)
        {
            var keyUser = (await myfirebase
                        .Child("Users").OnceAsync<User>())
                        .Where(a => a.Object.UserName == user_name && a.Object.Password == password )
                        .FirstOrDefault();

            await myfirebase
                .Child("Users")
                .Child(keyUser.Key).PutAsync(new User() { Password = password, UserName = user_name, DOB = dob, Weight = weight, ex_list = ex_List });
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
