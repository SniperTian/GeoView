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
    public partial class ShpToGvshp : Form
    {
        private string shpPath = string.Empty;
        private string gvshpPath = string.Empty;
        public ShpToGvshp()
        {
            InitializeComponent();
        }

        private void btnShpPath_Click(object sender, EventArgs e)
        {
            ofd.Filter = @"ESRI ShapeFile(*shp)|*.shp";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                shpPath = ofd.FileName;
                textShpPath.Text = shpPath;
            }
        }

        private void btnGvshpPath_Click(object sender, EventArgs e)
        {
            sfd.Filter = @"自定义图层(*gvshp)|*.gvshp";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gvshpPath = sfd.FileName;
                textGvshpPath.Text = gvshpPath;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (shpPath == String.Empty)
            {
                MessageBox.Show("还没选择shp文件呢!");
            }
            else if (gvshpPath == String.Empty)
            {
                MessageBox.Show("还没选择gvshp文件存储路径呢!");
            }
            try
            {
                string dbfPath = shpPath.Substring(0, shpPath.IndexOf(".shp")) + ".dbf";
                DataIOTools.shpFileReader sShpFileReader = new DataIOTools.shpFileReader(shpPath);
                MyMapObjects.moGeometryTypeConstant sGeometryType = sShpFileReader.ShapeType;
                List<MyMapObjects.moGeometry> sGeometries = sShpFileReader.Geometries;
                DataIOTools.gvShpFileManager sGvShpFileManager = new DataIOTools.gvShpFileManager(sGeometryType);
                sGvShpFileManager.UpdateGeometries(sGeometries);
                DataIOTools.dbfFileManager sDbfFileManager = new DataIOTools.dbfFileManager(dbfPath);
                string sGvDbfPath = gvshpPath.Substring(0, gvshpPath.IndexOf(".gvshp")) + ".gvdbf";
                sGvShpFileManager.SaveToFile(gvshpPath);
                sDbfFileManager.SaveToFile(sGvDbfPath);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            this.Close();
        }  

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
