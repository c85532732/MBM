using Common;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Crawl.webservice
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;
            string type = context.Request["t"].ToString();
            switch (type.ToLower())
            {
                case "getdatanum":
                    string getdatanum_num= context.Request["num"].ToString();
                    result=GetDataByNum(getdatanum_num);
                    break;
                case "getqssddata":
                    string qssd_num = context.Request["num"].ToString();
                    string qssd_sn = context.Request["sn"].ToString();
                    result = GetQSSDData(qssd_num, qssd_sn);
                    break;
            }
           context.Response.Write(result);
        }

        public string GetDataByNum(string num)
        {            
            if (string.IsNullOrEmpty(num)) return "";
            StringBuilder str = new StringBuilder();
            str.Append("select* from( ");
            str.Append("select ");
            str.Append(" top " + num);
            str.Append(" * from caifenfen ");
            str.Append(" order by id desc");
            str.Append(" ) as a order by id asc");

            DataTable dt = caifenfen.GetBySql(str.ToString());
            return JsonHelp.DataTableToStr(dt);
        }

        public string GetQSSDData(string top,string sn)
        {
            JavaScriptObject jObject = new JavaScriptObject();
            DataTable dt = caifenfen.GetList_NextBySN(top, sn);

            #region 数据处理
            Hashtable ht = new Hashtable();
            ht.Add("0", 0);
            ht.Add("1", 0);
            ht.Add("2", 0);
            ht.Add("3", 0);
            ht.Add("4", 0);
            ht.Add("5", 0);
            ht.Add("6", 0);
            ht.Add("7", 0);
            ht.Add("8", 0);
            ht.Add("9", 0);

            Hashtable ht_t = new Hashtable();
            ht_t.Add("0", 0);
            ht_t.Add("1", 0);
            ht_t.Add("2", 0);
            ht_t.Add("3", 0);
            ht_t.Add("4", 0);
            ht_t.Add("5", 0);
            ht_t.Add("6", 0);
            ht_t.Add("7", 0);
            ht_t.Add("8", 0);
            ht_t.Add("9", 0);

            foreach (DataRow dr in dt.Rows)
            {
                string[] r = dr["r"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, int> counts = r.GroupBy(x => x)
                                      .ToDictionary(g => g.Key,
                                                    g => g.Count());
                string wan = dr["wan"].ToString();
                string qian = dr["qian"].ToString();
                string bai = dr["bai"].ToString();
                string shi = dr["shi"].ToString();
                string ge = dr["ge"].ToString();

                foreach (string entry in counts.Keys)
                {
                    int val = Convert.ToInt32(counts[entry]);
                    if (val > 1)
                    {
                        ht_t[entry] = Convert.ToInt32(ht_t[entry]) + 1;
                    }
                }
                ht[wan] = Convert.ToInt32(ht[wan]) + 1;
                ht[qian] = Convert.ToInt32(ht[qian]) + 1;
                ht[bai] = Convert.ToInt32(ht[bai]) + 1;
                ht[shi] = Convert.ToInt32(ht[shi]) + 1;
                ht[ge] = Convert.ToInt32(ht[ge]) + 1;
            }
            #endregion

            jObject.Add("count", dt.Rows.Count);
            List<DictionaryEntry> list = ht.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).ToList();
            
            JavaScriptArray jArray = new JavaScriptArray();
            foreach (DictionaryEntry entry in list)
            {
                JavaScriptObject jObj_arr = new JavaScriptObject();
                jObj_arr.Add("num", entry.Key.ToString());
                jObj_arr.Add("d", entry.Value+"|" + ht_t[entry.Key]);
                jArray.Add(jObj_arr);               
            }
            jObject.Add("list", jArray);
            return JavaScriptConvert.SerializeObject(jObject);
        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}