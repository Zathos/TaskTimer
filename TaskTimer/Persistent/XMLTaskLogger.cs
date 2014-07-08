using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TaskTimer.Constants;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.Persistent
{
    public class XmlTaskLogger : ITaskLogger
    {
        public IEnumerable<string> LoadActiveTaskFileNames()
        {
            return Directory.EnumerateFiles(Directories.Current, "*.xml");
        }

        public IList<ReportTaskItem> LoadAllTasks()
        {
            return LoadTaskItems(Directories.Current);
        }

        public IList<ReportTaskItem> LoadArchivedTasks()
        {
            return LoadTaskItems(Directories.ArchiveLogs + "\\" + Directories.Current);
        }

        public IList<TaskItem> LoadTaskList()
        {
            var fileName = GetTodaysFileName();
            if (!File.Exists(fileName))
            {
                return LoadMasterTaskList();
            }

            return LoadTaskListByFileName(fileName);
        }

        public void SaveChanges(IList<TaskItem> taskItems)
        {
            WriteTaskName(taskItems);

            var fileName = GetTodaysFileName();
            var xmlSerializer = new XmlSerializer(typeof (List<TaskItem>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(writer, taskItems);
                writer.Close();
            }
        }

        public void WriteReportToFile(List<string> header, Dictionary<string, List<string>> fileToGenerate)
        {
            if (File.Exists(Files.ReportAllCsv))
            {
                File.Delete(Files.ReportAllCsv);
            }

            const string Seperator = ",";

            var outputString = string.Empty;
            foreach (string activity in header)
            {
                outputString += activity + Seperator;
            }
            outputString.Substring(0, outputString.Length - 1);
            outputString += "\n";

            foreach (KeyValuePair<string, List<string>> valuePair in fileToGenerate)
            {
                outputString += valuePair.Key + Seperator;
                foreach (string dailyTime in valuePair.Value)
                {
                    outputString += dailyTime + Seperator;
                }
                outputString.Substring(0, outputString.Length - 1);
                outputString += "\n";
            }


            using (var file = new StreamWriter(Files.ReportAllCsv))
            {
                file.Write(outputString);
                file.Close();
            }

            System.Diagnostics.Process.Start(Files.ReportAllCsv);
        }

        [NotNull]
        private static IEnumerable<string> GetTaskNames()
        {
            string allTaskNames;
            if (!File.Exists(Files.MasterTaskList))
            {
                var file = File.Create(Files.MasterTaskList);
                file.Close();
            }

            using (TextReader reader = new StreamReader(Files.MasterTaskList))
            {
                allTaskNames = reader.ReadLine();
                reader.Close();
            }
            return allTaskNames != null ? allTaskNames.Split(',') : new string[0];
        }

        [NotNull]
        private static List<TaskItem> LoadMasterTaskList()
        {
            var taskNames = GetTaskNames();
            return taskNames.Select(taskName => new TaskItem
                                                    {
                                                        TaskName = taskName,
                                                    }).ToList();
        }

        private static IList<ReportTaskItem> LoadTaskItems(string searchPath)
        {
            var fileNames = Directory.EnumerateFiles(searchPath, "*.xml");
            var list = new List<ReportTaskItem>();
            foreach (string fileName in fileNames)
            {
                IList<TaskItem> tasks = LoadTaskListByFileName(fileName);
                string date = fileName.Split('.')[1].Substring(1);
                list.Add(new ReportTaskItem(date, tasks));
            }
            return list;
        }

        private static IList<TaskItem> LoadTaskListByFileName(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof (List<TaskItem>));
            using (TextReader reader = new StreamReader(fileName))
            {
                var tasks = (List<TaskItem>) xmlSerializer.Deserialize(reader);
                reader.Close();
                return tasks;
            }
        }

        [CanBeNull]
        private string GetTodaysFileName()
        {
            return string.Format("{0}.TaskLog.xml", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void WriteTaskName([NotNull] IEnumerable<TaskItem> taskItems)
        {
            string taskNames = taskItems.Aggregate(string.Empty, (current, taskItem) => current + (taskItem.TaskName + ","));
            taskNames = taskNames.Substring(0, taskNames.Length - 1);
            using (TextWriter file = new StreamWriter(Files.MasterTaskList))
            {
                file.WriteLine(taskNames);
                file.Close();
            }
        }
    }
}