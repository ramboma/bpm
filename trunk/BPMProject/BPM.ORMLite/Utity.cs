using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
namespace BPM.ORMLite
{
    public class Utity
    {
        /// <summary>
        /// 连接数据库,获取数据连接类
        /// </summary>
        public static System.Data.IDbConnection Connection
        {
            get
            {

                string strconn = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconnect"].ConnectionString;
                var sqlfactory = new OrmLiteConnectionFactory(strconn, SqlServerOrmLiteDialectProvider.Instance);
                var conn = sqlfactory.OpenDbConnection();
                return conn;
            }
        }

    }
}
