using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;

namespace QL_HSGVTHPT
{
    public partial class frmHoSoGiangDay : Form
    {
        int count = 0;
        frmHocSinh obj_hs = new frmHocSinh();

        DataTable DS_Lop = new DataTable();
        DataTable DS_Mon = new DataTable();
        DataTable DS_HocKi = new DataTable();
        DataTable DS_HocSinh = new DataTable();
        DataTable DS_HocSinh_TheoLop = new DataTable();
        DataTable BangDiem = new DataTable();


        private int _i;
        public frmHoSoGiangDay(int i)
        {
            InitializeComponent();
            this._i = i;
            tabControlHoSoGD.SelectedIndex = _i;
            Enabled_ComBoBox(false);
            gbDiem.Enabled = false;

        }
        public void Enabled_ComBoBox(bool Enabled)
        {
            txtDSLop.Enabled = Enabled;
            txtDSMonHoc.Enabled = Enabled;
            txtHocKi.Enabled = Enabled;
            txtHocSinh.Enabled = Enabled;


        }

        private void RadioButtonMonHoc_CheckedChanged(object sender, EventArgs e)
        {
            dgvBangDiem.DataSource = null;
            Enabled_ComBoBox(false);




            txtHocSinh.DataSource = null;
            txtDSLop.DataSource = null;
            txtHocKi.DataSource = null;

            txtDSMonHoc.Enabled = true;
            DS_Mon = obj_hs.select_MonHoc();
            txtDSMonHoc.DataSource = DS_Mon;
            txtDSMonHoc.DisplayMember = "TenMon";
        }

        private void RadioButtonHocSinh_CheckedChanged(object sender, EventArgs e)
        {
            dgvBangDiem.DataSource = null;
            Enabled_ComBoBox(false);

            txtDSMonHoc.DataSource = null;
            DS_Mon = obj_hs.select_MonHoc();
            dgvDS.DataSource = DS_Mon;


            txtDSLop.Enabled = true;
            DS_Lop = obj_hs.select_Lop();
            txtDSLop.DataSource = DS_Lop;
            txtDSLop.DisplayMember = "TenLop";
        }

