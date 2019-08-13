using Core.Tools.Migrations;
using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    /// <summary>
    /// 数据库连接地址管理
    /// </summary>
    public class DataBaseAddress
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Int32 Id { get; set; }
        /// <summary>
        /// 连接服务器地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 连接账号
        /// </summary>
        public String User { get; set; }
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
        /// 链接字符串
        /// </summary>
        public string ConnectionStrings { get; set; }


        /// <summary>
        /// 数据库集合
        /// </summary>
        public List<DataBase> DataBases { get; set; }
    }
}
