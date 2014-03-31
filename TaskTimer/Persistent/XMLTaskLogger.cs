using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TaskTimer.Annotations;
using TaskTimer.POCOs;

namespace TaskTimer
{
    public class XmlTaskLogger : ITaskLogger
    {
        public IList<TaskItem> LoadTaskList()
        {
            var fileName = GetTodaysFileName();
            if (!File.Exists(fileName))
            {
                return new List<TaskItem>();
            }

            var xmlSerializer = new XmlSerializer(typeof(List<TaskItem>));
            using (TextReader reader = new StreamReader(fileName))
            {
                var tasks = (List<TaskItem>)xmlSerializer.Deserialize(reader);
                reader.Close();
                return tasks;
            }
        }

        public void SaveChanges(IList<TaskItem> taskItems)
        {
            var fileName = GetTodaysFileName();
            var xmlSerializer = new XmlSerializer(typeof(List<TaskItem>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(writer, taskItems);
                writer.Close(); 
            }
        }

        [CanBeNull]
        private string GetTodaysFileName()
        {
            return string.Format("{0}.TaskLog.xml", DateTime.Now.ToString("yyyy-MM-dd"));
        }
    }
}