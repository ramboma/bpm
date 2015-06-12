using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
namespace BPM.Entity
{
    public class FunctionInfo
    {
        [AutoIncrement]
        public long FuncID { get; set; }
        public string FuncName { get; set; }
        public long FuncCode { get; set; }
        public string FuncURL { get; set; }
        public string Remark { get; set; }
    }
}
