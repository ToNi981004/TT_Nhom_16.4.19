using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DAL;

namespace QL_HSGVTHPT
{
    public partial class frmMain : Form
    {
        private string _Ten;
        private string _ChucVu;

        public frmMain(string Ten,string ChucVu)
        {
            InitializeComponent();
            this._Ten = Ten;
            this._ChucVu = ChucVu;
            lbTaiKhoan.Text = _Ten;
            lbChucVu.Text = _ChucVu;
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            DateTime tm = DateTime.Now;
            lbTime.Text = tm.ToString("dd/MM/yyyy | hh:mm:ss");
        }

        private void HT_frmDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            this.Hide();
            frm.ShowDialog();
            frm.Close();
            Application.Exit();
        }

        private void frmDM_HSGV_Click(object sender, EventArgs e)
        {
            int s = 0;
            frmDanhMuc frm = new frmDanhMuc(s);
            frm.ShowDialog();
        }

        private void frmDM_HSHS_Click(object sender, EventArgs e)
        {
            int s = 1;
            frmDanhMuc frm = new frmDanhMuc(s);
            frm.ShowDialog();
        }

        private void frmDM_HSGD_Click(object sender, EventArgs e)
        {
            int s = 2;
            frmDanhMuc frm = new frmDanhMuc(s);
            frm.ShowDialog();
        }

        private void frmDM_PhongHoc_Click(object sender, EventArgs e)
        {
            int s = 3;
            frmDanhMuc frm = new frmDanhMuc(s);
            frm.ShowDialog();
        }

        private void frmDM_MonHoc_Click(object sender, EventArgs e)
        {
            int s = 4;
            frmDanhMuc frm = new frmDanhMuc(s);
            frm.ShowDialog();
        }

        private void frmDM_LopHoc_Click(object sender, EventArgs e)
        {
            int s = 5;
            frmDanhMuc frm = new frmDanhMuc(s);
            frm.ShowDialog();
        }

       

        private void frmThoiKhoaBieu_Click(object sender, EventArgs e)
        {
            frmThoiKhoaBieu frm = new frmThoiKhoaBieu();
            frm.ShowDialog();
        }

        private void HT_frmTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan(_Ten);
            frm.ShowDialog();
        }

        private void Frm_GiaoVien_Click(object sender, EventArgs e)
        {
            frmDanhMuc frm = new frmDanhMuc(0);
            frm.ShowDialog();
        }

    

        private void Frm_HocSinh_Click(object sender, EventArgs e)
        {
            frmDanhMuc frm = new frmDanhMuc(1);
            frm.ShowDialog();
        }

        private void Frm_HDSD_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://drive.google.com/open?id=1VIC2tTZfzLzXxUXhyrRCTTN5ud2PUWeE"); // path đường dẫn của file
        }
    }
}
