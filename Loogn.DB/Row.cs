using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Loogn.DB
{
    [Serializable]
    public class Row : System.ComponentModel.ICustomTypeDescriptor, IEnumerable<KeyValuePair<string, object>>
    {
        Dictionary<string, object> fields;
        PropertyDescriptorCollection pdcoll;
        private string _componentName;
        public Row()
        {
            fields = new Dictionary<string, object>();
            pdcoll = new PropertyDescriptorCollection(null);
        }
        public Row(string name)
            : this()
        {
            _componentName = name; 
        }
        public string Name
        {
            get { return _componentName; }
            set { _componentName = value; }
        }
        public int FieldCount
        {
            get { return fields.Count; }
        }
        public Dictionary<string, object>.KeyCollection FieldNames
        {
            get { return fields.Keys; }
        }
        public Dictionary<string, object>.ValueCollection FieldValues
        {
            get { return fields.Values; }
        }

        private void AddField<T>(string key)
        {
            var pd = new RowPropertyDescriptor<T>(key);
            pdcoll.Add(pd);
        }
        private void AddValue<T>(string key, T value)
        {
            fields.Add(key, value);
            AddField<T>(key);
        }

        public void Add(string key, object value)
        {
            Set(key, value);
        }
        public void Set(string key, object value)
        {
            lock (this)
            {
                var newvalue = value;
                if (value is DBNull)
                    newvalue = null;

                if (fields.Keys.Contains(key))
                {
                    fields[key] = newvalue;
                }
                else
                {
                    fields.Add(key, newvalue);
                    if (value != null)
                    {
                        var type = value.GetType();
                        if (type == typeof(int))
                        {
                            AddField<int>(key);
                        }
                        else if (type == typeof(string))
                        {
                            AddField<string>(key);
                        }
                        else if (type == typeof(DateTime))
                        {
                            AddField<DateTime>(key);
                        }
                        else if (type == typeof(bool))
                        {
                            AddField<bool>(key);
                        }
                        else if (type == typeof(byte))
                        {
                            AddField<byte>(key);
                        }
                        else if (type == typeof(long))
                        {
                            AddField<long>(key);
                        }
                        else if (type == typeof(DBNull))
                        {
                            AddField<object>(key);
                        }
                        else if (type == typeof(short))
                        {
                            AddField<short>(key);
                        }
                        else if (type == typeof(float))
                        {
                            AddField<float>(key);
                        }
                        else if (type == typeof(double))
                        {
                            AddField<double>(key);
                        }
                        else if (type == typeof(decimal))
                        {
                            AddField<decimal>(key);
                        }
                        else if (type == typeof(Guid))
                        {
                            AddField<Guid>(key);
                        }
                        else if (type == typeof(byte[]))
                        {
                            AddField<byte[]>(key);
                        }
                    }
                    else
                    {
                        AddField<object>(key);
                    }
                }
            }
        }
        public void Set<T>(string key, T value)
        {
            lock (this)
            {
                if (fields.Keys.Contains(key))
                {
                    fields[key] = value;
                }
                else
                {
                    AddValue<T>(key, value);
                }
            }
        }
        public T Get<T>(string key)
        {
            return (T)fields[key];
        }
        public object this[string key]
        {
            get
            {
                return fields[key];
            }
            set
            {
                Set(key, value);
            }
        }

        public string GetClassName()
        {
            return typeof(Row).FullName;
        }
        public string GetComponentName()
        {
            return _componentName;
        }
        public System.ComponentModel.PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return pdcoll;
        }
        public System.ComponentModel.PropertyDescriptorCollection GetProperties()
        {
            return pdcoll;
        }
        public System.ComponentModel.PropertyDescriptor GetDefaultProperty()
        {
            if (pdcoll.Count > 0)
                return pdcoll[0];
            else
                return null;
        }

        public System.ComponentModel.AttributeCollection GetAttributes()
        {
            return null;
        }
        public System.ComponentModel.TypeConverter GetConverter()
        {
            throw new NotImplementedException();
        }
        public System.ComponentModel.EventDescriptor GetDefaultEvent()
        {
            throw new NotImplementedException();
        }
        public object GetEditor(Type editorBaseType)
        {
            throw new NotImplementedException();
        }
        public System.ComponentModel.EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            throw new NotImplementedException();
        }
        public System.ComponentModel.EventDescriptorCollection GetEvents()
        {
            throw new NotImplementedException();
        }
        public object GetPropertyOwner(System.ComponentModel.PropertyDescriptor pd)
        {
            return this;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return fields.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Row FullFromReader(string name, System.Data.Common.DbDataReader reader)
        {
            Row m = new Row(name);
            for (int i = 0; i < reader.FieldCount; i++)
            {                
                m[reader.GetName(i)] = reader.GetValue(i);
            }
            return m;
        }
    }
}
