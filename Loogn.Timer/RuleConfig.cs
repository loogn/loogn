using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Loogn.Timer
{
    sealed class RuleConfig : ConfigurationSection
    {
        [ConfigurationProperty("rules")]
        public TimeRuleCollection Rules
        {
            get { return (TimeRuleCollection)base["rules"]; }
            set { base["rules"] = value; }
        }
    }
}
