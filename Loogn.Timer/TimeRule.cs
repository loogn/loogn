using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Loogn.Timer
{
    sealed class TimeRule :ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("disable", DefaultValue = false)]
        public bool Disable
        {
            get { return true.Equals(this["disable"]); }
            set { this["disable"] = value; }
        }

        #region 哪天
        //公共
        [ConfigurationProperty("intervalDate", DefaultValue = "1")]
        public int IntervalDate
        {
            get { return (int)this["intervalDate"]; }
            set { this["intervalDate"] = value; }
        }
        //默认应该是1,即每天\周\月
        [ConfigurationProperty("startDate", DefaultValue = "0001-01-01 00:00:00")]
        public DateTime StartDate
        {
            get { return DateTime.Parse(this["startDate"].ToString()); }
            set { this["startDate"] = value; }
        }
        [ConfigurationProperty("endDate", DefaultValue = "9999-12-31 23:59:59")]
        public DateTime EndDate {
            get { return DateTime.Parse(this["endDate"].ToString()); }
            set { this["endDate"] = value; }
        }

        //周
        [ConfigurationProperty("daysOfWeek", DefaultValue = "")]
        public string DaysOfWeek {
            get
            {
                return this["daysOfWeek"].ToString();
            }
        }

        private System.DayOfWeek[] m_daysOfWeek;
        private System.DayOfWeek[] GetDaysOfWeek()
        {
            if (m_daysOfWeek == null)
            {
                var daysOfWeek = DaysOfWeek;
                if (string.IsNullOrEmpty(daysOfWeek))
                {
                    m_daysOfWeek = new System.DayOfWeek[0];
                }
                else
                {
                    var str = daysOfWeek.Split(',');
                    m_daysOfWeek = Array.ConvertAll<string, System.DayOfWeek>(str, (s) =>
                    {
                        return (System.DayOfWeek)int.Parse(s);
                    });
                }
            }
            return m_daysOfWeek;
        }
        //月
        [ConfigurationProperty("dayIndex", DefaultValue = "0")]
        public int DayIndex
        {
            get { return int.Parse(this["dayIndex"].ToString()); }
            set { this["dayIndex"] = value; }
        }

        public bool IsDateHit()
        {
            if (StartDate > DateTime.Now || EndDate < DateTime.Now)
                return false;
            //每interval月
            if (DayIndex > 0)
            {
                if ((DateTime.Now.Date - StartDate.Date).TotalDays % (30 * IntervalDate) == 0)
                {
                    return DateTime.Now.Day == DayIndex;
                }
                return false;
            }
            //每interval周
            if (!string.IsNullOrEmpty(DaysOfWeek))
            {
                if ((DateTime.Now.Date - StartDate.Date).TotalDays % (IntervalDate * 7) == 0)
                {
                    return Array.Exists(GetDaysOfWeek(), (dow) => { return dow == DateTime.Now.DayOfWeek; });
                }
                return false;
            }
            //每interval天
            return (DateTime.Now.Date - StartDate.Date).TotalDays % IntervalDate == 0;
        }
        #endregion

        #region 一天内
        //interval
        [ConfigurationProperty("intervalTime")]
        public TimeSpan IntervalTime
        {
            get {
                if (this["intervalTime"] == null)
                {
                    return TimeSpan.MinValue;
                }
                else
                {
                    return TimeSpan.Parse(this["intervalTime"].ToString());
                }
            }
            set { this["intervalTime"] = value; }
        }
        [ConfigurationProperty("startTime", DefaultValue="00:00:00")]
        public TimeSpan StartTime
        {
            get {
                if (this["startTime"] == null)
                {
                    return EmptyTimeSpan;
                }
                else
                {
                    return TimeSpan.Parse(this["startTime"].ToString());
                }
            }
            set { this["beginTime"] = value; }
        }
        [ConfigurationProperty("endTime", DefaultValue = "23:59:59")]
        public TimeSpan EndTime
        {
            get
            {
                if (this["endTime"] == null)
                {
                    return new TimeSpan(23, 59, 59);
                }
                else
                {
                    return TimeSpan.Parse(this["endTime"].ToString());
                }
            }
            set { this["endTime"] = value; }
        }
        //once
        [ConfigurationProperty("executeTime", DefaultValue = "00:00:00")]
        public TimeSpan ExecuteTime
        {
            get {
                if (this["executeTime"] == null)
                {
                    return TimeSpan.MinValue;
                }
                else
                {
                    return TimeSpan.Parse(this["executeTime"].ToString());
                }
            }
            set { this["executeTime"] = value; }
        }

        static TimeSpan EmptyTimeSpan = new TimeSpan(0, 0, 0);
        public bool IsTimeHit()
        {
            var curTime = DateTime.Now.TimeOfDay;
            curTime = new TimeSpan(curTime.Hours, curTime.Minutes, curTime.Seconds);
            if (ExecuteTime != EmptyTimeSpan)
            {
                return curTime == ExecuteTime;
            }
            else
            {
                if (StartTime > curTime || EndTime < curTime)
                    return false;

                if ((curTime - StartTime).TotalSeconds % IntervalTime.TotalSeconds == 0)
                    return true;
                return false;
            }
        }
        #endregion

        public bool IsHit()
        {
            return IsDateHit() && IsTimeHit();
        }
    }
}
