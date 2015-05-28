using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.DataAnnotations;
using ServiceStack.Serialization;
using ServiceStack.Text;
namespace BPM.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //连接数据库,获取数据连接类
            string strconn = System.Configuration.ConfigurationManager.AppSettings["sqlconnect"];
            var sqlfactory = new OrmLiteConnectionFactory(strconn, SqlServerOrmLiteDialectProvider.Instance);
            var conn=sqlfactory.OpenDbConnection();
            //获取实体操作类
            var expression = conn.From<accounttest>();
            //查看生成的sql
            Console.WriteLine(expression.SelectInto<accounttest>());
            //执行查询，返回实体列表
            var list = conn.Select<accounttest>(expression);

            foreach (var v in list)
            {
                Console.WriteLine(string.Format("{0},{1},{2}", v.id, v.name, v.password));
            }
            //关联查询，增加on语句，限制条数，排序
            expression.Join<account, accounttest>((s, p) => s.id == p.id).Limit(100).OrderByDescending(s=>s.id);
            //将结果集写入需要的实体类，accounttest或者account都可以，新的类也可以，注意属性值的名称要相同
            Console.WriteLine(expression.SelectInto<accounttest>());
            //where条件
            expression.Where<account>(s => s.id == idenum.one);

            Console.WriteLine(expression.SelectInto<accounttest>());
            
/*
            using (var trans = conn.OpenTransaction())
            {
                conn.Insert<accounttest>(new accounttest() { id = idenum.two, name = "33" });
                conn.Insert<accounttest>(new accounttest() { id = idenum.two, name = "33" });
                conn.Insert<accounttest>(new accounttest() { id = idenum.two, name = "33" });
                conn.Insert<accounttest>(new accounttest() { id = idenum.two, name = "33" });
            }
            */

            Console.Read();

            
        }
    }
    public class account
    {
        public idenum id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string createtime { get; set; }
        public int age { get; set; }
    }
   
    [Alias("account")]
    public class accounttest
    {
       public idenum id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int age { get; set; }
       [Alias("createtime")]
        public string title { get; set; }
    }
   public enum idenum
   {
       one,two
   }
}
