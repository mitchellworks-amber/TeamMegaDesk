using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk2_0
{
    public partial class DisplayQuoteView : Form
    {
        private int QuotePrice;
        private DeskQuote TheQuote;

        public DisplayQuoteView(int quotePrice, DeskQuote quote)
        {
            QuotePrice = quotePrice;
            TheQuote = quote;
            InitializeComponent();
        }

        private void DisplayQuoteView_Load(object sender, EventArgs e)
        {
            label1.Text = "Desk Quote for " + TheQuote.CustomerName;
            label3.Text = "Width: " + TheQuote.TheDesk.Width;
            label4.Text = "Depth: " + TheQuote.TheDesk.Depth;
            label5.Text = "Drawers: " + TheQuote.TheDesk.Drawers;
            label6.Text = "Material: " + TheQuote.TheDesk.Material;
            label7.Text = "Production Days: " + TheQuote.RushDays;
            label2.Text = "$" + QuotePrice;
        }
    }
}
