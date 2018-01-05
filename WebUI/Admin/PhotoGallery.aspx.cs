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

public partial class MFA_Web_Admin_PhotoGallery : System.Web.UI.Page
{
    static string Status;
   static private int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
    }
    private void Initialize()
    {
        if (Session["User"] != null)
        {
            lblUser.Text = Session["UserName"].ToString() + " @ Picture";
            btnSave.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.AddNewAndModifyContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
            btnDelete.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.DeleteCotent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));
            btnApprove.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ApproveContent, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));

            PopulateCatagory();
            
            Populate();
        }
    }
    private void Populate()
    {
        try
        {

            Sanoy.AddisTower.BE.PhotoGallery[] PhotoGallary = Sanoy.AddisTower.DA.PhotoGallery.SelectAll( ddlCatagory.SelectedValue);
          
            ddListOperation.Items.Clear();
         
            if (PhotoGallary.Length == 0)
                ddListOperation.Items.Insert(0, "-- Create New --");
            else
            {
                ddListOperation.DataTextField = Sanoy.AddisTower.BE.PhotoGallery.FIELD_Title;
                ddListOperation.DataValueField = Sanoy.AddisTower.BE.PhotoGallery.FIELD_Id;
                ddListOperation.DataSource = PhotoGallary;
                ddListOperation.DataBind();
                ddListOperation.Items.Insert(0, "-- Create New --");
                btnApprove.Text = "Approve";
                btnSave.Text = "Save";

            }
        }
        catch { }
       
    }
    private void PopulateCatagory()
    {
        try
        {

            Sanoy.AddisTower.BE.PhotoGalleryCatagory[] PhotoGalleryCatagory = Sanoy.AddisTower.DA.PhotoGalleryCatagory.SelectApproved();

            ddlCatagory.Items.Clear();

            if (PhotoGalleryCatagory.Length == 0)
                ddListOperation.Items.Insert(0, "-- Create New --");
            else
            {
                ddlCatagory.DataTextField = Sanoy.AddisTower.BE.PhotoGalleryCatagory.FIELD_CatagoryName;
                ddlCatagory.DataValueField = Sanoy.AddisTower.BE.PhotoGalleryCatagory.FIELD_Id;
                ddlCatagory.DataSource = PhotoGalleryCatagory;
                ddlCatagory.DataBind();
          

            }
        }
        catch { }

    }
    protected void ddListOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateFilelds();
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
                Sanoy.AddisTower.BE.PhotoGallery photoGallary = Sanoy.AddisTower.DA.PhotoGallery.Select(int.Parse(strqur));

                if (photoGallary != null)
                {
                    btnSave.Text = "Update";
                    panStatus.Visible = true;
                }
                if (photoGallary.Publish == "D")
                {
                    lblStatus.Text = "Draft";
                    btnApprove.Text = "Approve";
                }
                else if (photoGallary.Publish == "P")
                {
                    lblStatus.Text = "Published";
                    btnApprove.Text = "Suspend";
                }
                else if (photoGallary.Publish == "X")
                {
                    lblStatus.Text = "Archive";
                    btnApprove.Text = "Approve";
                }
                else if (photoGallary.Publish == "S")
                {
                    lblStatus.Text = "Suspended";
                    btnApprove.Text = "Approve";
                }

                txtTitle.Text = photoGallary.Title;
                txtPicName.Text = photoGallary.NormalPicture;
                txtThumbnails.Text = photoGallary.Thumbnails;
                Status = photoGallary.Publish;
                Id = photoGallary.Id;


            }
        }
        catch { }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Approve(ddListOperation.SelectedValue.ToString());
        Populate();
        ddListOperation.Items[0].Selected = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Populate();
        ddListOperation.SelectedIndex = 0;
    }
    private void clear()
    {

        txtTitle.Text = "";
        ddListOperation.SelectedIndex = 0;
        lblStatus.Visible = false;
        panStatus.Visible = false;
        txtTitle.Text = "";
        txtPicName.Text = "";
        txtThumbnails.Text = "";
        btnSave.Text = "Save";
        btnApprove.Text = "Approve";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Delete(ddListOperation.SelectedValue);
        Populate();
        ddListOperation.Items[0].Selected = true;
        clear();
    }
    private void Delete(string entry)
    {
        if (entry == "")
        {
            lblMessage.Text = "Select a Title.";
            return;
        }

        if (PhotoGallery.Delete(Convert.ToInt32(entry)))
            lblMessage.Text = "The content was succesfully Deleted.";
        else
            lblMessage.Text = "There was problem Deleting the content.";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }

    private void Save()
    {
        try
        {
            string id;
            Sanoy.AddisTower.BE.PhotoGallery photoGallary= new Sanoy.AddisTower.BE.PhotoGallery();
             photoGallary.Title= txtTitle.Text;
           photoGallary.NormalPicture   =txtPicName.Text;
           photoGallary.Thumbnails = txtThumbnails.Text;
            photoGallary.Catagory=int.Parse(ddlCatagory.SelectedValue);
           

            if (ddListOperation.SelectedValue == "-- Create New --")
            {
                photoGallary.Id = Sanoy.AddisTower.DA.Utility.GetId("PhotoGallery", "Id");
                photoGallary.State = Sanoy.AddisTower.BE.RowState.Added;
                photoGallary.Publish = "D";
              
            }
            else
            {
                photoGallary.Publish = Status;
                photoGallary.Id = Id;
                photoGallary.State = Sanoy.AddisTower.BE.RowState.Modified;
               

            }
        if (PhotoGallery.Save(photoGallary))
                    lblMessage.Text = "The content was succesfully saved.";
                else
                    lblMessage.Text = "There was problem saving the content.";

            Populate();
            clear();
        }
        catch { }

    }
    protected void btnUploadThumb_Click(object sender, EventArgs e)
    {
        Boolean fileOK = false;
        String path = Server.MapPath("../PhotoGallery/Thumbnails/");


        if (fuThumb.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(fuThumb.FileName).ToLower();
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
                fuThumb.PostedFile.SaveAs(path
                    + fuThumb.FileName);
                lblMassage.Text = "File uploaded!";
                txtThumbnails.Text = fuThumb.FileName;
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
    protected void btnUploadNormal_Click(object sender, EventArgs e)
    {
        Boolean fileOK = false;
        String path = Server.MapPath("../PhotoGallery/Normal/");


        if (FileUpload2.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(FileUpload2.FileName).ToLower();
            String[] allowedExtensions = 
                { ".gif", ".png", ".jpeg", ".jpg" };
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
                FileUpload2.PostedFile.SaveAs(path
                    + FileUpload2.FileName);
           
                lblMassage.Text = "File uploaded!";
                txtPicName.Text = FileUpload2.FileName;
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
    private void Approve(string entry)
    {
        try
        {
            bool publish;
            publish = btnApprove.Text.Equals("Approve") ? true : false;
            if (publish)
            {

                if (PhotoGallery.ChangeStatus(Convert.ToInt32(entry), "P"))
                    lblMessage.Text = "The content was succesfully published.";
                else
                    lblMessage.Text = "There was problem publishing the content.";

            }
            else
            {
                if (PhotoGallery.ChangeStatus(Convert.ToInt32(entry), "X"))
                    lblMessage.Text = "The content was succesfully Suspended.";
                else
                    lblMessage.Text = "There was problem Suspending the content.";
            }
        }
        catch { }
    }

    protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate();
        clear();
    }
}
