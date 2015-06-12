using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPM.Entity;
using BPM.Entity.Process;
namespace BPM.Entity.DTO
{
    public class FlowDto
    {
        public FlowInstance flowInstance { get; set; }
        public object Date { get; set; }
    }
}
