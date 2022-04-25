using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ExtensionsMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session,string key,object value)
        {
            string ObjectString = JsonConvert.SerializeObject(value);
            session.SetString(key,ObjectString);

        }
        public static T GetObject<T>(this ISession session,string key) where T:class
        {
            string ObjectString = session.GetString(key);
            if(string.IsNullOrEmpty(ObjectString))
            {
                return null;
            }

           T valuetoDeserialize= JsonConvert.DeserializeObject<T>(ObjectString);
            return valuetoDeserialize;
        }
    }
}
