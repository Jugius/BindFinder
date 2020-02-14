using BindFinder.AppModels.Binds;
using BindFinder.DataManager;
using Geocoding;
using System;
using System.Collections.Generic;

namespace BindFinder
{
    static class BindBuilder
    {
        internal static Bind BuildBind(this Geocoding.IGeocoder geocoder, string address)
        {
            if (Geocoding.Location.TryParse(address, out Geocoding.Location location))
                return BuildBind(geocoder, location);
            else
            {
                try
                {
                    IEnumerable<Address> addresses = geocoder.Geocode(address);
                    return Bind.Create(address, addresses);
                }
                catch (Exception ex)
                {
                    return Bind.Create(address, ex);
                }
            }
        }
        internal static Bind BuildBind(this Geocoding.IGeocoder geocoder, Location location)
        {
            try
            {
                IEnumerable<Address> addresses = geocoder.ReverseGeocode(location);
                return Bind.Create(location, addresses);
            }
            catch (Exception ex)
            {
                return Bind.Create(location.ToString(), ex);
            }
        }
    }
}
