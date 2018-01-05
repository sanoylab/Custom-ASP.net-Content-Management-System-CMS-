using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class ContactUs
	{
        #region Manually Written Methods

        #endregion
        
        #region Auto Generated Methods

        public static BE.ContactUs Select(Int32 Id)
        {
            BE.ContactUs contactUs = new BE.ContactUs();
            string SQLQuery = "SELECT * FROM [ContactUs] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            contactUs.Id = Convert.ToInt32(reader["Id"]);
            contactUs.Post = Convert.ToString(reader["Post"]);
            contactUs.ContactName = Convert.ToString(reader["ContactName"]);
            contactUs.Tel = Convert.ToString(reader["Tel"]);
            contactUs.Fax = Convert.ToString(reader["Fax"]);
            contactUs.Email = Convert.ToString(reader["Email"]);
            contactUs.Pobox = Convert.ToString(reader["Pobox"]);
            contactUs.Created = Convert.ToDateTime(reader["Created"]);
            contactUs.Creator = Convert.ToString(reader["Creator"]);
            contactUs.Edited = Convert.ToDateTime(reader["Edited"]);
            contactUs.Editor = Convert.ToString(reader["Editor"]);
            contactUs.Publishing = Convert.ToString(reader["Publishing"]);
            contactUs.Language = Convert.ToString(reader["Language"]);

            reader.Close();
            reader.Dispose();
            return contactUs;
        }

        public static BE.ContactUs[] SelectAll()
        {
            ArrayList contactUss = new ArrayList();
            BE.ContactUs contactUs;
	    string SQLQuery = "SELECT * FROM [ContactUs]  ";
           SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                contactUs = new BE.ContactUs();

                contactUs.Id = Convert.ToInt32(reader["Id"]);
            contactUs.Post = Convert.ToString(reader["Post"]);
            contactUs.ContactName = Convert.ToString(reader["ContactName"]);
            contactUs.Tel = Convert.ToString(reader["Tel"]);
            contactUs.Fax = Convert.ToString(reader["Fax"]);
            contactUs.Email = Convert.ToString(reader["Email"]);
            contactUs.Pobox = Convert.ToString(reader["Pobox"]);
            contactUs.Created = Convert.ToDateTime(reader["Created"]);
            contactUs.Creator = Convert.ToString(reader["Creator"]);
            contactUs.Edited = Convert.ToDateTime(reader["Edited"]);
            contactUs.Editor = Convert.ToString(reader["Editor"]);
            contactUs.Publishing = Convert.ToString(reader["Publishing"]);
            contactUs.Language = Convert.ToString(reader["Language"]);
                contactUss.Add(contactUs);
            }

          
 	    reader.Close();
            reader.Dispose();
            return (BE.ContactUs[])contactUss.ToArray(typeof(BE.ContactUs));
        }

		public static void Save(BE.ContactUs[] contactUss)
        {
            foreach (BE.ContactUs contactUs in contactUss)
            {
                if (contactUs.State == BE.RowState.Added)
                    Insert(contactUs);
                else if (contactUs.State == BE.RowState.Modified)
                    Update(contactUs);
                else if (contactUs.State == BE.RowState.Deleted)
                    Delete(contactUs.Id);
            }
        }

        public static bool Save(BE.ContactUs contactUs)
        {
		
		bool IsAffected= false;
            if (contactUs.State == BE.RowState.Added)
              IsAffected=  Insert(contactUs);
            else if (contactUs.State == BE.RowState.Modified)
               IsAffected=  Update(contactUs);
            else if (contactUs.State == BE.RowState.Deleted)
              IsAffected=   Delete(contactUs.Id);
		return 	IsAffected;
        }

        public static bool Insert(Int32 id,String post,String contactName,String tel,String fax,String email,String pobox,DateTime created,String creator,DateTime edited,String editor,String publishing,String language)
		{
			string SQLQuery="INSERT INTO [ContactUs] ( id,post,contactName,tel,fax,email,pobox,created,creator,edited,editor,publishing,language ) VALUES	(@id, @post, @contactName, @tel, @fax, @email, @pobox, @created, @creator, @edited, @editor, @publishing, @language)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,post,contactName,tel,fax,email,pobox,created,creator,edited,editor,publishing,language);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}

        public static bool Insert(BE.ContactUs contactUs)
        {
            string SQLQuery = "INSERT INTO [ContactUs] ( id,post,contactName,tel,fax,email,pobox,created,creator,edited,editor,publishing,language ) VALUES	(@id, @post, @contactName, @tel, @fax, @email, @pobox, @created, @creator, @edited, @editor, @publishing, @language)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, contactUs);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.ContactUs[] contactUss)
		{
            foreach(BE.ContactUs contactUs in contactUss)
            {
                Insert(contactUs);
			}
		}

		public static void Update(BE.ContactUs[] contactUss)
		{
            foreach (BE.ContactUs contactUs in contactUss)
                Update(contactUs);
		}

        public static bool Update(BE.ContactUs contactUs)
        {
            string SQLQuery = "UPDATE [ContactUs] SET Id = @Id, Post= @Post, ContactName= @ContactName, Tel= @Tel, Fax= @Fax, Email= @Email, Pobox= @Pobox, Created= @Created, Creator= @Creator, Edited= @Edited, Editor= @Editor, Publishing= @Publishing, Language= @Language WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, contactUs);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 id,String post,String contactName,String tel,String fax,String email,String pobox,DateTime created,String creator,DateTime edited,String editor,String publishing,String language)
        {
            string SQLQuery = "UPDATE [ContactUs] SET Id = @Id, Post= @Post, ContactName= @ContactName, Tel= @Tel, Fax= @Fax, Email= @Email, Pobox= @Pobox, Created= @Created, Creator= @Creator, Edited= @Edited, Editor= @Editor, Publishing= @Publishing, Language= @Language WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,post,contactName,tel,fax,email,pobox,created,creator,edited,editor,publishing,language);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(Int32 id)
		{
			string SQLQuery = "DELETE FROM [ContactUs] WHERE [Id]=@Id ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Id",id);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}

        private static void AddParameters(SqlCommand command, BE.ContactUs contactUs)
        {
			command.Parameters.AddWithValue("@Id", contactUs.Id);
            command.Parameters.AddWithValue("@Post", contactUs.Post);
            command.Parameters.AddWithValue("@ContactName", contactUs.ContactName);
            command.Parameters.AddWithValue("@Tel", contactUs.Tel);
            command.Parameters.AddWithValue("@Fax", contactUs.Fax);
            command.Parameters.AddWithValue("@Email", contactUs.Email);
            command.Parameters.AddWithValue("@Pobox", contactUs.Pobox);
            command.Parameters.AddWithValue("@Created", contactUs.Created);
            command.Parameters.AddWithValue("@Creator", contactUs.Creator);
            command.Parameters.AddWithValue("@Edited", contactUs.Edited);
            command.Parameters.AddWithValue("@Editor", contactUs.Editor);
            command.Parameters.AddWithValue("@Publishing", contactUs.Publishing);
            command.Parameters.AddWithValue("@Language", contactUs.Language);
        }

        private static void AddParameters(SqlCommand command, Int32 id,String post,String contactName,String tel,String fax,String email,String pobox,DateTime created,String creator,DateTime edited,String editor,String publishing,String language)
        {
			command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Post", post);
            command.Parameters.AddWithValue("@ContactName", contactName);
            command.Parameters.AddWithValue("@Tel", tel);
            command.Parameters.AddWithValue("@Fax", fax);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Pobox", pobox);
            command.Parameters.AddWithValue("@Created", created);
            command.Parameters.AddWithValue("@Creator", creator);
            command.Parameters.AddWithValue("@Edited", edited);
            command.Parameters.AddWithValue("@Editor", editor);
            command.Parameters.AddWithValue("@Publishing", publishing);
            command.Parameters.AddWithValue("@Language", language);
        }
        #endregion        
	}
}