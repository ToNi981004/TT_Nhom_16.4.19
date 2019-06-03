using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

using Excel = Microsoft.Office.Interop.Excel;
namespace QL_HSGVTHPT
{
    public partial class frmThoiKhoaBieu : Form
    {
        ThoiKhoaBieu obj_tkb = new ThoiKhoaBieu();

        DataTable TKB = new DataTable();
       
        DataTable TKB_LOP = new DataTable();
        DataTable DS_Lop = new DataTable();
        DataTable DS_Thu = new DataTable();
        DataTable DS_Mon= new DataTable();
        DataTable DS_GiaoVien = new DataTable();
        DataTable DS_TietHoc = new DataTable();
        DataTable DS_PhongHoc = new DataTable();
        DataTable TG_Hoc = new DataTable();


        // Tạo 1 list để kiểm chưa tiết học.       
        List<string> Check_TKB = new List<string>();

        public frmThoiKhoaBieu()
        {
            InitializeComponent();
            ActiveControl = txtSearch;
            txtTG_BĐ.Enabled = false;
            txtTG_KT.Enabled = false;
            txtPhongHoc.Enabled = true;
            txtSoTiet.Enabled = false;
            btnLuu.Enabled = false;
            
            //Load TKB
            Load_TKB();
            // DS Lớp
            DS_Lop = obj_tkb.Select_DSLop();
            txtDS_Lop.DataSource = DS_Lop;
            txtDS_Lop.DisplayMember = "TenLop";


            groupBox1.Enabled = false;

        }
        public bool KiemTra_TKB(string TKB)
        {
            for(int i=0;i<dgv_ThoiKhoaBieu.Rows.Count-1;i++)
            {
               // Check_TKB.Add(dgv_ThoiKhoaBieu.Rows[i].Cells[])
            }
            return false;
        }
        public void Load_TKB()
        {
            TKB = obj_tkb.TKB();
            dgv_ThoiKhoaBieu.DataSource = TKB;
        }

        private void Dgv_ThoiKhoaBieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtThu.Text=dgv_ThoiKhoaBieu.CurrentRow.Cells[0].Value.ToString();
            txtMonHoc.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[1].Value.ToString();
            txtTietHoc.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[2].Value.ToString();
            txtPhongHoc.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[3].Value.ToString();
            txtTG_BĐ.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[4].Value.ToString();
            txtTG_KT.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[5].Value.ToString();
            txtGiaoVien.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[6].Value.ToString();
            //txtSoTiet.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[7].Value.ToString();
            txtLop.Text = dgv_ThoiKhoaBieu.CurrentRow.Cells[8].Value.ToString();
            if (txtTietHoc.Text == "1" || txtTietHoc.Text == "2" || txtTietHoc.Text == "3" || txtTietHoc.Text == "4" || txtTietHoc.Text == "5" || txtTietHoc.Text == "6" || txtTietHoc.Text == "7" || txtTietHoc.Text == "8" || txtTietHoc.Text == "9" || txtTietHoc.Text == "10")
            {
                txtSoTiet.Text = "1";
            }
            if (txtTietHoc.Text == "1-2" || txtTietHoc.Text == "3-4" || txtTietHoc.Text == "7-8" || txtTietHoc.Text == "9-10" || txtTietHoc.Text == "2-3" || txtTietHoc.Text == "4-5" || txtTietHoc.Text == "6-7" || txtTietHoc.Text == "8-9")
            {
                txtSoTiet.Text = "2";
            }
            if (txtTietHoc.Text == "1-2-3" || txtTietHoc.Text == "2-3-4" || txtTietHoc.Text == "3-4-5" || txtTietHoc.Text == "6-7-8" || txtTietHoc.Text == "7-8-9" || txtTietHoc.Text == "8-9-10")
            {
                txtSoTiet.Text = "3";
            }
            if (txtTietHoc.Text == "1-2-3-4" || txtTietHoc.Text == "2-3-4-5" || txtTietHoc.Text == "6-7-8-9")
            {
                txtSoTiet.Text = "4";
            }
            if (txtTietHoc.Text == "1-2-3-4" || txtTietHoc.Text == "2-3-4-5" || txtTietHoc.Text == "6-7-8-9" || txtTietHoc.Text == "7-8-9-10")
            {
                txtSoTiet.Text = "4";
            }
            if (txtTietHoc.Text == "1-2-3-4-5" || txtTietHoc.Text == "6-7-8-9-10")
            {
                txtSoTiet.Text = "5";
            }

