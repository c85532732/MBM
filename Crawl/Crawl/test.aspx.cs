using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

namespace Crawl
{
    public partial class test : System.Web.UI.Page
    {
        public StringBuilder r = new StringBuilder();
        public StringBuilder r1 = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string m = "7,7,1,4,6";
            //string[] d = m.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            //Array.Sort(d);
            //string aa=string.Join(",", d);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from  caifenfen where sn is null";
            DataTable dt=caifenfen.GetBySql(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string[] n = dr["r"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                Array.Sort(n);
                string[] a = n.Distinct().ToArray();
                string sn = string.Join("", a);
                sql = "update caifenfen set sn='" + sn + "' where id=" + dr["id"];
                caifenfen.ExecBySql(sql);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear(); ListBox2.Items.Clear();
            StringBuilder str = new StringBuilder();
            string day = this.DropDownList1.SelectedValue;
            string num = this.TextBox2.Text.Trim();

            if (string.IsNullOrEmpty(num))
            {
                return;
            }

            char[] n_num = num.ToCharArray();
            Array.Sort(n_num);
            num = string.Join("", n_num);

            #region

            str.Append("select ");
            if (day != "0")
            {
                str.Append(" top " + (Convert.ToInt32(day) * 60 * 24));
            }
            str.Append(" * from caifenfen where sn='" + num + "'");

            str.Append(" order by id desc");



            DataTable dt = caifenfen.GetBySql(str.ToString());
            string n = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Text = dr["n"].ToString() + "---" + dr["r"].ToString();
                ListBox2.Items.Add(li);
                n += "'" + (Convert.ToInt32(dr["n"]) + 1).ToString() + "',";
            }
            n = n.TrimEnd(new char[] { ',' });
            if (string.IsNullOrEmpty(n))
            {
                ListItem li = new ListItem();
                li.Text = "没有匹配数据";
                ListBox2.Items.Add(li);
                ListBox1.Items.Add(li);
                return;
            }
            #endregion

            #region
            string sql = "select * from  caifenfen where n in (" + n + ") order by id desc";
            dt = caifenfen.GetBySql(sql.ToString());

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



                ListItem li = new ListItem();
                li.Text = dr["n"].ToString() + "---" + dr["r"].ToString();
                ListBox1.Items.Add(li);
            }
            #endregion

            r.Append("共计" + dt.Rows.Count + "期,勾选去除<br /><br />");


            List<DictionaryEntry> list = ht.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).ToList();


            foreach (DictionaryEntry entry in list)
            {
                r.Append(" <input type=\"checkbox\" name=\"cbk\" value=\"" + entry.Key + "|"+ entry.Value +"\"  val=\""+ entry.Value + "\"/><span style='color:red;'>" + entry.Key + "</span>：" + entry.Value + "(+" + ht_t[entry.Key] + ")次\r\n\r\n\r\n");
            }
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
           
            //string num = TextBox3.Text.Trim();
            //if (string.IsNullOrEmpty(num)) return;
            //StringBuilder str = new StringBuilder();
            //str.Append("select* from( ");
            //str.Append("select ");
            //str.Append(" top " + num);
            //str.Append(" * from caifenfen ");
            //str.Append(" order by id desc");
            //str.Append(" ) as a order by id asc");

            //DataTable dt = caifenfen.GetBySql(str.ToString());
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();

            //Hashtable ht = new Hashtable();
            //ht.Add("0", 0);
            //ht.Add("1", 0);
            //ht.Add("2", 0);
            //ht.Add("3", 0);
            //ht.Add("4", 0);
            //ht.Add("5", 0);
            //ht.Add("6", 0);
            //ht.Add("7", 0);
            //ht.Add("8", 0);
            //ht.Add("9", 0);

            //Hashtable ht_t = new Hashtable();
            //ht_t.Add("0", 0);
            //ht_t.Add("1", 0);
            //ht_t.Add("2", 0);
            //ht_t.Add("3", 0);
            //ht_t.Add("4", 0);
            //ht_t.Add("5", 0);
            //ht_t.Add("6", 0);
            //ht_t.Add("7", 0);
            //ht_t.Add("8", 0);
            //ht_t.Add("9", 0);
            //for (int i=dt.Rows.Count-1;i>=0;i--)
            //{
            //    string[] r = dt.Rows[i]["r"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    Dictionary<string, int> counts = r.GroupBy(x => x)
            //                          .ToDictionary(g => g.Key,
            //                                        g => g.Count());
            //    foreach (string entry in counts.Keys)
            //    {
            //        ht_t[entry] = Convert.ToInt32(ht_t[entry]) + 1;
            //    }

            //    ListItem li = new ListItem();
            //    li.Text = dt.Rows[i]["n"].ToString() + "---" + dt.Rows[i]["r"].ToString();
            //    ListBox3.Items.Add(li);
            //}



            //List<DictionaryEntry> list = ht_t.Cast<DictionaryEntry>().OrderBy(entry => entry.Value).ToList();

            //foreach (DictionaryEntry entry in list)
            //{
            //    r1.Append("<span style='color:red;'>" + entry.Key + "</span>：" + Math.Abs(Convert.ToInt32(entry.Value)-Convert.ToInt32(num)) + "期\r\n\r\n\r\n");
            //}
        }

        public static string GetColor(object data,object num)
        {
            if (data.ToString().IndexOf(num.ToString()) >= 0)
                return "red";
            return "";
        }

    }
}