using System;


namespace VotingApplication
{
    public class Person
    {
        public static  List <Person> ourPersons = new List<Person>();
        
        public string Name { get; set; }
        public  double personsVote { get; set; }

        public Person(string name)
        {
            Name = name;
            if (personsVote==null)
                personsVote = 0;
            
        }
        public static Person GetUserByUsername(string username)
        {
            foreach (Person user in Person.ourPersons)
            {
                if (user.Name == username)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
