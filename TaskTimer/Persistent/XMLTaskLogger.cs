using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.Persistent
{
    public class XmlTaskLogger : ITaskLogger
    {
        private const string MasterTaskListFile = "MasterTaskList.txt";

        public IList<TaskItem> LoadTaskList()
        {
            var fileName = GetTodaysFileName();
            if (!File.Exists(fileName))
            {
                return LoadMasterTaskList();
            }

            var xmlSerializer = new XmlSerializer(typeof (List<TaskItem>));
            using (TextReader reader = new StreamReader(fileName))
            {
                var tasks = (List<TaskItem>) xmlSerializer.Deserialize(reader);
                reader.Close();
                return tasks;
            }
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

        private void WriteTaskName([NotNull] IEnumerable<TaskItem> taskItems)
        {
            string taskNames = taskItems.Aggregate(string.Empty, (current, taskItem) => current + (taskItem.TaskName + ","));
            taskNames = taskNames.Substring(0, taskNames.Length - 1);
            using (TextWriter writer = new StreamWriter(MasterTaskListFile))
            {
                writer.WriteLine(taskNames);
            }
        }

        [NotNull]
        private static IEnumerable<string> GetTaskNames()
        {
            string allTaskNames;
            if (!File.Exists(MasterTaskListFile))
            {
                var file = File.Create(MasterTaskListFile);
                file.Close();
            }

            using (TextReader reader = new StreamReader(MasterTaskListFile))
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

        [CanBeNull]
        private string GetTodaysFileName()
        {
            return string.Format("{0}.TaskLog.xml", DateTime.Now.ToString("yyyy-MM-dd"));
        }
    }
}