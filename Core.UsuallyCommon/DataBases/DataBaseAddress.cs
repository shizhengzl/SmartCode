using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 数据库连接地址管理
    /// </summary>
    public class DataBaseAddress
    {
        /// <summary>
        /// 连接服务器地址
        /// </summary>
        public String ServerAddress { get; set; }
        /// <summary>
        /// 连接账号
        /// </summary>
        public String Accout { get; set; }
        /// <summary>
        /// 连接密码
        /// </summary>
        public String Password { get; set; }
        /// <summary>
        /// 连接端口
        /// </summary> 
        public Int32 Port { get; set; }
        /// <summary>
        /// 连接数据库名称
        /// </summary>
        public String DefaultDataBaseName { get; set; }
        /// <summary>
        /// 连接数据库类型
        /// </summary>
        public DataBaseType DataBaseType { get; set; }

        /// <summary>
        /// 数据库集合
        /// </summary>
        public List<DataBase> ListDataBase { get; set; }
    }
}
