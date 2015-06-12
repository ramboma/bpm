using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    public enum UserLoginResult
    {
        e_UserLoginResult_Success = 0,
        e_UserLoginResult_Err_Pwd,
        e_UserLoginResult_Err_Account
    };
    public class UserAuthDto : UserAuth
    {
        public string DeptName { get; set; }
        public string RoleName { get; set; }
        public long RoleAccessMask { get; set; }
        public string RankName { get; set; }
        public string AttrName { get; set; }
        public UserLoginResult LoginState { get; set; }    //0表示成功，1表示账户错误，2表示密码错误
    }
    public class UserAuth
    {
        public string UserName { get;set;}
        public string LoginName { get; set; }
        public string UserPwd {get;set;}
        public string NewPwd { get; set; }
        public string AuthCode { get; set; }
        public string KeyValue { get; set; }
    }
}
