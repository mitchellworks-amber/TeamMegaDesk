using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MegaDesk2_0
{
    public partial class AllQuotesView : Form
    {
        public AllQuotesView()
        {
            InitializeComponent();
        }

        private void AllQuotesView_Load(object sender, EventArgs e)
        {
            try
            {
                // read the quotes file
                var json = File.ReadAllText(@"quotes.json");
                var quotes = JsonConvert.DeserializeObject<List<DeskQuote>>(json);

                DataTable dt = new DataTable();

                dt.Columns.Add("Order");
                dt.Columns.Add("Name");
                dt.Columns.Add("Width");
                dt.Columns.Add("Depth");
                dt.Columns.Add("Drawers");
                dt.Columns.Add("Material");
                dt.Columns.Add("Production Days");
                dt.Columns.Add("Surface Area");
                dt.Columns.Add("Total Price");
                foreach (var item in quotes)
                {
                    var row = dt.NewRow();

                    row["Order"] = item.QuoteDate;
                    row["Name"] = item.CustomerName;
                    row["Width"] = item.TheDesk.Width;
                    row["Depth"] = item.TheDesk.Depth;
                    row["Drawers"] = item.TheDesk.Drawers;
                    row["Material"] = item.TheDesk.Material;
                    row["Production Days"] = item.RushDays;
                    row["Surface Area"] = item.SurfaceArea;
                    row["Total Price"] = item.QuoteAmount;

                    dt.Rows.Add(row);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
                throw;
            }
        }
    }
}
