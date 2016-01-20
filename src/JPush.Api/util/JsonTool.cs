using JPush.Api.report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JPush.Api.util
{
    public class JsonTool
    {
        // 从一个对象信息生成Json串        
        public static string ObjectToJson(object obj)        
        {
            return JsonConvert.SerializeObject(obj);    
        }

        // 从一个Json串生成对象信息        
        public static object JsonToObject<T>(string jsonString, T obj)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        // 从一个对象信息生成Json串        
        public static string DictionaryToJson(Dictionary<String, Object> dict)
        {
            StringBuilder json = new StringBuilder();
            
            foreach (KeyValuePair<String, Object> pair in dict) 
            {
                json.Append("\"").Append(pair.Key).Append("\"").Append(":").Append(ValueToJson(pair.Value)).Append(",");            
            }
            //Console.WriteLine("json String ******"+json);
            if (json.Length > 0) 
            {
                json.Remove(json.Length -1, 1);            
            }
            json.Append("}");
            json.Insert(0, "{");
            
            return json.ToString();
        }

        public static List<ReceivedResult.Received> JsonList(string jsonString)
        {
            return JsonConvert.DeserializeObject<List<ReceivedResult.Received>>(jsonString);
        }
        //从dictionary 的value中解析出字符串
        private static string ValueToJson(object value)
        {
            Type type = value.GetType();
            if(type==typeof(int)){

                return value.ToString();
            }else if(type==typeof(string)){

                return "\""+value+"\"";

            }else if(type==typeof(List<int>)||type==typeof(List<string>)){

                return ObjectToJson(value);

            }else if(type==typeof(Dictionary<string,object>)){

                return JsonTool.DictionaryToJson((Dictionary<string, object>)value);
            }
            else{
                Debug.WriteLine("Type in Dictionary is error!");
                return "type erro";
            }
        }
    }
}
