using Common;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crawl
{
    public partial class index : System.Web.UI.Page
    {
        public string host = System.Configuration.ConfigurationManager.AppSettings["hosts"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

    }
}