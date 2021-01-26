using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BindFinder.DataManager.GrigDownload
{
    public static class WebUtils
    {
        public static Encoding GetEncodingFrom(
        NameValueCollection responseHeaders,
        Encoding defaultEncoding = null)
        {
            if (responseHeaders == null)
                throw new ArgumentNullException("responseHeaders");

            //Note that key lookup is case-insensitive
            var contentType = responseHeaders["Content-Type"];
            if (contentType == null)
                return defaultEncoding;

            var contentTypeParts = contentType.Split(';');
            if (contentTypeParts.Length <= 1)
                return defaultEncoding;

            var charsetPart =
                contentTypeParts.Skip(1).FirstOrDefault(
                    p => p.TrimStart().StartsWith("charset", StringComparison.InvariantCultureIgnoreCase));
            if (charsetPart == null)
                return defaultEncoding;

            var charsetPartParts = charsetPart.Split('=');
            if (charsetPartParts.Length != 2)
                return defaultEncoding;

            var charsetName = charsetPartParts[1].Trim();
            if (charsetName?.Length == 0)
                return defaultEncoding;

            try
            {
                return Encoding.GetEncoding(charsetName);
            }
            catch// (ArgumentException ex)
            {
                return defaultEncoding;
                //throw new Exception("The server returned data in an unknown encoding: " + charsetName, ex);
            }
        }
        public static async Task<string> GetResponseContentAsStringAsync(string url, string method)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (!string.IsNullOrEmpty(method))
            {
                request.Method = method;
                request.ContentLength = 0;
            }

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync().ConfigureAwait(false);
            var encoding = WebUtils.GetEncodingFrom(response.Headers, Encoding.UTF8);
            byte[] downloadedData;
            using (Stream stream = response.GetResponseStream())
            using (MemoryStream memStream = new MemoryStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await memStream.WriteAsync(buffer, 0, bytesRead);
                }
                downloadedData = memStream.ToArray();
            }
            response.Close();
            return encoding.GetString(downloadedData);
        }
    }
}
