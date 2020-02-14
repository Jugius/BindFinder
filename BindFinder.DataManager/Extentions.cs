using Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFinder.DataManager
{
    public static class Extentions
    {
        internal static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static IEnumerable<Address> Geocode(this IGeocoder geocoder, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.ArgumentNullException("address");

            if (Geocoding.Location.TryParse(address, out Geocoding.Location location))
            {
                return ReverseGeocode(geocoder, location);
            }
            else
            {
                IEnumerable<Address> addresses = Task.Factory.StartNew(() => geocoder.GeocodeAsync(address)).Unwrap().GetAwaiter().GetResult();
                return addresses;
            }
        }
        public static IEnumerable<Address> ReverseGeocode(this IGeocoder geocoder, Location location)
        {
            if (location == null)
                throw new System.ArgumentNullException("location");

            IEnumerable<Address> addresses = Task.Factory.StartNew(() => geocoder.ReverseGeocodeAsync(location)).Unwrap().GetAwaiter().GetResult();
            return addresses;
        }
    }
}
