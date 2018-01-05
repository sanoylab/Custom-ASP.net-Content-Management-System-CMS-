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
public partial class EIA_Admin_imageUploder : System.Web.UI.Page
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
    protected void btnUpload_Click(object sender, EventArgs e)
    {

        Boolean fileOK = false;
        String path = Server.MapPath("../Uploaded/other/");
        if(ddlType.SelectedItem.ToString()=="Image")
            path = Server.MapPath("../Uploaded/images/");
        else
            path = Server.MapPath("../Uploaded/other/");
       

        if (FileUpload1.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            String[] allowedExtensions = 
                { ".gif", ".bmp", ".png", ".jpeg", ".jpg", ".doc", ".wma", ".txt", ".pdf", ".xlsx", ".ppt", ".xls" };
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
               
            }
            catch (Exception ex)
            {
                lblMassage.Text = "File could not be uploaded.";
            }
        }
        else
        {
            lblMassage.Text = "Cannot accept files of this type.";
        }
    }
   
    
   

    #endregion

    #region methods
    private void Initialize()
    {
        if (Session["User"] != null)
        {
            btnUpload.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.UploadFile, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
        }
        else
            Page.Response.Redirect("Default.aspx");





    }
   

    #endregion
}
