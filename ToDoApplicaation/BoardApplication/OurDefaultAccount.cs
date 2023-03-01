using System;

namespace ToDoApplication
{
    public static class OurDefaultAccount
    {
      private static Dictionary<int, Person> ourPerson = new Dictionary<int, Person>();
        public static Dictionary<int,Person> ourDefaultPerson()
        {
            ourPerson.Add(1, new Person("emir", "yılmaz",1));
            ourPerson.Add(2, new Person("bilal", "yılmaz",2));
            ourPerson.Add(3, new Person("hilal", "yılmaz",3));
            ourPerson.Add(4, new Person("mecbure", "yılmaz",4));
            ourPerson.Add(5, new Person("casim", "yılmaz",5));
            ourPerson.Add(6, new Person("belma", "çimen",6));
            ourPerson.Add(7, new Person("zeynep", "keskin",7));
            ourPerson.Add(8, new Person("beyhun", "yılmaz",8));
            ourPerson.Add(9, new Person("selma", "yılmaz",9));
            ourPerson.Add(10, new Person("özkan", "kara",10));
            ourPerson.Add(11, new Person("mesut", "yılmaz",11));
            ourPerson.Add(12, new Person("ecenur", "aslan",12));
            ourPerson.Add(13, new Person("sude", "sevca",13));
            ourPerson.Add(14, new Person("nursema", "hulman",14));
            return ourPerson;

        }

        
    }
}
