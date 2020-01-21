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
        List<Tuple<string, Nullable<double>>> Exercise_List = new List<Tuple<string, Nullable<double>>>();
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
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Aerobics", 3.5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Backpacking", 7.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Badminton", 5.5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Baseball", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Basketball", 6.5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Biking", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Biking (Mountain)", 14));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Biking (Stationary)", 6.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Bowling", 4.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Boxing", 12.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Callisthenics", 3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Canoeing/Kyaking", 5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Cardio", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Conditioning Circuit", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Dancing (Ballet)", 5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Dancing (Ballroom)", 3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Dancing (Disco)", 7.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Dancing (Line)", 7.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Dancing (Swing)", 7.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Elliptical", 5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Football", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Frisbee", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Gardening", 3.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Golfing (No Cart)", 4.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Handball", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Hiking", 7.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Horseback Riding", 5.5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Ice Hockey", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Ice Skating", 7));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Jogging", 9.8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Karate", 10.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Kickboxing", 10.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Lacrosse", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Mopping", 2.5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Pilates", 3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Ping Pong", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Racquetball", 7));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Raking", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Rock Climbing", 6));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Roller Blading", 7));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Rope Jumping", 12.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Rowing", 6));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Rugby", 6.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Running", 19));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Shoveling Snow", 5.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Skiing (Downhill)", 5.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Skiing (Cross Country", 9));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Sledding", 5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Soccer", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Softball", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Stacking Firewood", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Stair Climber", 9));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Stair Climbing", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Surfing", 3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Sweeping", 3.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Swimming", 6.6));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Tae Kwon Do", 10.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Tai Chi", 3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Tennis", 8));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Volleyball", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Walking", 3.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Walking The Dog", 4));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Walking While Pushing A Stroller", 4.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Washing Windows", 3.2));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Water Aerobics", 5.3));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Water Polo", 10));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Water Skiing", 6));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Weightlifting", 5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Whitewater Rafting", 5));
            Exercise_List.Add(new Tuple<string, Nullable<double>>("Yoga", 2.5));

            await myfirebase.Child("Users").PostAsync<User>(new User()
            {
                Password = password,
                UserName = user_name,
                DOB = dob,
                Weight = weight,
                ex_list = Exercise_List
            });            
        }
    }
}
