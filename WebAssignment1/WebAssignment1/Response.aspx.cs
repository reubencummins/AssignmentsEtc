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
        Submission sub;
        protected void Page_Load(object sender, EventArgs e)
        {
            sub = (Submission)Session["sub"];
            if (sub!=null)
                lblResponse.Text = sub.ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["sub"] = sub;
            Response.Redirect("SchoolForm.aspx");
        }
    }
}