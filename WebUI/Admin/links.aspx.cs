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

public partial class Admin_links : System.Web.UI.Page
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Populate();
        ddListOperation.Items[0].Selected = true;
        clear();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Delete(ddListOperation.SelectedValue);
        Populate();
        ddListOperation.Items[0].Selected = true;
        clear();
        
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Approve(ddListOperation.SelectedValue.ToString());
        Populate();
        ddListOperation.Items[0].Selected = true;
        clear();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //cleartextbox();
    }
    protected void cboTWG_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate();
        clear();
    }
    protected void ddListOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateFilelds();

    }
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate();
    }
    #endregion

    #region methods
    private void Initialize()
    {
        try
        {
            if (Session["User"] != null)
            {
                lblUser.Text = Session["UserName"].ToString() + " @ Related Links";

                btnSave.Enabled = ddListOperation.Enabled = btnApprove.Enabled = btnDelete.Enabled = AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session);
                Populate();
            }
            else
                Page.Response.Redirect("LogIn.aspx");
        }
        catch { }

    }
    private void Populate()
    {
         try{
        DataTable dt = new DataTable();
        ddListOperation.Items.Clear();        
        dt = Links.SelectLanguage();
        if (dt.Rows == null || dt.Rows.Count == 0)
            ddListOperation.Items.Insert(0, "-- Create New --");
        else
        {

            ddListOperation.DataTextField = "UrlText";
            ddListOperation.DataValueField = "ID";
            ddListOperation.DataSource = dt;
            ddListOperation.DataBind();
            ddListOperation.Items.Insert(0, "-- Create New --");
            btnApprove.Text = "Approve";
            btnSave.Text = "Save";
        }
    }   
    catch { }
    } 
    private void PopulateFilelds()
    {
        try{
        DataTable dt = new DataTable();
        string strqur = ddListOperation.SelectedValue.ToString();
        lblMessage.Text = "";

        if (strqur.Equals("-- Create New --"))
        {
            clear();
            btnSave.Text = "Save";
            btnApprove.Text = "Approve";
        }
        else if (short.Parse(strqur) > 0)
        {
            short pageId = short.Parse(strqur);
            dt = Links.SelectByPK(int.Parse(strqur));
            if (dt != null)
            {
                btnSave.Text = "Update";
                lblStatus.Visible = true;
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

            txtTitle.Text = dt.Rows[0]["UrlText"].ToString();
            txtFileName.Text = dt.Rows[0]["Url"].ToString();
            

        }
    }
    catch { }
    }
  
    private void clear()
    {
        
        txtTitle.Text = "";
        ddListOperation.SelectedIndex = 0;
        lblStatus.Visible = false;
        txtFileName.Text = "";
        btnSave.Text = "Save";
        btnApprove.Text = "Approve";
    }
    private void Save()
    {
        try{
        string id;
        string sql;

        if (ddListOperation.SelectedValue == "-- Create New --")
        {
            id = AdminBaseUIPage.GetID("Links");
            if (id == "")
                id = "1";
            if(Links.Insert(int.Parse(id),txtTitle.Text,txtFileName.Text,"D"))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "There was problem saving the content.";
        }
        else
        {
            id = ddListOperation.SelectedValue;
            if (Links.Update(int.Parse(id), txtTitle.Text, txtFileName.Text))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "There was problem saving the content.";
        }
        
        Populate();
    }
    catch { }

    }
    private void Delete(string entry)
    {
        try{
        if (entry == "")
        {
            lblMessage.Text = "Select a Title.";
            return;
        }

        if (Links.Delete(Convert.ToInt32(entry)))
            lblMessage.Text = "The content was succesfully Deleted.";
        else
            lblMessage.Text = "There was problem Deleting the content.";
    }
    catch { }
    }
    private void Approve(string entry)
    {
      try
      {
        bool publish;
        publish = btnApprove.Text.Equals("Approve") ? true : false;
        if (publish)
        {

            if (Links.ChangeStatus(Convert.ToInt32(entry), "P"))
                lblMessage.Text = "The content was succesfully published.";
            else
                lblMessage.Text = "There was problem publishing the content.";
        }
        else
        {
            if (Links.ChangeStatus(Convert.ToInt32(entry), "X"))
                lblMessage.Text = "The content was succesfully Suspended.";
            else
                lblMessage.Text = "There was problem Suspending the content.";
        }
      }
    catch { }
    }

    #endregion
 
}
        