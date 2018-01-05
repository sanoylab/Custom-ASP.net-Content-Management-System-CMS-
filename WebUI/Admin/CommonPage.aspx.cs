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



public partial class NALA_Admin_CommonPage : System.Web.UI.Page
{
    #region mem vars
    string QueryString;
    static string Status = "";
    static DateTime CreatedDate;
    static string CreatedBy = "";
    #endregion

    #region event handlers
    private void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
        QueryString = Request.QueryString["Id"];
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
    }
    #endregion

    #region methods
    private void Initialize()
    {
        try
        {
            
            if (Session["User"] != null)
            {
                btnSave.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.AddNewAndModifyContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
                btnDelete.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.DeleteCotent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
                btnApprove.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ApproveContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
                ddListOperation.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ViewContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
                QueryString = Request.QueryString["Id"];
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
            ddListOperation.Items.Clear();
            Sanoy.AddisTower.BE.CommonPageContent[] commonPageContent = Sanoy.AddisTower.DA.CommonPageContent.SelectAll(QueryString);
            Sanoy.AddisTower.BE.CommonPage commonPage = Sanoy.AddisTower.DA.CommonPage.Select(int.Parse(QueryString));

            lblUser.Text = Session["UserName"].ToString() + "@ " + commonPage.Title;
            this.Title = lblCaption.Text = commonPage.Title;
            if (commonPageContent.Length == 0)
                ddListOperation.Items.Insert(0, "-- Create New --");
            else
            {
              //  

                ddListOperation.DataTextField = Sanoy.AddisTower.BE.CommonPageContent.FIELD_Title;
                ddListOperation.DataValueField = Sanoy.AddisTower.BE.CommonPageContent.FIELD_Id;
                ddListOperation.DataSource = commonPageContent;
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
            Sanoy.AddisTower.BE.CommonPageContent commonPageContent = Sanoy.AddisTower.DA.CommonPageContent.Select(int.Parse(strqur));

            if (commonPageContent != null)
            {
                btnSave.Text = "Update";
                panStatus.Visible = true;
            }
            if (commonPageContent.Publish == "D")
            {
                lblStatus.Text = "Draft";
                btnApprove.Text = "Approve";
            }
            else if (commonPageContent.Publish == "P")
            {
                lblStatus.Text = "Published";
                btnApprove.Text = "Suspend";
            }
            else if (commonPageContent.Publish == "X")
            {
                lblStatus.Text = "Archive";
                btnApprove.Text = "Approve";
            }
            else if (commonPageContent.Publish == "S")
            {
                lblStatus.Text = "Suspended";
                btnApprove.Text = "Approve";
            }
            Status = commonPageContent.Publish;
            lblUpdated.Text = (commonPageContent.Edited.ToShortDateString() == "1/1/1900" ? "" : commonPageContent.Edited.ToShortDateString());
              lblUpdated.Text+="<br> By " + commonPageContent.EditedBy;
            lblCreated.Text = commonPageContent.Created.ToShortDateString() + "<br> By " + commonPageContent.CreatedBy;
            txtTitle.Text = commonPageContent.Title;
            FCKeditor1.Value = commonPageContent.Content;
            CreatedDate=commonPageContent.Created;
            CreatedBy = commonPageContent.CreatedBy;


        }
    }
    catch { }
    }
    private void clear()
    {
        FCKeditor1.Value = "";
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
      
        Sanoy.AddisTower.BE.CommonPageContent commonPageContent = new Sanoy.AddisTower.BE.CommonPageContent();
        commonPageContent.Content = FCKeditor1.Value.Replace("\'", "\'\'");
        commonPageContent.Title = txtTitle.Text;
        commonPageContent.CommonPage = int.Parse(QueryString);
        if (ddListOperation.SelectedValue == "-- Create New --")
        {
            commonPageContent.Publish = "D";
            commonPageContent.State = Sanoy.AddisTower.BE.RowState.Added;
            commonPageContent.Created = DateTime.Now;
            commonPageContent.CreatedBy = Session["UserName"].ToString();
            commonPageContent.EditedBy = "";
            commonPageContent.Edited =  Convert.ToDateTime("01/01/1900");
            
        }
        else
        {
            commonPageContent.Created = CreatedDate;
            commonPageContent.CreatedBy=CreatedBy ;
            commonPageContent.Publish = Status;
            commonPageContent.State = Sanoy.AddisTower.BE.RowState.Modified;
            commonPageContent.EditedBy=Session["UserName"].ToString();
            commonPageContent.Edited = DateTime.Now;
            commonPageContent.Id = Int32.Parse(ddListOperation.SelectedValue);
            
        }
        if (Sanoy.AddisTower.DA.CommonPageContent.Save(commonPageContent))
            lblMessage.Text = "The content was succesfully saved.";
        else
            lblMessage.Text = "There was problem saving the content.";

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

            if (Sanoy.AddisTower.DA.CommonPageContent.Delete(Convert.ToInt32(entry)))
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
            Sanoy.AddisTower.DA.CommonPageContent.SuspendContent(int.Parse(QueryString));
           
            if ( Sanoy.AddisTower.DA.CommonPageContent.ChangeStatus(Convert.ToInt32(entry), "P"))
                lblMessage.Text = "The content was succesfully published.";
            else
                lblMessage.Text = "There was problem publishing the content.";

        }
        else
        {
            if (Sanoy.AddisTower.DA.CommonPageContent.ChangeStatus(Convert.ToInt32(entry), "X"))
                lblMessage.Text = "The content was succesfully Suspended.";
            else
                lblMessage.Text = "There was problem Suspending the content.";
        }
    }
    catch { }

    }

    #endregion
  
}
