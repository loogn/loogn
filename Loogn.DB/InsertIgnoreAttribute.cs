using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.DB
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class InsertIgnoreAttribute : Attribute
    {
    }
}
