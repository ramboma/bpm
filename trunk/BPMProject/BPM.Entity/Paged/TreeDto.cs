using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.Paged
{
    public class TreeDto
    {
        public string id { get; set; }
        public string text { get; set; }
        public List<TreeDto> children { get; set; }
        public object Node { get; set; }
    }
}
