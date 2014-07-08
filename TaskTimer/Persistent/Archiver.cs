using System;
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
            if (!Directory.Exists(Directories.ArchiveLogs))
            {
                Directory.CreateDirectory(Directories.ArchiveLogs);
            }

            var now = DateTime.Now;
            var durationToKeep = GetDateOfStartOfWeek(now);
            var allTaskNames = _taskLogger.LoadAllTaskFileNames();

            var tasksToArchive = allTaskNames.Where(fileName => File.GetLastWriteTime(fileName) < durationToKeep).ToList();

            foreach (string fileName in tasksToArchive)
            {
                File.Move(fileName, (Directories.ArchiveLogs + "\\" + fileName));
            }
        }

        public void OpenArchiveTaskView()
        {
            var archiverForm = new ArchiverForm(_taskLogger);
            archiverForm.ShowDialog();
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

        private readonly XmlTaskLogger _taskLogger;
    }
}