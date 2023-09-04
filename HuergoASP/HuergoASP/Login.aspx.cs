using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoASP
{
	public partial class Login : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {

            if (txPassword.Text == "1234" && txUser.Text.ToLower() == "admin")
            {
                Session.Add("user", txUser.Text);

                Response.Redirect("Home.aspx");

            }
            else
            {
                lbMsg.Text = "ERROR";
            }
        }
    }
}