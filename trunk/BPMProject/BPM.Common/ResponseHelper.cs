using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BPM.Common
{
    public class ResponseHelper
    {
        /// <summary>
        /// 简单的成功代码生成方法
        /// </summary>
        /// <param name="vProjectList"></param>
        /// <returns></returns>
        public static string GetSuccessReturn(object vProjectList)
        {
            ReturnBase rb = new ReturnBase();
            rb.Code = ResponseCode.SUCCESS;
            rb.Message = "";
            rb.Result = vProjectList;
            string strJsonResult = JsonConvert.SerializeObject(rb);
            return strJsonResult;
        }
        /// <summary>
        /// 简单的错误代码生成方法
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetErrorReturn(int code, string message)
        {
            ReturnBase rb = new ReturnBase();
            rb.Code = code;
            rb.Message = message;
            rb.Result = null;
            return JsonConvert.SerializeObject(rb);
        }
    }
}
