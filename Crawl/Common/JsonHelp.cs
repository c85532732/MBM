using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Common
{
   public class JsonHelp
    {
        public static string DataTableToStr(DataTable dt)
        {
            try
            {
                JavaScriptObject jsonObject = new JavaScriptObject();
                List<Hashtable> list = new List<Hashtable>();
                foreach (DataRow dr in dt.Rows)
                {
                    Hashtable ht = new Hashtable();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ht.Add(dc.ColumnName, dr[dc.ColumnName].ToString());
                    }
                    list.Add(ht);
                }
                jsonObject.Add("list", list);
                jsonObject.Add("result", "success");
                return JavaScriptConvert.SerializeObject(jsonObject);
            }
            catch
            {
                return "";
            }
        }
    }
}