using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
namespace BPM.Entity
{
    public class Role
    {
        [AutoIncrement]
        public long RoleID { get; set; }
        public string  RoleName { get; set; }
        public long EmplID { get; set; }
        public long AccessMask { get; set; }
        public string Remark { get; set; }
    }
}
