using System;
using System.Data;
using System.Configuration;
using System.Web;


using System.Data.SqlClient;

/// <summary>
/// Summary description for DT_UserManager
/// </summary>
/// 
namespace Sanoy.AddisTower.DA
{
    public class UserManager 
    {
        public UserManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable PopulatePermissions(string user)
        {
            string SQLQuery = "Select * from RoleMembers where [User] =@user ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;


            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select * from Users where   [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;


            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static bool DeleteRollMembers(string UserName)
        {
            string SQLQuery = "Delete  RoleMembers where ([User]=@UserName)";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@UserName", SqlDbType.Int).Value = UserName;

            return SQLHelper.ExecuteNonQuery(command);
           
        }
        public static bool InsertRollMembers(string UserName, string Role)
        {
            string SQLQuery = "Insert into RoleMembers (Role,[User]) values (@Role,@UserName) ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
            command.Parameters.Add("@Role", SqlDbType.VarChar).Value = Role;

            return SQLHelper.ExecuteNonQuery(command);
           
        }
        public static bool InserUser(int Id, string UserName, string Password, string FirstName, string MiddleName, string LastName, int LoggedIn)
        {
            string SQLQuery = "Insert into Users(ID,UserName,PassWord,FirstName,MiddleName,LastName,LoggedIn) " +
                "Values(@Id,@UserName,@PassWord,@FirstName,@MiddleName,@LastName,@LoggedIn)";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
            command.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = Password;
            command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            command.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            command.Parameters.Add("@LoggedIn", SqlDbType.VarChar).Value = LoggedIn;

            return SQLHelper.ExecuteNonQuery(command);
           
        }
        public static bool UpdateUser(int Id, string UserName, string Password, string FirstName, string MiddleName, string LastName)
        {
            string SQLQuery = "Update Users " +
                "set UserName = @UserName,PassWord=@PassWord,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName where ID =@Id ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
            command.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = Password;
            command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            command.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;


            return SQLHelper.ExecuteNonQuery(command);
           
        }
        public static bool DeleteUser(int Id)
        {
            string SQLQuery = "Delete Users Where (ID =@Id)";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            return SQLHelper.ExecuteNonQuery(command);
           
        }
    }
}
