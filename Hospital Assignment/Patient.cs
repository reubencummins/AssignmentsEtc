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
        public DateTime DOB 
        { 
            get; 
            set; 
        }
        public BloodType Blood
        {
            get;
            set;
        }

        public Patient(string name, DateTime dOB, BloodType blood)
        {
            Name = name;
            DOB = dOB;
            Blood = blood;
            if (Name == "")
                Name = "John Doe";
        }
        public Patient():this("John Doe", DateTime.Now, BloodType.O)
        {
        }
        public Patient( string name):this(name, DateTime.Now, BloodType.O)
        {
        }
        public Patient (DateTime dOB):this("John Doe", dOB, BloodType.O)
        {
        }
        public Patient (BloodType blood):this("John Doe", DateTime.Now, blood)
	    {
	    }

        public override string ToString()
        {
            int age = DateTime.Today.Year - DOB.Year;
            return String.Format("{0} Age: {1} Blood Type: {2}", Name, age, Blood);
        }
    }
    
}
