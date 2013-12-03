using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace WebAssignment1
{
    public class Submission
    {
        
        public string CName { get; set; }
        public string CSName { get; set; }
        public DateTime CDOB { get; set; }
        public string CPPS { get; set; }
        public Gender CGender { get; set; }
        public string AName { get; set; }
        public string ASName { get; set; }
        public RadioButtonList Relat;
        public string Relationship;
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressTown { get; set; }
        public string AddressCounty { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public CheckBoxList Days;
        public RadioButtonList TimeButtons;
        public string Time { get; set; }
        string pronoun;
        string pronounC;
        double pay =1;
        double dayCost;
        int selectedDays = 0;

        public Submission(string childName,string childSurname,DateTime childDOB, string childPPS, RadioButtonList childGender, string adultName, string adultSurname, RadioButtonList rel, string address1, string address2, string addressTown, string addressCounty, string phone1, string phone2, string email1, string email2, CheckBoxList days, RadioButtonList TimeButtons)
        {
            CName = childName;
            CSName = childSurname;CDOB = childDOB;
            CPPS = childPPS;
            CGender = (Gender)Enum.Parse((typeof(Gender)),childGender.SelectedValue);
            AName = adultName;
            ASName = adultSurname;
            Relat = rel;
            Address1 = address1;
            Address2 = address2;
            AddressTown = addressTown;
            AddressCounty = addressCounty;
            Phone1 = phone1;
            Phone2 = phone2;
            Email1 = email1;
            Email2 = email2;
            //Better way to get days?
            Days = days;

            //set string and cost for chosen time
            Time = TimeButtons.SelectedValue;
            if (Time == "Full Time")
                dayCost = 25;
            else dayCost = 15;

            //set relationship and pronoun strings
            Relationship = CGender.ToString();
            switch (Relationship)
            {
                case "Male":
                    Relationship = "son";
                    pronoun = "his";
                    pronounC = "His";
                    break;
                case "Female":
                    Relationship="daughter";
                    pronoun = "her";
                    pronounC = "Her";
                    break;
                default:
                    break;
            }
            if (Relat.SelectedValue == "Other")
                Relationship = "child";

            
        }

        private string DaysString()
        {
            //make a string of the selected days with appropriate commas and/or "and"
            StringBuilder sentence = new StringBuilder();
            int i = 0;
            string[] word = new string[5];
            foreach (ListItem li in Days.Items)
            {
                if (li.Selected)
                {
                    word[i] = li.Text;
                    i++;
                }
            }
            for (int a = 0; a < i - 1; a++)
            {
                sentence.Append(word[a]);
                sentence.Append(", ");
            }
            if (i > 1)
                sentence.Append("and ");
            sentence.Append(word[i - 1]);
            return sentence.ToString();
        }

        private double GetCost()
        {

            //Calculate the cost
            foreach (ListItem li in Days.Items)
            {
                if (li.Selected)
                {
                    selectedDays++;
                }
            }
            //apply the discount, if necessary
            if (selectedDays > 3)
                pay = 0.9;
            return selectedDays * dayCost * pay;
        }

        



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("<p>{0} {1}, you have registered your {2} {3} for a {4} place on {5}.</p>", AName, ASName, Relationship, CName, Time, DaysString()));
            sb.Append(String.Format("<p>{0} date of birth is {1} and  {2} PPS number is {3}.</p>", pronounC, CDOB.ToString("d"), pronoun, CPPS));
            sb.Append(String.Format("<p>Your contact details are: {0}, {1}, {2}, {3}. Mobile: {4}, other contact number: {5}.</p>", Address1, Address2, AddressTown, AddressCounty, Phone1, Phone2));
            sb.Append(String.Format("<p>The cost of preschool will be: {0:c}</p>", GetCost()));
            return sb.ToString();
        }
    }
}