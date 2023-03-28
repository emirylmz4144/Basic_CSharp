using System;

namespace AtmApplications
{
    //Kod okunabilirliği ve diğer kullanım gereklerinden dolayı sınıf static tanımlanır
    public static class DefaultAccount
    {
        public static List<Person> persons = new List<Person>();//Bu listeye dışarıdan erişim gerektiği için statik tanımlanır
            
            static DefaultAccount()//persons listesine default değerler atamak için statik bir constuructor gereklidir
        {
            persons.Add(new Person("emir","yılmaz",4144,"hayatla",500));
            persons.Add(new Person("bilal", "yılmaz", 9977,"hala beraberim", 500));
            persons.Add(new Person("hilal", "yılmaz", 9768,"ama ölüm", 500));
            persons.Add(new Person("mecbure", "yılmaz", 7768,"aklımı", 500));
            persons.Add(new Person("cesim", "yılmaz", 6877, "çelmek",500));
            persons.Add(new Person("beyhun", "yaman", 0143,"üzere" ,500));
        }
    }
}
