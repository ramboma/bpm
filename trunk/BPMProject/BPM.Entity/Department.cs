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
        public double ID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public double ParentId { get; set; }
    }
}
