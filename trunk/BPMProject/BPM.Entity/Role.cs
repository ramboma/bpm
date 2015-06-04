using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity
{
    public class Role
    {
        public double id { get; set; }
        public string  Name { get; set; }
        public double EmployeeID { get; set; }
        public string AccessMask { get; set; }
        public string Remark { get; set; }
    }
}