            groupBox1.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnDangKiPhongMay.Enabled = true;

        }

        private void TxtDS_Lop_TextChanged(object sender, EventArgs e)
        {
            TKB_LOP = obj_tkb.TKB_TheoLop(txtDS_Lop.Text);
            dgv_ThoiKhoaBieu.DataSource = TKB_LOP;

            txtLop.DataSource = obj_tkb.Select_PhongHoc(txtDS_Lop.Text);
            txtLop.DisplayMember = "TenPhong";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime tm = DateTime.Now;
            lbTime_TKB.Text = tm.ToString("dd/MM/yyyy | hh:mm:ss");
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                TKB_LOP = obj_tkb.Search(txtSearch.Text);
                dgv_ThoiKhoaBieu.DataSource = TKB_LOP;
            }
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {

            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRang = (Excel.Range)exSheet.Cells[1, 1];

            exRang.Range["A1:A2"].Font.Bold = true;
            exRang.Range["A1:A2"].Font.Size = 14;
            exRang.Range["A1"].Value = "Phần Mềm Quản Lí Học Sinh_Giáo Viên";
            exRang.Range["A2"].Value = "Hà Nội    Ngày: "+lbTime_TKB.Text;

            exRang.Range["E4"].Font.Bold = true;
            exRang.Range["E4"].Font.Size = 22;
            exRang.Range["E4"].Value = "Thời Khóa Biểu Lớp  "+txtDS_Lop.Text;
            exRang.Range["E4"].Font.Color = Color.Red;

            exRang.Range["A6:F6"].Font.Bold = true;
            exRang.Range["A6:F6"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exRang.Range["B6:C6"].ColumnWidth = 20;
            exRang.Range["D6"].ColumnWidth = 10;
            exRang.Range["E6:F6:G6:H6:I6:J6"].ColumnWidth = 20;
            exRang.Range["A6"].Value = "STT";
            exRang.Range["B6"].Value = "Thứ";
            exRang.Range["C6"].Value = "Môn Học";
            exRang.Range["D6"].Value = "Tiêt";
            exRang.Range["E6"].Value = "Phòng Học";
            exRang.Range["F6"].Value = "TG_Bắt Đầu";
            exRang.Range["G6"].Value = "TG_KếtThuc";
            exRang.Range["H6"].Value = "Giáo Viên";
            exRang.Range["I6"].Value = "Số Tiết";
            exRang.Range["J6"].Value = "Lớp";

            int row = 6;
            for (int i = 0; i < dgv_ThoiKhoaBieu.Rows.Count - 1; i++)
            {
                row++;
                exRang.Range["A" + row.ToString()].Value = (i + 1).ToString();
                exRang.Range["B" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[0].Value.ToString();
                exRang.Range["C" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[1].Value.ToString();
                exRang.Range["D" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[2].Value.ToString();
                exRang.Range["E" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[3].Value.ToString();
                exRang.Range["F" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[4].Value.ToString();
                exRang.Range["G" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[5].Value.ToString();
                exRang.Range["H" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[6].Value.ToString();
                exRang.Range["I" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[7].Value.ToString();
                exRang.Range["J" + row.ToString()].Value = dgv_ThoiKhoaBieu.Rows[i].Cells[8].Value.ToString();


            }
            row = row + 2;
            exRang.Range["E" + row.ToString()].Font.Bold = true;
            exRang.Range["E" + row.ToString()].Value = "Số Lượng: " + (dgv_ThoiKhoaBieu.Rows.Count - 1);

            exSheet.Name = "Thời Khóa Biểu";
            exBook.Activate();
            SaveFileDialog svFile = new SaveFileDialog();
            if (svFile.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(svFile.FileName);
                MessageBox.Show("Đã xuất file thành công.", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            exApp.Quit();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled==false)
            {
                if (obj_tkb.Check_TKB(txtDS_Lop.Text,txtGiaoVien.Text,txtThu.Text,txtTietHoc.Text,txtPhongHoc.Text) == true)
                {
                    MessageBox.Show("Đã tồn tại thời khóa biểu này! Yêu cầu nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnThem.Enabled = true;
                    groupBox1.Enabled = false;
                }
                else
                {
                    obj_tkb.Insert(txtLop.Text, txtGiaoVien.Text, txtThu.Text, txtTietHoc.Text, txtPhongHoc.Text, txtSoTiet.Text);

                    dgv_ThoiKhoaBieu.DataSource = obj_tkb.TKB_TheoLop(txtDS_Lop.Text);

                    btnThem.Enabled = true;
                    groupBox1.Enabled = false;
                }
            }
            if (btnDangKiPhongMay.Enabled == false)
            {
                if (obj_tkb.Check_TKB(txtDS_Lop.Text, txtGiaoVien.Text, txtThu.Text, txtTietHoc.Text, txtPhongHoc.Text) == true)
                {
                    MessageBox.Show("Đã tồn tại thời khóa biểu này! Yêu cầu nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnDangKiPhongMay.Enabled = true;
                    groupBox1.Enabled = false;
                }
                else
                {
                    obj_tkb.Insert(txtLop.Text, txtGiaoVien.Text, txtThu.Text, txtTietHoc.Text, txtPhongHoc.Text, txtSoTiet.Text);

                    dgv_ThoiKhoaBieu.DataSource = obj_tkb.TKB_TheoLop(txtDS_Lop.Text);

                    btnDangKiPhongMay.Enabled = true;
                    groupBox1.Enabled = false;
                }
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnDangKiPhongMay.Enabled = true;

            txtThu.Text = "";
            txtMonHoc.Text = "";
            txtGiaoVien.Text = "";
            txtTietHoc.Text = "";
            txtPhongHoc.Text = "";
            txtTG_BĐ.Text = "";
            txtTG_KT.Text = "";
            txtSoTiet.Text = "";
            txtLop.Text = "";


            groupBox1.Enabled = true;
            ActiveControl = txtThu;

            DS_Thu = obj_tkb.Select_Thu();
            DS_Mon = obj_tkb.Select_MonHoc();
            
            DS_TietHoc = obj_tkb.Select_TietHoc();

            DS_Lop = obj_tkb.Select_PhongHoc(txtDS_Lop.Text);



            txtThu.DataSource = DS_Thu;
            txtThu.DisplayMember = "Thu";

            txtMonHoc.DataSource = DS_Mon;
            txtMonHoc.DisplayMember = "TenMon";

            txtLop.DataSource = DS_Lop;
            txtLop.DisplayMember = "TenLop";

            txtTietHoc.DataSource = DS_TietHoc;
            txtTietHoc.DisplayMember = "Tiet";

           



        }

      

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDangKiPhongMay.Enabled = true;
            if (MessageBox.Show("Bạn Có chắc chắn muốn Xóa????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                obj_tkb.Delete(txtLop.Text, txtGiaoVien.Text, txtThu.Text, txtTietHoc.Text,txtPhongHoc.Text);

                dgv_ThoiKhoaBieu.DataSource = obj_tkb.TKB_TheoLop(txtDS_Lop.Text);

                btnXoa.Enabled = true;
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có chắc chắn muốn thoát????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }

        }


        private void TxtDS_Lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            TKB_LOP = obj_tkb.TKB_TheoLop(txtDS_Lop.Text);
            dgv_ThoiKhoaBieu.DataSource = TKB_LOP;

            DS_PhongHoc = obj_tkb.Select_PhongHoc(txtDS_Lop.Text);
            txtPhongHoc.DataSource = DS_PhongHoc;
            txtPhongHoc.DisplayMember = "TenPhong";

        }

        private void TxtMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS_GiaoVien = obj_tkb.Select_GiaoVien(txtMonHoc.Text);
            txtGiaoVien.DataSource = DS_GiaoVien;
            txtGiaoVien.DisplayMember = "HoTen";
        }

        private void TxtTietHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtTietHoc.Text=="1"|| txtTietHoc.Text == "2" || txtTietHoc.Text == "3" || txtTietHoc.Text == "4" || txtTietHoc.Text == "5" || txtTietHoc.Text == "6" || txtTietHoc.Text == "7" || txtTietHoc.Text == "8" || txtTietHoc.Text == "9" || txtTietHoc.Text == "10")
            {
                txtSoTiet.Text = "1";
            }
            if (txtTietHoc.Text == "1-2" || txtTietHoc.Text == "3-4" || txtTietHoc.Text == "7-8" || txtTietHoc.Text == "9-10" || txtTietHoc.Text == "2-3" || txtTietHoc.Text == "4-5" || txtTietHoc.Text == "6-7" || txtTietHoc.Text == "8-9")
            {
                txtSoTiet.Text = "2";
            }
            if (txtTietHoc.Text == "1-2-3" || txtTietHoc.Text == "2-3-4" || txtTietHoc.Text == "3-4-5" || txtTietHoc.Text == "6-7-8" || txtTietHoc.Text == "7-8-9" || txtTietHoc.Text == "8-9-10")
            {
                txtSoTiet.Text = "3";
            }
            if (txtTietHoc.Text == "1-2-3-4" || txtTietHoc.Text == "2-3-4-5" ||txtTietHoc.Text == "6-7-8-9" )
            {
                txtSoTiet.Text = "4";
            }
            if (txtTietHoc.Text == "1-2-3-4" || txtTietHoc.Text == "2-3-4-5" || txtTietHoc.Text == "6-7-8-9" || txtTietHoc.Text == "7-8-9-10")
            {
                txtSoTiet.Text = "4";
            }
            if (txtTietHoc.Text == "1-2-3-4-5" ||txtTietHoc.Text == "6-7-8-9-10")
            {
                txtSoTiet.Text = "5";
            }



            //load TG_Học

            TG_Hoc = obj_tkb.Select_ThoiGianHoc(txtTietHoc.Text);

            txtTG_BĐ.DataSource = TG_Hoc;
            txtTG_BĐ.DisplayMember = "TG_BatDau";

            txtTG_KT.DataSource = TG_Hoc;
            txtTG_KT.DisplayMember = "TG_KetThuc";

        }

        private void TxtLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS_PhongHoc = obj_tkb.Select_PhongHoc(txtLop.Text);
            txtPhongHoc.DataSource = DS_PhongHoc;
            txtPhongHoc.DisplayMember = "TenPhong";
        }

        private void BtnDangKiPhongMay_Click(object sender, EventArgs e)
        {

            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnDangKiPhongMay.Enabled = false;

            txtThu.Text = "";
            txtMonHoc.Text = "";
            txtGiaoVien.Text = "";
            txtTietHoc.Text = "";
            txtPhongHoc.Text = "";
            txtTG_BĐ.Text = "";
            txtTG_KT.Text = "";
            txtSoTiet.Text = "";
            txtLop.Text = "";


            groupBox1.Enabled = true;
            ActiveControl = txtThu;

            DS_Thu = obj_tkb.Select_Thu();
            DS_Mon = obj_tkb.Select_MonHoc();

            DS_TietHoc = obj_tkb.Select_TietHoc();

            DS_Lop = obj_tkb.Select_PhongHoc(txtDS_Lop.Text);




            txtThu.DataSource = DS_Thu;
            txtThu.DisplayMember = "Thu";

            txtMonHoc.DataSource = DS_Mon;
            txtMonHoc.DisplayMember = "TenMon";

            txtLop.DataSource = DS_Lop;
            txtLop.DisplayMember = "TenLop";

            txtTietHoc.DataSource = DS_TietHoc;
            txtTietHoc.DisplayMember = "Tiet";




            DS_PhongHoc = obj_tkb.Select_PhongMay();
            txtPhongHoc.DataSource = DS_PhongHoc;
            txtPhongHoc.DisplayMember = "TenPhong";




        }
    }
}
