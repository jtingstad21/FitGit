using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using final_app.Models;

namespace final_app
{
    public class User
    {
        public List<Exercise> ex_list;
        public List<Exercise> ex_hist;
        
        //public List<Exercise> ex_list
        //{
        //    get { return ex_list}
        //}

        public User()
        {
            ex_list = new List<Exercise>();
            ex_hist = new List<Exercise>();
        }

        public string Password
        {
            get;
            set;
        }

        public string DOB
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public double Weight
        {
            get;
            set;
        }
    }
    
}
