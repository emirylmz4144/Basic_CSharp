using System;


namespace PhoneDirectory
{
    public class Person
    {
        private String name;
        private String surName;
        private String number;

        public Person() { }
        public Person(string name, string surName, string number)
        {
            this.Name = name;
            this.SurName = surName;
            this.Number = number;
        }

        public string Name 
        { 
            get => name;
            set => name = value;
        }
        public string SurName
        {
            get => surName;
            set => surName = value;
        }
        public string Number 
        { 
            get => number; 
            set => number = value;
        }
    }
}
