using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static WindowsFormsApp7.Class1;

namespace WindowsFormsApp7
{

    public partial class Form1 : Form
    {
        private HouseBuilder houseBuilder;
        public Form1()
        {
            InitializeComponent();
            var houseTypeList = new List<string>()
            {   "Коттедж" ,
                "Вилла" ,
                "Таунхаус",
                "Дуплекс",
                "Квадруплекс",
                "Лейнхаус"
            };
            comboBox1.DataSource = houseTypeList;
        }
        private void btnAddHouse_Click(object sender, EventArgs e)
        {
            houseBuilder = new HouseBuilder();
            string type = comboBox1.SelectedItem.ToString();
            int basePrice = GetBasePrice(type);
            houseBuilder.SetHouseType(type, basePrice);
            Form2 form2 = new Form2(houseBuilder);
            form2.ShowDialog();
        }
        private int GetBasePrice(string type)
        {
            switch (type)
            {
                case "Коттедж":
                    return 13700000;
                case "Вилла":
                    return 30000000;
                case "Таунхаус":
                    return 18000000;
                case "Дуплекс":
                    return 13900000;
                case "Квадруплекс":
                    return 22000000;
                case "Лейнхаус":
                    return 133000000;
                default:
                    return 0;
            }
        }

    }
}
