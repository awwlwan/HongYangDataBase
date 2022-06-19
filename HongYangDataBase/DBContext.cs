using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using Common.Config;
namespace HongYangDataBase
{
    //数据库操作类
    public class DBContext
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static List<string> Listconn { get; set; }


        //主从库 连接设置属性，返回
        public SqlSugarClient Instance
        {

            //InitKeyType.SystemTable表示自动从数据库读取主键自增列的信息（适合SA等高权限的账户）
            get
            {
                var ConnStr = "";//主库
                var SlaveConnectionConfigs = new List<SlaveConnectionConfig>();
                for (int i = 0; i < Listconn.Count; i++)
                {
                    if (i==0)
                    {
                        ConnStr = Listconn[i];
                    }
                    else
                    {
                        SlaveConnectionConfigs.Add(new SlaveConnectionConfig
                        {
                            HitRate = i * 2,
                            ConnectionString = Listconn[i]//从库列表
                        }) ;
                    }
                }

                
                SqlSugarClient db = new SqlSugarClient(new ConnectionConfig
                {
                    ConnectionString = ConnStr,//主库
                    DbType = (DbType)1,//数据库类型
                    IsAutoCloseConnection = true,//是否自动释放数据库
                    InitKeyType = InitKeyType.Attribute,//从实体获取主键
                    SlaveConnectionConfigs = SlaveConnectionConfigs //配置就为读写分离
                }) ;
                db.Ado.CommandTimeOut = 30000; //设置超时时间
                //sql执行完毕事件
                db.Aop.OnLogExecuted = (sql, pars) =>
                {

                };
                //sql执行前事件
                db.Aop.OnLogExecuting = (sql, pars) =>
                {

                };
                db.Aop.OnDiffLogEvent = (item) =>//获取sql执行前后变化，log
                {
                    
                };
                return db;
            }
        }
        //设置链接字符串
        public static void SetConn()
        {
            SysConfig.InitConfig();
            var list = new List<string> { SysConfig.Parmars.ConnMain };//主库
            var ConnFrom=new List<string>() { SysConfig.Parmars.ConnFrom };
        }
    }
}
