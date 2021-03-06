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

public partial class Pages_Downloads : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Initialize();
        }
        catch { }
    }
    
    #region "Methods"
    protected void Initialize()
    {
        GetTitle();
    }

    protected string DocumentPath()
    {
        string path = "../Downloads/";
        try
        {
            string Id = Request.QueryString["Id"].ToString();
           
            //if (Id == "1")
            //    path += "Curriculum Materials/";
            //else if (Id == "2")
            //    path += "Educational Guidelines/";
            //else if (Id == "3")
            //    path += "Manuals/";
            //else if (Id == "4")
            //    path += "Publications/";
            //else if (Id == "5")
            //    path += "Reports /";
            //else if (Id == "6")
            //    path += "Research/";
            //else if (Id == "7")
            //    path += "Planning documents - AESDP/";
            //else if (Id == "8")
            //    path += "Planning documents - Annual Plan/";
            //else if (Id == "9")
            //    path += "Statically Abstract/";
            return path;
        }
        catch { return path; }
    }
    
    protected void GetTitle()
    {
        DataTable dt= new DataTable() ;
        if(Request.QueryString["Id"].ToString()!=null)
         dt = Downloads.SelectTitle(int.Parse(Request.QueryString["Id"].ToString()));
       if(dt.Rows.Count > 0)
            litMidTitle.Text = dt.Rows[0]["Catagory"].ToString();
       
    }
  
    #endregion
}
