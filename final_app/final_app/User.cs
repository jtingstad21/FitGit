using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace final_app
{
    class User
    {
        private string Password;
        private string DOB;
        private string U_Name;
        private double Weight;
        public List<List<string>> ex_list;
        public List<List<string>> ex_hist;

        
        string getPW()
        {
            return Password;
        }
        void setPW(string p)
        {
            Password = p;
        }
        string getDOB()
        {
            return DOB;
        }
        void setDOB(string d)
        {
            DOB = d;
        }
        double getWeight()
        {
            return Weight;
        }
        void setWeight(double w)
        {
            Weight = w;
        }
        string getUserName()
        {
            return U_Name;
        }
        void setUserName(string s)
        {
            U_Name = s;
        }
        List<List<string>> getExHist()
        {
            return ex_hist;
        }
        void addExHist(List<string> newHist)
        {
            ex_hist.Add(newHist);
        }
        List<List<string>> getExercises()
        {
            return ex_list;
        }
    }
    
}
