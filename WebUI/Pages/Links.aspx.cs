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
using System.Data.SqlClient;
using Sanoy.AddisTower.DA;

public partial class Pages_Links : System.Web.UI.Page
{
    #region mem vars
    
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
     
      
    }
   
 
    #endregion
}
