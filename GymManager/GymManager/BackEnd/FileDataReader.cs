using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using GymManager.BackEnd.Activities;
using Newtonsoft.Json;

namespace GymManager.BackEnd
{
    public class FileDataReader
    {
        private StreamReader _reader;

        public FileDataReader(string path)
        {
            string actualPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var FinalPath = actualPath + "\\Debug\\netcoreapp3.1\\" + path;
            Console.WriteLine(@path);
            try
            {
                _reader = new StreamReader(FinalPath);
            }
            catch
            {
                Console.WriteLine("Could not create a reader for path");
            }
        }

        public string ReadJsonData()
        {
            string jsonData = _reader.ReadToEnd();
            //Console.WriteLine($"jsondata is: {jsonData}");
            //Exercises deserializedData = JsonConvert.DeserializeObject<Exercises>(jsonData);

            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonData);

            DataTable dataTable = dataSet.Tables["exercises"];

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["exercise_name"] + " - " + row["date_time"]);
            }
            return ""; // here we need to return data Readed from file
        }

    }
}
