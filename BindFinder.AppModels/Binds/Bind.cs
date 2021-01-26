using BindFinder.AppModels.Boards;
using Geocoding;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BindFinder.AppModels.Binds
{
    public class Bind
    {
        public string OriginalAddress { get; set; }
        public string Description { get; set; }
        public BindAddress Address { get; set; }
        public List<Address> Addresses { get; set; }
        public Exception Error { get; set; }
        public List<IBoard> BindedBoards { get; set; } = new List<IBoard>();
        public Color Color { get; set; } = Color.Empty;
        public void SetPropertiesFrom(Bind other)
        {
            this.OriginalAddress = other.OriginalAddress;
            this.Description = other.Description;
            this.Address = other.Address;
            this.Addresses = other.Addresses;
            this.Error = null;
        }
        public static Bind Create(string originalAddress, IEnumerable<Address> addresses)
        {
            var adrList = addresses.ToList();
            if (adrList.Count == 0)
                return Create(originalAddress, new Exception("Адрес не найден"));

            Bind bind = new Bind { OriginalAddress = originalAddress, Addresses = addresses.ToList() };
            bind.Address = BindAddress.Create(addresses);
            return bind;
        }
        public static Bind Create(Location coordinates, IEnumerable<Address> addresses)
        {
            var adrList = addresses.ToList();
            if (adrList.Count == 0)
                return Create(coordinates.ToString(), new Exception("Адрес не найден"));

            Bind bind = new Bind { OriginalAddress = coordinates.ToString(), Addresses = adrList };
            bind.Address = BindAddress.Create(addresses, coordinates);
            return bind;
        }
        public static Bind Create(string originalAddress, Exception error)
        {
            return new Bind { OriginalAddress = originalAddress, Error = error };
        }
        
    }
}
