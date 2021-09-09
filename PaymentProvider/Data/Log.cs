using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProvider.Data
{
    public class Log
    {
        static string sLogFolder;

        #region Write message

    
        public static void Write(string Message)
        {
            Write(Message, string.Empty);
        }

        private static string GetLogFilePath()
        {
            if (string.IsNullOrEmpty(sLogFolder))
            {
                sLogFolder = AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                if (!Directory.Exists(sLogFolder))
                    Directory.CreateDirectory(sLogFolder);
            }

            return Path.Combine(sLogFolder, DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + ".txt");

        }

        public static void Write(string Message, string HelpContent)
        {
            try
            {
                string sLogFile = GetLogFilePath();
                FileStream fs = File.Open(sLogFile, System.IO.FileMode.Append);
                string projName = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);
                string sLog = DateTime.Now.ToString() + " --- *'" + Message + "'* --- " + projName + Environment.NewLine;
                Byte[] bLog = new UTF8Encoding(true).GetBytes(sLog);
                fs.Write(bLog, 0, sLog.Length);
                fs.Close();
            }
            catch { }
        }



        #endregion

        #region Write Exception

        public void Write(Exception exceptionToLog)
        {
            try
            {
                Write(exceptionToLog, String.Empty);
            }
            catch { }
        }

        public static void Write(Exception exceptionToLog, string HelpContent)
        {
            try
            {

                string sLogFile = GetLogFilePath();
                FileStream fs = File.Open(sLogFile, System.IO.FileMode.Append);
                string projName = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);
                string sLog = DateTime.Now.ToString() + "---" + projName + Environment.NewLine +
                               "\tMessage --- *'" + exceptionToLog.Message + "'*" + Environment.NewLine +
                               "\tSource --- *'" + exceptionToLog.Source + "'*" + Environment.NewLine +
                               "\tTargetSite --- *'" + exceptionToLog.TargetSite + "'*" + Environment.NewLine +
                               "\tStackTrace --- *'" + exceptionToLog.StackTrace + "'*" + Environment.NewLine +
                               "\tHelpLink --- *'" + exceptionToLog.HelpLink + "'*" + Environment.NewLine;
                Byte[] bLog = new UTF8Encoding(true).GetBytes(sLog);
                fs.Write(bLog, 0, sLog.Length);
                fs.Close();
            }
            catch { }
        }

        #endregion


    }

}
