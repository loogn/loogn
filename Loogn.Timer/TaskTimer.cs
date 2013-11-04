using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Configuration;

namespace Loogn.Timer
{
    public class TaskTimer : IDisposable
    {
        List<TimeRule> timeRules;
        System.Timers.Timer timer;
        public TaskTimer(string configSectionName = "taskTimer")
            : this(1000,configSectionName)
        {
        }
        public TaskTimer(int interval, string configSectionName="taskTimer")
        {
            timer = new System.Timers.Timer(interval);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timeRules = new List<TimeRule>();
            var ruleConfig = ConfigurationManager.GetSection(configSectionName) as RuleConfig;

            foreach (var item in ruleConfig.Rules)
            {
                var rule = (TimeRule)item;
                if (!rule.Disable)
                {
                    timeRules.Add(rule);
                }
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var rule in timeRules)
            {
                if (rule.IsHit())
                {
                    if (Elapsed != null)
                    {
                        //Elapsed(rule.Name);//同步调用
                        Elapsed.BeginInvoke(this, new TaskElapsedEventArgs(rule.Name), null, null); //异步调用
                    }
                }
            }
        }

        public event TaskElapsedEventHandler Elapsed;

        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                //清理托管资源
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
            }
            //清理自己的非托管资源，这里好像没有
            disposed = true;
        }
        ~TaskTimer()
        {
            Dispose(false);
        }
    }
}
