using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
namespace BPM.Entity
{
    public class Employee
    {
        [AutoIncrement]
        public double ID { get; set; }
        public string Name { get; set; }
        public double DeptID { get; set; }
        public double Attribute { get; set; }
        public int Age { get; set; }
        public string AliasName { get; set; }
        public string Password { get; set; }
        public string KeyString { get; set; }
        public int Sex { get; set; }
        public string TelNo { get; set; }
        public double Rank { get; set; }
        public string Remark { get; set; }
    }
}
