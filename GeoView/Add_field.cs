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
            this.Attribute_table = temp;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        //确认添加
        private void 确认添加_Click(object sender, EventArgs e)
        {
            this.Attribute_table.newfieldname = this.textBox1.Text;
            this.Attribute_table.newfieldtypr = this.comboBox1.SelectedIndex.ToString();
            this.Attribute_table.Add_field();
            this.Close();
        }
    }
}
