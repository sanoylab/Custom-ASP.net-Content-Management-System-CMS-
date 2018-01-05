using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Cryptography;


namespace Sanoy.AddisTower.DA
{
   public class Utility
    {
       public static int GetId(string TableName, string Id)
       {
           string sql = "select " + Id + "  from " + TableName + " ORDER BY " + Id;
           DataTable dt = SQLHelper.ExecuteDataTable(sql);
           Int32 LastId = 0;
           if (dt.Rows.Count >= 1)
           {
               LastId = dt.Rows.Count - 1;
               string L_Id = dt.Rows[LastId][0].ToString();
               LastId = Int32.Parse(L_Id) + 1;
           }
           else
               LastId = 1;
          


           return LastId;

       }
       public static string ComputeHash(string text)
       {
           System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
           byte[] byteText = new MD5CryptoServiceProvider().ComputeHash(ascii.GetBytes(text));
           return BitConverter.ToString(byteText);
       }
    }
}
