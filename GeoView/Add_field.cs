using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoView
{
    public partial class Add_field : Form
    {
        AttributeTable Attribute_table = new AttributeTable();

        public Add_field()
        {
            InitializeComponent();
        }

        public Add_field(AttributeTable temp)
        {
            InitializeComponent();
            this.Attribute_table = temp;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        //确认添加
        private void 确认添加_Click_1(object sender, EventArgs e)
        {
            string type_str = this.comboBox1.SelectedItem.ToString();
            switch (type_str)
            {
                case "Int16":
                    this.Attribute_table.newfieldtype = MyMapObjects.moValueTypeConstant.dInt16;
                    break;
                case "Int32":
                    this.Attribute_table.newfieldtype = MyMapObjects.moValueTypeConstant.dInt32;
                    break;
                case "Int64":
                    this.Attribute_table.newfieldtype = MyMapObjects.moValueTypeConstant.dInt64;
                    break;
                case "Single":
                    this.Attribute_table.newfieldtype = MyMapObjects.moValueTypeConstant.dSingle;
                    break;
                case "Double":
                    this.Attribute_table.newfieldtype = MyMapObjects.moValueTypeConstant.dDouble;
                    break;
                case "Text(文本)":
                    this.Attribute_table.newfieldtype = MyMapObjects.moValueTypeConstant.dText;
                    break;
            }
            this.Attribute_table.newfieldname = this.textBox1.Text;
            this.Attribute_table.EnableaddField = true;
            this.Attribute_table.Addfieldsucess = true;
            this.Attribute_table.Add_field();
            this.Close();
        }
    }
}
