using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Loogn.Timer
{
    [ConfigurationCollection(typeof(TimeRule))]
    sealed class TimeRuleCollection : ConfigurationElementCollection
    {
        
        protected override ConfigurationElement CreateNewElement()
        {
            return new TimeRule();    
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TimeRule)element).Name;
        }

        public new TimeRule this[string name]
        {
            get
            {
                return base[name] as TimeRule;
            }

        }
    }
}
