using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessEntitySearch;
using Sanoy.AddisTower.DA;

public partial class _Default : System.Web.UI.Page 
{
    BusinessEntitySearch.Motorcycle motorCycle = new Motorcycle();
    BusinessEntitySearch.Sparepart sparePart = new Sparepart();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ShowContent();
            if (ddlCategory.SelectedItem.Text == "-Select-")
                litCategory.Text = "Category";
            ShowNews();
            litYear.Text = DateTime.Now.Year.ToString();
           // showDate();
            imgMotor.Src = "~/Items/Motor/" + motorCycle.GetApprovedMotor().Model+"/" + motorCycle.GetApprovedImageUrl().ImageFileName;
            imgSparepart.Src = "~/Items/Sparepart/" + sparePart.GetApprovedSparepart().Name + "/" + sparePart.GetApprovedImageUrl().ImageFileName;
            litMotorName.Text = motorCycle.GetApprovedMotor().Name;
            litDescription.Text = motorCycle.GetApprovedMotor().Description;
            litSparepart.Text = sparePart.GetApprovedSparepart().Name;
            litSpareDescription.Text = sparePart.GetApprovedSparepart().Description;
        }
        catch { }
    }
    protected void ShowContent()
    {
        DataTable dt = new DataTable();
        dt = HomePage.SelectContent();

        litTitle.Text = dt.Rows[0]["Title"].ToString();
        litContent.Text = dt.Rows[0]["Content"].ToString();
        litContent1.Text = dt.Rows[0]["Content1"].ToString();


    }
    protected void ShowNews()
    {
        DataTable dt = new DataTable();
        dt = Sanoy.AddisTower.DA.News.ShowLatestNews();
        rptContent.DataSource = dt;
        rptContent.DataBind();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedItem.Text == "Motorcycle")
            litCategory.Text = "Motorcycle category:";
        else if (ddlCategory.SelectedItem.Text == "Sparepart")
            litCategory.Text = "Sparepart category:";
        else
            litCategory.Text = "Category:";
    }
    protected void btnSearchSite_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pages/SearchResults.aspx?SearchString="+txtSearchSite.Text);
    }
}
