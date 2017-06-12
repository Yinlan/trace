using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Trace.util
{
    class HttpUtil
    {
        /// <summary>
        /// 发送http post请求
        /// </summary>
        public static string post(string url, string postData){
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("UTF-8"));
            myStreamWriter.Write(postData);
            myStreamWriter.Close();
            myRequestStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
            return response.StatusCode.ToString();
        }

        /// <summary>
        /// http get
        /// </summary>
        public static string get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string charSet = response.CharacterSet;
            Encoding encode;
            if (charSet != "")
            {
                encode = Encoding.GetEncoding(charSet);
            }
            else
            {
                encode = Encoding.Default;
            }

            string result = "";

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            char[] read = new char[255];
            //每次读取255
            int count = reader.Read(read, 0, 255);
            while(count > 0) //如果读到一定数目的字符串后，将这些字符串输入到string中
            {
                result += new String(read, 0, count);
                count = reader.Read(read, 0, 255); //再度后面255的内容
            }

            reader.Close();
            stream.Close();
            response.Close();
           // return response.StatusCode.ToString();
         
            return result;
        }

    }
}
