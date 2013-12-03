using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssignment1
{
    public enum Relationship
    {
        mother,father,other
    }
    public enum Gender
    {
        Male, Female
    }
    public partial class SchoolForm : System.Web.UI.Page
    {


        

        protected void Page_Load(object sender, EventArgs e)
        {
            //set min and max dates based on today's date
            RangeValidator1.MaximumValue = (DateTime.Today - (new TimeSpan(365 * 3, 0, 0, 0))).ToString("d");
            RangeValidator1.MinimumValue = (DateTime.Today - (new TimeSpan(365 * 5, 0, 0, 0))).ToString("d");
            if (Session["sub"] !=null)
            {
                Submission sub = (Submission)Session["sub"];
                txtName.Text = sub.CName;
                txtName2.Text = sub.CSName;
                txtDOB.Text = sub.CDOB.ToString("d");
                txtPPS.Text = sub.CPPS;
                txtPName.Text = sub.AName;
                txtPSName.Text = sub.ASName;
                txtAddress1.Text = sub.Address1;
                txtAddress2.Text = sub.Address2;
                txtAddress3.Text = sub.AddressTown;
                txtAddress4.Text = sub.AddressCounty;
                txtPhone.Text = sub.Phone1;
                txtPhone2.Text = sub.Phone2;
                txtEmail.Text = sub.Email1;
                txtEmail2.Text = sub.Email2;
                //foreach (ListItem l in rblGender.Items)
                //{
                //    if (l is RadioButton)
                //    {
                //        RadioButton r = (RadioButton)l;
                //        if (r.Text == sub.CGender.ToString())
                //            r.Checked = true;
                //    }
                //}

            }
        }


        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Relationship rel;
                //if (rdbPRel.SelectedIndex=0)
                //    rel = father;

                

                //create a submission object
                Submission sub = new Submission(txtName.Text, txtName2.Text, DateTime.Parse(txtDOB.Text), txtPPS.Text, rblGender, txtPName.Text, txtPSName.Text,rdbPRel, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtAddress4.Text, txtPhone.Text, txtPhone2.Text, txtEmail.Text, txtEmail2.Text, cblDays, rblTime);
                Session["sub"] = sub;
                Response.Redirect("Response.aspx");
            }
        


        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            //step through all controls, clear their contents depending on their type
            foreach (Control box in Page.Form.Controls)
            {
                if (box is TextBox)
                {
                    TextBox text = (TextBox)box;
                    text.Text = "";
                }
                if (box is RadioButtonList)
                {
                    RadioButtonList rdb = (RadioButtonList)box;
                    rdb.ClearSelection();
                }
                if (box is CheckBoxList)

                {
                    CheckBoxList cbl = (CheckBoxList)box;
                    cbl.ClearSelection();
                }
            }
        }


        protected void rdbPRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //activate the "Please Specify" text box if "Other" is selected for parent's relationship
            //disable it if anything else is selected
            //this is slow, as it requires a postback...
            if (rdbPRel.SelectedValue == "3")
                txtPRel.Enabled = true;
            else
                txtPRel.Enabled = false;
        }

        protected void rblTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}