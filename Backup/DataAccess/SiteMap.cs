using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Data.SqlClient;
using Sanoy.AddisTower.DA;

/// <summary>
/// Summary description for DT_SiteMap
/// </summary>
/// 
namespace Sanoy.AddisTower.DA
{
    public class SiteMap
    {
        public SiteMap()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable SelectAll()
        {
            string SQLQuery = "Select ID,Title " +
                                " from SiteMap ";

            SqlCommand command = new SqlCommand(SQLQuery);



            DataTable dt =SQLHelper.ExecuteDataTable (command);
            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select * " +
                               " from SiteMap WHERE id=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static bool Insert(int Id, string Title, string Url, string Keywords, string Description, DateTime Created, string Creator, string Publish)
        {
            string SQLQuery = "INSERT INTO SiteMap  (ID,Title,Url,Keywords,Description,Created,Creator,Publish)" +
                            "VALUES (@Id,@Title,@Url,@Keywords,@Description,@Created,@Creator,@Publish)";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
            command.Parameters.Add("@Url", SqlDbType.VarChar).Value = Url;
            command.Parameters.Add("@Keywords", SqlDbType.VarChar).Value = Keywords;
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
            command.Parameters.Add("@Created", SqlDbType.DateTime).Value = Created;
            command.Parameters.Add("@Creator", SqlDbType.VarChar).Value = Creator;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = Publish;


          return SQLHelper.ExecuteNonQuery(command);
          
        }
        public static bool Update(int Id, string Title, string Url, string Keywords, string Description)
        {
            string SQLQuery = "UPDATE SiteMap SET " +
                " Title =@Title,Url =@Url,Keywords=@Keywords,Description=@Description  where ID=@Id";
            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
            command.Parameters.Add("@Url", SqlDbType.VarChar).Value = Url;
            command.Parameters.Add("@Keywords", SqlDbType.VarChar).Value = Keywords;
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;

            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [SiteMap] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool Delete(int Id)
        {
            string SQLQuery = "DELETE FROM [SiteMap] WHERE [Id]=@Id ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            return SQLHelper.ExecuteNonQuery(command);
        }
        public static DataTable Show()
        {
            string SQLQuery = "";

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int i = 0;
            SQLQuery = "SELECT DISTINCT '" + alphabet.Substring(i, 1) + "' AS Name, '" + alphabet.Substring(i, 1) + "' AS Title, '' AS Url FROM  SiteMap  WHERE (UPPER(SUBSTRING(Title, 1, 1)) = '" + alphabet.Substring(i, 1) + "') AND Publish = 'P'";
            SQLQuery += " UNION ";
            SQLQuery += "SELECT DISTINCT '" + alphabet.Substring(i, 1) + "' AS Name, Title, Url FROM SiteMap WHERE (UPPER(SUBSTRING(Title, 1, 1)) = '" + alphabet.Substring(i, 1) + "') AND Publish = 'P'";
            for (i = 1; i < 26; i++)
            {
                SQLQuery += " UNION ";
                SQLQuery += "SELECT DISTINCT '" + alphabet.Substring(i, 1) + "' AS Name, '" + alphabet.Substring(i, 1) + "' AS Title, '' AS Url FROM SiteMap WHERE (UPPER(SUBSTRING(Title, 1, 1)) = '" + alphabet.Substring(i, 1) + "') AND Publish = 'P'";
                SQLQuery += " UNION ";
                SQLQuery += "SELECT DISTINCT '" + alphabet.Substring(i, 1) + "' AS Name, Title, Url FROM SiteMap WHERE (UPPER(SUBSTRING(Title, 1, 1)) = '" + alphabet.Substring(i, 1) + "') AND Publish = 'P'";
            }


            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable Search(string Key)
        {
            string SQLQuery = "SELECT * FROM SiteMap WHERE (Upper(Title) LIKE  Upper('%" + Key + "%')) OR  (Upper(Description) LIKE   Upper('%" + Key + "%')) OR   (Upper(Keywords) LIKE   Upper('%" + Key + "%'))";
            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
    }
}
