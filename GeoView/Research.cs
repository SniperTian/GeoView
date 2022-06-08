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
    public partial class Research : Form
    {
        #region 字段

        Main father_form = new Main();//表示父窗口
        public int layer_selectindex;//表示第一个列表选中的图层
        public int field_selectindex;//表示被选中的字段


        #endregion

        #region 构造函数
        public Research()
        {
            InitializeComponent();
        }
        public Research(Main temp)
        {
            InitializeComponent();
            father_form = temp;//连通父窗口
            Load_layerselect();//加载图层选择下拉框
            layer_selectindex = -1;
            field_selectindex = -1;
        }
        #endregion

        #region 方法
        //重新加载Layer_SelectBox的内容
        public void Load_layerselect()
        {
            for(int i=0;i<father_form.moMap.Layers.Count;i++)
            {
                this.Layer_SelectBox.Items.Add(father_form.moMap.Layers.GetItem(i).Name);
                //将图层的名字添加到下拉框里面
            }
        }

        //重新加载字段显示窗口
        //双引号："\""
        //单引号："\'"
        public void Load_fieldslist()
        {
            for(int i=0;i<this.father_form.moMap.Layers.GetItem(layer_selectindex).AttributeFields.Count;i++)
            {
                this.Fields_List.Items.Add
                    (this.father_form.moMap.Layers.GetItem(layer_selectindex).AttributeFields.GetItem(i).Name);
                //将字段名字添加到下拉框
            }
        }
        #endregion

        #region 符号按钮

        private void Research_Load(object sender, EventArgs e)
        {

        }
        //=
        private void button1_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("=".ToString() + " ");
        }
        //<>
        private void button4_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("<>".ToString() + " ");
        }
        //Like
        private void button5_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("Like".ToString() + " ");
        }
        //>
        private void button2_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText(">".ToString() + " ");
        }
        //>=
        private void button6_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText(">=".ToString() + " ");
        }
        //And
        private void button8_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("And".ToString() + " ");
        }
        //<
        private void button3_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("<".ToString() + " ");
        }
        //<=
        private void button7_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("<=".ToString() + " ");
        }
        //Or
        private void button9_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("Or".ToString() + " ");
        }
        //_
        private void button12_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("_".ToString() + " ");
        }
        //%
        private void button13_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("%".ToString() + " ");
        }
        //(
        private void button11_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("(".ToString());
        }
        //)
        private void button22_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText(")".ToString() + " ");
        }
        //NOT
        private void button10_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("Not".ToString() + " ");
        }
        //Is
        private void button16_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("Is".ToString() + " ");
        }
        //In
        private void button15_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("In".ToString() + " ");
        }
        //Null
        private void button14_Click(object sender, EventArgs e)
        {
            this.SQL_text.AppendText("Null".ToString() + " ");
        }
        #endregion

        #region 操作按钮
        //选中某个图层后
        private void Layer_SelectBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            layer_selectindex = this.Layer_SelectBox.SelectedIndex;//获取选中的图层的索引
            this.UniqueValues.Items.Clear();//重新选择了图层必然唯一值框要清零
            this.Fields_List.Items.Clear();//清零字段显示图层
            Load_fieldslist();//重新加载下拉框
            field_selectindex = -1;//同时重新清零上次选中的字段
        }

        //选中某个字段后
        private void Fields_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            //暂时无用
        }

        //单击Fields_List时，单击一下选中，单击第二下将字体投到下方输入框
        private void Fields_List_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.Fields_List.IndexFromPoint(e.Location);//获取index
            if (index == System.Windows.Forms.ListBox.NoMatches)
                return;
            if(index==field_selectindex)
            {
                //如果是第二次选中了，就把名字添加到下面的文本框
                this.SQL_text.AppendText(this.father_form.moMap.Layers.GetItem(layer_selectindex).AttributeFields.GetItem(field_selectindex).Name + " ");
            }
            else
            {
                //第一次点就普普通通即可
                field_selectindex = index;//选中这个条目
            }
            this.Fields_List.SelectedIndex = index;//选中这个条目
        }
        //双击Fields_List时，直接将文本投入下面框
        private void Fields_List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.Fields_List.IndexFromPoint(e.Location);//获取index
            if (index == System.Windows.Forms.ListBox.NoMatches)
                return;
            this.SQL_text.AppendText(this.father_form.moMap.Layers.GetItem(layer_selectindex).AttributeFields.GetItem(field_selectindex).Name + " ");
            field_selectindex = index;//选中这个条目
            this.Fields_List.SelectedIndex = index;//选中这个条目
        }


        //唯一值
        private void button17_Click(object sender, EventArgs e)
        {

        }
        //验证
        private void button21_Click(object sender, EventArgs e)
        {

        }
        //确定
        private void button20_Click(object sender, EventArgs e)
        {

        }
        //应用
        private void button19_Click(object sender, EventArgs e)
        {

        }
        //关闭
        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
