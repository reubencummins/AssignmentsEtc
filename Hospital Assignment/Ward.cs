using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Assignment
{
    class Ward
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ObservableCollection<Patient> Patients = new ObservableCollection<Patient>();



        public Ward (string name, int capacity)
	    {
            Name = name;
            Capacity = capacity;
            if (Name == "")
                Name = "Unnamed Ward";
	    }

        public Ward():this ("New Ward", 10)
        {

        }
        public Ward(string name):this(name, 10)
        {

        }
        public Ward(int capacity):this("New Ward", capacity)
        {

        }

        public override string ToString()
        {
            return String.Format(Name + " - Capacity: " + Capacity);
        }
    }
}
