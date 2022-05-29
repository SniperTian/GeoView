using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMapObjectsDemo
{
    public partial class AttributeTable : Form
    {
        #region
        public MyMapObjects.moMapLayer layer_show;//展示图层
        private DataTable dataTable;//数据表
        #endregion
        public AttributeTable()
        {
            InitializeComponent();
        }
        public void Load_frame()
        {
            dataTable = new DataTable();
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
            }
            //读取字段数据,按行读取
            for (Int32 i = 0; i < layer_show.Features.Count; i++)
            {
                dataTable.Rows.Add(layer_show.Features.GetItem(i).Attributes.ToArray());

                //dataTable.Columns.Add(layer_show.Features.GetItem(i).Attributes.ToArray());
            }
        }
    }
}
