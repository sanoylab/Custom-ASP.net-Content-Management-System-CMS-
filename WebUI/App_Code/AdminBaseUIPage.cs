using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.SessionState ;
using System.Security.Cryptography;

namespace  Sanoy.AddisTower.DA
{

    public class AdminBaseUIPage : SQLHelper
    {
        public static string msg = "";
        private static int mvLogIn = 0;
        public static string CurrentUser = "0";
        public static string errorMsg = "";

        public static int MvLogIn
        {
            get { return AdminBaseUIPage.mvLogIn; }
            set { AdminBaseUIPage.mvLogIn = value; }
        }
        private static string currentTWG = "0";

        public static string CurrentTWG
        {
            get { return AdminBaseUIPage.currentTWG; }
            set { AdminBaseUIPage.currentTWG = value; }
        }

        public AdminBaseUIPage()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public enum Role
        {
            ViewContent = 1,
            AddNewAndModifyContent = 2,
          // AddNewContent = 2,
            ApproveContent = 3,
            DeleteCotent = 4,
           // ApproveContent,
            ViewUsers = 5,
            AddNewUser = 6,
            ModifyUser = 7,
            DeleteUser = 8,
            DisableUser = 9,
            GivePermission = 10,
            UploadFile = 11,
            Admin = 12,
            ManageJobOpportunities=17,
            ManageNews=18,
            ManageTraining=19,
            ManageDownloads=20,
            ManageAnnouncements=21,
            ManageForum=22,
            ManageFacilities=23
        }
        public enum MenuPosition
        {
            TopRight = 0,
            TopLeft = 1,
            BottomRight = 2,
            BottomLeft = 3
        }
        public static bool CheckRole(string user, Role role)
        {
            SqlDataReader dr = null;
            bool ret = false;

            string sql =
                "SELECT     * " +
                " FROM         Users INNER JOIN " +
                          " RoleMembers ON  Users.ID = RoleMembers.[User] INNER JOIN " +
                          " Roles ON RoleMembers.Role = Roles.ID " +
                "WHERE     (Users.ID = " + user + ") AND (Roles.RoleName = '" + role.ToString() + "')";

            try
            {
                dr = ExecuteReader(sql);
                if (dr.HasRows)
                    ret = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message.ToString();
            }
            finally
            {

                if (dr != null)
                    dr.Close();
            }

            return ret;
        }
        public static bool CheckRole(Role role, HttpSessionState session)
        {
            object user = session["User"];

            if (user == null)
                return false;
            else
                return CheckRole(user.ToString(), role);
        }
        public static bool CheckEmail(System.Web.UI.WebControls.TextBox tb, int maxLength)
        {
            if (tb.Text.Length > maxLength || tb.Text.Length < 10)
            {
                //lit.Text="Email is too long";
                return false;
            }
            Regex rEmail;
            rEmail = new Regex("^[a-zA-Z][a-zA-Z_0-9\\.]+@[a-zA-Z_=>0-9\\.]+\\.[a-zA-Z]{1,}$");
            Match mEmail = rEmail.Match(tb.Text);
            if (!tb.Text.Equals("") && !mEmail.Success)
            {
                //lit.Text="Invalid Email";
                return false;
            }
            return true;
        }
        public static bool Login(string userName, string Password, HttpSessionState session, out string msg)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytePassword = new MD5CryptoServiceProvider().ComputeHash(ascii.GetBytes(Password));
            string stringPassWord = BitConverter.ToString(bytePassword);
            SqlDataReader SqlDr = null;
            string strQuery = "";
            bool IsSuccessed = true;
            msg = "";

            strQuery =
                "SELECT ID FROM Users " +
                "WHERE  UserName='" + userName.ToLower().Trim() + "' And " +
                        "PassWord = '" + stringPassWord + "'";

            try	//TRY READ FROM DATABASE	
            {
                //START READING FROM THE DATABASE			
                SqlDr = ExecuteReader(strQuery);
                //USERNAME,PASSWORD MATCHES
                if (SqlDr.Read())
                {
                    string user = SqlDr[0].ToString();
                    session["UserName"] = userName.ToLower().Trim();
                    AcceptUser(user, 120, session);

                    IsSuccessed = true;
                }
                else//USERNAME OR PASSWORD DOESN'T MATCHE
                {
                    CleanUp(session);
                    msg = "Invalid UserName Or Password";
                    IsSuccessed = false;
                }
            }
            catch //CATCH CONNECTION ERRORS
            {
                msg = "ERRORS ENCOUNTERED.PLEASE TRY AGAIN LATER!!!";
                IsSuccessed = false;
            }
            finally
            {
                SqlDr.Close();
            }
            return IsSuccessed;
        }
        public static void AcceptUser(string user, int endSession, HttpSessionState session)
        {
            SetSession(user, endSession, session);
        }
        public static bool ChangePassword(string user, string password, string newPassword)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            string oldPW = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ascii.GetBytes(password)));
            string newPW = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ascii.GetBytes(newPassword)));

            string sql = "Update Users set Password = '" + newPW + "' where Password='" + oldPW + "' AND [ID] = " + user;

            return Convert.ToBoolean(ExecuteNonQuery(sql));
        }
        public static void CleanUp(HttpSessionState session)
        {
            session.RemoveAll();
        }
        //SET THE VALUES OF THE USER SESSION VARIABLES
        public static void SetSession(string user, int end, HttpSessionState session)
        {
            session["User"] = user;
            CurrentUser = user;
            session.Timeout = end;
        }
        public static string GetID(string tableName)
        {
            string sql = "Select Max(ID)+ 1 from " + tableName;
            object ret;

            ret =ExecuteScalar(sql);
            if (ret == null)
                return "1";
            else
                return Convert.ToString(ret);
        }
        public static string FormatQueryString(string sql)
        {
            string pattern = @"'";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(sql, "''");
        }
        public static bool IsNumeric(TextBox textBox)
        {
            bool ret = true;

            if (textBox.Text == "")
            {
                ret = false;
            }
            else
            {
                int len = textBox.Text.Length;

                for (int i = 0; i < len; i++)
                    if (!Char.IsNumber(textBox.Text[i]))
                        ret = false;
            }
            return ret;
        }
        public static string ConvertToHtml(string content)
        {
            content = HttpUtility.HtmlEncode(content);
            content = content.Replace("  ", "&nbsp;&nbsp;").Replace(
               "\t", "&nbsp;&nbsp;&nbsp;").Replace("\n", "<br>");
            return content;
        }

    }
}