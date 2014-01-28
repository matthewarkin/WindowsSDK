using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public static bool is_default_new_or_null<T>(T x)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            int compareValue = 0;

            foreach (PropertyInfo property in properties)
            {
                IComparable valx = property.GetValue(x, null) as IComparable;

                IComparable newObj = null;
                if (property.PropertyType == typeof(string))
                {
                    newObj = null;
                }
                else
                {
                    newObj = Activator.CreateInstance(property.PropertyType) as IComparable;
                }

                if (valx == null)
                {
                    if (newObj != null)
                    {
                        return false;
                    }
                }
                else
                {
                    compareValue = valx.CompareTo(newObj);
                }
                if (compareValue != 0)
                    return false;
            }
            foreach (FieldInfo field in fields)
            {
                IComparable valx = field.GetValue(x) as IComparable;
                IComparable newObj = null;
                if (field.FieldType == typeof(string))
                {
                    newObj = null;
                }
                else
                {
                    newObj = Activator.CreateInstance(field.FieldType) as IComparable;
                }

                if (valx == null)
                {
                    if (newObj != null)
                    {
                        return false;
                    }
                }
                else
                {
                    compareValue = valx.CompareTo(newObj);
                }

                if (compareValue != 0)
                    return false;
            }

            return true;
        } 
    }
}
