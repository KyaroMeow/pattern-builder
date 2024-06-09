using System;
using System.Windows.Forms;
using static WindowsFormsApp7.Class1;

namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        private HouseBuilder houseBuilder;
        public Form2(HouseBuilder builder)
        {
            InitializeComponent();
            houseBuilder = builder;
            label1.Text = label1.Text + houseBuilder.GetHouseType();
            labelSumm.Text = Convert.ToString(houseBuilder.GetTotalPrice());
        }
        private void UpdateButtonStates(string addition, int count)
        {
            switch (addition)
            {
                case "Бассейн":
                    labelPoolCount.Text = count.ToString();
                    buttonPoolMinus.Visible = count > 0;
                    buttonPoolPlus.Visible = count < 3; 
                    break;
                case "Гараж (1 авто)":
                    labelGarage1Count.Text = count.ToString();
                    buttonGarage1Minus.Visible = count > 0;
                    buttonGarage1Plus.Visible = count < 3; 
                    break;
                case "Гараж (2 авто)":
                    labelGarage2Count.Text = count.ToString();
                    buttonGarage2Minus.Visible = count > 0;
                    buttonGarage2Plus.Visible = count < 3; 
                    break;
                case "Гараж (3 авто)":
                    labelGarage3Count.Text = count.ToString();
                    buttonGarage3Minus.Visible = count > 0;
                    buttonGarage3Plus.Visible = count < 3; 
                    break;
                case "Статуя":
                    labelStatueCount.Text = count.ToString();
                    buttonStatueMinus.Visible = count > 0;
                    buttonStatuePlus.Visible = count < 10; 
                    break;
                case "Газон":
                    labelGrassCount.Text = count.ToString();
                    buttonGrassMinus.Visible = count > 0;
                    buttonGrassPlus.Visible = count < 1; 
                    break;
                case "Безопасность (охрана)":
                    labelSecurityCount.Text = count.ToString();
                    buttonSecurityMinus.Visible = count > 0;
                    buttonSecurityPlus.Visible = count < 1;
                    break;
            }
        }
        private void btnAddAddition_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string addition = null;
            int count = 0;
            switch (btn.Name)
            {
                case "buttonPoolPlus":
                    addition = "Бассейн";
                    count = Convert.ToInt32(labelPoolCount.Text);
                    labelPoolCount.Text = Convert.ToString(++count);
                    break;
                case "buttonGarage1Plus":
                    addition = "Гараж (1 авто)";
                    count = Convert.ToInt32(labelGarage1Count.Text);
                    labelGarage1Count.Text = Convert.ToString(++count);
                    break;
                case "buttonGarage2Plus":
                    addition = "Гараж (2 авто)";
                    count = Convert.ToInt32(labelGarage2Count.Text);
                    labelGarage2Count.Text = Convert.ToString(++count);
                    break;
                case "buttonGarage3Plus":
                    addition = "Гараж (3 авто)";
                    count = Convert.ToInt32(labelGarage3Count.Text);
                    labelGarage3Count.Text = Convert.ToString(++count);
                    break;
                case "buttonStatuePlus":
                    addition = "Статуя";
                    count = Convert.ToInt32(labelStatueCount.Text);
                    labelStatueCount.Text = Convert.ToString(++count);
                    break;
                case "buttonGrassPlus":
                    addition = "Газон";
                    count = Convert.ToInt32(labelGrassCount.Text);
                    labelGrassCount.Text = Convert.ToString(++count);
                    break;
                case "buttonSecurityPlus":
                    addition = "Безопасность (охрана)";
                    count = Convert.ToInt32(labelSecurityCount.Text);
                    labelSecurityCount.Text = Convert.ToString(++count);
                    break;
            }
            UpdateButtonStates(addition, count);
            houseBuilder.AddAdditionalBuilding(addition);
            labelSumm.Text = Convert.ToString(houseBuilder.GetTotalPrice());
        }

        private void btnRemoveAddition_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string addition = "";
            int count = 0;
            switch (btn.Name)
            {
                case "buttonPoolMinus":
                    addition = "Бассейн";
                    count = Convert.ToInt32(labelPoolCount.Text);
                    labelPoolCount.Text = Convert.ToString(--count);
                    break;
                case "buttonGarage1Minus":
                    addition = "Гараж (1 авто)";
                    count = Convert.ToInt32(labelGarage1Count.Text);
                    labelGarage1Count.Text = Convert.ToString(--count);
                    break;
                case "buttonGarage2Minus":
                    addition = "Гараж (2 авто)";
                    count = Convert.ToInt32(labelGarage2Count.Text);
                    labelGarage2Count.Text = Convert.ToString(--count);
                    break;
                case "buttonGarage3Minus":
                    addition = "Гараж (3 авто)";
                    count = Convert.ToInt32(labelGarage3Count.Text);
                    labelGarage3Count.Text = Convert.ToString(--count);
                    break;
                case "buttonStatueMinus":
                    addition = "Статуя";
                    count = Convert.ToInt32(labelStatueCount.Text);
                    labelStatueCount.Text = Convert.ToString(--count);
                    break;
                case "buttonGrassMinus":
                    addition = "Газон";
                    count = Convert.ToInt32(labelGrassCount.Text);
                    labelGrassCount.Text = Convert.ToString(--count);
                    break;
                case "buttonSecurityMinus":
                    addition = "Безопасность (охрана)";
                    count = Convert.ToInt32(labelSecurityCount.Text);
                    labelSecurityCount.Text = Convert.ToString(--count);
                    break;
            }
            UpdateButtonStates(addition, count);
            houseBuilder.RemoveAdditionalBuilding(addition);
            labelSumm.Text = Convert.ToString(houseBuilder.GetTotalPrice());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            House house = houseBuilder.GetResult();
            Form3 form3 = new Form3(house);
            form3.ShowDialog();
        }
    }
}
