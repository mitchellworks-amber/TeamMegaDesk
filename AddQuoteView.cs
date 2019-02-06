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
    public partial class AddQuoteView : Form
    {
        private string name;
        private int width;
        private int depth;
        private int drawers;
        private string material;
        private int rushDays;
        private int quotePrice;

        public AddQuoteView()
        {
            InitializeComponent();
        }

        private void AddQuoteView_Load(object sender, EventArgs e)
        {
            // get WoodMaterials, cast to a string list
            List<string> materials = new List<string>();
            materials = Enum.GetNames(typeof(WoodMaterial)).ToList();
            // add a default item
            materials.Insert(0, " ");
            // now load up the materials combo box
            comboBox4.DataSource = materials;

            //for (int i = 0; i < materials.Count; i++)
            //{
            //    comboBox4.Items.Add(materials[i]);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Select(0, textBox1.Text.Length);
                errorProvider1.SetError(textBox1, "Customer name is required.");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox1.GetItemText(comboBox1.SelectedItem).Equals("-"))
            {
                errorProvider1.SetError(comboBox1, "Width is required.");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null || comboBox2.GetItemText(comboBox2.SelectedItem).Equals("-"))
            {
                errorProvider1.SetError(comboBox2, "Depth is required.");
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null || comboBox3.GetItemText(comboBox3.SelectedItem).Equals("-"))
            {
                errorProvider1.SetError(comboBox3, "Drawer Number is required.");
            }
            else
            {
                errorProvider1.SetError(comboBox3, "");
            }
        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null || comboBox4.GetItemText(comboBox4.SelectedItem).Equals("-"))
            {
                errorProvider1.SetError(comboBox4, "Material is required.");
            }
            else
            {
                errorProvider1.SetError(comboBox4, "");
            }
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == null || comboBox5.GetItemText(comboBox5.SelectedItem).Equals("-"))
            {
                errorProvider1.SetError(comboBox5, "Delivery days is required.");
            }
            else
            {
                errorProvider1.SetError(comboBox5, "");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // check all the error providers to make sure
                bool success = true;
                foreach (Control c in this.Controls)
                {
                    if (errorProvider1.GetError(c).Length > 0)
                    {
                        success = false;
                    }
                    if (c is ComboBox && string.IsNullOrEmpty(c.Text))
                    {
                        success = false;
                    }
                }

                // okay, run the quote and display the quote view!
                if (success)
                {
                    name = textBox1.Text;
                    width = int.Parse(comboBox1.SelectedItem.ToString());
                    depth = int.Parse(comboBox2.SelectedItem.ToString());
                    drawers = int.Parse(comboBox3.SelectedItem.ToString());
                    material = comboBox4.SelectedItem.ToString();
                    rushDays = int.Parse(comboBox5.SelectedItem.ToString());
                    DeskQuote quote = new DeskQuote(name, width, depth, drawers, material, rushDays);
                    // get the total
                    quotePrice = quote.CalulateQuote();
                    // write the full quote to file
                    quote.WriteQuote();

                    // head over to the view!
                    DisplayQuoteView view = new DisplayQuoteView(quotePrice, quote);
                    view.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please fix all errors and submit again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                textBox1.Text = "Error";
            }
        }

    }
}
