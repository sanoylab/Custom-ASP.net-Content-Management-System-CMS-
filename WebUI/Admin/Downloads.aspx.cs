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

public partial class ANRSEB_Admin_Downloads : System.Web.UI.Page
{
    #region mem vars
   public static string  Id;
    #endregion

    #region event handlers
    private void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        GetId();
        Boolean fileOK = false;
        String path = Server.MapPath("../Downloads/");
        //if (Id == "1")
        //    path += "Manuals/";
        //else if(Id=="2")
        //    path += "Manuals/";
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
        if (FileUpload1.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            String[] allowedExtensions = 
                { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".wma", ".txt", ".pdf", ".docx", ".zip", ".rar", ".ppt", ".xls", ".rtf" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }
        }

        if (fileOK)
        {
            try
            {
                FileUpload1.PostedFile.SaveAs(path
                    + FileUpload1.FileName);
                lblMassage.Text = "File uploaded!";
                txtFileName.Text = FileUpload1.FileName;
            }
            catch (Exception ex)
            {
                lblMassage.Text = "File could not be uploaded." + ex.ToString();
            }
        }
        else
        {
            lblMassage.Text = "Cannot accept files of this type.";
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
    protected void ddlLangauge_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate();
        clear();
    }
    protected void ddListOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateFilelds();

    }
 
    #endregion

    #region methods
    private void Initialize()
    {
        try
        {
            if (Session["User"] != null)
            {
              btnUpload.Enabled=  ddListOperation.Enabled = btnApprove.Enabled = btnDelete.Enabled = btnSave.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ManageDownloads, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
                GetId();
                Populate();
                PopulateDocumentType();
            }
            else
                Page.Response.Redirect("LogIn.aspx");
        }
        catch { }
    }
    private void GetId()
    {
        Id = Request.QueryString["Id"].ToString();
    }
    private void Populate()
    {
        try
        {
            DataTable dt = new DataTable();

            ddListOperation.Items.Clear();
            dt = Downloads.SelectByCatagory(int.Parse(Id));
            if (dt.Rows == null || dt.Rows.Count == 0)
                ddListOperation.Items.Insert(0, "-- Create New --");
            else
            {

                ddListOperation.DataTextField = "Title";
                ddListOperation.DataValueField = "id";
                ddListOperation.DataSource = dt;
                ddListOperation.DataBind();
                ddListOperation.Items.Insert(0, "-- Create New --");
                btnApprove.Text = "Approve";
                btnSave.Text = "Save";
            }
        }
        catch { }

    }
    private void PopulateDocumentType()
    {
        try{
        DataTable dt = new DataTable();

        cmbDocType.Items.Clear();
        dt = DocumentType.SelectAll();
        if (dt.Rows == null || dt.Rows.Count == 0)
            cmbDocType.Items.Insert(0, "-- Select Document Type  --");
        else
        {

            cmbDocType.DataTextField = "Name";
            cmbDocType.DataValueField = "id";
            cmbDocType.DataSource = dt;
            cmbDocType.DataBind();


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
            dt = Downloads.SelectByPK(int.Parse(strqur));
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

            txtTitle.Text = dt.Rows[0]["Title"].ToString();
            FCKeditor1.Value = dt.Rows[0]["Summary"].ToString();
            txtFileName.Text = dt.Rows[0]["Url"].ToString();
            cmbDocType.Text = dt.Rows[0]["DocumentType"].ToString();
            txtSize.Text = dt.Rows[0]["Size"].ToString();
        }
    }
    catch { }
    }
    private void clear()
    {
        FCKeditor1.Value = "";
        txtTitle.Text = "";
        ddListOperation.SelectedIndex = 0;
        lblStatus.Visible = false;
        txtFileName.Text = "";
        txtSize.Text = "";
        btnSave.Text = "Save";
        btnApprove.Text = "Approve";
 
    }
    private void Save()
    {
        try{
        string id;
        GetId();

        if (ddListOperation.SelectedValue == "-- Create New --")
        {
            id = AdminBaseUIPage.GetID("downloadable");
            if (id == "")
                id = "1";
            if (Downloads.Insert(int.Parse(id), int.Parse(Id), txtTitle.Text, txtFileName.Text, FCKeditor1.Value, txtSize.Text, int.Parse(cmbDocType.SelectedValue), "D", DateTime.Now))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "There was problem saving the content.";

        }
        else
        {
            id = ddListOperation.SelectedValue;
            if (Downloads.Update(int.Parse(id), txtTitle.Text, txtFileName.Text, FCKeditor1.Value, txtSize.Text, int.Parse(cmbDocType.SelectedValue), DateTime.Now))
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
        try {
        if (entry == "")
        {
            lblMessage.Text = "Select a Title.";
            return;
        }

        if (Downloads.Delete(Convert.ToInt32(entry)))
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

            if (Downloads.ChangeStatus(Convert.ToInt32(entry), "P"))
                lblMessage.Text = "The content was succesfully published.";
            else
                lblMessage.Text = "There was problem publishing the content.";
        }
        else
        {
            if (Downloads.ChangeStatus(Convert.ToInt32(entry), "X"))
                lblMessage.Text = "The content was succesfully Suspended.";
            else
                lblMessage.Text = "There was problem Suspending the content.";
        }
    }
    catch { }
    }

    #endregion
}
