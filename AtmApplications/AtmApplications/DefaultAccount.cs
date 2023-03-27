using System;

namespace AtmApplications
{
    public class DefaultAccount
    {
        public static List<Person> persons = new List<Person>();
            
            static DefaultAccount()
        {
            persons.Add(new Person("emir","yılmaz",4144,"hayatla",500));
            persons.Add(new Person("bilal", "yılmaz", 9977,"beraberim", 500));
            persons.Add(new Person("hilal", "yılmaz", 9768,"ama ölüm", 500));
            persons.Add(new Person("mecbure", "yılmaz", 7768,"aklımı", 500));
            persons.Add(new Person("cesim", "yılmaz", 6877, "çelmek",500));
            persons.Add(new Person("beyhun", "yaman", 0143,"üzere" ,500));
        }
    }
}
