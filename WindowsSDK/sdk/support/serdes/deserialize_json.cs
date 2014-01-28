using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private T deserialize_json<T>(string json_string)
        {
            try
            {
                log("deserialize_json input: " + json_string);

                if (string_null_or_empty(json_string))
                {
                    log("deserialize_json null input supplied", true);
                    throw new Exception();
                }

                T ret = JsonConvert.DeserializeObject<T>(json_string);

                if (
                    EqualityComparer<T>.Default.Equals(ret, default(T))
                    || ret == null 
                    || ret.Equals(default(T))
                    || object.Equals(ret, default(T))
                    )
                {
                    log("deserialize_json unable to deserialize based on requested type");
                    throw new Exception();
                }

                if (is_default_new_or_null<T>(ret))
                {
                    log("deserialize_json unable to deserialize based on requested type");
                    throw new Exception();
                }

                return ret;
            }
            catch (Exception e)
            {
                log("deserialize_json unable to deserialize JSON string", true);
                throw e;
            }
        }
    }
}
