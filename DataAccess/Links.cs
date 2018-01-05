using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class Links
	{
        #region Manually Written Methods

        #endregion
        
        #region Auto Generated Methods

        public static BE.Links Select(Int32 Id)
        {
            BE.Links links = new BE.Links();
            string SQLQuery = "SELECT * FROM [Links] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            links.ID = Convert.ToInt32(reader["ID"]);
            links.UrlText = Convert.ToString(reader["UrlText"]);
            links.Url = Convert.ToString(reader["Url"]);
            links.Publish = Convert.ToString(reader["Publish"]);

            reader.Close();
            reader.Dispose();
            return links;
        }
        public static DataTable SelectLanguage()
        {
            string SQLQuery = "Select ID,UrlText " +
                                " from Links  ";

            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select * " +
                               " from Links WHERE id=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;


            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static bool Update(int Id, string UrlText, string Url)
        {
            string SQLQuery = "UPDATE Links SET " +
                "UrlText =@UrlText,Url =@Url where ID=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            command.Parameters.Add("@UrlText", SqlDbType.NVarChar).Value = UrlText;
            command.Parameters.Add("@Url", SqlDbType.VarChar).Value = Url;
            return SQLHelper.ExecuteNonQuery(command);

        }
        public static BE.Links[] SelectAll()
        {
            ArrayList linkss = new ArrayList();
            BE.Links links;
	    string SQLQuery = "SELECT * FROM [Links]  ";
           SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                links = new BE.Links();

                links.ID = Convert.ToInt32(reader["ID"]);
            links.UrlText = Convert.ToString(reader["UrlText"]);
            links.Url = Convert.ToString(reader["Url"]);
            links.Publish = Convert.ToString(reader["Publish"]);
                linkss.Add(links);
            }

          
 	    reader.Close();
            reader.Dispose();
            return (BE.Links[])linkss.ToArray(typeof(BE.Links));
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [Links] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);

        }
        public static DataTable Show()
        {
            string SQLQuery;

            SQLQuery = "SELECT      ID, UrlText, Url  " +
                        "FROM         Links " +
                            "WHERE     (Publish = @Publish)";



            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }

		public static void Save(BE.Links[] linkss)
        {
            foreach (BE.Links links in linkss)
            {
                if (links.State == BE.RowState.Added)
                    Insert(links);
                else if (links.State == BE.RowState.Modified)
                    Update(links);
                else if (links.State == BE.RowState.Deleted)
                    Delete(links.ID);
            }
        }

        public static bool Save(BE.Links links)
        {
		
		bool IsAffected= false;
            if (links.State == BE.RowState.Added)
              IsAffected=  Insert(links);
            else if (links.State == BE.RowState.Modified)
               IsAffected=  Update(links);
            else if (links.State == BE.RowState.Deleted)
              IsAffected=   Delete(links.ID);
		return 	IsAffected;
        }

        public static bool Insert(Int32 iD,String urlText,String url,String publish)
		{
			string SQLQuery="INSERT INTO [Links] ( iD,urlText,url,publish ) VALUES	(@iD, @urlText, @url, @publish)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, iD,urlText,url,publish);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}

        public static bool Insert(BE.Links links)
        {
            string SQLQuery = "INSERT INTO [Links] ( iD,urlText,url,publish ) VALUES	(@iD, @urlText, @url, @publish)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, links);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.Links[] linkss)
		{
            foreach(BE.Links links in linkss)
            {
                Insert(links);
			}
		}

		public static void Update(BE.Links[] linkss)
		{
            foreach (BE.Links links in linkss)
                Update(links);
		}

        public static bool Update(BE.Links links)
        {
            string SQLQuery = "UPDATE [Links] SET ID = @ID, UrlText= @UrlText, Url= @Url, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, links);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 iD,String urlText,String url,String publish)
        {
            string SQLQuery = "UPDATE [Links] SET ID = @ID, UrlText= @UrlText, Url= @Url, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, iD,urlText,url,publish);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(Int32 id)
		{
			string SQLQuery = "DELETE FROM [Links] WHERE [Id]=@Id ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Id",id);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}

        private static void AddParameters(SqlCommand command, BE.Links links)
        {
			command.Parameters.AddWithValue("@ID", links.ID);
            command.Parameters.AddWithValue("@UrlText", links.UrlText);
            command.Parameters.AddWithValue("@Url", links.Url);
            command.Parameters.AddWithValue("@Publish", links.Publish);
        }

        private static void AddParameters(SqlCommand command, Int32 iD,String urlText,String url,String publish)
        {
			command.Parameters.AddWithValue("@ID", iD);
            command.Parameters.AddWithValue("@UrlText", urlText);
            command.Parameters.AddWithValue("@Url", url);
            command.Parameters.AddWithValue("@Publish", publish);
        }
        #endregion        
	}
}