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

public partial class Pages_PhotoGallery : System.Web.UI.Page
{
    #region mem vars
    static string currentTWG = "1";
    static string maxNewsId = "0";
    static string maxPublicationId = "0";
    static string maxEventId = "0";

    #endregion

    #region event handlers
    private void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        Literal1.Text = Request.QueryString["Catagory"];

    }
 
    #endregion

    #region methods
    private void Initialize()
    {
        DataTable dt = new DataTable();
        dt = Sanoy.AddisTower.DA.PhotoGallery.SelectPublished(Request.QueryString["Id"]);
        dlstImageGallery.DataSource = dt;
        dlstImageGallery.DataBind();
        

    }
 
    #endregion
   
}
