using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk2_0
{
    //set up the possible wood types
    public enum WoodMaterial
    {
        Laminate,
        Oak,
        Pine,
        Rosewood,
        Veneer
    }

    public class Desk
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public string Material { get; set; }
    }

    // Here is an example of Desk as a structure:
    //public struct Desk
    //{
    //    public int Width, Depth, Drawers;
    //    public string Material;

    //    public Desk(int width, int depth, int drawers, string material)
    //    {
    //        Width = width;
    //        Depth = depth;
    //        Drawers = drawers;
    //        Material = material;
    //    }
    //}
}
