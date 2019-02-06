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
    public partial class SearchQuotesView : Form
    {
        private string TheMaterial;

        public SearchQuotesView()
        {
            InitializeComponent();
        }

        private void SearchQuotesView_Load(object sender, EventArgs e)
        {
            // get WoodMaterials, cast to a string list
            List<string> materials = new List<string>();
            materials = Enum.GetNames(typeof(WoodMaterial)).ToList();
            // add a default item
            materials.Insert(0, " ");
            // now load up the materials combo box
            comboBox1.DataSource = materials;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // get the material
                TheMaterial = comboBox1.SelectedItem.ToString();

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
                    // let's search for the material while we have the order line complete, then add it to a secondary list if a match
                    if (Lines[i].Contains(TheMaterial))
                    {
                        Fields = Lines[i].Replace("\"", "").Split(new char[] { '\t' });
                        Row = dt.NewRow();
                        for (int f = 0; f < Cols; f++)
                            Row[f] = Fields[f];
                        dt.Rows.Add(Row);
                    }
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
