using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Data.SqlClient;

/// <summary>
/// Summary description for DT_DocumentType
/// </summary>
/// 
namespace Sanoy.AddisTower.DA
{
    public class DocumentType
    {
        public DocumentType()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable SelectAll()
        {
            string SQLQuery = "Select Id,Name" +
                                " from DocumentType";

            SqlCommand command = new SqlCommand(SQLQuery);

            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select * " +
                               " from DocumentType WHERE id=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.TinyInt).Value = Id;


            DataTable dt = SQLHelper.ExecuteDataTable(command);
            //ds.Tables[0].TableName = "Attributes";
            return dt;
        }
        public static bool Insert(int Id, string Name, string ImgUrl)
        {
            string SQLQuery = "INSERT INTO DocumentType  (Id,Name,ImgUrl)" +
                            "VALUES (@Id,@Name,@ImgUrl)";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@ImgUrl", SqlDbType.NVarChar).Value = ImgUrl;


             return SQLHelper.ExecuteNonQuery(command);
            
        }
        public static bool Update(int Id, string Name, string ImgUrl)
        {
            string SQLQuery = "UPDATE DocumentType SET " +
                "Name =@Name,ImgUrl =@ImgUrl where ID=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@ImgUrl", SqlDbType.NVarChar).Value = ImgUrl;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool Delete(int Id)
        {
            string SQLQuery = "DELETE FROM [DocumentType] WHERE [Id]=@Id ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            return SQLHelper.ExecuteNonQuery(command);
        }

    }
}