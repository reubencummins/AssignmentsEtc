using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital_Assignment
{

    

    class Patient
    {
        public string Name 
        { 
            get; 
            set; 
        }
        public int Age 
        { 
            get; 
            set; 
        }
        public BloodType Blood
        {
            get;
            set;
        }

        public Patient(string name, int age, BloodType blood)
        {
            Name = name;
            Age = age;
            Blood = blood;
            if (Name == "")
                Name = "John Doe";
        }
        public Patient():this("John Doe", 20, BloodType.O)
        {
        }
        public Patient( string name):this(name, 20, BloodType.O)
        {
        }
        public Patient (int age):this("John Doe", age, BloodType.O)
        {
        }
        public Patient (BloodType blood):this("John Doe", 20, blood)
	    {
	    }

        public override string ToString()
        {
            return String.Format("{0} Age: {1} Blood Type: {2}", Name, Age, Blood);
        }
    }
    
}
