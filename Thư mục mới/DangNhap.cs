using QuanLyDiemHS.LoginTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemHS
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

       
        private void btnDN_Click(object sender, EventArgs e)
        
            {
                QueriesTableAdapter dn = new QueriesTableAdapter();
                if (dn.CheckLog(txtTK.Text, txtMK.Text) == 1)
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                    txtTK.ResetText();
                    txtMK.ResetText();
                }
            }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
