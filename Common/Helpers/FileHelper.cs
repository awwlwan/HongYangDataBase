using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Helpers
{
    public class FileHelper
    {
        public static string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                return "";
            }
            relativePath = relativePath.Replace("/","\\");
            if (relativePath[0] == '\\')
            {
                relativePath = relativePath.Remove(0, 1);
            }
            //判断是Web程序还是window程序
            if (HttpContext.Current != null)
            {
                return Path.Combine(HttpRuntime.AppDomainAppPath, relativePath);
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        }

        /// <summary>
        /// 获取文件的绝对路径,针对window程序和web程序都可使用
        /// </summary> 
        /// <returns>绝对路径地址</returns>
        public static string GetRootPath()
        {
            //判断是Web程序还是window程序
            return HttpContext.Current != null ? HttpRuntime.AppDomainAppPath : AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
