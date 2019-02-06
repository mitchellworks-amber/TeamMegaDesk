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
    public partial class MainMenuView : Form
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            AddQuoteView view = new AddQuoteView();
            view.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllQuotesView view = new AllQuotesView();
            view.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchQuotesView view = new SearchQuotesView();
            view.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
