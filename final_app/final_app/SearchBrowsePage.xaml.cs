using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBrowsePage : ContentPage
    {
        string CurrentUser = string.Empty;
        public SearchBrowsePage(string CurUser)
        {
            InitializeComponent();
            CurrentUser = CurUser;
        }

        public async void CalCalc_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalorieCalculator());
        }

        public void AddCalories(object sender, EventArgs e)
        {
            double.TryParse(test.Text, out double numBurnt);
            numBurnt += 56 /*should be calories burned for specific exercise*/;
            test.Text = numBurnt.ToString();
        }

        public void setIntensityLvl(object sender, EventArgs e)
        {
            var button = sender as Button;
            AerobicsIntensity.Text = button.CommandParameter.ToString();

            BaseballIntensity.Text = button.CommandParameter.ToString();
            BackPackingIntensity.Text = button.CommandParameter.ToString();
            BadmintonIntensity.Text = button.CommandParameter.ToString();
            BasketballIntensity.Text = button.CommandParameter.ToString();
            BikingIntensity.Text = button.CommandParameter.ToString();
            BikingMtnIntensity.Text = button.CommandParameter.ToString();
            BikingStatIntensity.Text = button.CommandParameter.ToString();
            BowlingIntensity.Text = button.CommandParameter.ToString();
            BoxingIntensity.Text = button.CommandParameter.ToString();
            CallisthenicsIntensity.Text = button.CommandParameter.ToString();
            CanoeingIntensity.Text = button.CommandParameter.ToString();
            CardioIntensity.Text = button.CommandParameter.ToString();
            ConditioningCircuitIntensity.Text = button.CommandParameter.ToString();
            DancingBalletIntensity.Text = button.CommandParameter.ToString();
            DancingBallroomIntensity.Text = button.CommandParameter.ToString();
            DancingDiscoIntensity.Text = button.CommandParameter.ToString();
            DancingLineIntensity.Text = button.CommandParameter.ToString();
            DancingSwingIntensity.Text = button.CommandParameter.ToString();
            EllipticalIntensity.Text = button.CommandParameter.ToString();
            FootballIntensity.Text = button.CommandParameter.ToString();
            FrisbeeIntensity.Text = button.CommandParameter.ToString();
            GardeningIntensity.Text = button.CommandParameter.ToString();
            GolfingNoCartIntensity.Text = button.CommandParameter.ToString();
            HandballIntensity.Text = button.CommandParameter.ToString();
            HikingIntensity.Text = button.CommandParameter.ToString();
            HorsebackRidingIntensity.Text = button.CommandParameter.ToString();
            IceHockeyIntensity.Text = button.CommandParameter.ToString();
            IceSkatingIntensity.Text = button.CommandParameter.ToString();
            JoggingIntensity.Text = button.CommandParameter.ToString();
            KarateIntensity.Text = button.CommandParameter.ToString();
            KickBoxingIntensity.Text = button.CommandParameter.ToString();
            LacrosseIntensity.Text = button.CommandParameter.ToString();
            MoppingIntensity.Text = button.CommandParameter.ToString();
            PilatesIntensity.Text = button.CommandParameter.ToString();
            PingPongIntensity.Text = button.CommandParameter.ToString();
            RacquetballIntensity.Text = button.CommandParameter.ToString();
            RakingIntensity.Text = button.CommandParameter.ToString();
            RockClimbingIntensity.Text = button.CommandParameter.ToString();
            RollerBladingIntensity.Text = button.CommandParameter.ToString();
            RopeJumpingIntensity.Text = button.CommandParameter.ToString();
            RowingIntensity.Text = button.CommandParameter.ToString();
            ShovelingSnowIntensity.Text = button.CommandParameter.ToString();
            SkiingDownhillIntensity.Text = button.CommandParameter.ToString();
            SkiingCrossCountryIntensity.Text = button.CommandParameter.ToString();
            SleddingIntensity.Text = button.CommandParameter.ToString();
            SoccerIntensity.Text = button.CommandParameter.ToString();
            SoftballIntensity.Text = button.CommandParameter.ToString();
            StackingFirewoodIntensity.Text = button.CommandParameter.ToString();
            StairClimberIntensity.Text = button.CommandParameter.ToString();
            StairClimbingIntensity.Text = button.CommandParameter.ToString();
            SurfingIntensity.Text = button.CommandParameter.ToString();
            SweepingIntensity.Text = button.CommandParameter.ToString();
            SwimmingIntensity.Text = button.CommandParameter.ToString();
            TaeKwonDoIntensity.Text = button.CommandParameter.ToString();
            TaiChiIntensity.Text = button.CommandParameter.ToString();
            TennisIntensity.Text = button.CommandParameter.ToString();
            VolleyballIntensity.Text = button.CommandParameter.ToString();
            WalkingIntensity.Text = button.CommandParameter.ToString();
            WalkingTheDogIntensity.Text = button.CommandParameter.ToString();
            WalkingWithAStrollerIntensity.Text = button.CommandParameter.ToString();
            WashingWindowsIntensity.Text = button.CommandParameter.ToString();
            WaterAerobicsIntensity.Text = button.CommandParameter.ToString();
            WaterPoloIntensity.Text = button.CommandParameter.ToString();
            WaterSkiingIntensity.Text = button.CommandParameter.ToString();
            WhitewaterRaftingIntensity.Text = button.CommandParameter.ToString();
            YogaIntensity.Text = button.CommandParameter.ToString();
        }

    }
}