using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.DataAnnotations;
namespace BPM.Entity
{
    public class Department
    {
        [AutoIncrement]
        public long DeptID { get; set; }
        public string DeptName { get; set; }
        public string DeptRemark { get; set; }
        public long DeptParentID { get; set; }
    }
}
