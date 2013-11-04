using System;
using System.Collections.Generic;
using System.Text;

namespace Loogn.Timer
{

    public delegate void TaskElapsedEventHandler(TaskTimer sender, TaskElapsedEventArgs e);

    public class TaskElapsedEventArgs
    {
        public TaskElapsedEventArgs(string taskName) : this(taskName, DateTime.Now) { }
        public TaskElapsedEventArgs(string taskName, DateTime signalTime)
        {
            this.TaskName = taskName;
            this.SignalTime = signalTime;
        }
        public string TaskName { get; private set; }
        public DateTime SignalTime { get; private set; }
    }
}
