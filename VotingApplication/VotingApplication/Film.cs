using System;


namespace VotingApplication
{
    public class Film:Categories
    {
        public static List<Film> ourCatagories = new List<Film>();
        public static double votateOfType { get; set; }
        public static int personQuality { get; set; }
        public Film(string typeName) : base("Film Kategorisi", typeName)
        {
            ourCatagories.Add(this);
            
        }
    }
}
