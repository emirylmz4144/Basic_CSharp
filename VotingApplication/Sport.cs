using System;


namespace VotingApplication
{
    public class Sport:Categories
    {

        public static List<Sport> ourCatagories = new List<Sport>();
        public static double votateOfType { get; set; }
        public static int personQuality { get; set; }
        public Sport(string typeName) : base("Spor Kategorisi", typeName)
        {
          ourCatagories.Add(this);

        }
    }
}
