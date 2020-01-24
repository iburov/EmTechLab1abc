using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Models
{
    public class LogUtil
    {
        public void LogEvent(Exception ex, EventLogEntryType type) {
            using (EventLog eventLog = new EventLog("Application")) 
            {
                eventLog.Source = "Application"; 
                eventLog.WriteEntry(ex + "LOGGED ERROR " + DateTime.Now, type, 101, 1); 
            }
        }

        public void LogToText(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;


            if (System.IO.File.Exists(@"C:\Users\iburov\Desktop\log.txt"))
            {
                using (StreamWriter w = System.IO.File.AppendText(@"C:\Users\iburov\Desktop\log.txt"))
                {
                    Log(filterContext.Exception.ToString(), w);
                    w.Close();
                }
            }
            else
            {
                using (FileStream fs = System.IO.File.Create(@"C:\Users\iburov\Desktop\log.txt"))
                {
                    using (StreamReader r = System.IO.File.OpenText(@"C:\Users\iburov\Desktop\log.txt"))
                    {
                        DumpLog(r);

                        r.Close();
                    }
                    fs.Close();
                }
            }

        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine(" :");
            w.WriteLine($" :{logMessage}");
            w.WriteLine("-------------------------------");
        }        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}