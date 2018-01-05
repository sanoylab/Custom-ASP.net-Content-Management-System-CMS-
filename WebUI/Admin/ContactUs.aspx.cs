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

public partial class Admin_ContactUs : System.Web.UI.Page
{
    #region mem vars
    private string sql, title = "";
    private string strqur;
    #endregion

    #region event handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            Initialize();
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
                lblUser.Text = Session["UserName"].ToString() + " @ Contacts";

              btnSave.Enabled=ddListOperation.Enabled=  btnApprove.Enabled = btnDelete.Enabled = AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session);
               
                Populate();
            }
            else
                Response.Redirect("Default.aspx");
        }
        catch { }


    }
    protected void Populate()
    {
        try{
        ddListOperation.Items.Clear();
        DataTable dt = new DataTable();
        dt = Contacts.SelectContacts();
        if (dt.Rows == null)
            return;
        if (dt.Rows.Count == 0)
            ddListOperation.Items.Insert(0, "-- Create New --");

        ddListOperation.DataTextField = "ContactName";
        ddListOperation.DataValueField = "ID";
        ddListOperation.DataSource = dt;
        ddListOperation.DataBind();
        ddListOperation.Items.Insert(0, "-- Create New --");
        btnApprove.Text = "Approve";
        btnSave.Text = "Save";
        cleartextbox();
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
                id = Sanoy.AddisTower.DA.Utility.GetId("ContactUs", "Id").ToString();
                if (id == "")
                    id = "1";

                if (Contacts.Insert(int.Parse(id), txtPosition.Text, txtContactName.Text, txtTel.Text, txtFax.Text, txtEmail.Text, txtPOBox.Text, DateTime.Now, Session["UserName"].ToString(), "D",txtFileName.Text))
                    lblMessage.Text = "The content was succesfully saved.";
                else
                    lblMessage.Text = "There was problem saving the content.";
            }
            else
            {
                id = ddListOperation.SelectedValue;
                if (Contacts.Update(int.Parse(id), txtPosition.Text, txtContactName.Text, txtTel.Text, txtFax.Text, txtEmail.Text, txtPOBox.Text, DateTime.Now, Session["UserName"].ToString(), txtFileName.Text))
                    lblMessage.Text = "The content was succesfully saved.";
                else
                    lblMessage.Text = "There was problem saving the content.";
            }

            Populate();
        }
        catch { }
    }
    private void Approve(string entry)
    {
        try{
        bool publish;
        publish = btnApprove.Text.Equals("Approve") ? true : false;
        if (publish)
        {

            if (Contacts.ChangeStatus(Convert.ToInt32(entry), "P"))
                lblMessage.Text = "The content was succesfully published.";
            else
                lblMessage.Text = "There was problem Publish the content.";

        }
        else
        {
            if (Contacts.ChangeStatus(Convert.ToInt32(entry), "X"))
                lblMessage.Text = "The content was succesfully Suspended.";
            else
                lblMessage.Text = "There was problem Suspending the content.";
        }
    }
    catch { }
    }
    private string CheckNull(string str)
    {
        if (str != "")
            str += "<br>";

        return str;
    }
    private string RemoveBr(string str)
    {
        int len, removeAt;

        if (str != "")
        {
            len = str.Length;
            removeAt = len - 4;
            str = str.Remove(removeAt);
        }


        return str;
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

            if (Contacts.Delete(Convert.ToInt32(entry)))
                lblMessage.Text = "The content was succesfully Deleted.";
            else
                lblMessage.Text = "There was problem Deleting the content.";
        }
        catch { }
    }
    protected void cleartextbox()
    {
       txtFileName.Text= txtContactName.Text = "";
        txtPosition.Text = "";
        txtTel.Text = "";
        txtFax.Text = "";
        txtEmail.Text = "";
        ddListOperation.SelectedIndex = 0;
        panStatus.Visible = false;
        txtPOBox.Text = "";

    }
    private void PopulateFilelds()
    {
        try{
        DataTable dt = new DataTable();

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
            dt = Contacts.SelectContactsByPK(int.Parse(strqur));
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
            txtContactName.Text = dt.Rows[0]["ContactName"].ToString();
            txtPosition.Text = dt.Rows[0]["Post"].ToString();
            txtTel.Text = dt.Rows[0]["Tel"].ToString();
            txtFax.Text =dt.Rows[0]["Fax"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();           
            txtPOBox.Text = dt.Rows[0]["Pobox"].ToString();
            txtFileName.Text = dt.Rows[0]["Language"].ToString();
        }
    }
    catch { }
    }
    #endregion

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
        Boolean fileOK = false;
        String path = Server.MapPath("../ContactUs/");
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

        if (fileContactUs.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(fileContactUs.FileName).ToLower();
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
                fileContactUs.PostedFile.SaveAs(path
                    + fileContactUs.FileName);
                lblMassage.Text = "File uploaded!";
                txtFileName.Text = fileContactUs.FileName;
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
}
