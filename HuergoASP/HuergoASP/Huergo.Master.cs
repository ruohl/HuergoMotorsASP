using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoASP
{
	public partial class Huergo : System.Web.UI.MasterPage
	{
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            lbUsuario.Text = (string)Session["user"];
        }
    }
}