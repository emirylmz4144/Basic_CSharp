using System;


namespace VotingApplication
{
    public class Music:Categories
    {
        public static List<Music> ourCatagories = new List<Music>();
        public static double votateOfType { get; set; }
        public static int personQuality { get; set; }

        public Music (string typeName) : base("Müzik kategorisi", typeName)
        {
            ourCatagories.Add(this);
            
        }
    }
}
