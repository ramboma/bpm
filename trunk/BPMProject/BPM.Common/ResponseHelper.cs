using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
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

        public static ReturnBase Post(string queryurl, string c,string m,string p)
        {

            string data = string.Format("c={0}&m={1}&p={2}", c, m, p);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(queryurl));
            request.Method = "POST";
            byte[] bytes= Encoding.GetEncoding("gb2312").GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
            request.ContentLength = bytes.Length; 
            //post数据，获取实际数据
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("gb2312"));
                string result = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                request.Abort();
                response.Close();
                return  JsonConvert.DeserializeObject<ReturnBase>(result);
            }
            return new ReturnBase() { Code = 1 };
        }
    }
}
