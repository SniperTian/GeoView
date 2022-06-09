using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GeoView
{
    public partial class AttributeTable : Form
    {
        #region 字段
        public MyMapObjects.moMapLayer layer_show;//展示图层
        public int select_index;//表示最近选择图层序号
        private int field_delete_index;//表示即将删除的字段序号
        public string newfieldname;
        public MyMapObjects.moValueTypeConstant newfieldtype;//分别表示新字段名字和类型

        private bool EnablechangeArribute;//表示是否可以编辑属性，默认状态下是flase不可编辑
        public bool EnableaddField;//表示是否可以编辑字段，在这种情况下什么都不能干，只能看
        private bool Select_delete_able;//表示是否可以删除字段
        private bool Arributesave;//表示属性表发生了变化需要进行保存
        private bool Fieldaddsave;//表示字段增加发生变化需要保存
        private bool Fielddelsave;//表示字段删除发生变化，需要保存
        private bool Show_select;//是否仅显示选中字段
        public bool Addfieldsucess;//表示有没有成功的添加字段,好像没用，先留着吧

        private DataTable dataTable;//数据表
        private DataTable dataTable_select;//选中数据的数据表
        Main father_form = new Main();//表示父窗口

        private delegate void myInvoke();//定义委托
        #endregion

        #region 构造函数
        private void AttributeTable_Load(object sender, EventArgs e)
        {
        }
        public AttributeTable(Main temp, int index)
        {
            InitializeComponent();
            select_index = index;
            layer_show = temp.moMap.Layers.GetItem(index);
            this.father_form = temp;
            EnablechangeArribute = false;//默认开始不可编辑
            EnableaddField = false;//默认开始不可编辑
            dataGridView1.ReadOnly = true;//一开始谁都不能动
            Select_delete_able = false;//一开始不可删除字段
            Arributesave = false;
            Fieldaddsave = false;
            Fielddelsave = false;//表示一开始谁都没动
            EnableaddField = false;//表示一开始是普通显示
            field_delete_index = -1;
            Load_frame();
            this.Nameshow.Text = layer_show.Name;
            //myThread = new Thread(Load_frame);//实例化线程
            //ma.Set();// 信号打开，不阻塞当前线程
            //myThread.Start();
        }
        public AttributeTable()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法
        /// <summary>
        /// 窗口关闭时调用，终止线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributeTable_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        /// <summary>
        /// 每次调用都开一个全新线程
        /// </summary>
        public void refresh()
        {
            Thread thread = new Thread(Invokework);
            thread.Start();
        }

        /// <summary>
        /// 合理使用invoke的函数
        /// </summary>
        public void Invokework()
        {
            myInvoke mission = new myInvoke(Load_frame);
            this.BeginInvoke(mission);
        }

        /// <summary>
        /// 加载图表的方法，每次刷新图层都需要重新调用一下这个方法
        /// </summary>
        public void Load_frame()
        {
            if (Show_select)
            {
                dataTable_select = new DataTable();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataTable_select;
                for (Int32 i = 0; i < layer_show.AttributeFields.Count; i++)
                {
                    if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dDouble)
                    {
                        dataTable_select.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(double));
                    }
                    else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt16)
                    {
                        dataTable_select.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Int16));
                    }
                    else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt32)
                    {
                        dataTable_select.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Int32));
                    }
                    else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt64)
                    {
                        dataTable_select.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Int64));
                    }
                    else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dSingle)
                    {
                        dataTable_select.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(Single));
                    }
                    else if (layer_show.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dText)
                    {
                        dataTable_select.Columns.Add(layer_show.AttributeFields.GetItem(i).Name, typeof(string));
                    }
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                for (Int32 i = layer_show.SelectedFeatures.Count-1; i >=0; i--)
                {
                    dataTable_select.Rows.Add(layer_show.SelectedFeatures.GetItem(i).Attributes.ToArray());
                }
                dataGridView1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;//所有的都设置成蓝的
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.LightGoldenrodYellow;//设置前景色
                //表示如果是仅仅展示选中字段
            }
            else
            {
                dataTable = new DataTable();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataTable;
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
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                //读取字段数据,按行读取
                for (Int32 i = 0; i < layer_show.Features.Count; i++)
                {
                    dataTable.Rows.Add(layer_show.Features.GetItem(i).Attributes.ToArray());
                }
                dataGridView1.DefaultCellStyle.BackColor = Color.White;//所有的都设置成蓝的
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.LightGoldenrodYellow;//设置前景色
                Refresh_dataform_select();//在这里加一个
            }
        }


        /// <summary>
        /// 添加字段的方法
        /// </summary>
        public void Add_field()
        {
            if (EnableaddField == false)
                return;
            MyMapObjects.moField moFieldtemp = new MyMapObjects.moField(newfieldname, newfieldtype);
            //this.father_form.moMap.Layers.GetItem(select_index).AttributeFields.Append(moFieldtemp);
            MyMapObjects.moAttributes moAttributestemp= new MyMapObjects.moAttributes();
            List<object> temp_array=new List<object>();
            for (int i = 0; i < this.father_form.moMap.Layers.GetItem(select_index).Features.Count; i++)
                temp_array.Add(0);
            moAttributestemp.FromArray(temp_array.ToArray());
            this.father_form.mDbfFiles[select_index].CreateField(moFieldtemp, moAttributestemp);//保存进去，全是一堆零
            layer_show = this.father_form.moMap.Layers.GetItem(select_index);
            Fieldaddsave = true;
            refresh();//重新加载一下
            EnableaddField = false;
        }
        /// <summary>
        /// 更新标签
        /// </summary>
        public void Refresh_scaletext_select()
        {
            this.Scaleshow.Text = (dataGridView1.SelectedRows.Count.ToString() + " / " + dataGridView1.Rows.Count.ToString() + "已选择");
            //更新lable标签显示
        }


        /// <summary>
        /// 更新本窗体内的显示，由图表更改属性表
        /// </summary>
        public void Refresh_dataform_select()
        {
            int index = -1;
            for (int i=0;i<layer_show.SelectedFeatures.Count;i++)
            {
                index = layer_show.Features.Find(layer_show.SelectedFeatures.GetItem(i));
                dataGridView1.Rows[index].Selected = true;//将该序号设置为亮
            }
            Refresh_scaletext_select();//更新一波标签
        }

        /// <summary>
        /// 更新main窗体内的显示,由选中行更改图标
        /// </summary>
        public void Refresh_mainform_select()
        {
            layer_show.SelectedFeatures.Clear();//清空
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                layer_show.SelectedFeatures.Add(layer_show.Features.GetItem(dataGridView1.SelectedRows[i].HeaderCell.RowIndex));
            }
            this.father_form.moMap.RedrawTrackingShapes();
            Refresh_scaletext_select();//更新一波标签
        }



        #endregion

        #region 窗体和按钮处理

        //按了编辑键
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Show_select)
            {
                MessageBox.Show("部分字段显示模式下不可编辑");
                return;
            }
            if (EnablechangeArribute == true)
                return;
            EnablechangeArribute = true;//表示可以进行编辑
            dataGridView1.ReadOnly = false;
            MessageBox.Show("您已经可以开始编辑属性数据，单击选择需要修改的属性数据后，双击即可开始编辑");
        }

        //按了停止编辑键
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Show_select)
            {
                MessageBox.Show("部分字段显示模式下不可编辑");
                return;
            }
            if (EnablechangeArribute == false)
                return;
            EnablechangeArribute = false;
            dataGridView1.ReadOnly = true;//设为仅读
            MessageBox.Show("编辑已停止，但是如果不进行保存则无法保存至文件");
        }

        //单击单元格的内容时
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //单击删除所选字段
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Show_select)
            {
                MessageBox.Show("部分字段显示模式下不可删除字段");
                return;
            }
            if (EnablechangeArribute == true)
            {
                MessageBox.Show("请退出属性编辑模式后再进行尝试");
                return;
            }
            if (Select_delete_able == false)
            {
                MessageBox.Show("请选择需要删除的字段");
                return;
            }
            this.father_form.mDbfFiles[select_index].DeleteField(field_delete_index);//从文件中删除,其实也已经从属性表中删除了
            layer_show = this.father_form.moMap.Layers.GetItem(select_index);
            Select_delete_able = false;//重新设置为无法删除
            field_delete_index = -1;//重新回到最初没有选择的情况
            MessageBox.Show("字段已成功删除");
            refresh();//重新加载一下
        }

        //单击保存按钮
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (Arributesave == true)
            {
                List<MyMapObjects.moAttributes> newattributeslist=new List<MyMapObjects.moAttributes>();
                for (int i = 0; i < this.father_form.moMap.Layers.GetItem(select_index).Features.Count; i++)
                    newattributeslist.Add(layer_show.Features.GetItem(i).Attributes);
                this.father_form.mDbfFiles[select_index].UpdateAttributesList(newattributeslist);
                //将属性更改存到内存的文件管理类中
            }
            this.father_form.mDbfFiles[select_index].SaveToFile();
            MessageBox.Show("保存成功");
            //这个地方需要merge一下代码
        }
        //单击添加字段
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(Show_select)
            {
                MessageBox.Show("部分字段显示模式下不可添加字段");
                return;
            }
            if (EnablechangeArribute == true)
            {
                MessageBox.Show("请退出属性编辑模式后再进行尝试");
                return;
            }
            Add_field add_Field = new Add_field(this);
            add_Field.Show();
        }

        //单击表头，即表示要即将删除某个字段
        private void dataGridView1_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (EnablechangeArribute == true)
            {
                if (field_delete_index >= 0)
                    dataGridView1.Columns[field_delete_index].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                field_delete_index = e.ColumnIndex;
                return;
            }
            if (field_delete_index != e.ColumnIndex && field_delete_index >= 0)//第二次以及第多次选择
            {
                dataGridView1.Columns[field_delete_index].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                field_delete_index = e.ColumnIndex;
                Select_delete_able = true;//表示现在是可删状态
            }
            else if (field_delete_index < 0)//初次选择
            {
                dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                field_delete_index = e.ColumnIndex;
                Select_delete_able = true;//表示现在是可删状态
            }
        }

        //用户修改完当前单元格
        private void dataGridView1_CellParsing_1(object sender, DataGridViewCellParsingEventArgs e)
        {
            int col = e.ColumnIndex;//获取被修改单元格的纵坐标
            int row = e.RowIndex;//获取被修改单元格的横坐标
            //将原来的值设置为一个新值，但是存在一个问题，当再次打开的时候，就不会被保存
            this.father_form.moMap.Layers.GetItem(select_index).Features.GetItem(row).Attributes.SetItem(col, e.Value);
            layer_show = this.father_form.moMap.Layers.GetItem(select_index);
            Arributesave = true;
            refresh();//重新加载一下
        }

        //单击属性表头的时候会发生
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Show_select)
            {
                return;//就毫无反应
            }
            dataGridView1.Rows[e.RowIndex].Selected = true;//表示选中了这一行
            this.Refresh_mainform_select();
        }
        //用于操作鼠标点选或者拖动要素
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Show_select)
            {
                return;//就毫无反应
            }
            if (e.ColumnIndex<0)
            {
                this.Refresh_mainform_select();//更新窗体显示事件
            }
        }
        //全部选择
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Show_select)
            {
                MessageBox.Show("部分字段显示模式下不可操作");
                return;
            }
            for (int i=0;i<dataGridView1.Rows.Count;i++)
            {
                dataGridView1.Rows[i].Selected = true;
            }
            this.Refresh_mainform_select();
        }
        //清除选择
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (Show_select)
            {
                MessageBox.Show("部分字段显示模式下不可操作");
                return;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                }
                this.Refresh_mainform_select();
            }
        }

        #endregion
        //显示所有记录
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (Show_select == false)
                return;
            Show_select = false;
            refresh();
        }
        //显示选中记录
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (Show_select == true)
                return;
            Show_select = true;
            refresh();
        }
    }
}
