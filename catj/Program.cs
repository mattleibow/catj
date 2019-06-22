using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace catj
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length < 1)
                return 1;

            var file = args[0];

            if (!File.Exists(file))
                return 1;

            var jtoken = JToken.Parse(File.ReadAllText(file));

            Print(jtoken);

            return 0;
        }

        private static void Print(JToken jtoken, string path = "")
        {
            if (jtoken.Type == JTokenType.Array)
                PrintArray((JArray)jtoken, path);
            else if (jtoken.Type == JTokenType.Object)
                PrintObject((JObject)jtoken, path);
            else
                PrintValue((JValue)jtoken, path);
        }

        private static void PrintObject(JObject jobject, string path)
        {
            foreach (var prop in jobject)
            {
                var value = prop.Value;
                var nodePath = $"{path}.{prop.Key}";

                Print(value, nodePath);
            }
        }

        private static void PrintArray(JArray jarray, string path)
        {
            for (var i = 0; i < jarray.Count; i++)
            {
                var value = jarray[i];
                var nodePath = $"{path}[{i}]";

                Print(value, nodePath);
            }
        }

        private static void PrintValue(JValue jvalue, string path)
        {
            var val = jvalue.Type == JTokenType.String
                ? $@"""{jvalue}"""
                : $"{jvalue}";

            Console.WriteLine($@"{path} = {val}");
        }
    }
}
