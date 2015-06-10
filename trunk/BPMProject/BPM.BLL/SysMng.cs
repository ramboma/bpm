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
            //SqlExpression<Employee> sqlexpression = Utity.Connection.From<Employee>();
            //sqlexpression.LeftJoin<Department>((e, d) => e.DeptID == d.DeptID);
            string str_sql = @"SELECT Employee.EmplID,Employee.EmplName,Employee.DeptID,Employee.AliasName,Employee.KeyString
                            ,Employee.Password,Employee.Sex
                            ,DATEDIFF(YEAR,Employee.Birthday,GETDATE())as Age
                            ,Employee.Attribute
                            ,Employee.Rank
                            ,Employee.TelNo
                            ,Employee.AccessMask
                            ,Employee.Remark
                            ,Dept.DeptName
                            ,pv.CatalogName as RankName
                            ,pv1.CatalogName as AttributeName
                            ,pv2.CatalogName as SexName
                            FROM Employee
                            left join Department dept on Employee.DeptID=dept.DeptID
                            LEFT JOIN Provider pv ON Employee.Rank = pv.CatalogId
                            LEFT JOIN Provider pv1 ON Employee.Attribute = pv1.CatalogId
                            LEFT JOIN Provider pv2 ON Employee.Sex = pv2.CatalogId";
            return Utity.Connection.Select<EmplyeeDto>(str_sql);
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
            return Utity.Connection.Delete<Employee>(s => s.EmplID == strParams);
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
            return Utity.Connection.Delete<Role>(s => s.RoleID == strParams);
        }
        public static List<RoleDto> GetAllRoleInfo()
        {
            SqlExpression<Role> sqlexpression = Utity.Connection.From<Role>();
            sqlexpression.LeftJoin<Employee>((r, e) => r.EmplID == e.EmplID);
            return Utity.Connection.Select<RoleDto>(sqlexpression);
        }
        #endregion
        #region 部门

        public static long AddDeptInfo(Department departInput)
        {
            return Utity.Connection.Insert<Department>(departInput, selectIdentity: true);
        }
        public static List<TreeDto> GetAllDeptInfoList()
        {
            SqlExpression<Department> sqlexpression = Utity.Connection.From<Department>();
            var deptInfo=Utity.Connection.Select(sqlexpression);
            var treeList = new List<TreeDto>();
            foreach (var info in deptInfo)
            {
                var current = new TreeDto
                {
                    id = info.DeptID.ToString(),
                    text = info.DeptName,
                    Node = info
                };
                treeList.Add(current);
            }
            return treeList;
        }
        public static List<TreeDto> GetAllDeptInfo()
        {
            List<TreeDto> list = new List<TreeDto>();
            SqlExpression<Department> sqlexpression = Utity.Connection.From<Department>();
            string str = sqlexpression.SelectInto<Department>();
            var allDept = Utity.Connection.Select(sqlexpression);
            //先填充第一层
            //对于第一层依次遍历，查找下一层,查找到一个就添加到子节点中
            List<Department> firstLayer = allDept.Where(s => s.DeptParentID == 0).ToList();
            foreach (var v in firstLayer)
            {
                TreeDto td = new TreeDto()
                {
                    id = v.DeptID.ToString(),
                    text = v.DeptName,
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
            return allDept.Where(s => s.DeptParentID.ToString() == td.id).ToList();
        }



        private static void FillNode(List<Department> allDept, TreeDto v)
        {
            foreach (var node in allDept)
            {
                if (node.DeptParentID.ToString() == v.id)
                {
                    TreeDto currentTd = new TreeDto()
                    {
                        id = node.DeptID.ToString(),
                        text = node.DeptName,
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

            return Utity.Connection.Delete<Department>(s => s.DeptID == strParams);
        }
        #endregion

    }
}
