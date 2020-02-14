using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFinder.AppModels.Binds
{
    public class BindAddress : Address
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Intersection { get; set; }
        public string PlaceId { get; set; }
        public override string FormattedAddress
        {
            get
            {
                if (string.IsNullOrEmpty(this.Street))
                    return base.FormattedAddress;
                return BuildFormattedAddress();
            }
            set => base.FormattedAddress = value;
        }
        private string BuildFormattedAddress()
        {
            return $"{Country}, {City}, {Street}, {StreetNumber}, {Intersection}".TrimEnd(',', ' ');
        }
        internal string ExtractStreet(string address)
        {
            if (string.IsNullOrEmpty(address)) return null;

            string newStr = address.Clone() as string;
            if (!string.IsNullOrEmpty(this.Country)) newStr = newStr.Replace(this.Country, "");
            if (!string.IsNullOrEmpty(this.Region)) newStr = newStr.Replace(this.Region, "");
            if (!string.IsNullOrEmpty(this.City)) newStr = newStr.Replace(this.City, "");
            if (!string.IsNullOrEmpty(this.District)) newStr = newStr.Replace(this.District, "");
            if (!string.IsNullOrEmpty(this.Zip)) newStr = newStr.Replace(this.Zip, "");
            return newStr.Trim(',', ' ');
        }
        public BindAddress(string formattedAddress, Location coordinates, string provider) : base(formattedAddress, coordinates, provider) { }
        public void UpdatePropertiesFrom(BindAddress other)
        {
            bool streetchanged = false;
            if (string.IsNullOrEmpty(this.Country) && !string.IsNullOrEmpty(other.Country)) this.Country = other.Country;
            if (string.IsNullOrEmpty(this.Region) && !string.IsNullOrEmpty(other.Region)) this.Region = other.Region;
            if (string.IsNullOrEmpty(this.City) && !string.IsNullOrEmpty(other.City)) this.City = other.City;
            if (string.IsNullOrEmpty(this.Zip) && !string.IsNullOrEmpty(other.Zip)) this.Zip = other.Zip;
            if (string.IsNullOrEmpty(this.Street) && !string.IsNullOrEmpty(other.Street))
            {
                this.Street = other.Street;
                streetchanged = true;
            }
            if (string.IsNullOrEmpty(this.StreetNumber) && !string.IsNullOrEmpty(other.StreetNumber) && streetchanged) this.StreetNumber = other.StreetNumber;
            if (string.IsNullOrEmpty(this.District) && !string.IsNullOrEmpty(other.District)) this.District = other.District;
            if (string.IsNullOrEmpty(this.Intersection) && !string.IsNullOrEmpty(other.Intersection)) this.Intersection = other.Intersection;
        }
        public static BindAddress Create(GoogleAddress address)
        {
            string addressShortName = string.Empty;
            string addressCountry = string.Empty;
            string addressAdministrativeAreaLevel1 = string.Empty;
            string addressAdministrativeAreaLevel2 = string.Empty;
            string addressAdministrativeAreaLevel3 = string.Empty;
            string addressColloquialArea = string.Empty;
            string addressLocality = string.Empty;
            string addressSublocality = string.Empty;
            string addressNeighborhood = string.Empty;
            string addressStreet = string.Empty;
            string addressStreetNumber = string.Empty;
            string addressPostalCode = string.Empty;
            string addressDistrict = string.Empty;
            string addressIntersection = string.Empty;

            foreach (var c in address.Components)
            {
                switch (c.Types[0])
                {
                    case GoogleAddressType.Unknown:
                        break;
                    case GoogleAddressType.StreetAddress:
                        break;
                    case GoogleAddressType.Route:
                        if (c.LongName != "Unnamed Road") addressStreet = c.LongName;
                        break;
                    case GoogleAddressType.Intersection:
                        addressIntersection = c.LongName;
                        break;
                    case GoogleAddressType.Political:
                        addressDistrict = c.ShortName;
                        break;
                    case GoogleAddressType.Country:
                        addressCountry = c.LongName;
                        break;
                    case GoogleAddressType.AdministrativeAreaLevel1:
                        addressAdministrativeAreaLevel1 = c.ShortName;
                        break;
                    case GoogleAddressType.AdministrativeAreaLevel2:
                        break;
                    case GoogleAddressType.AdministrativeAreaLevel3:
                        break;
                    case GoogleAddressType.ColloquialArea:
                        addressColloquialArea = c.LongName;
                        break;
                    case GoogleAddressType.Locality:
                        addressLocality = c.LongName;
                        break;
                    case GoogleAddressType.SubLocality:
                        addressSublocality = c.LongName;
                        break;
                    case GoogleAddressType.Neighborhood:
                        addressNeighborhood = c.LongName;
                        break;
                    case GoogleAddressType.Premise:
                        break;
                    case GoogleAddressType.Subpremise:
                        break;
                    case GoogleAddressType.PostalCode:
                        addressPostalCode = c.LongName;
                        break;
                    case GoogleAddressType.NaturalFeature:
                        break;
                    case GoogleAddressType.Airport:
                        break;
                    case GoogleAddressType.Park:
                        break;
                    case GoogleAddressType.PointOfInterest:
                        break;
                    case GoogleAddressType.PostBox:
                        break;
                    case GoogleAddressType.StreetNumber:
                        addressStreetNumber = c.ShortName;
                        break;
                    case GoogleAddressType.Floor:
                        break;
                    case GoogleAddressType.Room:
                        break;
                    case GoogleAddressType.PostalTown:
                        break;
                    case GoogleAddressType.Establishment:
                        break;
                    case GoogleAddressType.SubLocalityLevel1:
                        break;
                    case GoogleAddressType.SubLocalityLevel2:
                        break;
                    case GoogleAddressType.SubLocalityLevel3:
                        break;
                    case GoogleAddressType.SubLocalityLevel4:
                        break;
                    case GoogleAddressType.SubLocalityLevel5:
                        break;
                    case GoogleAddressType.PostalCodeSuffix:
                        break;
                    default:
                        break;
                }
            }

            return new BindAddress(address.FormattedAddress, address.Coordinates, "BindAddress")
            {
                Country = addressCountry,
                Region = addressAdministrativeAreaLevel1,
                City = addressLocality,
                Zip = addressPostalCode,
                Street = addressStreet,
                StreetNumber = addressStreetNumber,
                District = addressDistrict,
                Intersection = addressIntersection,
                PlaceId = address.PlaceId
            };
        }
        public static BindAddress Create(IEnumerable<Address> addresses, Address basic)
        {
            BindAddress primary = Create(basic as GoogleAddress);
            foreach (var address in Convert(addresses))
            {
                primary.UpdatePropertiesFrom(address);
            }
            if (string.IsNullOrEmpty(primary.Street)) primary.Street = primary.ExtractStreet(primary.FormattedAddress);
            return primary;
        }
        public static IEnumerable<BindAddress> Convert(IEnumerable<Address> addresses)
        {
            if (addresses == null)
                yield break;
            foreach (var address in addresses)
            {
                if (address is GoogleAddress)
                    yield return Create(address as GoogleAddress);
            }
        }
        public static BindAddress Create(IEnumerable<Address> addresses)
        {
            List<GoogleAddress> list = addresses.Select(a => a as GoogleAddress).ToList();
            var priority = list.FirstOrDefault(a =>
                (a.Type == GoogleAddressType.StreetAddress && (a.LocationType == GoogleLocationType.Rooftop || a.LocationType == GoogleLocationType.GeometricCenter)) ||
                (a.Type == GoogleAddressType.Route && a.LocationType == GoogleLocationType.GeometricCenter) ||
                (a.Type == GoogleAddressType.Premise && a.LocationType == GoogleLocationType.Rooftop));

            return Create(list, priority ?? list.First());
        }

        public static BindAddress Create(IEnumerable<Address> addresses, Location coordinates)
        {
            if (coordinates == null) return Create(addresses);
            List<GoogleAddress> list = addresses.Select(a => a as GoogleAddress).ToList();

            BindAddress relevant;

            var priority = list.Where(a =>
                (a.Type == GoogleAddressType.StreetAddress && (a.LocationType == GoogleLocationType.Rooftop || a.LocationType == GoogleLocationType.GeometricCenter)) ||
                (a.Type == GoogleAddressType.Route && a.LocationType == GoogleLocationType.GeometricCenter) ||
                (a.Type == GoogleAddressType.Premise && a.LocationType == GoogleLocationType.Rooftop)).ToList();

            if (priority.Count == 0)
            {
                relevant = Create(list, list.First());
            }
            else
            {
                GoogleAddress nearest = null;
                double nearestDistance = double.MaxValue;

                foreach (var address in priority)
                {
                    var distance = address.Coordinates.DistanceBetween(coordinates).Value;
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearest = address;
                    }
                }

                relevant = Create(list, nearest);
            }
            relevant.Coordinates = coordinates;// new BindAddress(nearest.FormattedAddress, coordinates, "BindAddress");

            return relevant;
        }
    }
}
