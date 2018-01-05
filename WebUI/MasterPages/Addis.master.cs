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
        ShowNews();
        litYear.Text = DateTime.Now.Year.ToString();
    }
    protected void ShowNews()
    {
        DataTable dt = new DataTable();
        dt = Sanoy.AddisTower.DA.News.ShowLatestNews();
        rptContent.DataSource = dt;
        rptContent.DataBind();
    }
}
