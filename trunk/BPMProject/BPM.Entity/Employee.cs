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
        public long EmplID { get; set; }
        public string EmplName { get; set; }
        public long DeptID { get; set; }
        public string AliasName { get; set; }
        public string Password { get; set; }
        public string KeyString { get; set; }
        public DateTime Birthday { get; set; }
        public long Attribute { get; set; }
        public long Sex { get; set; }
        public string TelNo { get; set; }
        public long Rank { get; set; }
        public long AccessMask { get; set; }
        public string Remark { get; set; }
    }
}
