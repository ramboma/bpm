using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    public class EmplyeeDto:Employee
    {
        public string DeptName { get; set; }
        public string AttributeName { get; set; }
        public string RankName { get; set; }
        public string SexName { get; set; }
        public string Age { get; set; }
    }
}
