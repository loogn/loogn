using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Loogn.DB
{
    class RowPropertyDescriptor<T> : PropertyDescriptor
    {
        public RowPropertyDescriptor(string name)
            : base(name, null)
        { }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get { return typeof(Row); }
        }

        public override object GetValue(object component)
        {
            var m = component as Row;
            return m[Name];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return typeof(T); }
        }

        public override void ResetValue(object component)
        {
            var m = component as Row;
            m.Set<T>(Name, default(T));
        }

        public override void SetValue(object component, object value)
        {
            var m = component as Row;
            m.Set<T>(Name, (T)value);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }
}
