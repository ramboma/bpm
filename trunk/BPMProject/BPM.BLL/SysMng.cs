using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using BPM.Entity;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using BPM.ORMLite;
namespace BPM.BLL
{
    public class SysMng
    {
        #region 员工


        public static List<EmplyeeDto> GetAllEmployeeInfo()
        {
            SqlExpression<Employee> sqlexpression = Utity.Connection.From<Employee>();
            sqlexpression.LeftJoin<Department>((e, d) => e.DeptID == d.ID);

            return Utity.Connection.Select<EmplyeeDto>(sqlexpression);
        }

        public static long AddEmployeeInfo(Employee employee)
        {
            return Utity.Connection.Insert<Employee>(employee, selectIdentity: true);
        }

        public static long UpdateEmployeeInfo(Employee employee)
        {
            return Utity.Connection.Update<Employee>(employee);
        }

        public static long DeleteEmployeeInfo(int strParams)
        {
            return Utity.Connection.Delete<Employee>(s => s.ID == strParams);
        }

        #endregion
        #region 角色

        public static long AddRoleInfo(Role roleInput)
        {
            return Utity.Connection.Insert<Role>(roleInput, selectIdentity: true);
        }

        public static long UpdateRoleInfo(Role roleInput)
        {
            return Utity.Connection.Update<Role>(roleInput);
        }

        public static long DeleteRoleInfo(int strParams)
        {
            return Utity.Connection.Delete<Role>(s => s.id == strParams);
        }
        public static List<RoleDto> GetAllRoleInfo()
        {
            SqlExpression<Role> sqlexpression = Utity.Connection.From<Role>();
            sqlexpression.LeftJoin<Employee>((r, e) => r.EmployeeID == e.ID);
            return Utity.Connection.Select<RoleDto>(sqlexpression);
        }
        #endregion
        #region 部门

        public static long AddDeptInfo(Department departInput)
        {
            return Utity.Connection.Insert<Department>(departInput, selectIdentity: true);
        }

        public static List<TreeDto> GetAllDeptInfo()
        {
            List<TreeDto> list = new List<TreeDto>();
            SqlExpression<Department> sqlexpression = Utity.Connection.From<Department>();
            string str = sqlexpression.SelectInto<Department>();
            var allDept = Utity.Connection.Select(sqlexpression);
            //先填充第一层
            //对于第一层依次遍历，查找下一层,查找到一个就添加到子节点中
            List<Department> firstLayer = allDept.Where(s => s.ParentId == 0).ToList();
            foreach (var v in firstLayer)
            {
                TreeDto td = new TreeDto()
                {
                    id = v.ID.ToString(),
                    text = v.Name,
                    Node = v,
                    children = new List<TreeDto>()
                };
                list.Add(td);
                //递归查询下层
                List<Department> childList = GetChilda(allDept,td);
                if (childList.Count>0)
                {
                    FillNode(allDept, td);
                }
            }

            return list;
        }

        private static List<Department> GetChilda(List<Department> allDept, TreeDto td)
        {
            return allDept.Where(s => s.ParentId.ToString() == td.id).ToList();
        }



        private static void FillNode(List<Department> allDept, TreeDto v)
        {
            foreach (var node in allDept)
            {
                if (node.ParentId.ToString() == v.id)
                {
                    TreeDto currentTd = new TreeDto()
                    {
                        id = node.ID.ToString(),
                        text = node.Name,
                        Node = node,
                        children = new List<TreeDto>()
                    };
                    v.children.Add(currentTd);
                    List<Department> childList = GetChilda(allDept,currentTd);
                    if (childList.Count>0)
                    {
                        FillNode(allDept, currentTd);
                    }
                }
            }
        }

        public static long UpdateDeptInfo(Department departInput)
        {
            return Utity.Connection.Update<Department>(departInput);
        }

        public static long DeleteDeptInfo(int strParams)
        {
            return Utity.Connection.Delete<Department>(s => s.ID == strParams);
        }
        #endregion

    }
}
