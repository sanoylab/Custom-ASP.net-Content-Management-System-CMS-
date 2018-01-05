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

public partial class Pages_SiteMap : System.Web.UI.Page
{
    #region mem vars
    private static string TWG = "";
    private static string lalstPublicationId = "0";
    #endregion

    #region event handlers
    private void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
    }
         #endregion

    #region methods  
    private void Initialize()
    {
        try
        {
            ShowSiteMap();
        }
        catch { }
      
    } 
    private void ShowSiteMap()
    {

        DataTable dt =  Sanoy.AddisTower.DA.SiteMap.Show();
        rptContent.DataSource = dt;
        rptContent.DataBind();
    } 
    #endregion
}
