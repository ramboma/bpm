using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ReturnBase 的摘要说明
/// </summary>
    public class ReturnBase
    {
        public ReturnBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public int Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }

    /// <summary>
    /// 相应码
    /// </summary>
    public class ResponseCode
    {
        /// <summary>
        /// 1 执行成功
        /// </summary>
        public const int SUCCESS = 1;

        /// <summary>
        /// 失败
        /// </summary>
        public const int FAIL = -99;

        /// <summary>
        /// 没有操作权限
        /// </summary>
        public const int NoPermission = -11;

        /// <summary>
        /// 用户操作失败
        /// </summary>
        public const int UserFail = -12;

        /// <summary>
        /// 已审核
        /// </summary>
        public const int Reviewed = -13;

        /// <summary>
        /// 参数有误
        /// </summary>
        public const int ErrorParameter = -14;

        /// <summary>
        /// 查看最大次数
        /// </summary>
        public const int LookMax = -15;
    }