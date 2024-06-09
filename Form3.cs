using System;
using System.Windows.Forms;
using static WindowsFormsApp7.Class1;

namespace WindowsFormsApp7
{
    public partial class Form3 : Form
    {
        House house = new House();
        public Form3(House house)
        {
            InitializeComponent();
            this.house = house;
            label1.Text = Convert.ToString(house.GetReceipt());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
