using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sanoy.AddisTower.DA
{
   public class Downloads
    {
        public static DataTable SelecDownloadables()
        {
            string SQLQuery = "SELECT    Id, Catagory AS Downloads " +
                                   " FROM        Downloads  ";

            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;

        }
       
        public static DataTable SelectByCatagory( int Catagory)
        {
            string SQLQuery = "Select Id,Title" +
                                " from downloadable WHERE  Downloads=@Catagory ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Catagory", SqlDbType.Int).Value = Catagory;
            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select Id,Title,Url,Summary,[Size],DocumentType,Publish" +
                               " from downloadable WHERE id=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;


            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static bool Insert(int Id, int Catagory, string Title, string Url, string Summary, string Size, int DocumentType, string Publish,  DateTime Date)
        {
            string SQLQuery = "INSERT INTO downloadable  (Id,Downloads,Title,Url,Summary,Size,DocumentType,Publish,[Date])" +
                            "VALUES (@Id,@Catagory,@Title,@Url" +
               ",@Summary,@Size,@DocumentType,@Publish,@Date)";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            command.Parameters.Add("@Catagory", SqlDbType.Int).Value = Catagory;
            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
            command.Parameters.Add("@Url", SqlDbType.VarChar).Value = Url;
            command.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = Summary;
            command.Parameters.Add("@Size", SqlDbType.NVarChar).Value = Size;
            command.Parameters.Add("@DocumentType", SqlDbType.Int).Value = DocumentType;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = Publish;
            command.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;


           return SQLHelper.ExecuteNonQuery(command);
           
        }
        public static bool Update(int Id, string Title, string Url, string Summary, string Size, int DocumentType, DateTime Date)
        {
            string SQLQuery = "UPDATE downloadable SET " +
                "Title = @Title,Url =@Url,Summary=@Summary,Size=@Size,DocumentType=@DocumentType, [Date]=@Date" +
                      "   where ID=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
            command.Parameters.Add("@Url", SqlDbType.VarChar).Value = Url;
            command.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = Summary;
            command.Parameters.Add("@Size", SqlDbType.NVarChar).Value = Size;
            command.Parameters.Add("@DocumentType", SqlDbType.Int).Value = DocumentType;
            command.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [downloadable] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool Delete(int Id)
        {
            string SQLQuery = "DELETE FROM [downloadable] WHERE [Id]=@Id ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            return SQLHelper.ExecuteNonQuery(command);
        }
        public static DataTable SelectTop()
        {
            string SQLQuery = "";
          
               

                SQLQuery = "SELECT TOP 4 downloadable.Id, downloadable.Title, downloadable.Summary, downloadable.Url, DocumentType.ImgUrl " +
                    "FROM   downloadable INNER JOIN " +
                "DocumentType ON downloadable.DocumentType = DocumentType.Id " +
                "where Publish = @Publish And downloadable.TWG = 0 Order by PublicationDate desc";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable SelectTopNine(string TWG, int LastId)
        {
            string SQLQuery = "";
            if (TWG != "")
                SQLQuery = "SELECT TOP 4 downloadable.Id, downloadable.Title, DocumentType.ImgUrl, downloadable.Summary,downloadable.Url " +
                    "FROM   downloadable INNER JOIN " +
                "DocumentType ON downloadable.DocumentType = DocumentType.Id" +
                " where Publish = @Publish And downloadable.TWG =@TWG  And downloadable.Id < @LastId Order by PublicationDate desc";
            else
                SQLQuery = "SELECT TOP 4 downloadable.Id, downloadable.Title, DocumentType.ImgUrl , downloadable.Summary,downloadable.Url " +
                         "FROM   downloadable INNER JOIN " +
                     "DocumentType ON downloadable.DocumentType = DocumentType.Id" +
                     " where Publish = @Publish And downloadable.TWG =0 And downloadable.Id < @LastId Order by PublicationDate desc";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@TWG", SqlDbType.VarChar).Value = TWG;
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";
            command.Parameters.Add("@LastId", SqlDbType.VarChar).Value = LastId;

            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
       
        public static DataTable ShowAllPublications(int Catagory)
        {
            string SQLQuery = "SELECT  downloadable.Id,downloadable.Size, downloadable.Title, DocumentType.ImgUrl, downloadable.Summary,downloadable.Url " +
                    "FROM   downloadable INNER JOIN " +
                "DocumentType ON downloadable.DocumentType = DocumentType.Id" +
                " where (Publish = @Publish) And (downloadable.Downloads =@Catagory)  ORDER BY [Date] DESC ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Catagory", SqlDbType.Int).Value = Catagory;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = "P";

            DataTable dt =SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable Search(string TWG, string filter)
        {
            string SQLQuery = "";

            SQLQuery = "SELECT TOP 10 downloadable.Id, downloadable.Title,downloadable.Url, downloadable.Summary, DocumentType.ImgUrl " +
            "FROM   downloadable INNER JOIN " +
                "DocumentType ON downloadable.DocumentType = DocumentType.Id  Where (" + filter + ") AND (downloadable.TWG=@TWG )";
            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@TWG", SqlDbType.VarChar).Value = TWG;
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable SelectTitle(int Id)
        {
            string SQLQuery = "SELECT  Downloads.Catagory, Downloads.AmharicText  " +
                    "FROM   Downloads " +
                " where (Id = @Id)  ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
    }
}
