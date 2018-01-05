using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPages_Addis : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //litWelcome.Text = Session["UserName"].ToString();
    }
   
    protected void likLogout_Click(object sender, EventArgs e)
    {
        Session["User"] = null;
        Response.Redirect("Default.aspx");

    }
}
