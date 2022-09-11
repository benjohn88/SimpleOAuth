using System.Web;

namespace SimpleOAuth
{
    internal static class UriExtensions
    {
        public static Uri AddParamerteCollection(this Uri url, Dictionary<string, string> keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
                url = url.AddParameter(item.Key, item.Value);
            }
            return url;
        }

        public static Uri AddParameter(this Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}