        private void TxtDSMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtDSLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonMonHoc.Checked)
            {
                DS_HocSinh_TheoLop = obj_hs.DS_Lop(txtDSLop.Text);
                dgvDS.DataSource = DS_HocSinh_TheoLop;

            }
        }

        private void TxtHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtDSLop_Click(object sender, EventArgs e)
        {
            if (radioButtonMonHoc.Checked)
            {
                txtHocKi.Enabled = true;
                DS_HocKi = obj_hs.select_HocKi();
                txtHocKi.DataSource = DS_HocKi;
                txtHocKi.DisplayMember = "NamHoc";
            }
            if (radioButtonHocSinh.Checked)
            {
                txtHocKi.Enabled = true;
                DS_HocKi = obj_hs.select_HocKi();
                txtHocKi.DataSource = DS_HocKi;
                txtHocKi.DisplayMember = "NamHoc";

                txtHocSinh.Enabled = true;


                DS_HocSinh = obj_hs.select_SDHS_theo_Lop(txtDSLop.Text);
                txtHocSinh.DataSource = DS_HocSinh;
                txtHocSinh.DisplayMember = "TenHS";
            }
        }

        private void TxtDSMonHoc_Click(object sender, EventArgs e)
        {
            txtDSLop.Enabled = true;
            DS_Lop = obj_hs.select_Lop();
            txtDSLop.DataSource = DS_Lop;
            txtDSLop.DisplayMember = "TenLop";
        }

        private void TxtHocKi_Click(object sender, EventArgs e)
        {
            if (radioButtonHocSinh.Checked)
            {
                txtHocKi.Enabled = true;
                DS_HocKi = obj_hs.select_HocKi();
                txtHocKi.DataSource = DS_HocKi;
                txtHocKi.DisplayMember = "NamHoc";
            }

        }

        private void TxtHocSinh_Click(object sender, EventArgs e)
        {

        }

        private void TxtDiem15Phut_KeyDown(object sender, KeyEventArgs e)
        {
            
          
                if (e.KeyCode == Keys.Enter)
                {
                if (Convert.ToDouble(txtDiem15Phut.Text.ToString()) > 10)
                {
                    MessageBox.Show("Điểm không được lớn quá 10", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiem15Phut.Clear();
                    ActiveControl = txtDiem15Phut;

                }
                else
                {
                    ActiveControl = txtDiemMieng;
                }
               
                }
            
           
        }

        private void TxtDiem1Tiet_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDouble(txtDiem15Phut.Text.ToString()) > 10)
                {
                    MessageBox.Show("Điểm không được lớn quá 10", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiem15Phut.Clear();
                    ActiveControl = txtDiem15Phut;

                }
                else
                {
                    ActiveControl = txtDiemHocKi;
                }
            }
        }

        private void TxtDiemMieng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDouble(txtDiem15Phut.Text.ToString()) > 10)
                {
                    MessageBox.Show("Điểm không được lớn quá 10", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiem15Phut.Clear();
                    ActiveControl = txtDiem15Phut;

                }
                else
                {
                    ActiveControl = txtDiem1Tiet;
                }
            }
        }
        public void XuongDong_HS()
        {

            // Cho xuống dòng.

            if (dgvDS.Rows.Count == 0)
                return;
            if (dgvDS.SelectedRows.Count == 0)
                return;
            int index = dgvDS.Rows.IndexOf(dgvDS.SelectedRows[0]);// dòng hiện tại
            if (index < dgvDS.Rows.Count - 1)
                index = index + 1;// chuyển về dòng sau đó
            else
                return;
            dgvDS.ClearSelection();// Xóa lựa chọn trước đó
            dgvDS.Rows[index].Selected = true;// chọn dòng cuối index
            dgvDS.Refresh();
            ActiveControl = dgvDS;
            if (index == dgvDS.Rows.Count - 1)
            {
                MessageBox.Show("Dòng bạn chọn rỗng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lbID.Text = dgvDS.Rows[index].Cells[0].Value.ToString();
            }
        }

        public void XuongDong()
        {
         
            // Cho xuống dòng.
           
            if (dgvDS.Rows.Count == 0)
                return;
            if (dgvDS.SelectedRows.Count == 0)
                return;
            int index = dgvDS.Rows.IndexOf(dgvDS.SelectedRows[0]);// dòng hiện tại
            if (index < dgvDS.Rows.Count - 1)
                index = index + 1;// chuyển về dòng sau đó
            else
                return;
            dgvDS.ClearSelection();// Xóa lựa chọn trước đó
            dgvDS.Rows[index].Selected = true;// chọn dòng cuối index
            dgvDS.Refresh();
            ActiveControl = dgvDS;
            if (index== dgvDS.Rows.Count-1)
            {
                MessageBox.Show("Dòng bạn chọn rỗng!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                lbID.Text = dgvDS.Rows[index].Cells[1].Value.ToString();
            }
           
        }
        public  void Load_BangDiem()
        {
            BangDiem = obj_hs.Select_BangDiem(txtDSMonHoc.Text, txtHocKi.Text, txtDSLop.Text);
            dgvBangDiem.DataSource = BangDiem;
        }
        public void Load_BangDiem_TheoHS()
        {
            BangDiem = obj_hs.Select_BangDiem_TheoHS(txtHocSinh.Text,txtHocKi.Text,txtDSLop.Text);
            dgvBangDiem.DataSource = BangDiem;
            
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (radioButtonMonHoc.Checked)
            {
                //sét điều kiện,nếu ô sủa điểm k đc tích thì là insert
                if (radioButtonSuaDiem.Checked)
                {
                    obj_hs.Update_BangDiem(txtDSMonHoc.Text, lbID.Text, txtHocKi.Text, txtDiem15Phut.Text, txtDiem1Tiet.Text, txtDiemMieng.Text, txtDiemHocKi.Text);
                    Load_BangDiem();

                   
                }
                else if(radioButtonNhapDiem.Checked)
                {
                    // Insert vào bảng điểm
                    obj_hs.insert_BangDiem(txtDSMonHoc.Text, lbID.Text, txtHocKi.Text, txtDiem15Phut.Text, txtDiem1Tiet.Text, txtDiemMieng.Text, txtDiemHocKi.Text);
                    Load_BangDiem();
                }
                XuongDong();

                txtDiem15Phut.Text = null;
                txtDiemMieng.Text = null;
                txtDiem1Tiet.Text = null;
                txtDiemHocKi.Text = null;
                ActiveControl = txtDiem15Phut;
            }
            if(radioButtonHocSinh.Checked)
            {

                //sét điều kiện,nếu ô sủa điểm k đc tích thì là insert
                if (radioButtonNhapDiem.Checked)
                {
                    // Insert vào bảng điểm
                    obj_hs.insert_BangDiem_TheoHS(lbID.Text,txtHocSinh.Text, txtHocKi.Text, txtDiem15Phut.Text, txtDiem1Tiet.Text, txtDiemMieng.Text, txtDiemHocKi.Text);
                    Load_BangDiem_TheoHS();
                }
                else if(radioButtonSuaDiem.Checked)
                {
                    obj_hs.Update_BangDiem_TheoHS(lbID.Text, txtHocSinh.Text, txtHocKi.Text, txtDiem15Phut.Text, txtDiem1Tiet.Text, txtDiemMieng.Text, txtDiemHocKi.Text);
                    Load_BangDiem_TheoHS();
                }
                XuongDong_HS();

                txtDiem15Phut.Text = null;
                txtDiemMieng.Text = null;
                txtDiem1Tiet.Text = null;
                txtDiemHocKi.Text = null;
                ActiveControl = txtDiem15Phut;
            }
        }

        private void DgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButtonMonHoc.Checked)
            {
                lbID.Text = dgvDS.CurrentRow.Cells[1].Value.ToString();
                gbDiem.Enabled = true;
                txtDiem15Phut.Text = null;
                txtDiemMieng.Text = null;
                txtDiem1Tiet.Text = null;
                txtDiemHocKi.Text = null;
                ActiveControl = txtDiem15Phut;
                Load_BangDiem();
            }
            if(radioButtonHocSinh.Checked)
            {
                lbID.Text = dgvDS.CurrentRow.Cells[0].Value.ToString();
                gbDiem.Enabled = true;
                txtDiem15Phut.Text = null;
                txtDiemMieng.Text = null;
                txtDiem1Tiet.Text = null;
                txtDiemHocKi.Text = null;
                ActiveControl = txtDiem15Phut;
                Load_BangDiem_TheoHS();
            }
        
        }

        private void TxtDiemHocKi_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (Convert.ToDouble(txtDiem15Phut.Text.ToString()) > 10)
                {
                    MessageBox.Show("Điểm không được lớn quá 10", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiem15Phut.Clear();
                    ActiveControl = txtDiem15Phut;

                }
                else
                {
                    ActiveControl = btnNext;
                }
            }
           
        }

        private void BtnNext_KeyDown(object sender, KeyEventArgs e)
        {
           
          
        }

        private void DgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButtonMonHoc.Checked)
            {
                txtDiem15Phut.Text = dgvBangDiem.CurrentRow.Cells[1].Value.ToString();
                txtDiemMieng.Text = dgvBangDiem.CurrentRow.Cells[2].Value.ToString();
                txtDiem1Tiet.Text = dgvBangDiem.CurrentRow.Cells[3].Value.ToString();
                txtDiemHocKi.Text = dgvBangDiem.CurrentRow.Cells[4].Value.ToString();
            }
            if (radioButtonHocSinh.Checked)
            {
                txtDiem15Phut.Text = dgvBangDiem.CurrentRow.Cells[1].Value.ToString();
                txtDiemMieng.Text = dgvBangDiem.CurrentRow.Cells[2].Value.ToString();
                txtDiem1Tiet.Text = dgvBangDiem.CurrentRow.Cells[3].Value.ToString();
                txtDiemHocKi.Text = dgvBangDiem.CurrentRow.Cells[4].Value.ToString();
            }

        }

        private void TxtDSLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS_Mon = obj_hs.select_MonHoc();
            dgvDS.DataSource = DS_Mon;
        }

        private void TxtDiem15Phut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtDiemMieng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtDiem1Tiet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtDiemHocKi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void DgvBangDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvBangDiem.CurrentCell.c
        }
    }
}
