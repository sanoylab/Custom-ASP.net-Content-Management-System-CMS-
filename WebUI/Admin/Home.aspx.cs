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

public partial class MFA_Web_Admin_Home : System.Web.UI.Page
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
        clear();
    }
    protected void ddListOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateFilelds();

    }
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate();
        clear();
    }
    #endregion

    #region methods
    private void Initialize()
    {
        try
        {
            if (Session["User"] != null)
            {
                btnSave.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.AddNewAndModifyContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                btnDelete.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.DeleteCotent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                btnApprove.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ApproveContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                ddListOperation.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ViewContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                Populate();
            }
            else
                Response.Redirect("Default.aspx");
        }
        catch { }
    }
    private void Populate()
    {
        try
        {
            lblUser.Text = Session["UserName"].ToString() + "@ Home Page";
            this.Title = "Home Page";
            lblCaption.Text = "Home Page";
            DataTable dt = new DataTable();
            ddListOperation.Items.Clear();
            dt = HomePage.SelectByLanguage();
            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                ddListOperation.Items.Insert(0, "-- Create New --");
            }
            else
            {
                ddListOperation.DataTextField = "Title";
                ddListOperation.DataValueField = "Id";
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
        try
        {
            DataTable dt = new DataTable();
            string strqur = ddListOperation.SelectedValue.ToString();
            lblMessage.Text = "";

            if (strqur.Equals("-- Create New --"))
            {
                clear();
                panStatus.Visible = false;
                btnSave.Text = "Save";
                btnApprove.Text = "Approve";
            }
            else if (short.Parse(strqur) > 0)
            {
                short pageId = short.Parse(strqur);
                dt = HomePage.SelectByPK(int.Parse(strqur));
                if (dt != null)
                {
                    btnSave.Text = "Update";
                    panStatus.Visible = true;
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
                lblUpdated.Text = dt.Rows[0]["Edited"].ToString() + "<br> By " + dt.Rows[0]["EditedBy"].ToString();
                lblCreated.Text = dt.Rows[0]["Created"].ToString() + "<br> By " + dt.Rows[0]["CreatedBy"].ToString();
                txtTitle.Text = dt.Rows[0]["Title"].ToString();
                FCKeditor1.Value = dt.Rows[0]["Content"].ToString();
                FCKeditor2.Value = dt.Rows[0]["Content1"].ToString();

            }
        }
        catch { }
    }
    private void clear()
    {
        FCKeditor1.Value = "";
        FCKeditor2.Value = "";
        txtTitle.Text = "";
        ddListOperation.SelectedIndex = 0;
        btnSave.Text = "Save";
        btnApprove.Text = "Approve";
        panStatus.Visible = false;

    }
    private void Save()
    {
        try
        {
            string id;
            string sql;

            if (ddListOperation.SelectedValue == "-- Create New --")
            {
                id = AdminBaseUIPage.GetID("[HomePage]");
                if (id == "")
                    id = "1";
                if (HomePage.Insert(int.Parse(id), txtTitle.Text, FCKeditor1.Value.Replace("\'", "\'\'"), FCKeditor2.Value.Replace("\'", "\'\'"), "D", DateTime.Now, Session["UserName"].ToString()))
                    lblMessage.Text = "The content was succesfully saved.";
                else
                    lblMessage.Text = "There was problem saving the content.";
            }
            else
            {
                id = ddListOperation.SelectedValue;
                if (HomePage.Update(int.Parse(id), txtTitle.Text, FCKeditor1.Value.Replace("\'", "\'\'"), FCKeditor2.Value.Replace("\'", "\'\'"), DateTime.Now, Session["UserName"].ToString()))
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
        try
        {
            if (entry == "")
            {
                lblMessage.Text = "Select a Title.";
                return;
            }

            if (HomePage.Delete(Convert.ToInt32(entry)))
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
                HomePage.SuspendContent(Convert.ToInt32(entry));
                if (HomePage.ChangeStatus(Convert.ToInt32(entry), "P"))
                    lblMessage.Text = "The content was succesfully published.";
                else
                    lblMessage.Text = "There was problem publishing the content.";

            }
            else
            {
                if (HomePage.ChangeStatus(Convert.ToInt32(entry), "X"))
                    lblMessage.Text = "The content was succesfully Suspended.";
                else
                    lblMessage.Text = "There was problem Suspending the content.";
            }
        }
        catch { }
    }

    #endregion
   
}

