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

public partial class Pages_FAQ : System.Web.UI.Page
{
    #region mem vars
    private static string TWG = "";
    private static string lalstPublicationId = "0";
    string maxNewsId = "0";
    private static string maxEventId = "0";
    #endregion

    #region event handlers
    private void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
       
            ShowNewsDetail(Request["Id"]);
    } 
    #endregion

    #region methods
    private void Initialize()
    {
        try
        {
            ShowFAQ();
        }
        catch { }
      
    }
    private void ShowFAQ()
    {
        try
        {
            string sql;
            DataTable tbl = Faq.Show(maxNewsId);
            if (tbl.Rows.Count > 0)
                maxNewsId = tbl.Rows[tbl.Rows.Count - 1]["ID"].ToString();

            rptFAQ.DataSource = tbl;
            rptFAQ.DataBind();
        }
        catch { }
    }

    protected void ShowNewsDetail(string id)
    {
         try
            {
        if (id != null)
        {
            DataTable dr = null;
            answer.Visible = true;
                dr = Faq.ShowNewsDetail(int.Parse(id));

                if (dr.Rows.Count > 0)
                {
                    lblTitle.Text = dr.Rows[0][1].ToString();
                    lblBody.Text = dr.Rows[0][2].ToString();
                }
                else
                {
                    lblTitle.Text = "";
                    lblBody.Text = "";
                }
        }
    }
    catch
    {
        lblTitle.Text = "";
        lblBody.Text = "";
    }
    }
 
    #endregion
 
}
