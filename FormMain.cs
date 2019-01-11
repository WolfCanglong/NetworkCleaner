using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace NetworkCleaner
{

    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string Pid = Process.GetCurrentProcess().Id.ToString();
            Version Ver = new Version(Application.ProductVersion);
            Text += " v" + Ver.Major + "." + Ver.Minor + "." + Ver.Build + "." + Ver.MinorRevision + " PID:" + Pid;
            FlushList();
        }

        private void FlushList()
        {
            treeViewReg.Nodes.Clear();
            var NodeRoot = treeViewReg.Nodes.Add("网络列表");
            RegistryKey Reg = Registry.LocalMachine;
            var RegUnmanaged = Reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged\", true);
            var Keys = RegUnmanaged.GetSubKeyNames();
            for (int i = 0; i < Keys.Length; i++)
            {
                NetworkInfo Info = new NetworkInfo();
                Info.KeyName = Keys[i];
                var RegNetwork = RegUnmanaged.OpenSubKey(Keys[i]);
                Info.Name = RegNetwork.GetValue("Description").ToString();
                Info.Guid = RegNetwork.GetValue("ProfileGuid").ToString();
                var node = NodeRoot.Nodes.Add(Info.Name);
                node.Tag = Info;
            }
            NodeRoot.ExpandAll();
            Reg.Close();
        }

        private void treeViewReg_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                    e.Node.Nodes[i].Checked = e.Node.Checked;
        }

        private void treeViewReg_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            toolStripButtonRename.Enabled = e.Node.Level > 0;
        }

        private void toolStripButtonFlush_Click(object sender, EventArgs e)
        {
            FlushList();
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            int Count = 0;
            for (int i = 0; i < treeViewReg.Nodes[0].Nodes.Count; i++)
            {
                if (treeViewReg.Nodes[0].Nodes[i].Checked)
                    Count++;
            }
            if (Count == 0)
            {
                MessageBox.Show(this, "至少选中一个网络进行删除", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Msg = "确定要删除选中网络？";
            if (treeViewReg.Nodes[0].Nodes.Count == Count)
                Msg = "确定要全删光一个不留？？？";
            if (MessageBox.Show(this, Msg, Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                for (int i = 0; i < treeViewReg.Nodes[0].Nodes.Count; i++)
                    if (treeViewReg.Nodes[0].Nodes[i].Checked)
                    {
                        NetworkInfo networkInfo = (NetworkInfo)treeViewReg.Nodes[0].Nodes[i].Tag;
                        RegistryKey Reg = Registry.LocalMachine;
                        var RegNet = Reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged\" , true);
                        RegNet.DeleteSubKey(networkInfo.KeyName);
                        RegNet.Close();
                        RegNet = Reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles\", true);
                        RegNet.DeleteSubKey(networkInfo.Guid);
                        RegNet.Close();
                        Reg.Close();
                    }
                FlushList();
            }
        }

        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            if (treeViewReg.SelectedNode.Level > 0)
            {
                NetworkInfo networkInfo = (NetworkInfo)treeViewReg.SelectedNode.Tag;
                var Frm = new FormRename(networkInfo, new DelegateNetworkInfo(SetNetworkName));
                Frm.ShowDialog();
                FlushList();
            }
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            Version Ver = new Version(Application.ProductVersion);
            string Msg = Text;
            DateTime dtbase = new DateTime(2000, 1, 1, 0, 0, 0);//微软编译基准时间
            TimeSpan tsbase = new TimeSpan(dtbase.Ticks);
            TimeSpan tsv = new TimeSpan(tsbase.Days + Ver.Build, 0, 0, Ver.Revision * 2);//编译时间，注意修订号要*2
            DateTime dtv = new DateTime(tsv.Ticks);//转换成编译时间
            Msg += "\nRelease Time : " + dtv.ToString() + "\n\nBy Hke\nWuHansen.Com";
            MessageBox.Show(this, Msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetNetworkName(NetworkInfo networkInfo, string Name)
        {
            RegistryKey Reg = Registry.LocalMachine;
            var RegNet = Reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged\"+ networkInfo.KeyName, true);
            RegNet.SetValue("Description", Name);
            RegNet.SetValue("FirstNetwork", Name);
            RegNet.Close();
            RegNet = Reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles\" + networkInfo.Guid, true);
            RegNet.SetValue("ProfileName", Name);
            RegNet.Close();
            Reg.Close();
        }

    }

    public class NetworkInfo
    {
        public string Name;
        public string Guid;
        public string KeyName;
    }
}
