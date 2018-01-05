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

public partial class NALA_Admin_News : System.Web.UI.Page
{
    #region mem vars
    private string sql, title = "";
    private string strqur;
    #endregion


    #region event handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        Save();
        Populate();
        ddListOperation.Items[0].Selected = true;
        cleartextbox();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Delete(ddListOperation.SelectedValue);
        Populate();
        ddListOperation.Items[0].Selected = true;
        cleartextbox();

    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Approve(ddListOperation.SelectedValue.ToString());
        Populate();
        ddListOperation.Items[0].Selected = true;
        cleartextbox();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        cleartextbox();
    }
    protected void ddListOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateFilelds();

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lblAutoexpire.Text = Calendar1.SelectedDate.ToString();
    }
   
    #endregion

    #region methods
    private void Initialize()
    {
        try
        {

            if (Session["User"] != null)
            {
                ddListOperation.Enabled = btnApprove.Enabled = btnDelete.Enabled = btnSave.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ManageNews, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
               
                GetYMD();
                Populate();
            }
            else
                Response.Redirect("Default.aspx");
        }
        catch { }


    }
    private void GetYMD()
    {
        Calendar1.SelectedDate = DateTime.Now.AddDays(30);
    }
    protected void Populate()
    {
        try
        {
        DataTable dt = new DataTable();
        ddListOperation.Items.Clear();
        dt = News.SelectAll();
        if (dt.Rows == null || dt.Rows.Count == 0)
            ddListOperation.Items.Insert(0, "-- Create New --");
        else
        {

            ddListOperation.DataTextField = "Title";
            ddListOperation.DataValueField = "Id";
            ddListOperation.DataSource = dt;
            ddListOperation.DataBind();
            ddListOperation.Items.Insert(0, "-- Create New --");
            btnApprove.Text = "Approve";
            btnSave.Text = "Save";
            lblAutoexpire.Text = Calendar1.SelectedDate.ToString();
        }
    }
    catch { }

    }
    private void PopulateFilelds()
    {
        try
        {
        DataTable dt = new DataTable();
        DateTime expire;
        string strqur = ddListOperation.SelectedValue.ToString();
        lblMessage.Text = "";

        if (strqur.Equals("-- Create New --"))
        {
            cleartextbox();
            btnSave.Text = "Save";
            btnApprove.Text = "Approve";
        }
        else if (short.Parse(strqur) > 0)
        {
            short pageId = short.Parse(strqur);
            dt = News.SelectByPK(int.Parse(strqur));
            if (dt != null)
            {

                panStatus.Visible = true;
                btnSave.Text = "Update";

            }
            if (dt.Rows[0]["Publish"].ToString() == "D")
            {
                lblStatus.Text = "Draft";
                btnApprove.Text = "Approve";
            }
            else if (dt.Rows[0]["Publish"].ToString() == "P")
            {
                lblStatus.Text = "Published";
                btnApprove.Text = "Suspend";
            }
            else if (dt.Rows[0]["Publish"].ToString() == "X")
            {
                lblStatus.Text = "Archive";
                btnApprove.Text = "Approve";
            }
            else if (dt.Rows[0]["Publish"].ToString() == "S")
            {
                lblStatus.Text = "Suspended";
                btnApprove.Text = "Approve";
            }
            lblUpdated.Text = dt.Rows[0]["Edited"].ToString() + "<br> By " + dt.Rows[0]["Editor"].ToString();
            lblCreated.Text = dt.Rows[0]["Created"].ToString() + "<br> By " + dt.Rows[0]["Creator"].ToString();
            txtHeadLine.Text = dt.Rows[0]["Title"].ToString();
            FCKeditor2.Value  = dt.Rows[0]["HomePageSummary"].ToString();
            FCKeditor1.Value = dt.Rows[0]["Body"].ToString();
            expire = Convert.ToDateTime(dt.Rows[0]["AutoExpire"]);
            Calendar1.SelectedDate = expire;
            lblAutoexpire.Text = Calendar1.SelectedDate.ToString();
            if (dt.Rows[0]["ShowOnHomePage"].ToString() == "Y")
                chkShow.Checked = true;
            else
                chkShow.Checked = false;
        }
    }
    catch { }
    }
    private void Save()
    {
        try
        {
        string id;
      

        if (ddListOperation.SelectedValue == "-- Create New --")
        {
            id =   Sanoy.AddisTower.DA.Utility.GetId("News", "Id").ToString();
           

            if (News.Insert(int.Parse(id), txtHeadLine.Text, FCKeditor2.Value.Replace("\'", "\'\'"), DateTime.Now, Session["UserName"].ToString(), FCKeditor1.Value.Replace("\'", "\'\'"), (chkShow.Checked ? "Y" : "N"), "D", Calendar1.SelectedDate, ""))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "The content was not succesfully saved.";

        }
        else
        {
            id = ddListOperation.SelectedValue;

            if (News.Update(int.Parse(id), txtHeadLine.Text, FCKeditor2.Value.Replace("\'", "\'\'"), DateTime.Now, Session["UserName"].ToString(), FCKeditor1.Value.Replace("\'", "\'\'"), (chkShow.Checked ? "Y" : "N"), Calendar1.SelectedDate))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "The content was succesfully saved.";
        }
        Populate();
    }
    catch (Exception ex)
        
        {}

    }
    private void Approve(string entry)
    {
        try
        {
        bool publish;
        publish = btnApprove.Text.Equals("Approve") ? true : false;
        if (publish)
        {

            if (News.ChangeStatus(Convert.ToInt32(entry), "P"))
                lblMessage.Text = "The content was succesfully published.";
            else
                lblMessage.Text = "There was problem publishing the content.";
        }
        else
        {
            if (News.ChangeStatus(Convert.ToInt32(entry), "X"))
                lblMessage.Text = "The content was succesfully Suspended.";
            else
                lblMessage.Text = "There was problem Suspending the content.";
        }
    }
    catch { }
    }
    private void Delete(string entry)
    {
        try
        {
        if (entry == "")
        {
            lblMessage.Text = "Select a Title.";
            return;
        }


        if (News.Delete(Convert.ToInt32(entry)))
            lblMessage.Text = "The content was succesfully Deleted.";
        else
            lblMessage.Text = "There was problem Deleting the content.";
    }
    catch { }
    }
    protected void cleartextbox()
    {
        FCKeditor1.Value = "";
        FCKeditor2.Value = "";
        txtHeadLine.Text = "";
        ddListOperation.SelectedIndex = 0;
        panStatus.Visible = false;
        chkShow.Checked = false;
        Calendar1.SelectedDate = DateTime.Now.AddDays(30);


    }
    #endregion
}
