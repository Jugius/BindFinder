using BindFinder.AppModels.Binds;
using BindFinder.AppModels.Boards;
using Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFinder.Helpers
{
    static class BindsHelper
    {
        public static IEnumerable<Bind> UpdateBoards(this IEnumerable<Bind> binds, List<IBoard> boards, double dist)
        {
            foreach (var bind in binds)
            {
                if (bind.Error == null)
                {
                    foreach (var board in boards)
                    {
                        var distance = bind.Address.Coordinates.DistanceBetween(board.Location, DistanceUnits.Kilometers);
                        if (distance.Value <= dist && bind.BindedBoards.FirstOrDefault(a=>a.Equals(board))==null)
                        {
                            bind.BindedBoards.Add(board);
                        }
                    }                    
                }
                yield return bind;
            }
        }
        static void ShowBrowserBindMap(Bind b)
        {
            if (b.Error == null)
                System.Diagnostics.Process.Start(@"https://www.google.com/maps/search/" + b.Address.Coordinates.ToString());
        }        
    }
}
