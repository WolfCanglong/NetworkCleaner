using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetworkCleaner
{
    public delegate void DelegateNetworkInfo(NetworkInfo networkInfo, string Name);

    public partial class FormRename : Form
    {
        DelegateNetworkInfo CallBackSet;
        NetworkInfo networkInfo;

        public FormRename(NetworkInfo networkInfo, DelegateNetworkInfo CallBackSet)
        {
            InitializeComponent();
            this.CallBackSet = CallBackSet;
            this.networkInfo = networkInfo;
            textBoxName.Text = networkInfo.Name;
        }

        private void FormRename_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length > 0)
            {
                CallBackSet?.Invoke(networkInfo, textBoxName.Text);
                Close();
            }
            else
                MessageBox.Show(this, "需要填写新网络名", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
