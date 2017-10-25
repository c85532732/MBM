using Common;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AutoCrawl
{
    
    partial class Service1 : ServiceBase
    {
        public string host = System.Configuration.ConfigurationManager.AppSettings["hosts"].ToString();
        System.Timers.Timer timer = new System.Timers.Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            log.WriteEvent("服务启动--------------------" + DateTime.Now);
            timer = new System.Timers.Timer();
            timer.Interval = 1 * 1000 * 60;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(ExecutionCode);
            timer.Enabled = true;

        }

        protected override void OnStop()
        {
            log.WriteEvent("服务停止--------------------" + DateTime.Now);
            timer.Enabled = false;  //执行一次
        }

        public  void ExecutionCode(object source, System.Timers.ElapsedEventArgs e)
        {
            string url = host + "/cp/loadDrawHistory.do?siteCode=HELSSC1&noOfD=4";
            DrawHistory data1 = null;
            try
            {
                string result = HttpCommon.HttpGet(url);
                data1 = JsonConvert.DeserializeObject<DrawHistory>(result);
            }
            catch (Exception)
            {
                data1 = null;
            }
            if (data1 != null)
            {
                List<Message> Messagelist = JsonConvert.DeserializeObject<List<Message>>(data1.Message);
                DataTable dt = caifenfen.GetLast();
                int last_n = 0;
                if (dt.Rows.Count > 0)
                {
                    last_n = Convert.ToInt32(dt.Rows[0]["n"]);
                }

                foreach (Message m in Messagelist)
                {
                    int n = Convert.ToInt32(m.n);
                    if (n <= last_n) continue;
                    string[] d = m.r.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string r = m.r;

                    Array.Sort(d);
                    string[] a = d.Distinct().ToArray();
                    string sn = string.Join("", a);

                    int wan = Convert.ToInt32(d[0]);
                    int qian = Convert.ToInt32(d[1]);
                    int bai = Convert.ToInt32(d[2]);
                    int shi = Convert.ToInt32(d[3]);
                    int ge = Convert.ToInt32(d[4]);
                    try
                    {
                        caifenfen.Insert(n, r, wan, qian, bai, shi, ge, sn);
                    }
                    catch
                    {
                        continue;
                    }

                }
            }


        }
    }
}
