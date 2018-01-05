using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class HomePage
	{
        #region Manually Written Methods
        public static DataTable SelectContent()
        {
            string SQLQuery = "select Id,Title,Content,Content1 from HomePage where Publish='P' ";

            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable SelectByLanguage()
        {
            string SQLQuery = " SELECT     Id, Title " +
                " FROM        HomePage ";


            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "SELECT     HomePage.* " +
                    " FROM         HomePage " +
               " WHERE     (Id = @Id) ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static bool Insert(int Id, string Title, string Abstract, string Content, string Publish, DateTime Created, string CreatedBy)
        {
            string SQLQuery = "INSERT INTO [HomePage]  (Id,Title,Content,Content1,Publish,Created,CreatedBy)" +
                            "VALUES (@Id,@Name,@Abstract" +
               ",@Profile,@Publish,@Created,@CreatedBy)";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Title;
            command.Parameters.Add("@Abstract", SqlDbType.NVarChar).Value = Abstract;
            command.Parameters.Add("@Profile", SqlDbType.NVarChar).Value = Content;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = Publish;
            command.Parameters.Add("@Created", SqlDbType.DateTime).Value = Created;
            command.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool SuspendContent(int CommonPage)
        {
            string SQLQuery = "UPDATE [HomePage] SET Publish=@Suspend  where  Publish=@Publish ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Suspend", SqlDbType.Char).Value = "X";
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";

            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool Update(int Id, string Name, string Abstract, string Profile, DateTime Edited, string EditedBy)
        {
            string SQLQuery = "UPDATE [HomePage] SET " +
                "Title = @Name,Content1 =@Profile,Content=@Abstract, Edited=@Edited ,EditedBy=@EditedBy  " +
                      "   where ID=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@Abstract", SqlDbType.NVarChar).Value = Abstract;
            command.Parameters.Add("@Profile", SqlDbType.NVarChar).Value = Profile;
            command.Parameters.Add("@Edited", SqlDbType.DateTime).Value = Edited;
            command.Parameters.Add("@EditedBy", SqlDbType.VarChar).Value = EditedBy;



            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [HomePage] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
        }
        #endregion
        
        #region Auto Generated Methods

        public static BE.HomePage Select(Int32 Id)
        {
            BE.HomePage homePage = new BE.HomePage();
            string SQLQuery = "SELECT * FROM [HomePage] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            homePage.Id = Convert.ToInt32(reader["Id"]);
            homePage.Title = Convert.ToString(reader["Title"]);
            homePage.Content = Convert.ToString(reader["Content"]);
            homePage.Content1 = Convert.ToString(reader["Content1"]);
            homePage.Created = Convert.ToDateTime(reader["Created"]);
            homePage.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            homePage.Edited = Convert.ToDateTime(reader["Edited"]);
            homePage.EditedBy = Convert.ToString(reader["EditedBy"]);
            homePage.Publish = Convert.ToString(reader["Publish"]);
            homePage.Language = Convert.ToString(reader["Language"]);

            reader.Close();
            reader.Dispose();
            return homePage;
        }

        public static BE.HomePage[] SelectAll()
        {
            ArrayList homePages = new ArrayList();
            BE.HomePage homePage;
	    string SQLQuery = "SELECT * FROM [HomePage]  ";
           SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                homePage = new BE.HomePage();

                homePage.Id = Convert.ToInt32(reader["Id"]);
            homePage.Title = Convert.ToString(reader["Title"]);
            homePage.Content = Convert.ToString(reader["Content"]);
            homePage.Content1 = Convert.ToString(reader["Content1"]);
            homePage.Created = Convert.ToDateTime(reader["Created"]);
            homePage.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            homePage.Edited = Convert.ToDateTime(reader["Edited"]);
            homePage.EditedBy = Convert.ToString(reader["EditedBy"]);
            homePage.Publish = Convert.ToString(reader["Publish"]);
            homePage.Language = Convert.ToString(reader["Language"]);
                homePages.Add(homePage);
            }

          
 	    reader.Close();
            reader.Dispose();
            return (BE.HomePage[])homePages.ToArray(typeof(BE.HomePage));
        }

		public static void Save(BE.HomePage[] homePages)
        {
            foreach (BE.HomePage homePage in homePages)
            {
                if (homePage.State == BE.RowState.Added)
                    Insert(homePage);
                else if (homePage.State == BE.RowState.Modified)
                    Update(homePage);
                else if (homePage.State == BE.RowState.Deleted)
                    Delete(homePage.Id);
            }
        }

        public static bool Save(BE.HomePage homePage)
        {
		
		bool IsAffected= false;
            if (homePage.State == BE.RowState.Added)
              IsAffected=  Insert(homePage);
            else if (homePage.State == BE.RowState.Modified)
               IsAffected=  Update(homePage);
            else if (homePage.State == BE.RowState.Deleted)
              IsAffected=   Delete(homePage.Id);
		return 	IsAffected;
        }

        public static bool Insert(Int32 id,String title,String content,String content1,DateTime created,String createdBy,DateTime edited,String editedBy,String publish,String language)
		{
			string SQLQuery="INSERT INTO [HomePage] ( id,title,content,content1,created,createdBy,edited,editedBy,publish,language ) VALUES	(@id, @title, @content, @content1, @created, @createdBy, @edited, @editedBy, @publish, @language)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,title,content,content1,created,createdBy,edited,editedBy,publish,language);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}

        public static bool Insert(BE.HomePage homePage)
        {
            string SQLQuery = "INSERT INTO [HomePage] ( id,title,content,content1,created,createdBy,edited,editedBy,publish,language ) VALUES	(@id, @title, @content, @content1, @created, @createdBy, @edited, @editedBy, @publish, @language)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, homePage);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.HomePage[] homePages)
		{
            foreach(BE.HomePage homePage in homePages)
            {
                Insert(homePage);
			}
		}

		public static void Update(BE.HomePage[] homePages)
		{
            foreach (BE.HomePage homePage in homePages)
                Update(homePage);
		}

        public static bool Update(BE.HomePage homePage)
        {
            string SQLQuery = "UPDATE [HomePage] SET Id = @Id, Title= @Title, Content= @Content, Content1= @Content1, Created= @Created, CreatedBy= @CreatedBy, Edited= @Edited, EditedBy= @EditedBy, Publish= @Publish, Language= @Language WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, homePage);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 id,String title,String content,String content1,DateTime created,String createdBy,DateTime edited,String editedBy,String publish,String language)
        {
            string SQLQuery = "UPDATE [HomePage] SET Id = @Id, Title= @Title, Content= @Content, Content1= @Content1, Created= @Created, CreatedBy= @CreatedBy, Edited= @Edited, EditedBy= @EditedBy, Publish= @Publish, Language= @Language WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,title,content,content1,created,createdBy,edited,editedBy,publish,language);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(Int32 id)
		{
			string SQLQuery = "DELETE FROM [HomePage] WHERE [Id]=@Id ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Id",id);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}

        private static void AddParameters(SqlCommand command, BE.HomePage homePage)
        {
			command.Parameters.AddWithValue("@Id", homePage.Id);
            command.Parameters.AddWithValue("@Title", homePage.Title);
            command.Parameters.AddWithValue("@Content", homePage.Content);
            command.Parameters.AddWithValue("@Content1", homePage.Content1);
            command.Parameters.AddWithValue("@Created", homePage.Created);
            command.Parameters.AddWithValue("@CreatedBy", homePage.CreatedBy);
            command.Parameters.AddWithValue("@Edited", homePage.Edited);
            command.Parameters.AddWithValue("@EditedBy", homePage.EditedBy);
            command.Parameters.AddWithValue("@Publish", homePage.Publish);
            command.Parameters.AddWithValue("@Language", homePage.Language);
        }

        private static void AddParameters(SqlCommand command, Int32 id,String title,String content,String content1,DateTime created,String createdBy,DateTime edited,String editedBy,String publish,String language)
        {
			command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Content", content);
            command.Parameters.AddWithValue("@Content1", content1);
            command.Parameters.AddWithValue("@Created", created);
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            command.Parameters.AddWithValue("@Edited", edited);
            command.Parameters.AddWithValue("@EditedBy", editedBy);
            command.Parameters.AddWithValue("@Publish", publish);
            command.Parameters.AddWithValue("@Language", language);
        }
        #endregion        
	}
}