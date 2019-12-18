using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GlobalParameter
    {
        // form间传值
        public static bool USE_DB = false;          // 默认不使用数据库
        public static bool HAS_CONNDB = false;      // 默认数据库没有连接
        public static string URL;
        public static string DATEBASE;
        public static string COLLECTION;

    }
}
