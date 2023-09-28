namespace Hackerspace.Shared.Models
{
    public class SpeedFeedCalc
    {
        private double chipLoad;

        public double ChipLoad
        {
            get { return chipLoad; }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Chipload must be positive!");
                }
                chipLoad = value; 
                Calc(); 
            }
        }

        private double rpm;

        public double RPM
        {
            get { return rpm; }
            set { rpm = value; Calc(); }
        }

        private double flutes;

        public double Flutes
        {
            get { return flutes; }
            set { flutes = value; Calc(); }
        }

        public double FeedRate { get; private set; }

        private void Calc()
        {
            FeedRate = chipLoad * rpm * flutes;
        }
    }
}
