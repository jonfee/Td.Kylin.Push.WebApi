using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.Loger
{
    public abstract class BaseLoger
    {
        public BaseLoger(string fileFolderPath)
        {
            this.FileFolderPath = Path.Combine(Startup.WebRootPath, fileFolderPath);
        }

        /// <summary>
        /// 基于Application的文件夹路径 
        /// </summary>
        private string FileFolderPath;

        /// <summary>
        /// 写入内容
        /// </summary>
        /// <param name="content"></param>
        protected void LogWrite(StringBuilder content)
        {
            LogWrite(content.ToString());
        }

        /// <summary>
        /// 写入内容
        /// </summary>
        /// <param name="content"></param>
        protected void LogWrite(string content)
        {
            try
            {
                if (!Directory.Exists(FileFolderPath))
                {
                    Directory.CreateDirectory(FileFolderPath);
                }

                string appFilePath = Path.Combine(FileFolderPath, string.Format("{0}.txt", DateTime.Now.Month));

                if (!File.Exists(appFilePath))
                {
                    File.Create(appFilePath).Close();
                }

                using (StreamWriter sw = File.AppendText(appFilePath))
                {
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch(Exception ex)
            {
                //
            }
        }
    }
}
