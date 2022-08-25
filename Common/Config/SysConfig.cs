using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Common.Config
{
    public class SysConfig
    {
        //系统配置json路径
        public static string ConfigPath = FileHelper.GetAbsolutePath("Jsons/Configs.json");
        public static dynamic Parmars { get; set; }

        public static void InitConfig()
        {
            //判断是否存在此文件
            if (!System.IO.File.Exists(ConfigPath))
            {
                return;
            }
            try
            {
                System.IO.StreamReader file = System.IO.File.OpenText(ConfigPath);
                if (file!=null)
                {
                    JsonTextReader json=new JsonTextReader(file);
                    Parmars = JToken.ReadFrom(json);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
