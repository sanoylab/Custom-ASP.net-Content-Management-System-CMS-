using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class CommonPage
	{
        #region Manually Written Methods

        #endregion
        
        #region Auto Generated Methods

        public static BE.CommonPage Select(Int32 Id)
        {
            BE.CommonPage commonPage = new BE.CommonPage();
            string SQLQuery = "SELECT * FROM [CommonPage] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            commonPage.Id = Convert.ToInt32(reader["Id"]);
            commonPage.Title = Convert.ToString(reader["Title"]);
            commonPage.MenuCaption = Convert.ToString(reader["MenuCaption"]);

            reader.Close();
            reader.Dispose();
            return commonPage;
        }

        public static BE.CommonPage[] SelectAll()
        {
            ArrayList commonPages = new ArrayList();
            BE.CommonPage commonPage;
	    string SQLQuery = "SELECT * FROM [CommonPage]  ";
           SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                commonPage = new BE.CommonPage();

                commonPage.Id = Convert.ToInt32(reader["Id"]);
            commonPage.Title = Convert.ToString(reader["Title"]);
            commonPage.MenuCaption = Convert.ToString(reader["MenuCaption"]);
                commonPages.Add(commonPage);
            }

          
 	    reader.Close();
            reader.Dispose();
            return (BE.CommonPage[])commonPages.ToArray(typeof(BE.CommonPage));
        }

		public static void Save(BE.CommonPage[] commonPages)
        {
            foreach (BE.CommonPage commonPage in commonPages)
            {
                if (commonPage.State == BE.RowState.Added)
                    Insert(commonPage);
                else if (commonPage.State == BE.RowState.Modified)
                    Update(commonPage);
                else if (commonPage.State == BE.RowState.Deleted)
                    Delete(commonPage.Id);
            }
        }

        public static bool Save(BE.CommonPage commonPage)
        {
		
		bool IsAffected= false;
            if (commonPage.State == BE.RowState.Added)
              IsAffected=  Insert(commonPage);
            else if (commonPage.State == BE.RowState.Modified)
               IsAffected=  Update(commonPage);
            else if (commonPage.State == BE.RowState.Deleted)
              IsAffected=   Delete(commonPage.Id);
		return 	IsAffected;
        }

        public static bool Insert(Int32 id,String title,String menuCaption)
		{
			string SQLQuery="INSERT INTO [CommonPage] ( id,title,menuCaption ) VALUES	(@id, @title, @menuCaption)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,title,menuCaption);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}

        public static bool Insert(BE.CommonPage commonPage)
        {
            string SQLQuery = "INSERT INTO [CommonPage] ( id,title,menuCaption ) VALUES	(@id, @title, @menuCaption)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, commonPage);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.CommonPage[] commonPages)
		{
            foreach(BE.CommonPage commonPage in commonPages)
            {
                Insert(commonPage);
			}
		}

		public static void Update(BE.CommonPage[] commonPages)
		{
            foreach (BE.CommonPage commonPage in commonPages)
                Update(commonPage);
		}

        public static bool Update(BE.CommonPage commonPage)
        {
            string SQLQuery = "UPDATE [CommonPage] SET Id = @Id, Title= @Title, MenuCaption= @MenuCaption WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, commonPage);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 id,String title,String menuCaption)
        {
            string SQLQuery = "UPDATE [CommonPage] SET Id = @Id, Title= @Title, MenuCaption= @MenuCaption WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,title,menuCaption);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(Int32 id)
		{
			string SQLQuery = "DELETE FROM [CommonPage] WHERE [Id]=@Id ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Id",id);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}

        private static void AddParameters(SqlCommand command, BE.CommonPage commonPage)
        {
			command.Parameters.AddWithValue("@Id", commonPage.Id);
            command.Parameters.AddWithValue("@Title", commonPage.Title);
            command.Parameters.AddWithValue("@MenuCaption", commonPage.MenuCaption);
        }

        private static void AddParameters(SqlCommand command, Int32 id,String title,String menuCaption)
        {
			command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@MenuCaption", menuCaption);
        }
        #endregion        
	}
}