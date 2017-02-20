using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace reading_SQuad_Dataset
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            dynamic data;
            using (StreamReader r = new StreamReader(@"C:\Users\peter\Downloads\train-v1.1 (1).json"))
            {
                string json = r.ReadLine();  
                 data = JObject.Parse(json);
             }
           
            string directory = @"D:\Squad data\";
            
            for (int i = 0; i < 442; i++)
            {
               
                int num = data.data[i].paragraphs.Count;
                string fileName = data.data[i].title.ToString() + ".txt";

               

                var unwantedchars = new string[] { "@", ",", "*", ";", "'" ,"/","\\" , "[", "]" , ":" };
                foreach (var c in unwantedchars)
                {
                    fileName = fileName.Replace(c, string.Empty);
                }

                
                List<string> xx = new List<string>();
                for (int j=0;j<num;j++)
                {
                    xx.Add(data.data[i].paragraphs[j].context.ToString());
                }
                //  @"Output{0}.txt";
                // using (TextWriter tw = new StreamWriter(Path.Combine(directory, string.Format(fileName, i))))
                using (TextWriter tw = new StreamWriter(Path.Combine(directory, fileName)))
                {
                    foreach (String a in xx)
                        tw.WriteLine(a);
                }
                
            }
        }
    }
}
