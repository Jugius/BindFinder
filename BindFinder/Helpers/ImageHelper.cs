using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace BindFinder.Helpers
{
    internal static class ImageHelper
    {
        private static readonly Dictionary<Uri, Image> StaticMapsDic = new Dictionary<Uri, Image>();
        public static Image GetImage(Uri uri)
        {
            if (StaticMapsDic.ContainsKey(uri))
            {
                return StaticMapsDic[uri];
            }            
            else
            {
                Image newImage = null;
                try
                {                    
                    using (WebClient web = new WebClient())
                    {
                        var stream = web.OpenRead(uri);
                        newImage = Image.FromStream(stream);
                    }
                }
                catch { }
                if (newImage != null)
                {
                    StaticMapsDic.Add(uri, newImage);
                    return newImage;
                }
                else
                    return null;
            }

        }
    }
}
