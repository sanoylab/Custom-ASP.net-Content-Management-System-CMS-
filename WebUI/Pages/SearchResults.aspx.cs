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


public partial class Pages_SearchResults : System.Web.UI.Page
{
    #region mem vars
    static string maxPublicationId = "0";
    static string curretnTWGId = "0";
    private static string TWG = "";
    string SearchString;
    #endregion
    

    #region event handlers
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            
            Initialize();
        }
    }
  
    #endregion

    #region methods
    private void Search(string SearchString)
    {
        if (SearchString != "" && SearchString!= null)
        {
            int Count;
            SearchString = SearchString.Trim();
            DataTable dt = Sanoy.AddisTower.DA.SiteMap.Search(SearchString);
            
            Count = dt.Rows.Count;
            lblResult.Text = "<b>" + Count.ToString() + " </b> search result(s)were found for  <b><font color=#ff3366>" + SearchString + "</font></b><br /><br />";
            rptSearchResults.DataSource = dt;
            rptSearchResults.DataBind();
           
        }

        else

            lblResult.Text = "Please enter the word you want to search";

    }
    private void Initialize()
    {
      
        SearchString = Request["SearchString"];
        curretnTWGId = AdminBaseUIPage.CurrentTWG;      
        Search(SearchString);
    }
  
  
   #endregion
}


