using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssignment1
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Submission sub = (Submission)Session["sub"];
            if (sub!=null)
                lblResponse.Text = sub.ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("SchoolForm.aspx");
        }
    }
}