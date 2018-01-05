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
using System.Collections.Generic;

public partial class Pages_MFA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] == "3")
            {
                panMotorcycle.Visible = true;
                
                //txtName.Text = Guid.NewGuid().ToString();
            }
            else
            {
                panMotorcycle.Visible = false;
            }

            if (Request.QueryString["Id"] == "4")
            {
               panSparepart.Visible = true;
              //List<DataAccessSearch.SparepartCategory>category  =  BusinessEntitySearch.SparepartCategory.PopulateAllSparepartCategoy();

              // ddlCategory.SelectedItem.Text = category[0].Name.ToString();
            }
            else
            {
                panSparepart.Visible = false;
            }
            if (Request.QueryString["Id"] != null)
            {
               Sanoy.AddisTower.BE.CommonPage commonPage =Sanoy.AddisTower.DA.CommonPage.Select(Convert.ToInt32(Request.QueryString["Id"].ToString()));
                this.Title = litContentTitle.Text = commonPage.Title.ToString();
               Sanoy.AddisTower.BE.CommonPageContent commonPageContent =Sanoy.AddisTower.DA.CommonPageContent.SelectApproved(int.Parse(Request.QueryString["Id"].ToString()));
                litContent.Text = commonPageContent.Content;
            }
           

        }
        catch { }
    }
}
