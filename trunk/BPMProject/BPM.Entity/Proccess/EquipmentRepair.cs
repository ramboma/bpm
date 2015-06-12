using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
namespace BPM.Entity.Proccess
{
    /// <summary>
    /// 装备维修实体
    /// </summary>
    public class EquipmentRepair
    {
        [AutoIncrement]
        public long EquipmentRepairId { get; set; }

        /// <summary>
        /// 流程实例id
        /// </summary>
        public long FlowInstanceId{ get; set; }    
        public double equipmentid { get; set; }
        public string equipmentname { get; set; }
        public string associateTime { get; set; }
        public string associateLoc { get; set; }
        public string associateLog { get; set; }
        public string attachLog { get; set; }
        public string docLog { get; set; }

        public int preRepairLevel { get; set; }
        public string preRepairTime { get; set; }
        public string createTime { get; set; }
        public string inputFactoryTime { get; set; }
        public string userLog { get; set; }
        public string repairAdvice { get; set; }
        public string inquestUnit { get; set; }
        public string inquestUser { get; set; }
        public string repairRequire { get; set; }
        public int    repairMakeLevel { get; set; }
        public string makeLevelReason { get; set; }
        public string checkTask { get; set; }
        public string kpi { get; set; }
        public string checkLoc { get; set; }
        public string checkMethod { get; set; }
        public string armyCheck { get; set; }
        public string armyResult { get; set; }
        public string equipmentResult { get; set; }
        public string armyManResult { get; set; }
        public string equipmentConsignLog { get; set; }
        public string attachConsignLog { get; set; }
        public string docConsignLog { get; set; }
    }
}
