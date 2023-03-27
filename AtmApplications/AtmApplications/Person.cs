using System;
namespace AtmApplications
{
    public class Person
    {

        public Person(string name, string surname, int id,string password, int balance)
        {
            this.Name=name;
            this.Surnme=surname;
            this.Id=id;
            this.Password = password;
            this.Balance=balance;
            DefaultAccount.persons.Add(this);
        }

        public string Name { get; set; }
        public string Surnme { get; set; }
        public int Id { get; set; }
        public int Balance { get; set; }

        public string Password { get; set; }
    }
}
