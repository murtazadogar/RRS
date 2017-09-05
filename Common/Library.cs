using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public class Library
    {
        /// <summary>
        /// Use for server deployment
        /// </summary>

        //static String Server_path = @"D:\home\testlogs\ParseData.txt";
        //static String Server_path_error = @"D:\home\testlogs\LogFileException.txt";


        ///Use for local setting
        static String Server_path_error = AppDomain.CurrentDomain.BaseDirectory + "LogFileException.txt";
        static String Server_path = AppDomain.CurrentDomain.BaseDirectory + "LogFileException.txt";


        #region Generate Logs
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        public static void WriteErrorLog(Exception ex)
        {
            //// Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                using (StreamWriter sw = File.AppendText(Server_path_error))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim() + "; " + ex.StackTrace.Trim() + "; " + ex.InnerException.Message.Trim());
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public static void WriteCrawlLog(string Message)
        {
            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                using (StreamWriter sw = File.AppendText(Server_path))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        #endregion
    }
}
