using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSdk.Core.Runtime.Helpers
{
    public static class WebHelper
    {
        public static bool IsValidUrl(string uriName)
        {
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out var uriResult) 
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
        
        public static string AttachParameters(string url, Dictionary<string,string> collection)
        {
            if (!IsValidUrl(url))
            {
                return url;
            }
            
            var stringBuilder = new StringBuilder(url);
            string str = "?";

            if (url.Contains("?"))
            {
                str = "&";
            }

            if (collection != null)
            {
                foreach (KeyValuePair<string,string> pair in collection)
                {
                    string aName = pair.Key;
                    string aValue = pair.Value;
                
                    if (!url.Contains(aName))
                    {
                        stringBuilder.Append(str + aName + "=" + aValue);
                        str = "&";
                    }
                }
            }
            
            return stringBuilder.ToString();
        }
        
        public static Dictionary<string, string> DecodeQueryParameters(Uri uri)
        {
            if (uri == null) return null;
            if (uri.Query.Length == 0) return new Dictionary<string, string>();
            
            return uri.Query.TrimStart('?')
                .Split(new[] { '&', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parameter => parameter.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
                .GroupBy(parts => parts[0],
                    parts => parts.Length > 2 ? string.Join("=", parts, 1, parts.Length - 1) : (parts.Length > 1 ? parts[1] : ""))
                .ToDictionary(grouping => grouping.Key,
                    grouping => string.Join(",", grouping));
        }
    }
}