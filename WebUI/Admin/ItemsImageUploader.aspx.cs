using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessSearch;
using Motorcycle = BusinessEntitySearch.Motorcycle;

public partial class Admin_ItemsImageUploader : System.Web.UI.Page
{
    private DataAccessSearch.ItemImage itemImageData;
    BusinessEntitySearch.Motorcycle motorImage = new Motorcycle();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkUploadMotorImage_Click(object sender, EventArgs e)
    {
        panUploadMotorImage.Visible = true;
        panUploadSpareImage.Visible = false;
    }

    protected void lnkUploadSpareImage_Click(object sender, EventArgs e)
    {
        panUploadMotorImage.Visible = false;
        panUploadSpareImage.Visible = true;
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (imgMotor.HasFile)
        {
            if (HasAllowedExtension(imgMotor))
            {
                string fileUrl = CreateDirectory("~/Items/Motor/" + ddlMotorModel.SelectedItem.Text + "/");
                itemImageData = new ItemImage
                                    {
                                        Id = Guid.NewGuid(),
                                        ImageFileName = imgMotor.FileName,
                                        ImageUrl = fileUrl,
                                        MotorOrSpareId = new Guid(ddlMotorModel.SelectedValue)
                                    };
                motorImage.SaveImage(itemImageData);
                imgMotor.PostedFile.SaveAs(fileUrl + imgMotor.FileName);
            }
        }
    }
    protected void btnSpareUpload_Click(object sender, EventArgs e)
    {
        if (imgSprepart.HasFile)
        {
            if (HasAllowedExtension(imgSprepart))
            {
                string fileUrl = CreateDirectory("~/Items/Sparepart/" + ddlSparepart.SelectedItem.Text + "/");
                itemImageData = new ItemImage
                {
                    Id = Guid.NewGuid(),
                    ImageFileName = imgSprepart.FileName,
                    ImageUrl = fileUrl,
                    MotorOrSpareId = new Guid(ddlSparepart.SelectedValue)
                };
                motorImage.SaveImage(itemImageData);
                imgSprepart.PostedFile.SaveAs(fileUrl + imgSprepart.FileName);
            }
        }
    }

    public bool HasAllowedExtension(FileUpload fileUploader)
    {
        string[] allowedExtension = { ".png", ".jpg", ".gif" };
        string fileExtention = Path.GetExtension(fileUploader.FileName).ToLower();
        for (int i = 0; i < allowedExtension.Length; i++)
        {
            if (fileExtention.Equals(allowedExtension[i]))
                return true;
        }
        return false;
    }

    public string CreateDirectory(string directoryURL)
    {
        string dirPath = Server.MapPath(directoryURL);
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
        return dirPath;
    }
    //protected void btnPreview_Click(object sender, EventArgs e)
    //{
    //    //string dirPath = Server.MapPath(directoryURL);
    //   // imgPreview.ImageUrl = imgSprepart.
       
    //}
}
