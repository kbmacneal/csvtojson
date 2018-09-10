using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ChoETL;
using System.Dynamic;

namespace csvtojson
{
    class Program
    {
        static void Main(string[] args)
        {
            string csv_path = args[0].ToString();

            string filename = args[1].ToString();

            List<object> obj_array = new List<object>();

            var reader = new ChoCSVReader<object>(csv_path).WithFirstLineHeader();
            object rec;

            while ((rec = reader.Read()) != null)
            {
                obj_array.Add(rec);
            }

            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(obj_array));
        }
    }
}
