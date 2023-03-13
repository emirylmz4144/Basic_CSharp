using System;
using System.Runtime.CompilerServices;

namespace VotingApplication
{
    public abstract class Categories
    {
        public string categorieName { get; set; }
        public string typeName { get; set; }

        

        


        public Categories(string categorieName,string typeName)
        {
            this.categorieName=categorieName;
            this.typeName=typeName;
            
        }
      

    }
}
