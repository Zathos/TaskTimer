using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TaskTimer.Constants;
using TaskTimer.Persistent;
using TaskTimer.UI;

namespace TaskTimer
{
    public class Archiver
    {
        public Archiver()
        {
            _taskLogger = new XmlTaskLogger();
            ArchiverFiles();
        }

        public void ArchiverFiles()
        {
            CheckCreateArchiveLogsDirectory();
            var tasksToArchive = GetTasksToArchive();
            foreach (string fileName in tasksToArchive)
            {
                File.Move(fileName, (Directories.ArchiveLogs + "\\" + fileName));
            }
        }

        public void OpenArchiveTaskView()
        {
            ArchiverFiles();
            var archiverForm = new ArchiverForm(_taskLogger);
            archiverForm.ShowDialog();
        }

        private static void CheckCreateArchiveLogsDirectory()
        {
            if (!Directory.Exists(Directories.ArchiveLogs))
            {
                Directory.CreateDirectory(Directories.ArchiveLogs);
            }
        }

        private DateTime GetDateOfStartOfWeek(DateTime now)
        {
            const DayOfWeek StartOfWeek = DayOfWeek.Sunday;
            int diff = now.DayOfWeek - StartOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return now.AddDays(-1 * diff).Date;
        }

        private IEnumerable<string> GetTasksToArchive()
        {
            var now = DateTime.Now;
            var durationToKeep = GetDateOfStartOfWeek(now);
            var allTaskNames = _taskLogger.LoadActiveTaskFileNames();
            var tasksToArchive = allTaskNames.Where(fileName => File.GetLastWriteTime(fileName) < durationToKeep).ToList();
            return tasksToArchive;
        }

        private readonly XmlTaskLogger _taskLogger;
    }
}