using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk2_0
{
    public class DeskQuote
    {
        // vars
        #region Object member variables
        public string CustomerName;
        public DateTime QuoteDate = new DateTime();
        public Desk TheDesk = new Desk();
        public int RushDays;
        public int QuoteAmount;
        #endregion

        #region Local variables
        public int SurfaceArea = 0;
        public int TotalPrice = 0;
        #endregion

        private const int PRICE_BASE = 200;
        private const int SIZE_MAX = 1000;
        private const int PRICE_PER_DRAWER = 50;
        // ....


        // constructor
        public DeskQuote(string name, int width, int depth, int drawers, string material, int rushDays)
        {
            QuoteDate = DateTime.Now;
            CustomerName = name;
            TheDesk.Width = width;
            TheDesk.Depth = depth;
            TheDesk.Drawers = drawers;
            TheDesk.Material = material;
            RushDays = rushDays;
            SurfaceArea = TheDesk.Width * TheDesk.Depth;

        }

        public int CalulateQuote()
        {
            TotalPrice = PRICE_BASE + AddOns();
            return PRICE_BASE + AddOns();
        }

        private int AddOns()
        {
            int AddOnCost = 0;
            int OverCost = 0;
            int DrawerCost = 0;

            // drawer cost
            DrawerCost = TheDesk.Drawers * PRICE_PER_DRAWER;
            AddOnCost += DrawerCost;

            // surface area cost
            if (SurfaceArea > 1000)
            {
                OverCost = SurfaceArea - 1000;
                AddOnCost += OverCost;
            }

            // set material price
            switch (TheDesk.Material)
            {
                case "Oak":
                    AddOnCost += 200;
                    break;
                case "Laminate":
                    AddOnCost += 100;
                    break;
                case "Pine":
                    AddOnCost += 50;
                    break;
                case "Rosewood":
                    AddOnCost += 300;
                    break;
                default:
                    AddOnCost += 125;
                    break;
            }

            // set rush order price
            switch (RushDays)
            {
                case 3:
                    if (SurfaceArea < 1000)
                        AddOnCost += 60;
                    else if (SurfaceArea >= 1000 && SurfaceArea < 2000)
                        AddOnCost += 70;
                    else if (SurfaceArea >= 2000)
                        AddOnCost += 80;
                    break;
                case 5:
                    if (SurfaceArea < 1000)
                        AddOnCost += 40;
                    else if (SurfaceArea >= 1000 && SurfaceArea < 2000)
                        AddOnCost += 50;
                    else if (SurfaceArea >= 2000)
                        AddOnCost += 60;
                    break;
                case 7:
                    if (SurfaceArea < 1000)
                        AddOnCost += 30;
                    else if (SurfaceArea >= 1000 && SurfaceArea < 2000)
                        AddOnCost += 35;
                    else if (SurfaceArea >= 2000)
                        AddOnCost += 40;
                    break;
                default:
                    AddOnCost += 0;
                    break;

            }

            return AddOnCost;
        }

        public void WriteQuote()
        {
            try
            {
                using(StreamWriter writer = new StreamWriter("quotes.csv", true))
                {
                    //writer.WriteLine("Order\tName\tWidth\tDepth\tDrawers\tMaterial\tProduction Days\tTotal");
                    writer.WriteLine(QuoteDate + "\t" + CustomerName + "\t" + TheDesk.Width + "\t" + TheDesk.Depth + "\t" + TheDesk.Drawers + "\t" + TheDesk.Material + "\t" + RushDays + "\t" + TotalPrice);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
        }
        public void ReadQuotes()
        {
            try
            {
                // Read and show each line from the file.
                string line = "";
                using (StreamReader sr = new StreamReader("quotes.csv"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        // stuff here like Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
        }
    }
}
