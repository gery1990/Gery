using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCI.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using DCI.DataModal;
using System.Net;
namespace LayerBind
{
    public partial class FrmBind : Form
    {
        static IOrmDatabase IDatabase;
        static object temp = 0;
        public static IOrmDatabase SsDataBase
        {
            get
            {
                if (IDatabase == null)
                {
                    lock (temp)
                    {
                        if (IDatabase != null) return IDatabase;
                        IDatabase = DatabaseFactory.Create();
                    }
                }
                return IDatabase;
            }
        }
        public FrmBind()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialogMXD.Filter = "MXD文件|*.mxd";
            openFileDialogMXD.Multiselect = false;
            openFileDialogMXD.FileName = "";
            if (openFileDialogMXD.ShowDialog() == DialogResult.OK)
            {
                textBoxMxd.Text = openFileDialogMXD.FileName;
                var d = openFileDialogMXD.FileName;
                string name = d.Substring(d.LastIndexOf('\\') + 1).Substring(0,
                                d.Substring(d.LastIndexOf('\\') + 1).LastIndexOf('.'));
                mxdName.Text = name;
                txServicesName.Text = ChineseLetter.GetFirstLetter(name);
                lbSvrName.Text = "服务地址";
                lbSvrName.Visible = true;
                lbServiceUrl.Text = GetServiceUrl();
            }
        }
        private void SetDisable()
        {
            this.buttonBd.Enabled = false;
            this.buttonOpen.Enabled = false;
            txServicesName.Enabled = false;
            tbServiceName.Enabled = false;
            textBoxServerN.Enabled = false;
            btDataSet.Enabled = false;
            mxdName.Enabled = false;
        }
        private void SetEnable()
        {
            this.buttonBd.Enabled = true;
            this.buttonOpen.Enabled = true;
            txServicesName.Enabled = true;
            tbServiceName.Enabled = true;
            textBoxServerN.Enabled = true;
            btDataSet.Enabled = true;
            mxdName.Enabled = true;
        }
        int index = -1;
        int count = 0;
        ILayer prelayer = null;
        /// <summary>
        /// layerbind
        /// </summary>
        /// <param name="layer"></param>
        private void DataBd(ILayer layer)
        {
            if (layer is GroupLayer)
            {
                index++;
                ICompositeLayer pComLayer = layer as ICompositeLayer;
                for (int i = 0; i < pComLayer.Count; i++)
                {
                    DataBd(pComLayer.get_Layer(i));
                }
            }
            else if (layer is FeatureLayer || layer is RasterLayer)
            {
                try
                {
                    index++;
                    IFeatureLayer flayer = layer as IFeatureLayer;
                    IDataLayer dlayer = layer as IDataLayer;
                    IDatasetName ds = dlayer.DataSourceName as IDatasetName;
                    string servicesName = null;
                    List<LOGICAL_LAYERS> data = SsDataBase.QueryForList<LOGICAL_LAYERS>("PHYSICALLAYER=" + ds.Name);
                    if (data.Count == 1 && string.IsNullOrEmpty(GetServerNText().ToString()) == false)
                    {
                        servicesName = GetMxdText().ToString().Substring(GetMxdText().ToString().LastIndexOf('\\') + 1).Substring(0,
                                GetMxdText().ToString().Substring(GetMxdText().ToString().LastIndexOf('\\') + 1).LastIndexOf('.'));
                        if (txServicesName.Text != string.Empty)
                            servicesName = txServicesName.Text;

                        if (mxdName.Text == string.Empty)
                            data[0].LAYERID = servicesName;
                        else
                            data[0].LAYERID = mxdName.Text.Trim();

                        if (tbServiceName.Text == string.Empty)
                            data[0].LAYERURL = "http://" + GetServerNText().ToString() + "/arcgis/rest/services/" + servicesName + "/MapServer";
                        else
                            data[0].LAYERURL = "http://" + GetServerNText().ToString() + "/arcgis/rest/services/" + tbServiceName.Text.Trim() + "/" + servicesName + "/MapServer";
                        data[0].LAYERINDEX = index.ToString();
                        data[0].LAYERDTYPE = "DYNAMICMAP";
                        data[0].MINSCALE = Convert.ToDecimal(layer.MinimumScale);
                        data[0].MAXSCALE = Convert.ToDecimal(layer.MaximumScale);
                        SsDataBase.Update<LOGICAL_LAYERS>(data[0], false, "ID=" + data[0].ID.ToString());
                        count++;
                    }
                    if (layer as IAnnotationLayer != null)
                        index++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// dowork
        /// </summary>
        private void DoWork()
        {
            if (string.IsNullOrEmpty(GetMxdText().ToString()) || string.IsNullOrEmpty(GetServerNText().ToString()))
                return;
            this.BeginInvoke(new MethodInvoker(this.SetDisable));
            index = -1; prelayer = null;
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            IMapDocument pMapDocument = new MapDocument();
            pMapDocument.Open(GetMxdText().ToString(), "");
            IMap pMap = pMapDocument.get_Map(0);
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                ILayer layer = pMap.get_Layer(i);
                DataBd(layer);
            }
            //pMapDocument.Save(false, true);
            pMapDocument.Close();
            this.BeginInvoke(new MethodInvoker(this.SetEnable));
            MessageBox.Show("绑定完成！共绑定" + count.ToString() + "条记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private delegate object GetValue();

        private delegate void SetValue(string value);

        /// <summary>
        /// mxdpath
        /// </summary>
        /// <returns></returns>
        private object GetMxdText()
        {
            if (textBoxMxd.InvokeRequired)
            {
                return textBoxMxd.Invoke(new GetValue(GetMxdText));
            }
            return textBoxMxd.Text;
        }

        /// <summary>
        /// servername
        /// </summary>
        /// <returns></returns>
        private object GetServerNText()
        {
            if (textBoxServerN.InvokeRequired)
            {
                return textBoxServerN.Invoke(new GetValue(GetServerNText));
            }
            return textBoxServerN.Text;
        }

        /// <summary>
        /// thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBd_Click(object sender, EventArgs e)
        {
            if (textBoxMxd.Text == string.Empty)
            {
                MessageBox.Show("请选择绑定的文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBoxServerN.Text == string.Empty)
            {
                MessageBox.Show("请设置绑定的服务器地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确定要绑定吗？", "绑定提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                count = 0;
                System.Threading.Thread td = new System.Threading.Thread(new System.Threading.ThreadStart(DoWork));
                td.IsBackground = true;
                td.Start();
            }

        }

        private void FrmBind_Load(object sender, EventArgs e)
        {
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            textBoxServerN.Text = IpEntry.AddressList[1].ToString();
            buttonOpen.Select();
        }

        private void txServicesName_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxMxd.Text != string.Empty)
                lbServiceUrl.Text = GetServiceUrl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDataBase frm = new FrmDataBase();
            frm.ShowDialog();
        }

        private string GetServiceUrl()
        {
            string name = GetMxdText().ToString().Substring(GetMxdText().ToString().LastIndexOf('\\') + 1).Substring(0,
                               GetMxdText().ToString().Substring(GetMxdText().ToString().LastIndexOf('\\') + 1).LastIndexOf('.'));
            string svrName = txServicesName.Text == string.Empty ? name : txServicesName.Text;
            string ip = textBoxServerN.Text;
            string svrFolder = tbServiceName.Text == string.Empty ? "" : tbServiceName.Text + "/";
            string result = "http://" + ip + "/arcgis/rest/" + svrFolder + svrName + "/MapServer";
            return result;
        }

        private void textBoxServerN_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxMxd.Text != string.Empty)
                lbServiceUrl.Text = GetServiceUrl();
        }

        private void tbServiceName_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxMxd.Text != string.Empty)
                lbServiceUrl.Text = GetServiceUrl();
        }
    }
}
