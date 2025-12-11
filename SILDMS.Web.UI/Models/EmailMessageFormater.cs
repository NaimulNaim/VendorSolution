using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SILDMS.Web.UI.Models
{
    public static class EmailMessageFormater
    {
        public static string Format(string emailBody,Dictionary<string,string> parms) {

            string result = emailBody;
            if (parms.Count < 1)
            {
                return result;
            }

            foreach (var item in parms)
            {
                if (result.Contains("@" + item.Key))
                {
                    result = result.Replace("@" + item.Key, item.Value);
                }
            }
            return result;
        }
    }
}