using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using GymManager.BackEnd.Users;
using Newtonsoft.Json;

namespace GymManager.BackEnd
{
    public class FileDataReader
    {
        private StreamReader _reader;

        public StreamReader  Reader
        {
            get { return _reader; }
        }

        public FileDataReader(string path)
        {
            string actualPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var FinalPath = actualPath + "\\Debug\\netcoreapp3.1\\" + path;
            try
            {
                _reader = new StreamReader(FinalPath);
            }
            catch
            {
                Console.WriteLine("Could not create a reader for path");
            }
        }

        public List<Exercise> ReadJsonData()
        {
            string jsonData = _reader.ReadToEnd();
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonData);

            DataTable dataTable = dataSet.Tables["exercises"];
            List<Exercise> listOfExercises = new List<Exercise>();
            foreach (DataRow row in dataTable.Rows)
            {
                string exerciseName = row["exercise_name"].ToString();
                string coach = row["coach"].ToString();
                Console.WriteLine(coach);

                string[] date = getDateConvertedToArray(row["date_time"].ToString());

                var newExercise = new Exercise(exerciseName,
                    new DateTime(
                    Int32.Parse(date[2]),   // year
                    Int32.Parse(date[1]),   // month
                    Int32.Parse(date[0]),   // day
                    Int32.Parse(date[3]),   // hour
                    Int32.Parse(date[4]),   // minute
                    Int32.Parse(date[5])    //  seconds
                    ), coach);
                listOfExercises.Add(newExercise);
            }
            return listOfExercises;
        }
        public static string[] getDateConvertedToArray(string date)
        {
            return Regex.Split(date, "/");
        }
    }
}
