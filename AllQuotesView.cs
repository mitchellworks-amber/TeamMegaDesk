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
                string CSVFilePathName = "quotes.csv";
                string[] Lines = File.ReadAllLines(CSVFilePathName);
                string[] Fields;
                Fields = Lines[0].Replace("\"", "").Split(new char[] { '\t' });
                int Cols = Fields.GetLength(0);
                DataTable dt = new DataTable();
                //1st row must be column names
                for (int i = 0; i < Cols; i++)
                    dt.Columns.Add(Fields[i], typeof(string));
                DataRow Row;
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    Fields = Lines[i].Replace("\"", "").Split(new char[] { '\t' });
                    Row = dt.NewRow();
                    for (int f = 0; f < Cols; f++)
                        Row[f] = Fields[f];
                    dt.Rows.Add(Row);
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
