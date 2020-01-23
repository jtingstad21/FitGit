using System;
using System.Collections.Generic;
using System.Text;

namespace final_app.Models
{
    public class Exercise   // Exercises that the user can select from
    {
        public Exercise()
        {
            Name = "";
            MET = 0;
            Intensity = "Low";
        }
        public Exercise(string n, double M)
        {
            Name = n;
            MET = M;
            Intensity = "Low";
        }

        public double ExerciseTime
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public double MET
        {
            get;
            set;
        }

        public string Intensity
        {
            get;
            set;
        }

        public double CaloriesVal
        {
            get;
            set;
        }

        public double intMinutes
        {
            get;
            set;
        }

        public double Calories(double Min, double Weight)
        {
            double cals = 0;
            if (this.Intensity == "High")
            {
                cals = (this.MET * Min * 3.5 * (Weight/2.2)) / 200;
                cals = cals * 1.25;
            }
            else if (this.Intensity == "Medium")
            {
                cals = (this.MET * Min * 3.5 * (Weight / 2.2)) / 200;
            }
            else
            {
                cals = (this.MET * Min * 3.5 * (Weight / 2.2)) / 200;
                cals = cals * 0.75;
            }
            CaloriesVal = cals;
            return cals;
        }
        public double IntMins(double min)
        {
            double mins = 0;
            if (this.Intensity == "High")
            {
                mins = min;
            }
            else if (this.Intensity == "Medium")
            {
                mins = 0.75 * min;
            }
            else
            {
                mins = 0.5 * min;
            }
            intMinutes = mins;
            return mins;
        }
    }
}
