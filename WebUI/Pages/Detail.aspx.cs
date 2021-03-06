using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Sanoy.AddisTower.DA;

public partial class Pages_Detail : System.Web.UI.Page
{
    #region Member Variables
    string QueryString = "";
    string type = "";
    #endregion

    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Initialize();
        }
        catch { }
    }
    #endregion

    #region Methods
    private void GetId()
    {
        QueryString = Request.QueryString["nid"];
        
    }
    private void Initialize()
    {
        GetId();       
        ShowDetailNews(QueryString);
        
    }
    protected void ShowDetailNews(string ID)
    {
        DataTable dt = new DataTable();
        
        try
        {
           dt = Sanoy.AddisTower.DA.News.ShowDetail(int.Parse(ID));
        }
        catch
        { }

       
        rptContent.DataSource = dt;
        rptContent.DataBind();       
        

    }
    #endregion
}
