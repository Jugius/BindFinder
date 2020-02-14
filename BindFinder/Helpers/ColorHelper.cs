using BindFinder.AppModels.Binds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFinder.Helpers
{
    public static class ColorHelper
    {
        private static List<Color> _colors = new List<Color>
        {
            Color.FromArgb(255, 82, 82),//Red
            Color.FromArgb(2, 136, 209),//Blue
            Color.FromArgb(15, 157, 88),//Green
            Color.FromArgb(156, 39, 176),//Violet
            Color.FromArgb(230, 81, 0),//Orange
            Color.FromArgb(255, 214, 0)//Yellow
        };
        static Random randonGen = new Random();
        public static void SetColors(List<Bind> binds)
        {
            int colorsMaxIndex = _colors.Count-1;
            for (int i = 0; i < binds.Count; i++)
            {
                if (i <= colorsMaxIndex)
                {
                    binds[i].Color = _colors[i];
                }
                else
                {
                    binds[i].Color = GetRandomColor();
                }
            }
        }

        private static Color GetRandomColor()
        {            
            Color randomColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
            return randomColor;
        }
    }
}
