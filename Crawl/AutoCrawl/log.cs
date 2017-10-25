using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutoCrawl
{
    public class log
    {
        public static object m_objectLocker = new object();
        public static void WriteEvent(string strEvent)
        {

            //TODO: Finish it.   
            // 将当前时间 和 strEvent写入日志.

            lock (m_objectLocker)
            {
                WriteLoginToFile(System.AppDomain.CurrentDomain.BaseDirectory, GetLogFileName(), strEvent + "\r\n");
            }

        }

        /// <summary>
        /// Get the log file name.
        /// </summary>
        /// <returns></returns>
        private static string GetLogFileName()
        {
            // 日志应该存储在当前目录下的Log目录下，每天一个文件。
            // 文件名为当前日期yyyy-mm-dd.log
            string strToReturn = "";

            DateTime dtNow = DateTime.Now;
            strToReturn = string.Format("{0}_{1}_{2}.log", dtNow.Year, dtNow.Month, dtNow.Day);
            return strToReturn;

        }
        private static void WriteLoginToFile(string path, string filename, string content)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            StreamWriter sw = File.AppendText(path + filename);
            sw.Write(content);
            sw.Flush();
            sw.Close();
            sw.Dispose();

        }
    }
}
