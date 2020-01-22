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
        public List<Exercise> ex_hist;
        public List<Exercise> ex_list;
        //public Dictionary<string, Exercise> ex_list;

        public User()
        {
            ex_hist = new List<Exercise>();
            //ex_list = new Dictionary<string, Exercise>();
            ex_list = new List<Exercise>();


            ex_list.Add(new Exercise("Aerobics", 3.5));
            ex_list.Add(new Exercise("Backpacking", 7.8));
            ex_list.Add(new Exercise("Badminton", 5.5));
            ex_list.Add(new Exercise("Baseball", 4));
            ex_list.Add(new Exercise("Basketball", 6.5));
            ex_list.Add(new Exercise("Biking", 8));
            ex_list.Add(new Exercise("Biking (Mountain)", 14));
            ex_list.Add(new Exercise("Biking (Stationary)", 6.8));
            ex_list.Add(new Exercise("Bowling", 4.8));
            ex_list.Add(new Exercise("Boxing", 12.8));
            ex_list.Add(new Exercise("Callisthenics", 3));
            ex_list.Add(new Exercise("Canoeing/Kyaking", 5));
            ex_list.Add(new Exercise("Cardio", 4));
            ex_list.Add(new Exercise("Conditioning Circuit", 8));
            ex_list.Add(new Exercise("Dancing (Ballet)", 5));
            ex_list.Add(new Exercise("Dancing (Ballroom)", 3));
            ex_list.Add(new Exercise("Dancing (Disco)", 7.8));
            ex_list.Add(new Exercise("Dancing (Line)", 7.8));
            ex_list.Add(new Exercise("Dancing (Swing)", 7.8));
            ex_list.Add(new Exercise("Elliptical", 5));
            ex_list.Add(new Exercise("Football", 4));
            ex_list.Add(new Exercise("Frisbee", 8));
            ex_list.Add(new Exercise("Gardening", 3.8));
            ex_list.Add(new Exercise("Golfing (No Cart)", 4.3));
            ex_list.Add(new Exercise("Handball", 8));
            ex_list.Add(new Exercise("Hiking", 7.3));
            ex_list.Add(new Exercise("Horseback Riding", 5.5));
            ex_list.Add(new Exercise("Ice Hockey", 8));
            ex_list.Add(new Exercise("Ice Skating", 7));
            ex_list.Add(new Exercise("Jogging", 9.8));
            ex_list.Add(new Exercise("Karate", 10.3));
            ex_list.Add(new Exercise("Kickboxing", 10.3));
            ex_list.Add(new Exercise("Lacrosse", 8));
            ex_list.Add(new Exercise("Mopping", 2.5));
            ex_list.Add(new Exercise("Pilates", 3));
            ex_list.Add(new Exercise("Ping Pong", 4));
            ex_list.Add(new Exercise("Racquetball", 7));
            ex_list.Add(new Exercise("Raking", 4));
            ex_list.Add(new Exercise("Rock Climbing", 6));
            ex_list.Add(new Exercise("Roller Blading", 7));
            ex_list.Add(new Exercise("Rope Jumping", 12.3));
            ex_list.Add(new Exercise("Rowing", 6));
            ex_list.Add(new Exercise("Rugby", 6.3));
            ex_list.Add(new Exercise("Running", 19));
            ex_list.Add(new Exercise("Shoveling Snow", 5.3));
            ex_list.Add(new Exercise("Skiing (Downhill)", 5.3));
            ex_list.Add(new Exercise("Skiing (Cross Country", 9));
            ex_list.Add(new Exercise("Sledding", 5));
            ex_list.Add(new Exercise("Soccer", 4));
            ex_list.Add(new Exercise("Softball", 4));
            ex_list.Add(new Exercise("Stacking Firewood", 4));
            ex_list.Add(new Exercise("Stair Climber", 9));
            ex_list.Add(new Exercise("Stair Climbing", 8));
            ex_list.Add(new Exercise("Surfing", 3));
            ex_list.Add(new Exercise("Sweeping", 3.3));
            ex_list.Add(new Exercise("Swimming", 6.6));
            ex_list.Add(new Exercise("Tae Kwon Do", 10.3));
            ex_list.Add(new Exercise("Tai Chi", 3));
            ex_list.Add(new Exercise("Tennis", 8));
            ex_list.Add(new Exercise("Volleyball", 4));
            ex_list.Add(new Exercise("Walking", 3.3));
            ex_list.Add(new Exercise("Walking The Dog", 4));
            ex_list.Add(new Exercise("Walking While Pushing A Stroller", 4.3));
            ex_list.Add(new Exercise("Washing Windows", 3.2));
            ex_list.Add(new Exercise("Water Aerobics", 5.3));
            ex_list.Add(new Exercise("Water Polo", 10));
            ex_list.Add(new Exercise("Water Skiing", 6));
            ex_list.Add(new Exercise("Weightlifting", 5));
            ex_list.Add(new Exercise("Whitewater Rafting", 5));
            ex_list.Add(new Exercise("Yoga", 2.5));

            //ex_list.Add("Aerobics", new Exercise("Aerobics", 3.5));
            //ex_list.Add("Backpacking", new Exercise("Backpacking", 7.8));
            //ex_list.Add("Badminton", new Exercise("Badminton", 5.5));
            //ex_list.Add("Baseball", new Exercise("Baseball", 4));
            //ex_list.Add("Basketball", new Exercise("Basketball", 6.5));
            //ex_list.Add("Biking", new Exercise("Biking", 8));
            //ex_list.Add("BikingMTN", new Exercise("Biking (Mountain)", 14));
            //ex_list.Add("BikingStn", new Exercise("Biking (Stationary)", 6.8));
            //ex_list.Add("Bowling", new Exercise("Bowling", 4.8));
            //ex_list.Add("Boxing", new Exercise("Boxing", 12.8));
            //ex_list.Add("Callisthenics", new Exercise("Callisthenics", 3));
            //ex_list.Add("Canoeing", new Exercise("Canoeing/Kyaking", 5));
            //ex_list.Add("Cardio", new Exercise("Cardio", 4));
            //ex_list.Add("CondCircuit", new Exercise("Conditioning Circuit", 8));
            //ex_list.Add("DancingBall", new Exercise("Dancing (Ballet)", 5));
            //ex_list.Add("DancingBallrm", new Exercise("Dancing (Ballroom)", 3));
            //ex_list.Add("DancingDisco", new Exercise("Dancing (Disco)", 7.8));
            //ex_list.Add("DancingLine", new Exercise("Dancing (Line)", 7.8));
            //ex_list.Add("DancingSwing", new Exercise("Dancing (Swing)", 7.8));
            //ex_list.Add("Elliptical", new Exercise("Elliptical", 5));
            //ex_list.Add("Football", new Exercise("Football", 4));
            //ex_list.Add("Frisbee", new Exercise("Frisbee", 8));
            //ex_list.Add("Garden", new Exercise("Gardening", 3.8));
            //ex_list.Add("Golf", new Exercise("Golfing (No Cart)", 4.3));
            //ex_list.Add("HndBll", new Exercise("Handball", 8));
            //ex_list.Add("Hiking", new Exercise("Hiking", 7.3));
            //ex_list.Add("HorseRiding", new Exercise("Horseback Riding", 5.5));
            //ex_list.Add("IceHockey", new Exercise("Ice Hockey", 8));
            //ex_list.Add("IceSkt", new Exercise("Ice Skating", 7));
            //ex_list.Add("Jog", new Exercise("Jogging", 9.8));
            //ex_list.Add("Karate", new Exercise("Karate", 10.3));
            //ex_list.Add("Kickboxing", new Exercise("Kickboxing", 10.3));
            //ex_list.Add("Lacrosse", new Exercise("Lacrosse", 8));
            //ex_list.Add("Mopping", new Exercise("Mopping", 2.5));
            //ex_list.Add("Pilates", new Exercise("Pilates", 3));
            //ex_list.Add("PngPong", new Exercise("Ping Pong", 4));
            //ex_list.Add("Racbll", new Exercise("Racquetball", 7));
            //ex_list.Add("Rake", new Exercise("Raking", 4));
            //ex_list.Add("Rckclmb", new Exercise("Rock Climbing", 6));
            //ex_list.Add("Rllblade", new Exercise("Roller Blading", 7));
            //ex_list.Add("RpJmp", new Exercise("Rope Jumping", 12.3));
            //ex_list.Add("Rowing", new Exercise("Rowing", 6));
            //ex_list.Add("Rugby", new Exercise("Rugby", 6.3));
            //ex_list.Add("Running", new Exercise("Running", 19));
            //ex_list.Add("ShvlSnow", new Exercise("Shoveling Snow", 5.3));
            //ex_list.Add("SkiiDWN", new Exercise("Skiing (Downhill)", 5.3));
            //ex_list.Add("SkiiXC", new Exercise("Skiing (Cross Country", 9));
            //ex_list.Add("Sled", new Exercise("Sledding", 5));
            //ex_list.Add("Soccer", new Exercise("Soccer", 4));
            //ex_list.Add("SftBll", new Exercise("Softball", 4));
            //ex_list.Add("StckFirewood", new Exercise("Stacking Firewood", 4));
            //ex_list.Add("StrClimber", new Exercise("Stair Climber", 9));
            //ex_list.Add("StrCliming", new Exercise("Stair Climbing", 8));
            //ex_list.Add("Surf", new Exercise("Surfing", 3));
            //ex_list.Add("Sweep", new Exercise("Sweeping", 3.3));
            //ex_list.Add("Swim", new Exercise("Swimming", 6.6));
            //ex_list.Add("TaeKwonDo", new Exercise("Tae Kwon Do", 10.3));
            //ex_list.Add("TaiChi", new Exercise("Tai Chi", 3));
            //ex_list.Add("Tennis", new Exercise("Tennis", 8));
            //ex_list.Add("Volleyball", new Exercise("Volleyball", 4));
            //ex_list.Add("Walking", new Exercise("Walking", 3.3));
            //ex_list.Add("WalkingTheDog", new Exercise("Walking The Dog", 4));
            //ex_list.Add("WalkingWhilePushingAStroller", new Exercise("Walking While Pushing A Stroller", 4.3));
            //ex_list.Add("WashingWindows", new Exercise("Washing Windows", 3.2));
            //ex_list.Add("WaterAerobics", new Exercise("Water Aerobics", 5.3));
            //ex_list.Add("WaterPolo", new Exercise("Water Polo", 10));
            //ex_list.Add("WaterSkiing", new Exercise("Water Skiing", 6));
            //ex_list.Add("Weightlifting", new Exercise("Weightlifting", 5));
            //ex_list.Add("WhitewaterRafting", new Exercise("Whitewater Rafting", 5));
            //ex_list.Add("Yoga", new Exercise("Yoga", 2.5));
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
