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
            if (x == null) return true;

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            int compare_val = 0;

            foreach (PropertyInfo property in properties)
            {
                IComparable valx = property.GetValue(x, null) as IComparable;

                IComparable new_obj = null;
                if (property.PropertyType == typeof(string))
                {
                    new_obj = null;
                }
                else
                {
                    new_obj = Activator.CreateInstance(property.PropertyType) as IComparable;
                }

                if (valx == null)
                {
                    if (new_obj != null)
                    {
                        return false;
                    }
                }
                else
                {
                    compare_val = valx.CompareTo(new_obj);
                }

                if (compare_val != 0)
                {
                    return false;
                }
            }
            foreach (FieldInfo field in fields)
            {
                IComparable valx = field.GetValue(x) as IComparable;
                IComparable new_obj = null;
                if (field.FieldType == typeof(string))
                {
                    new_obj = null;
                }
                else
                {
                    new_obj = Activator.CreateInstance(field.FieldType) as IComparable;
                }

                if (valx == null)
                {
                    if (new_obj != null)
                    {
                        return false;
                    }
                }
                else
                {
                    compare_val = valx.CompareTo(new_obj);
                }

                if (compare_val != 0) return false;
            }

            return true;
        } 
    }
}
