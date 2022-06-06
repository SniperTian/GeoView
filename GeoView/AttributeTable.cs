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
    public partial class AttributeTable : Form
    {
        #region 字段
        public MyMapObjects.moMapLayer layer_show;//展示图层
        public int select_index;//表示最近选择图层序号
        private DataTable dataTable;//数据表
        private bool EnablechangeArribute;//表示是否可以编辑属性，默认状态下是flase不可编辑
        private bool EnableaddField;//表示是否可以编辑字段
        private bool Select_delete_able;//表示是否可以删除字段
        private int field_delete_index;//表示即将删除的字段序号
        public string newfieldname;
        public string newfieldtypr;//分别表示新字段名字和类型
        Main father_form=new Main();//表示父窗口
        #endregion

        #region 构造函数
        public AttributeTable(Main temp,int index)
        {
            InitializeComponent();
            select_index = index;
            layer_show = temp.moMap.Layers.GetItem(index);
            this.father_form = temp;
            EnablechangeArribute = false;//默认开始不可编辑
            EnableaddField = false;//默认开始不可编辑
            this.dataGridView1.ReadOnly = true;//一开始谁都不能动
            Select_delete_able = false;//一开始不可删除字段
            field_delete_index = -1;
            Load_frame();
            this.dataGridView1.DataSource = dataTable;
            refresh();
        }
        public AttributeTable()
        {      
            InitializeComponent();
            EnablechangeArribute = false;//默认开始不可编辑
            this.dataGridView1.ReadOnly = true;//一开始谁都不能动
        }

        #endregion

        #region 方法
        /// <summary>
        /// 加载图表的方法，每次刷新图层都需要重新调用一下这个方法
        /// </summary>
        public void Load_frame()
        {
            dataTable = new DataTable();
            for (Int32 i = 0; i < layer_show.AttributeFields.Count; i++)
            {
                if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dDouble)
                {
                    dataTable.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(double));
                }
                else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt16)
                {
                    dataTable.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Int16));
                }
                else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt32)
                {
                    dataTable.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Int32));
                }
                else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt64)
                {
                    dataTable.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Int64));
                }
                else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dSingle)
                {
                    dataTable.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Single));
                }
                else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dText)
                {
                    dataTable.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(string));
                }
            }
            //读取字段数据,按行读取
            for (Int32 i = 0; i < layer_show.Features.Count; i++)
            {
                dataTable.Rows.Add(layer_show.Features.GetItem(i).Attributes.ToArray());
                //dataTable.Columns.Add(layer_show.Features.GetItem(i).Attributes.ToArray());
            }
        }

        public void refresh()
        {
            //dataGridView1.DataSource = dataTable;
            for (Int32 i = 0; i < layer_show.AttributeFields.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        /// <summary>
        /// 添加字段的方法
        /// </summary>
        public void Add_field()
        {
            if (EnableaddField == false)
                return;
            MyMapObjects.moField moFieldtemp = new MyMapObjects.moField(newfieldname);
            this.father_form.moMap.Layers.GetItem(select_index).AttributeFields.Append(moFieldtemp);
            ///////
            //****注意，这里没有完成对类型的设置，仅仅完成了一个添加字段
            ///////
            refresh();//重新加载一下
            EnableaddField = false;
        }



        #endregion

        #region 窗体和按钮处理
        //按了编辑键
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (EnablechangeArribute == true)
                return;
            EnablechangeArribute = true;//表示可以进行编辑
            this.dataGridView1.ReadOnly = false;
            MessageBox.Show("您已经可以开始编辑属性数据，单击选择需要修改的属性数据后，双击即可开始编辑");
        }
        //按了停止编辑键
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (EnablechangeArribute == false)
                return;
            EnablechangeArribute = false;
            this.dataGridView1.ReadOnly = false;
            MessageBox.Show("编辑已停止，但是如果不进行保存则无法保存至文件");
        }





        #endregion
        //单击单元格的内容时
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //用户修改完当前单元格
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            int col = e.ColumnIndex;//获取被修改单元格的纵坐标
            int row = e.RowIndex;//获取被修改单元格的横坐标
            //将原来的值设置为一个新值，但是存在一个问题，当再次打开的时候，就不会被保存
            this.father_form.moMap.Layers.GetItem(select_index).Features.GetItem(row).Attributes.SetItem(col, e.Value);
            layer_show = this.father_form.moMap.Layers.GetItem(select_index);
            refresh();
        }

        //单击删除所选字段
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(EnablechangeArribute==true)
            {
                MessageBox.Show("请退出属性编辑模式后再进行尝试");
                return;
            }
            if(Select_delete_able==false)
            {
                MessageBox.Show("请选择需要删除的字段");
                return;
            }
            this.father_form.moMap.Layers.GetItem(select_index).AttributeFields.RemoveAt(field_delete_index);//删除这个字段，同时要删除剩余的属性
            for(int i=0;i< this.father_form.moMap.Layers.GetItem(select_index).Features.Count;i++)
            {
                this.father_form.moMap.Layers.GetItem(select_index).Features.RemoveAt(field_delete_index);
            }
            layer_show = this.father_form.moMap.Layers.GetItem(select_index);
            Select_delete_able = false;//重新设置为无法删除
            MessageBox.Show("字段已成功删除");
            refresh();
        }

        //单击表头，即表示要即将删除某个字段
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(EnablechangeArribute==true)
            {
                return;
            }
            field_delete_index = e.ColumnIndex;
            Select_delete_able = true;//表示现在是可删状态
        }
        //单击保存按钮
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //这个地方后续再沟通一下
        }
        //单击添加字段
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Add_field add_Field = new Add_field(this);
            add_Field.Show();
        }
    }
}
