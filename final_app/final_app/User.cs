using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace final_app
{
    public class User
    {
        //private string DOB;
        //private string Password
        //private string U_Name;
        //private double Weight;
        private List<List<string>> ex_list;
        public List<List<string>> ex_hist;

        public List<List<string>> exercise_List
        {
            get { return ex_list; }
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

        //public string getPW()
        //{
        //    return Password;
        //}
        //public void setPW(string p)
        //{
        //    Password = p;
        //}
        //public string getDOB()
        //{
        //    return DOB;
        //}
        //public void setDOB(string d)
        //{
        //    DOB = d;
        //}
        //public double getWeight()
        //{
        //    return Weight;
        //}
        //public void setWeight(double w)
        //{
        //    Weight = w;
        //}
        //public string getUserName()
        //{
        //    return U_Name;
        //}
        //public void setUserName(string s)
        //{
        //    U_Name = s;
        //}
        //public List<List<string>> getExHist()
        //{
        //    return ex_hist;
        //}
        //public void addExHist(List<string> newHist)
        //{
        //    ex_hist.Add(newHist);
        //}
        //public List<List<string>> getExercises()
        //{
        //    return ex_list;
        //}
    }
    
}
