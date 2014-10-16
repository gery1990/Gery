using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DCI.Data;
using DCI.DataModal;
using System.Net;
using System.Xml;
using System.Data.OracleClient;
namespace LayerBind
{
    public partial class FrmDataBase : Form
    {
        public FrmDataBase()
        {
            InitializeComponent();
        }

        private void FrmDataBase_Load(object sender, EventArgs e)
        {
            button1.Select();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(@"LayerBind.exe.config");
                XmlNode xn = doc.DocumentElement.SelectSingleNode("connectionStrings");
                string ormUrl = ((xn).ChildNodes[0]).Attributes["connectionString"].Value;
                string[] ormArr = ormUrl.Split(';');
                dbName.Text = ormArr[0].Split('=')[1];
                dbUser.Text = ormArr[2].Split('=')[1];
                dbPwd.Text = ormArr[3].Split('=')[1];
            }
            catch (Exception ex) { }
            finally {
                doc = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dbName.Text == string.Empty) { MessageBox.Show("请输入服务器", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (dbUser.Text == string.Empty) { MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(@"LayerBind.exe.config");
                XmlNode xn = doc.DocumentElement.SelectSingleNode("connectionStrings");
                string orm = string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};Unicode=True",
                    dbName.Text, dbUser.Text, dbPwd.Text);
                ((xn).ChildNodes[0]).Attributes["connectionString"].Value = orm;
                doc.Save(@"LayerBind.exe.config");
                this.Close();
            }
            catch (Exception ex) { }
            finally{
                doc = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dbName.Text == string.Empty) { MessageBox.Show("请输入服务器", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (dbUser.Text == string.Empty) { MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            button2.Enabled = false;
            button1.Enabled = false;
            OracleConnection conn = null;
            try
            {
                string constring =string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};Unicode=True",
                    dbName.Text, dbUser.Text, dbPwd.Text);
                conn = new OracleConnection(constring);
                conn.Open();
                MessageBox.Show("连接成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                button2.Enabled = true;
                button1.Enabled = true;
                if (conn != null) conn.Close();
            }
        }
    }
}
