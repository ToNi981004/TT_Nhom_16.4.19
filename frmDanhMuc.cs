using BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


using Excel = Microsoft.Office.Interop.Excel;




namespace QL_HSGVTHPT
{
    public partial class frmDanhMuc : Form
    {
        frmDM_GiaoVien obj_gv = new frmDM_GiaoVien();
        frmHocSinh obj_hs = new frmHocSinh();
        frmThongTinGiangDay obj_hsgd = new frmThongTinGiangDay();
        HocKi obj_hk = new HocKi();
        PhongHoc obj_ph = new PhongHoc();
        ThuTrongTuan obj_day = new ThuTrongTuan();
        MonHoc obj_mh = new MonHoc();
        Lop obj_class = new Lop();


        DataTable dtGV = new DataTable();
        DataTable dtHS = new DataTable();
        DataTable dtGV_HS = new DataTable();
        DataTable dtDiemHS = new DataTable();
        DataTable dtTenMonHoc = new DataTable();
        DataTable dtDS_Lop = new DataTable();
        DataTable dtDS_Mon = new DataTable();
        DataTable dtDS_HanhKiem = new DataTable();
        DataTable dtDS_HocLuc = new DataTable();
        DataTable dtDSHS_TheoLop = new DataTable();
        DataTable dtDSHS_TheoBoMon = new DataTable();
        DataTable dtDSHS_TheoHanhKiem = new DataTable();
        DataTable dtDSHS_TheoHocLuc = new DataTable();
        DataTable HSGD = new DataTable();
        DataTable HSGD_BoLoc = new DataTable();
        DataTable HocKi = new DataTable();
        DataTable PhongHoc = new DataTable();
        DataTable Day = new DataTable();
        DataTable MonHoc = new DataTable();
        DataTable Lop = new DataTable();
        DataTable GVBM = new DataTable();
        


        private string TrungGian="";
        private string TrungGian_HS = "";
        private string MaGV,HoTen, NgaySinh, GioiTinh, DiaChi, SDT_GV, ChucVu, QuocTich, DanToc, TonGiao, Email, MaMon;
        private string MaHS,TenHS, NgaySinh_HS, GioiTinh_HS, DiaChi_HS, HanhKiem, HocLuc, KhenThuong, KyLuat,MaLop;
        private string imgLocation = "";
        public int str;
        // kết nối với SQL để lưu file ảnh
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-G1AOD02;Initial Catalog=QL_GVHSTHPT;Integrated Security=True");
        SqlCommand cmd;

        // Hàm khoi tao
        public frmDanhMuc(int s)
        {
            // Lấy địa chỉ của tab tương ứng vs s
            InitializeComponent();
            this.str = s;
            tabpDanhMuc.SelectedIndex = s;
          
            //Load Bảng Danh Sánh GV
            LoadTable();
            // Load Danh Sách Học Sinh
            Load_SD_HS();
            //Che dấu GroupBox
            groupBoxAnhGV.Enabled = false;
            groupBoxThongTinCaNhan.Enabled = false;
            gbThongTin_HS.Enabled = false;
            gbAnh_HS.Enabled = false;

            // GV
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            //HS
            btnThem_HS.Enabled = false;
            btnSua_HS.Enabled = false;
            btnXoa_HS.Enabled = false;
            btnLuu_HS.Enabled = false;
            btnDetail.Enabled = false;
            // Khi load form thì vị trí con trỏ nằm trên thanh tìm kiếm
            ActiveControl = txtSearch;
            // Load Bảng HSDG
            HSGD = obj_hsgd.HSGD();
            dgvHSGD.DataSource = HSGD;
            gbThongTinGiangDay.Enabled = false;
            Enable_HSGD(false);
            // Load Bảng Học Kì
            txtMaPhong.Enabled = false;
            txtMaNgay.Enabled = false;
            txtMaHocKi.Enabled = false;
            btnLuu_PH_HK_NTT.Enabled = false;
            btnThem_PH_HK_NTT.Enabled = false;
            btnSua_PH_HK_NTT.Enabled = false;
            btnXoa_PH_HK_NTT.Enabled = false;
            HocKi = obj_hk.Select_HocKi();
            dataGridView_HocKi.DataSource = HocKi;
            groupBox_HocKi.Enabled = false;
            //Load Bảng Phòng Học
            PhongHoc = obj_ph.Select_PhongHoc();
            dataGridView_PhongHoc.DataSource = PhongHoc;
            groupBox_PhongHoc.Enabled = false;
            //Load Bảng Thứ Trong Tuần
            Day = obj_day.Select_ThuTronhTuan();
            dataGridView_ThuTrongTuan.DataSource = Day;
            groupBox_ThuTrongTuan.Enabled = false;
            //load bảng Môn Học
            groupBox_TacVu_MonHoc.Enabled = false;
            txtMaMon_MH.Enabled = false;
            btnLuu_MH.Enabled = false;
            MonHoc = obj_mh.Select_MonHoc();
            dataGridView_MonHoc.DataSource = MonHoc;
            // Load bảng Lớp Học
            txtMaLop_Lop.Enabled = false;
            btnLuu_Lop.Enabled = false;
            Lop = obj_class.Select_Lop();
            dataGridView_Lop.DataSource = Lop;

        }
        public void Load_SD_HS()
        {
            dtGV_HS = obj_hs.SelectDSHS();
            dgvHocSinh.DataSource = dtGV_HS;
        }
        /// <summary>
        /// Hàm Load Diểm Trùn Bình các kì học của học sinh
        /// </summary>
        public void Load_Diem(string ID)
        {
 
            chartDiemHK_HS.ChartAreas["ChartArea1"].AxisX.Title = "Học Kỳ";
           
            dtDiemHS = obj_hs.DiemTB_HK(ID);
            chartDiemHK_HS.DataSource = dtDiemHS;
            
             chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].YValueMembers= "DiemKH";
             chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].XValueMember = "MaHocKi";
             chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].Label = "";
             
             
            //chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].Points[]

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
         
        
        // mở Group để thao tác
            groupBoxThongTinCaNhan.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        // chiển các giá trị trên Ô thông tin về Rỗng
                lbID.Text ="ID";
                txtHoTen.Text = "";
                txtNgaySinh.Text = "";
                txtGioiTinh.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtChucVu.Text = "";
                txtQuocTich.Text = "";
                txtDanToc.Text = "";
                txtTonGiao.Text = "";
                txtEmail.Text = "";
                pictGiaoVien.Image = null;
                txtMonHoc.Text = "";
            ActiveControl = txtHoTen;
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            // đóng nút Sửa
            btnSua.Enabled = false;
            if(lbID.Text==""||lbID.Text== "ID")
            {
                MessageBox.Show("Bạn Chưa Chọn Giáo Viên Nào để Sửa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                groupBoxAnhGV.Enabled = true;
                groupBoxThongTinCaNhan.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // đóng nút xóa
            btnXoa.Enabled = false;
            if (lbID.Text == "" || lbID.Text == "ID")
            {
                MessageBox.Show("Bạn Chưa Chọn Giáo Viên Nào để Xóa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Không ??", "*Chú Ý:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    obj_gv.Delete_GiaoVien(lbID.Text);
                    MessageBox.Show("Đã Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadTable();
                }
            }
        }

        /// <summary>
        /// Hàm chuyển chữ thường sang chữ HOA
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ChuanHoa(string str)
        {
            str = str.ToUpper();
            return str;
        }
        /// <summary>
        /// hàm load ảnh cho HS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browse_HS_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureAnhHS.ImageLocation = imgLocation;
            }
        }
        /// <summary>
        /// Hàm lưu ảnh học sinh
        /// </summary>
        /// <param name="ID"></param>
        public void SavePicture_HS(string ID)
        {
            try
            {
                byte[] imges = null;
                FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                imges = brs.ReadBytes((int)stream.Length);



                string sqlQuery = "Update HocSinh set Pictures_HS = @imges where MaHS =N'" + ID + "'";
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    cmd = new SqlCommand(sqlQuery, connection);
                    cmd.Parameters.Add(new SqlParameter("@imges", imges));
                    int N = cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Bạn Thêm Được: " + N.ToString() + " Ảnh");
                    pictGiaoVien.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // lưu xong load lại bảng
            Load_SD_HS();
        }
        /// <summary>
        /// Hàm load ảnh Học Sinh
        /// </summary>
        /// <param name="ID"></param>
        public void Show_Picture_HS(string ID)
        {
            try
            {
                // tạo điều kiện mà rỗng thì k hiển thị đc
                if (obj_hs.Check_Image(lbID_HS.Text) == true)
                {
                    if (MessageBox.Show("Không Có Ảnh, Mời Bạn Thêm Ảnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        gbAnh_HS.Enabled = true;
                        pictureAnhHS.Image = null;
                    }
                }
                else
                {
                    string sql = "select Pictures_HS from HocSinh where MaHS=N'" + ID + "'";
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                        cmd = new SqlCommand(sql, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            byte[] img = (byte[])(reader[0]);
                            if (img == null)
                                pictureAnhHS.Image = null;
                            else
                            {
                                MemoryStream ms = new MemoryStream(img);
                                pictureAnhHS.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                           if(MessageBox.Show("Đối Tượng Được chọn Rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)==DialogResult.OK)
                            {
                                btnThem_HS.Enabled = true;
                            }
                        }
                        connection.Close();
                    }
                }
                dgvHocSinh.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_HS_Click(object sender, EventArgs e)
        {
            SavePicture_HS(lbID_HS.Text);
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (obj_gv.Check_Search(txtSearch.Text) == true)
                {
                   dtGV=obj_gv.Search(txtSearch.Text);
                   dgvGiaoVien.DataSource = dtGV;
                }
                else
                {
                    MessageBox.Show("Đối Tượng:    '" + txtSearch.Text + "'    Không Tồn Tại Trong Hệ Thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                }

            }
        }

        private void btnSua_HS_Click(object sender, EventArgs e)
        {
            btnSua_HS.Enabled = false;
            if (lbID_HS.Text == "" || lbID_HS.Text == "ID")
            {
                MessageBox.Show("Bạn Chưa Chọn Học Sinh Nào để Sửa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                gbAnh_HS.Enabled = true;
                gbThongTin_HS.Enabled = true;
            }
        }

        private void btnXoa_HS_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            if (lbID_HS.Text == "" || lbID_HS.Text == "ID")
            {
                MessageBox.Show("Bạn Chưa Chọn Học Sinh Nào để Xóa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Không ??", "*Chú Ý:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    obj_hs.Delete_HocSinh(lbID_HS.Text);
                    MessageBox.Show("Đã Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    obj_hs.Delete_ChiTietMon_KhiDeleteHS(txtHoTen_HS.Text);
                    Load_SD_HS();
                }
            }
        }

        private void btnExit_HS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có chắc chắn muốn thoát????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void TxtMonHoc_Click(object sender, EventArgs e)
        {
            dtTenMonHoc = obj_gv.select_MonHoc();
            txtMonHoc.DataSource = dtTenMonHoc;
            txtMonHoc.DisplayMember = "TenMon";
        }
        private void TxtDoiTuongLoc_HS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (txtBoLoc_HS.Text == "Theo Lớp")
            {

                    dtDSHS_TheoLop = obj_hs.selectDSHS_The_Lop(txtDoiTuongLoc_HS.Text);
                    dgvHocSinh.DataSource = dtDSHS_TheoLop;
                    
            }
            if (txtBoLoc_HS.Text == "Theo Môn Học")
            {

                dtDSHS_TheoBoMon = obj_hs.selectDSHS_Theo_Mon(txtDoiTuongLoc_HS.Text);
                dgvHocSinh.DataSource = dtDSHS_TheoBoMon;

            }
            if (txtBoLoc_HS.Text == "Theo Hạnh Kiểm")
            {

                dtDSHS_TheoHanhKiem = obj_hs.selectDSHS_Theo_HanhKiem(txtDoiTuongLoc_HS.Text);
                dgvHocSinh.DataSource = dtDSHS_TheoHanhKiem;

            }
            if (txtBoLoc_HS.Text == "Theo Học Lực")
            {

                dtDSHS_TheoHocLuc = obj_hs.selectDSHS_Theo_HocLuc(txtDoiTuongLoc_HS.Text);
                dgvHocSinh.DataSource = dtDSHS_TheoHocLuc;

            }


        }

        private void TxtBoLoc_HS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBoLoc_HS.Text == "Theo Lớp")
            {
                txtDoiTuongLoc_HS.Text = "";
                dtDS_Lop = obj_hs.select_Lop();
                txtDoiTuongLoc_HS.DataSource = dtDS_Lop;
                txtDoiTuongLoc_HS.DisplayMember = "TenLop";
            }
            if (txtBoLoc_HS.Text == "Theo Môn Học")
            {
                txtDoiTuongLoc_HS.Text = "";
                dtDS_Mon = obj_hs.select_MonHoc();
                txtDoiTuongLoc_HS.DataSource = dtDS_Mon;
                txtDoiTuongLoc_HS.DisplayMember = "TenMon";
            }
            if (txtBoLoc_HS.Text == "Theo Hạnh Kiểm")
            {
                txtDoiTuongLoc_HS.Text = "";
                dtDS_HanhKiem = obj_hs.select_DS_HanhKiem();
                txtDoiTuongLoc_HS.DataSource = dtDS_HanhKiem;
                txtDoiTuongLoc_HS.DisplayMember = "HanhKiem";
            }
            if (txtBoLoc_HS.Text == "Theo Học Lực")
            {
                txtDoiTuongLoc_HS.Text = "";
                dtDS_HocLuc = obj_hs.select_DS_HocLuc();
                txtDoiTuongLoc_HS.DataSource = dtDS_HocLuc;
                txtDoiTuongLoc_HS.DisplayMember = "HocLuc";
            }

        }

        private void BtnDetail_Click(object sender, EventArgs e)
        {
            frmPointDetails frm = new frmPointDetails(lbID_HS.Text,txtHoTen_HS.Text,txtNgaySinh_HS.Text,txtHocLuc_HS.Text,txtHanhKiem_HS.Text,txtMaLop_HS.Text);
            frm.ShowDialog();
        }

        private void BtnNhapDiem_Click(object sender, EventArgs e)
        {
            frmHoSoGiangDay frm = new frmHoSoGiangDay(0);
            frm.ShowDialog();
        }





        public void exportExcel_HoSoGiangDay()
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRang = (Excel.Range)exSheet.Cells[1, 1];

            exRang.Range["A1"].Font.Bold = true;
            exRang.Range["A1"].Font.Size = 14;
            exRang.Range["A1"].Value = "Phần Mềm Quản Lí Học Sinh_Giáo Viên";
            



            exRang.Range["E4"].Font.Bold = true;
            exRang.Range["E4"].Font.Size = 22;
            exRang.Range["E4"].Value = "Bảng Điểm";
            exRang.Range["E4"].Font.Color = Color.Red;


            //exRang.Range["A6:B6:C6:D6:E6:F6:G6:H6"].Font.Color = Color.Red;
            exRang.Range["A6:F6"].Font.Bold = true;
            exRang.Range["A6:F6"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exRang.Range["B6:C6"].ColumnWidth = 20;
            exRang.Range["D6"].ColumnWidth = 10;
            exRang.Range["E6:F6:G6:H6"].ColumnWidth = 20;
            exRang.Range["A6"].Value = "STT";
            exRang.Range["B6"].Value = "Tên Học Sinh";
            exRang.Range["C6"].Value = "Môn Học";
            exRang.Range["D6"].Value = "Học Kì";
            exRang.Range["E6"].Value = "Điểm 15 Phút";
            exRang.Range["F6"].Value = "Điểm Miệng";
            exRang.Range["G6"].Value = "Điểm Một Tiết";
            exRang.Range["H6"].Value = "Điểm Cuối Học Kì";

            int row = 6;
            for (int i = 0; i < dgvHSGD.Rows.Count - 1; i++)
            {
                row++;
                exRang.Range["A" + row.ToString()].Value = (i + 1).ToString();
                exRang.Range["B" + row.ToString()].Value = dgvHSGD.Rows[i].Cells[0].Value.ToString();
                exRang.Range["C" + row.ToString()].Value = dgvHSGD.Rows[i].Cells[1].Value.ToString();
                exRang.Range["D" + row.ToString()].Value = dgvHSGD.Rows[i].Cells[2].Value.ToString();
                exRang.Range["E" + row.ToString()].Value = dgvHSGD.Rows[i].Cells[3].Value.ToString();
                exRang.Range["F" + row.ToString()].Value = dgvHSGD.Rows[i].Cells[4].Value.ToString();
                exRang.Range["G" + row.ToString()].Value = dgvHSGD.Rows[i].Cells[5].Value.ToString();
                exRang.Range["H" + row.ToString()].Value = dgvHSGD.Rows[i].Cells[6].Value.ToString();

            }
            row = row + 2;
            exRang.Range["E" + row.ToString()].Font.Bold = true;
            exRang.Range["E" + row.ToString()].Value = "Tổng Số Sinh Viên: "+dgvHSGD.Rows.Count;

            exSheet.Name = "Bảng Điểm";
            exBook.Activate();
            SaveFileDialog svFile = new SaveFileDialog();
            if (svFile.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(svFile.FileName);
                MessageBox.Show("Đã xuất file thành công");
            }
            exApp.Quit();
        }





        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {

            exportExcel_HoSoGiangDay();
        }
        public void Enable_HSGD(bool Enable)
        {
          
            btnSua_HSGD.Enabled = Enable;
            btnXoa_HSGD.Enabled = Enable;
            btnLuu_HSGD.Enabled = Enable;
        }
        private void DgvHSGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHocSinh_HSGD.Text = dgvHSGD.CurrentRow.Cells[0].Value.ToString();
            txtMonHoc_HSGD.Text = dgvHSGD.CurrentRow.Cells[1].Value.ToString();
            txtHocKi_HSGD.Text = dgvHSGD.CurrentRow.Cells[2].Value.ToString();
            txtDiem15Phut_HSGD.Text = dgvHSGD.CurrentRow.Cells[3].Value.ToString();
            txtDiemMieng_HSGD.Text = dgvHSGD.CurrentRow.Cells[4].Value.ToString();
            txtDiemMotTiet_HSGD.Text = dgvHSGD.CurrentRow.Cells[5].Value.ToString();
            txtDiemCuoiKi_HSGD.Text = dgvHSGD.CurrentRow.Cells[6].Value.ToString();
            Enable_HSGD(true);
            gbThongTinGiangDay.Enabled = false;
            btnLuu_HSGD.Enabled = false;
        }

        private void TxtSearch_HSGD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                HSGD=obj_hsgd.Search(txtSearch_HSGD.Text);
                dgvHSGD.DataSource = HSGD;
            }
        }

        private void BtnLuu_HSGD_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtDiem15Phut_HSGD.Text.ToString()) > 10 || Convert.ToDouble(txtDiemMieng_HSGD.Text.ToString()) > 10 || Convert.ToDouble(txtDiemMotTiet_HSGD.Text.ToString()) > 10 || Convert.ToDouble(txtDiemCuoiKi_HSGD.Text.ToString()) > 10)
            {
                MessageBox.Show("Điểm không lớn quá 10!", "Chú Ý:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (btnSua_HSGD.Enabled == false)
                {
                    obj_hsgd.Update_ChiTietMon(txtMonHoc_HSGD.Text, txtHocSinh_HSGD.Text, txtHocKi_HSGD.Text, txtDiem15Phut_HSGD.Text, txtDiemMieng_HSGD.Text, txtDiemMotTiet_HSGD.Text, txtDiemCuoiKi_HSGD.Text);
                    HSGD = obj_hsgd.HSGD();
                    dgvHSGD.DataSource = HSGD;
                    btnSua_HSGD.Enabled = true;
                }
            }
        }

       

        private void BtnSua_HSGD_Click(object sender, EventArgs e)
        {
            btnSua_HSGD.Enabled = false;
            btnLuu_HSGD.Enabled = true;

            gbThongTinGiangDay.Enabled = true;
           
        }

        private void BtnXoa_HSGD_Click(object sender, EventArgs e)
        {
            btnXoa_HSGD.Enabled = false;
            if (MessageBox.Show("Bạn Có chắc chắn muốn XÓA????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                obj_hsgd.Delete_ChiTietMon(txtMonHoc_HSGD.Text, txtHocSinh_HSGD.Text, txtHocKi_HSGD.Text);
                HSGD = obj_hsgd.HSGD();
                dgvHSGD.DataSource = HSGD;
                btnXoa_HSGD.Enabled = true;
            }
        }

        private void BtnExit_HSGD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có chắc chắn muốn thoát????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void TxtDanhMucLoc_HSGD_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                HSGD_BoLoc = obj_hs.select_MonHoc();
                txtBoLocMonHoc_HSGD.DataSource = HSGD_BoLoc;
                txtBoLocMonHoc_HSGD.DisplayMember = "TenMon";
           
        }

        private void Label44_Click(object sender, EventArgs e)
        {

        }

        private void TxtDoiTuongLoc_HSGD_SelectedIndexChanged(object sender, EventArgs e)
        {
           


            HSGD_BoLoc = obj_hs.select_HocKi();
            txtDanhMucLoc_HSGD.DataSource = HSGD_BoLoc;
            txtDanhMucLoc_HSGD.DisplayMember = "NamHoc";
        }

        private void TxtBoLocMonHoc_HSGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            HSGD = obj_hsgd.BoLoc_ChiTieMonHoc(txtBoLocMonHoc_HSGD.Text, txtDoiTuongLoc_HSGD.Text, txtDanhMucLoc_HSGD.Text);
            dgvHSGD.DataSource = HSGD;
        }

        private void TxtDoiTuongLoc_HSGD_Click(object sender, EventArgs e)
        {
            HSGD_BoLoc = obj_hs.select_Lop();
            txtDoiTuongLoc_HSGD.DataSource = HSGD_BoLoc;
            txtDoiTuongLoc_HSGD.DisplayMember = "TenLop";
        }

        private void DataGridView_PhongHoc_Click(object sender, EventArgs e)
        {
           
        }

        private void DataGridView_HocKi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHocKi.Text = dataGridView_HocKi.CurrentRow.Cells[0].Value.ToString();
            txtNamHoc.Text = dataGridView_HocKi.CurrentRow.Cells[1].Value.ToString();
            txtThoiGianBatDau.Text = dataGridView_HocKi.CurrentRow.Cells[2].Value.ToString();
            txtThoiGianKetThuc.Text = dataGridView_HocKi.CurrentRow.Cells[3].Value.ToString();


            btnThem_PH_HK_NTT.Enabled = true;
            btnSua_PH_HK_NTT.Enabled = true;
            btnXoa_PH_HK_NTT.Enabled = true;

        }

        private void DataGridView_PhongHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = dataGridView_PhongHoc.CurrentRow.Cells[0].Value.ToString();
            txtTenPhong.Text = dataGridView_PhongHoc.CurrentRow.Cells[1].Value.ToString();
            txtChoNgoi.Text = dataGridView_PhongHoc.CurrentRow.Cells[2].Value.ToString();
           
            btnThem_PH_HK_NTT.Enabled = true;
            btnSua_PH_HK_NTT.Enabled = true;
            btnXoa_PH_HK_NTT.Enabled = true;
        }

        private void DataGridView_ThuTrongTuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNgay.Text = dataGridView_ThuTrongTuan.CurrentRow.Cells[0].Value.ToString();
            txtThu.Text = dataGridView_ThuTrongTuan.CurrentRow.Cells[1].Value.ToString();

            btnThem_PH_HK_NTT.Enabled = true;
            btnSua_PH_HK_NTT.Enabled = true;
            btnXoa_PH_HK_NTT.Enabled = true;
        }

        private void DataGridView_HocKi_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridView_ThuTrongTuan_Click(object sender, EventArgs e)
        {
            
        }

        private void TxtSeachr_PH_HK_NTT_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton_PhongHoc_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_PhongHoc.Enabled = true;
            groupBox_HocKi.Enabled = false;
            groupBox_ThuTrongTuan.Enabled = false;
            ActiveControl = txtSeachr_PH_HK_NTT;
        }

        private void RadioButton_ThuTrongTuan_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_PhongHoc.Enabled = false;
            groupBox_HocKi.Enabled = false;
            groupBox_ThuTrongTuan.Enabled = true;
            ActiveControl = txtSeachr_PH_HK_NTT;
        }

        private void RadioButton_HocKi_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_PhongHoc.Enabled = false;
            groupBox_HocKi.Enabled = true;
            groupBox_ThuTrongTuan.Enabled = false;
            ActiveControl = txtSeachr_PH_HK_NTT;
        }

        private void BtnLuu_PH_HK_NTT_Click(object sender, EventArgs e)
        {
            if(radioButton_PhongHoc.Checked)
            {
                if (btnSua_PH_HK_NTT.Enabled == false)
                {
                    obj_ph.Update_PhongHoc(txtMaPhong.Text, txtTenPhong.Text, txtChoNgoi.Text);
                    PhongHoc = obj_ph.Select_PhongHoc();
                    dataGridView_PhongHoc.DataSource = PhongHoc;
                    btnSua_PH_HK_NTT.Enabled = true;
                    btnLuu_PH_HK_NTT.Enabled = false;
                }
                if(btnThem_PH_HK_NTT.Enabled==false)
                {
                   
                        obj_ph.Insert_PhongHoc(txtTenPhong.Text, txtChoNgoi.Text);
                    
                    PhongHoc = obj_ph.Select_PhongHoc();
                    dataGridView_PhongHoc.DataSource = PhongHoc;
                    btnThem_PH_HK_NTT.Enabled = true;
                    btnLuu_PH_HK_NTT.Enabled = false;
                }
            }
            if (radioButton_ThuTrongTuan.Checked)
            {

                if (btnThem_PH_HK_NTT.Enabled == false)
                {
                    obj_day.Insert_Day(txtThu.Text);


                    Day = obj_day.Select_ThuTronhTuan();
                    dataGridView_ThuTrongTuan.DataSource = Day;


                    btnThem_PH_HK_NTT.Enabled = true;
                    btnLuu_PH_HK_NTT.Enabled = false;
                }
                if (btnSua_PH_HK_NTT.Enabled == false)
                {
                    obj_day.Update_Day(txtThu.Text, txtMaNgay.Text);


                    Day = obj_day.Select_ThuTronhTuan();
                    dataGridView_ThuTrongTuan.DataSource = Day;


                    btnSua_PH_HK_NTT.Enabled = true;
                    btnLuu_PH_HK_NTT.Enabled = false;
                }
            }
            if (radioButton_HocKi.Checked)
            {
                if (btnThem_PH_HK_NTT.Enabled == false)
                {
                    obj_hk.Insert_HocKi(txtNamHoc.Text, txtThoiGianBatDau.Text, txtThoiGianKetThuc.Text);


                    HocKi = obj_hk.Select_HocKi();
                    dataGridView_HocKi.DataSource = HocKi;


                    btnThem_PH_HK_NTT.Enabled = true;
                    btnLuu_PH_HK_NTT.Enabled = false;
                }
                if (btnSua_PH_HK_NTT.Enabled == false)
                {
                    obj_hk.Update_HocKi(txtMaHocKi.Text, txtNamHoc.Text, txtThoiGianBatDau.Text, txtThoiGianKetThuc.Text);


                    HocKi = obj_hk.Select_HocKi();
                    dataGridView_HocKi.DataSource = HocKi;


                    btnSua_PH_HK_NTT.Enabled = true;
                    btnLuu_PH_HK_NTT.Enabled = false;
                }
            }

        }

       

        private void BtnSua_PH_HK_NTT_Click(object sender, EventArgs e)
        {
            btnSua_PH_HK_NTT.Enabled = false;
            btnLuu_PH_HK_NTT.Enabled = true;

        }

        private void BtnXoa_PH_HK_NTT_Click(object sender, EventArgs e)
        {
            btnXoa_PH_HK_NTT.Enabled = false;
            if (radioButton_PhongHoc.Checked)
            {
                if (MessageBox.Show("Bạn Có chắc chắn muốn Xóa????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    obj_ph.Delete_PhongHoc(txtMaPhong.Text);
                    PhongHoc =obj_ph.Select_PhongHoc();
                    dataGridView_PhongHoc.DataSource = PhongHoc;
                    btnXoa_PH_HK_NTT.Enabled = true;
                }
            }
            if (radioButton_ThuTrongTuan.Checked)
            {
                if (MessageBox.Show("Bạn Có chắc chắn muốn Xóa????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    obj_day.Delete_Day(txtMaNgay.Text);


                    Day = obj_day.Select_ThuTronhTuan();
                    dataGridView_ThuTrongTuan.DataSource = Day;


                    btnXoa_PH_HK_NTT.Enabled = true;
                }
            }
            if (radioButton_HocKi.Checked)
            {
                if (MessageBox.Show("Bạn Có chắc chắn muốn Xóa????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    obj_hk.Delete_HocKi(txtMaHocKi.Text);
                    HocKi = obj_hk.Select_HocKi();
                    dataGridView_HocKi.DataSource = HocKi;
                    btnXoa_PH_HK_NTT.Enabled = true;
                }
            }
        }

        private void BtnExit_PH_HK_NTT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có chắc chắn muốn thoát????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BtnThem_PH_HK_NTT_Click_1(object sender, EventArgs e)
        {
            btnThem_PH_HK_NTT.Enabled = false;
            btnLuu_PH_HK_NTT.Enabled = true;

            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtChoNgoi.Text = "";
           

            txtMaHocKi.Text = "";
            txtNamHoc.Text = "";
            txtThoiGianBatDau.Text = "";
            txtThoiGianKetThuc.Text = "";

            txtMaNgay.Text = "";
            txtThu.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void LbID_Click(object sender, EventArgs e)
        {

        }

        private void Label52_Click(object sender, EventArgs e)
        {

        }
        public void Load_ThongTinGV_LenMonHoc(string ID_MH)
        {
            GVBM = obj_mh.Select_GBBM(ID_MH);
            dataGridView_DSGVBM.DataSource = GVBM;
        }
        private void DataGridView_MonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMon_MH.Text = dataGridView_MonHoc.CurrentRow.Cells[0].Value.ToString();
            txtTenMon_MH.Text = dataGridView_MonHoc.CurrentRow.Cells[1].Value.ToString();
            txtHeSoDiem_MH.Text = dataGridView_MonHoc.CurrentRow.Cells[2].Value.ToString();
            groupBox_TacVu_MonHoc.Enabled = true;
            btnLuu_MH.Enabled = false;
            btnThem_MH.Enabled = true;
            btnSua_MH.Enabled = true;
            btnXoa_MH.Enabled = true;
            Load_ThongTinGV_LenMonHoc(txtMaMon_MH.Text);

        }

        private void BtnLuu_MH_Click(object sender, EventArgs e)
        {
            if(btnThem_MH.Enabled==false)
            {
                obj_mh.Insert_MH(txtTenMon_MH.Text, txtHeSoDiem_MH.Text);

                // load lại bảng
                MonHoc = obj_mh.Select_MonHoc();
                dataGridView_MonHoc.DataSource = MonHoc;

                // Trả quyền điều khiển cho nút Thêm
                btnThem_MH.Enabled = true;
                btnLuu_MH.Enabled = false;


            }
            if (btnSua_MH.Enabled == false)
            {
                obj_mh.Update_MH(txtTenMon_MH.Text,txtHeSoDiem_MH.Text,txtMaMon_MH.Text);

                // load lại bảng
                MonHoc = obj_mh.Select_MonHoc();
                dataGridView_MonHoc.DataSource = MonHoc;

                // Trả quyền điều khiển cho nút Thêm
                btnSua_MH.Enabled = true;
                btnLuu_MH.Enabled = false;


            }
        }

        private void BtnXoa_MH_Click(object sender, EventArgs e)
        {
            btnXoa_MH.Enabled = false;
           
            if (MessageBox.Show("Bạn Có chắc chắn muốn Xóa????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                obj_mh.Delete_MH(txtMaMon_MH.Text);

                // load lại bảng
                MonHoc = obj_mh.Select_MonHoc();
                dataGridView_MonHoc.DataSource = MonHoc;

                // Trả quyền điều khiển cho nút Thêm
                btnXoa_MH.Enabled = true;
            }
        }

        private void BtnSua_MH_Click(object sender, EventArgs e)
        {
            btnSua_MH.Enabled = false;
            btnLuu_MH.Enabled = true;
            btnThem_MH.Enabled = true;
            btnXoa_MH.Enabled = true;
        }

        private void BtnThem_MH_Click(object sender, EventArgs e)
        {
            txtMaMon_MH.Text = "";
            txtTenMon_MH.Text = "";
            txtHeSoDiem_MH.Text = "";

            btnThem_MH.Enabled = false;
            btnLuu_MH.Enabled = true;
            btnSua_MH.Enabled = true;
            btnXoa_MH.Enabled = true;
        }

        private void BtnExit_MH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có chắc chắn muốn thoát????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void TxtSeach_MH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                MonHoc = obj_mh.Search_MH(txtSeach_MH.Text);
                dataGridView_MonHoc.DataSource = MonHoc;
            }
        }

        private void DataGridView_Lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLop_Lop.Text = dataGridView_Lop.CurrentRow.Cells[0].Value.ToString();
            txtTenLop_Lop.Text = dataGridView_Lop.CurrentRow.Cells[1].Value.ToString();
            txtSySo_Lop.Text = dataGridView_Lop.CurrentRow.Cells[2].Value.ToString();
            txtNiemKhoa_Lop.Text = dataGridView_Lop.CurrentRow.Cells[3].Value.ToString();


            btnThem_Lop.Enabled = true;
            btnSua_Lop.Enabled = true;
            btnXoa_Lop.Enabled = true;
            btnLuu_Lop.Enabled = false;
        }

        private void TxtSearch_Lop_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Lop = obj_class.Search_Lop(txtSearch_Lop.Text);
                dataGridView_Lop.DataSource = Lop;
            }
        }

        private void BtnLuu_Lop_Click(object sender, EventArgs e)
        {
            if(btnThem_Lop.Enabled==false)
            {
                obj_class.Insert_Lop(txtTenLop_Lop.Text, txtSySo_Lop.Text, txtNiemKhoa_Lop.Text);

                Lop = obj_class.Select_Lop();
                dataGridView_Lop.DataSource = Lop;


                btnThem_Lop.Enabled = true;
                btnLuu_Lop.Enabled = false;

            }

            if (btnSua_Lop.Enabled == false)
            {
                obj_class.Update_Lop(txtMaLop_Lop.Text,txtTenLop_Lop.Text, txtSySo_Lop.Text, txtNiemKhoa_Lop.Text);

                Lop = obj_class.Select_Lop();
                dataGridView_Lop.DataSource = Lop;


                btnSua_Lop.Enabled = true;
                btnLuu_Lop.Enabled = false;

            }

        }

        private void BtnXoa_Lop_Click(object sender, EventArgs e)
        {
            btnThem_Lop.Enabled = true;
            btnLuu_Lop.Enabled = false;
            btnSua_Lop.Enabled = true;
            btnXoa_Lop.Enabled = false;

            if (MessageBox.Show("Bạn Có chắc chắn muốn Xoa????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                obj_class.Delete_Lop(txtMaLop_Lop.Text);

                Lop = obj_class.Select_Lop();
                dataGridView_Lop.DataSource = Lop;

                btnXoa_Lop.Enabled = true;
            }
        }

        private void BtnSua_Lop_Click(object sender, EventArgs e)
        {
            btnThem_Lop.Enabled = true;
            btnLuu_Lop.Enabled = true;
            btnSua_Lop.Enabled = false;
            btnXoa_Lop.Enabled = true;

        }

        private void BtnThem_Lop_Click(object sender, EventArgs e)
        {
            btnThem_Lop.Enabled = false;
            btnLuu_Lop.Enabled = true;
            btnSua_Lop.Enabled = true;
            btnXoa_Lop.Enabled = true;

            txtMaLop_Lop.Text = "";
            txtTenLop_Lop.Text = "";
            txtSySo_Lop.Text = "";
            txtNiemKhoa_Lop.Text = "";


        }

        private void BtnExit_Lop_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn Có chắc chắn muốn thoát????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void TxtSeachr_PH_HK_NTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton_HocKi.Checked)
                {
                    HocKi=obj_hk.Search_HocKi(txtSeachr_PH_HK_NTT.Text);


                    dataGridView_HocKi.DataSource = HocKi;
                }
                if (radioButton_PhongHoc.Checked)
                {
                    PhongHoc=obj_ph.Search_PhongHoc(txtSeachr_PH_HK_NTT.Text);

                   
                    dataGridView_PhongHoc.DataSource = PhongHoc;
                }
                if (radioButton_ThuTrongTuan.Checked)
                {
                    Day=obj_day.Search_Day(txtSeachr_PH_HK_NTT.Text);

                    
                    dataGridView_ThuTrongTuan.DataSource = Day;
                }
            }
        }

        private void BtnXuatFileExcel_GV_Click(object sender, EventArgs e)
        {

            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRang = (Excel.Range)exSheet.Cells[1, 1];

            exRang.Range["A1:A2"].Font.Bold = true;
            exRang.Range["A1:A2"].Font.Size = 14;
            exRang.Range["A1"].Value = "Phần Mềm Quản Lí Học Sinh_Giáo Viên";
            exRang.Range["A2"].Value = "Hà Nội    Ngày: " + lbTime_MH.Text;

            exRang.Range["E4"].Font.Bold = true;
            exRang.Range["E4"].Font.Size = 22;
            exRang.Range["E4"].Value = "Danh Sách Giáo Viên";
            exRang.Range["E4"].Font.Color = Color.Red;
            
            exRang.Range["A6:F6"].Font.Bold = true;
            exRang.Range["A6:F6"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exRang.Range["B6:C6"].ColumnWidth = 20;
            exRang.Range["D6"].ColumnWidth = 10;
            exRang.Range["C6:E6:F6:G6:H6:I:J:K:L"].ColumnWidth = 20;
            exRang.Range["A6"].Value = "STT";
            exRang.Range["B6"].Value = "Họ Tên";
            exRang.Range["C6"].Value = "Ngày Sinh";
            exRang.Range["D6"].Value = "Giới Tính";
            exRang.Range["E6"].Value = "Địa Chỉ";
            exRang.Range["F6"].Value = "Số Điện Thoại";
            exRang.Range["G6"].Value = "Chức Vụ";
            exRang.Range["H6"].Value = "Quốc Tịch";
            exRang.Range["I6"].Value = "Dân Tộc";
            exRang.Range["J6"].Value = "Tôn Giáo";
            exRang.Range["K6"].Value = "Email";
            exRang.Range["L6"].Value = "Môn Học Đảm Nhiệm";
            int row = 6;
            for (int i = 0; i < dgvGiaoVien.Rows.Count - 1; i++)
            {
                row++;
                exRang.Range["A" + row.ToString()].Value = (i + 1).ToString();
                exRang.Range["B" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[1].Value.ToString();
                exRang.Range["C" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[2].Value.ToString();
                exRang.Range["D" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[3].Value.ToString();
                exRang.Range["E" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[4].Value.ToString();
                exRang.Range["F" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[5].Value.ToString();
                exRang.Range["G" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[6].Value.ToString();
                exRang.Range["H" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[7].Value.ToString();
                exRang.Range["I" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[8].Value.ToString();
                exRang.Range["J" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[9].Value.ToString();
                exRang.Range["K" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[10].Value.ToString();
                exRang.Range["L" + row.ToString()].Value = dgvGiaoVien.Rows[i].Cells[12].Value.ToString();

            }
            row = row + 2;
            exRang.Range["E" + row.ToString()].Font.Bold = true;
            exRang.Range["E" + row.ToString()].Value = "Tổng Số Giáo Viên: "+(dgvGiaoVien.Rows.Count-1);

            exSheet.Name = "Giáo Viên";
            exBook.Activate();
            SaveFileDialog svFile = new SaveFileDialog();
            if (svFile.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(svFile.FileName);
                MessageBox.Show("Đã xuất file thành công.","Chúc Mừng",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            exApp.Quit();
        }

        private void BtnXuatExel_HS_Click(object sender, EventArgs e)
        {

            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRang = (Excel.Range)exSheet.Cells[1, 1];

            exRang.Range["A1:A2"].Font.Bold = true;
            exRang.Range["A1:A2"].Font.Size = 14;
            exRang.Range["A1"].Value = "Phần Mềm Quản Lí Học Sinh_Giáo Viên";
            exRang.Range["A2"].Value = "Hà Nội    Ngày: "+lbTime_MH.Text;

            exRang.Range["E4"].Font.Bold = true;
            exRang.Range["E4"].Font.Size = 22;
            exRang.Range["E4"].Value = "Danh Sách Học Sinh  "+txtBoLoc_HS.Text+"_"+txtDoiTuongLoc_HS.Text;
            exRang.Range["E4"].Font.Color = Color.Red;

            exRang.Range["A6:F6"].Font.Bold = true;
            exRang.Range["A6:F6"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exRang.Range["B6:C6"].ColumnWidth = 20;
            exRang.Range["D6"].ColumnWidth = 10;
            exRang.Range["D6:E6:F6:G6:H6:I6:J6:K6"].ColumnWidth = 20;
            exRang.Range["A6"].Value = "STT";
            exRang.Range["B6"].Value = "ID Học Sinh";
            exRang.Range["C6"].Value = "Họ Tên";
            exRang.Range["D6"].Value = "Ngày Sinh";
            exRang.Range["E6"].Value = "Giới Tính";
            exRang.Range["F6"].Value = "Địa Chỉ";
            exRang.Range["G6"].Value = "Hạnh Kiểm";
            exRang.Range["H6"].Value = "Học Lực";
            exRang.Range["I6"].Value = "Khen Thưởng";
            exRang.Range["J6"].Value = "Kỉ Luật";
            exRang.Range["K6"].Value = "Mã Lớp";

            int row = 6;
            for (int i = 0; i < dgvHocSinh.Rows.Count - 1; i++)
            {
                row++;
                exRang.Range["A" + row.ToString()].Value = (i + 1).ToString();
                exRang.Range["B" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[0].Value.ToString();
                exRang.Range["C" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[1].Value.ToString();
                exRang.Range["D" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[2].Value.ToString();
                exRang.Range["E" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[3].Value.ToString();
                exRang.Range["F" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[4].Value.ToString();
                exRang.Range["G" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[5].Value.ToString();
                exRang.Range["H" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[6].Value.ToString();
                exRang.Range["I" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[7].Value.ToString();
                exRang.Range["J" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[8].Value.ToString();
                exRang.Range["K" + row.ToString()].Value = dgvHocSinh.Rows[i].Cells[10].Value.ToString();


            }
            row = row + 2;
            exRang.Range["E" + row.ToString()].Font.Bold = true;
            exRang.Range["E" + row.ToString()].Value = "Số Lượng: " + (dgvHocSinh.Rows.Count - 1);

            exSheet.Name = "Danh Sách Học Sinh";
            exBook.Activate();
            SaveFileDialog svFile = new SaveFileDialog();
            if (svFile.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(svFile.FileName);
                MessageBox.Show("Đã xuất file thành công.", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            exApp.Quit();
        }

        private void TxtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtDiemMieng_HSGD_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

          
            
        }

        private void TxtDiemMotTiet_HSGD_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

       

        private void TxtDiemCuoiKi_HSGD_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtDiem15Phut_HSGD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
           

        }

            private void TxtChoNgoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtSySo_Lop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuu_HS_Click(object sender, EventArgs e)
        {
            btnLuu_HS.Enabled = false;
            // sét điều kiện nếu có ID thì là thực hiện sửa, nếu ID= Rỗng thì là thêm
            if (btnThem_HS.Enabled==false)
            {
                //Đóng group ảnh
                gbAnh_HS.Enabled = false;
                if (txtHoTen_HS.Text == "" || txtNgaySinh_HS.Text == "" || txtGioiTinh_HS.Text == "" || txtDiaChi_HS.Text == "" || txtHanhKiem_HS.Text == "" || txtHocLuc_HS.Text == "" || txtKhenThuong_HS.Text == "" || txtKyLuat_HS.Text == "" || txtMaLop_HS.Text == "")
                {
                    MessageBox.Show("Bạn Nhập Thiếu Thông Tin, Yêu Cầu Nhập Lại.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TenHS = ChuanHoa(txtHoTen_HS.Text);
                    NgaySinh_HS = txtNgaySinh_HS.Text;
                    GioiTinh_HS = txtGioiTinh_HS.Text;
                    DiaChi_HS = txtDiaChi_HS.Text;
                    HanhKiem = txtHanhKiem_HS.Text;
                    HocLuc = txtHocLuc_HS.Text;
                    KhenThuong = txtKhenThuong_HS.Text;
                    KyLuat = txtKyLuat_HS.Text;

                    //MaMon = txtMonHoc.Text;
                    if (txtMaLop_HS.Text == "10A1")
                    {
                        MaLop = "1";
                    }
                    if (txtMaLop_HS.Text == "10A2")
                    {
                        MaLop = "2";
                    }
                    if (txtMaLop_HS.Text == "10A3")
                    {
                        MaLop = "3";
                    }
                    if (txtMaLop_HS.Text == "10A4")
                    {
                        MaLop = "4";
                    }
                    if (txtMaLop_HS.Text == "10A5")
                    {
                        MaLop = "5";
                    }
                    if (txtMaLop_HS.Text == "11B1")
                    {
                        MaLop = "6";
                    }
                    if (txtMaLop_HS.Text == "11B2")
                    {
                        MaLop = "7";
                    }
                    if (txtMaLop_HS.Text == "11B3")
                    {
                        MaLop = "8";
                    }
                    if (txtMaLop_HS.Text == "11B4")
                    {
                        MaLop = "9";
                    }
                    if (txtMaLop_HS.Text == "11B5")
                    {
                        MaLop = "10";
                    }
                    if (txtMaLop_HS.Text == "12C1")
                    {
                        MaLop = "11";
                    }
                    if (txtMaLop_HS.Text == "12C2")
                    {
                        MaLop = "12";
                    }
                    if (txtMaLop_HS.Text == "12C3")
                    {
                        MaLop = "13";
                    }
                    if (txtMaLop_HS.Text == "12C4")
                    {
                        MaLop = "14";
                    }
                    if (txtMaLop_HS.Text == "12C5")
                    {
                        MaLop = "15";
                    }


                    // kiểm tra điều kiện, nếu tên k có trong hệ thống thì mới cho nhập
                    if (obj_hs.Check_Name(TenHS, NgaySinh_HS, GioiTinh_HS) == false)
                    {
                        obj_hs.Insert_HS(TenHS, NgaySinh_HS, GioiTinh_HS, DiaChi_HS, HanhKiem, HocLuc, KhenThuong, KyLuat, MaLop);
                        //Load lại bảng
                        Load_SD_HS();
                        // kiểm tra xem lưu được hay không thì mới thực hiện tiếp
                        if (obj_hs.Check_Name(TenHS, NgaySinh_HS, GioiTinh_HS) == true)
                        {

                            //Load vị trí ID giáo Viên lên label
                            for (int i = 0; i < dgvHocSinh.Rows.Count - 1; i++)
                            {
                                if (txtHoTen_HS.Text == dgvHocSinh.Rows[i].Cells[1].Value.ToString() || txtNgaySinh_HS.Text == dgvHocSinh.Rows[i].Cells[2].Value.ToString() || txtGioiTinh_HS.Text == dgvHocSinh.Rows[i].Cells[3].Value.ToString())
                                {
                                    dgvHocSinh.CurrentCell = dgvHocSinh.Rows[i].Cells[1];
                                    TrungGian_HS = dgvHocSinh.Rows[i].Cells[0].Value.ToString();
                                }
                            }

                            if (MessageBox.Show("Chúc Mừng Bạn Đã Lưu Thành Công,Tiếp Theo Mời bạn chọn Ảnh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                            {
                                // mở ảnh, đóng phần nhập thông tin
                                gbAnh_HS.Enabled = true;
                                gbThongTin_HS.Enabled = false;
                                // lấy ID để lưu ảnh
                                lbID_HS.Text = TrungGian_HS;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lỗi : Yêu Cầu Của Bạn Không Được Thực Hiện, Yêu cầu thực hiện lại!.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Lỗi : Tên Đã Tồn Tại Trong Hệ Thống, Yêu Cầu Nhập Lại.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ActiveControl = txtHoTen_HS;
                    }
                }
            }
            else if(btnSua_HS.Enabled==false)
            {
                
                if (txtHoTen_HS.Text == "" || txtNgaySinh_HS.Text == "" || txtGioiTinh_HS.Text == "" || txtDiaChi_HS.Text == "" || txtHanhKiem_HS.Text == "" || txtHocLuc_HS.Text == "" || txtKhenThuong_HS.Text == "" || txtKyLuat_HS.Text == "")
                {
                    MessageBox.Show("Lỗi! Bạn Nhập Thiếu Thông Tin Yêu Cầu Bổ Sung", "Eroor!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MaHS = lbID_HS.Text;
                    TenHS = ChuanHoa(txtHoTen_HS.Text);
                    NgaySinh_HS = txtNgaySinh_HS.Text;
                    GioiTinh_HS = txtGioiTinh_HS.Text;
                    DiaChi_HS = txtDiaChi_HS.Text;
                    HanhKiem = txtHanhKiem_HS.Text;
                    HocLuc = txtHocLuc_HS.Text;
                    KhenThuong = txtKhenThuong_HS.Text;
                    KyLuat = txtKyLuat_HS.Text;
                    //MaMon = txtMonHoc.Text;
                    if (txtMaLop_HS.Text == "10A1")
                    {
                        MaLop = "1";
                    }
                    if (txtMaLop_HS.Text == "10A2")
                    {
                        MaLop = "2";
                    }
                    if (txtMaLop_HS.Text == "10A3")
                    {
                        MaLop = "3";
                    }
                    if (txtMaLop_HS.Text == "10A4")
                    {
                        MaLop = "4";
                    }
                    if (txtMaLop_HS.Text == "10A5")
                    {
                        MaLop = "5";
                    }
                    if (txtMaLop_HS.Text == "11B1")
                    {
                        MaLop = "6";
                    }
                    if (txtMaLop_HS.Text == "11B2")
                    {
                        MaLop = "7";
                    }
                    if (txtMaLop_HS.Text == "11B3")
                    {
                        MaLop = "8";
                    }
                    if (txtMaLop_HS.Text == "11B4")
                    {
                        MaLop = "9";
                    }
                    if (txtMaLop_HS.Text == "11B5")
                    {
                        MaLop = "10";
                    }
                    if (txtMaLop_HS.Text == "12C1")
                    {
                        MaLop = "11";
                    }
                    if (txtMaLop_HS.Text == "12C2")
                    {
                        MaLop = "12";
                    }
                    if (txtMaLop_HS.Text == "12C3")
                    {
                        MaLop = "13";
                    }
                    if (txtMaLop_HS.Text == "12C4")
                    {
                        MaLop = "14";
                    }
                    if (txtMaLop_HS.Text == "12C5")
                    {
                        MaLop = "15";
                    }

                    obj_hs.Update_TT_HocSinh(MaHS, TenHS, NgaySinh_HS, GioiTinh_HS, DiaChi_HS, HanhKiem, HocLuc, KhenThuong, KyLuat, MaLop);
                    SavePicture_HS(lbID_HS.Text);
                    Load_SD_HS();
                    if (MessageBox.Show("Chúc Mừng: Bạn đã Update thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        gbAnh_HS.Enabled = false;
                        gbThongTin_HS.Enabled = false;
                    }
                }
            }

            
        }

        private void txtSearch_HS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (obj_hs.Check_Search(txtSearch_HS.Text) == true)
                {
                    dtHS= obj_hs.Search(txtSearch_HS.Text);
                    dgvHocSinh.DataSource = dtHS;
                }
                else
                {
                    MessageBox.Show("Đối Tượng:    '" + txtSearch_HS.Text + "'    Không Tồn Tại Trong Hệ Thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                }

            }
        }

        /// <summary>
        /// Hàm Lưu Ảnh
        /// </summary>
        /// <param name="ID">là ID của Giáo Viên</param>
        public void SavePicture(string ID)
        {
            try
            {
                byte[] imges = null;
                FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                imges = brs.ReadBytes((int)stream.Length);



                string sqlQuery = "Update GiaoVien set Pictures_GV = @imges where MaGV =N'" + ID + "'";
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    cmd = new SqlCommand(sqlQuery, connection);
                    cmd.Parameters.Add(new SqlParameter("@imges", imges));
                    int N = cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Bạn Thêm Được: " + N.ToString() + " Ảnh");
                    pictGiaoVien.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // lưu xong load lại bảng
            dtGV = obj_gv.SelectGV();
            dgvGiaoVien.DataSource = dtGV;
        }
        /// <summary>
        /// Hàm load Lại bảng
        /// </summary>
        public void LoadTable()
        {
            //Load lại bảng
            dtGV = obj_gv.SelectGV();
            dgvGiaoVien.DataSource = dtGV;
        }
        /// <summary>
        ///  Sự Kiện Click vào nút Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
            SavePicture(lbID.Text);

        }
        /// <summary>
        /// Hàm thêm ảnh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictGiaoVien.ImageLocation = imgLocation;
            }
        }
        /// <summary>
        /// Hàm load ảnh
        /// </summary>
        /// <param name="ID"></param>
        public void Show_Picture(string ID)
        {
            try
            {
                // tạo điều kiện mà rỗng thì k hiển thị đc
                if (obj_gv.Check_Image(lbID.Text)==true)
                {
                    if (MessageBox.Show("Không Có Ảnh, Mời Bạn Thêm Ảnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)==DialogResult.OK)
                    {
                        groupBoxAnhGV.Enabled = true;
                        pictGiaoVien.Image = null;
                        btnLuu.Enabled = false;
                        btnThem.Enabled = false;
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                    }
                }
                else
                {
                    string sql = "select Pictures_GV from GiaoVien where MaGV=N'" + ID + "'";
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                        cmd = new SqlCommand(sql, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            byte[] img = (byte[])(reader[0]);
                            if (img == null)
                                pictGiaoVien.Image = null;
                            else
                            {
                                MemoryStream ms = new MemoryStream(img);
                                pictGiaoVien.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Đối Tượng Được chọn Rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                            {
                                btnThem.Enabled = true;
                            }
                        }
                        connection.Close();
                    }
                }
                dgvGiaoVien.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có chắc chắn muốn thoát????", "Chú Ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnThem_HS_Click(object sender, EventArgs e)
        {
            btnLuu_HS.Enabled = true;
            btnThem_HS.Enabled = false;
            gbThongTin_HS.Enabled = true;
            
            lbID_HS.Text = "ID";
            txtHoTen_HS.Text = "";
            txtNgaySinh_HS.Text = "";
            txtGioiTinh_HS.Text = "";
            txtDiaChi_HS.Text = "";
            txtHanhKiem_HS.Text = "";
            txtHocLuc_HS.Text = "";
            txtKhenThuong_HS.Text = "";
            txtKyLuat_HS.Text = "";
            txtMaLop_HS.Text = "";

            ActiveControl = txtHoTen_HS;
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbID_HS.Text = dgvHocSinh.CurrentRow.Cells[0].Value.ToString();
            txtHoTen_HS.Text = dgvHocSinh.CurrentRow.Cells[1].Value.ToString();
            txtNgaySinh_HS.Text = dgvHocSinh.CurrentRow.Cells[2].Value.ToString();
            txtGioiTinh_HS.Text = dgvHocSinh.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi_HS.Text = dgvHocSinh.CurrentRow.Cells[4].Value.ToString();
            txtHanhKiem_HS.Text= dgvHocSinh.CurrentRow.Cells[5].Value.ToString();
            txtHocLuc_HS.Text= dgvHocSinh.CurrentRow.Cells[6].Value.ToString();
            txtKhenThuong_HS.Text= dgvHocSinh.CurrentRow.Cells[7].Value.ToString();
            txtKyLuat_HS.Text= dgvHocSinh.CurrentRow.Cells[8].Value.ToString();
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "1")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("10A1");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "2")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("10A2");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "3")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("10A3");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "4")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("10A4");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "5")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("10A5");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "6")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("11B1");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "7")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("11B2");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "8")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("11B3");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "9")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("11B4");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "10")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("11B5");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "11")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("12C1");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "12")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("12C2");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "13")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("12C3");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "14")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("12C4");
            }
            if (dgvHocSinh.CurrentRow.Cells[10].Value.ToString() == "15")
            {
                txtMaLop_HS.Text = txtMaLop_HS.GetItemText("12C5");
            }
            //Che giấu GroupBox
            gbAnh_HS.Enabled = false;
            gbThongTin_HS.Enabled = false;
            btnThem_HS.Enabled = true;
            btnSua_HS.Enabled = true;
            btnXoa_HS.Enabled = true;
            btnLuu_HS.Enabled = true;
            btnDetail.Enabled = true;
            // Show Ảnh 
            Show_Picture_HS(lbID_HS.Text);
            // Load Điểm Học Sinh
            Load_Diem(lbID_HS.Text);
        }

        //Hàm lưu 
        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            // sét điều kiện nếu có ID thì là thực hiện sửa, nếu ID= Rỗng thì là thêm
            if (btnThem.Enabled==false)
            {
                //Đóng group ảnh
                groupBoxAnhGV.Enabled = false;
                if (txtHoTen.Text == "" || txtNgaySinh.Text == "" || txtGioiTinh.Text == ""||txtDiaChi.Text=="" || txtSDT.Text == "" || txtChucVu.Text == "" || txtQuocTich.Text == "" || txtDanToc.Text == "" || txtTonGiao.Text == "" || txtEmail.Text == "" || txtMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn Nhập Thiếu Thông Tin, Yêu Cầu Nhập Lại.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HoTen = ChuanHoa(txtHoTen.Text);
                    NgaySinh = txtNgaySinh.Text;
                    GioiTinh = txtGioiTinh.Text;
                    DiaChi = txtDiaChi.Text;
                    SDT_GV = txtSDT.Text;
                    ChucVu = txtChucVu.Text;
                    QuocTich = txtQuocTich.Text;
                    DanToc = txtDanToc.Text;
                    TonGiao = txtTonGiao.Text;
                    Email = txtEmail.Text;
                    //MaMon = txtMonHoc.Text;
                    if (txtMonHoc.Text == "Ngữ Văn")
                    {
                        MaMon = "1";
                    }
                    if (txtMonHoc.Text == "Toán")
                    {
                        MaMon = "2";
                    }
                    if (txtMonHoc.Text == "Giáo Dục Công Dân")
                    {
                        MaMon = "3";
                    }
                    if (txtMonHoc.Text == "Lịch Sử")
                    {
                        MaMon = "4";
                    }
                    if (txtMonHoc.Text == "Địa Lý")
                    {
                        MaMon = "5";
                    }
                    if (txtMonHoc.Text == "Hóa Học")
                    {
                        MaMon = "7";
                    }
                    if (txtMonHoc.Text == "Sinh Học")
                    {
                        MaMon = "8";
                    }
                    if (txtMonHoc.Text == "Công Nghệ")
                    {
                        MaMon = "9";
                    }
                    if (txtMonHoc.Text == "Tin Học")
                    {
                        MaMon = "10";
                    }
                    if (txtMonHoc.Text == "Giáo Dục Thể Chất")
                    {
                        MaMon = "11";
                    }
                    if (txtMonHoc.Text == "Tiếng Anh")
                    {
                        MaMon = "12";
                    }
                    if (txtMonHoc.Text == "Vật Lý")
                    {
                        MaMon = "6";
                    }
                    if (txtMonHoc.Text == "")
                    {
                        MaMon = "1";
                    }


                    // kiểm tra điều kiện, nếu tên k có trong hệ thống thì mới cho nhập
                    if (obj_gv.Check_Name(HoTen, NgaySinh, GioiTinh) == false)
                    {
                        obj_gv.Insert_GV(HoTen,NgaySinh,GioiTinh,DiaChi,SDT_GV,ChucVu,QuocTich,DanToc,TonGiao,Email,MaMon);
                        //Load lại bảng
                        LoadTable();
                        // kiểm tra xem lưu được hay không thì mới thực hiện tiếp
                        if (obj_gv.Check_Name(HoTen, NgaySinh, GioiTinh) == true)
                        {

                            //Load vị trí ID giáo Viên lên label
                            for (int i = 0; i < dgvGiaoVien.Rows.Count - 1; i++)
                            {
                                if (txtHoTen.Text == dgvGiaoVien.Rows[i].Cells[1].Value.ToString() || txtNgaySinh.Text == dgvGiaoVien.Rows[i].Cells[2].Value.ToString() || txtGioiTinh.Text == dgvGiaoVien.Rows[i].Cells[3].Value.ToString())
                                {
                                    dgvGiaoVien.CurrentCell = dgvGiaoVien.Rows[i].Cells[1];
                                    TrungGian = dgvGiaoVien.Rows[i].Cells[0].Value.ToString();
                                }
                            }

                            if (MessageBox.Show("Chúc Mừng Bạn Đã Lưu Thành Công,Tiếp Theo Mời bạn chọn Ảnh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                            {
                                // mở ảnh, đóng phần nhập thông tin
                                groupBoxAnhGV.Enabled = true;
                                groupBoxThongTinCaNhan.Enabled = false;
                                btnSua.Enabled = false;
                                btnXoa.Enabled = false;
                                // lấy ID để lưu ảnh
                                lbID.Text = TrungGian;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lỗi : Yêu Cầu Của Bạn Không Được Thực Hiện, Yêu cầu thực hiện lại!.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Lỗi : Tên Đã Tồn Tại Trong Hệ Thống, Yêu Cầu Nhập Lại.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ActiveControl = txtHoTen;
                    }
                }
            }
            else if(btnSua.Enabled==false)
            {
                MaGV = lbID.Text;
                HoTen = ChuanHoa(txtHoTen.Text);
                NgaySinh = txtNgaySinh.Text;
                GioiTinh = txtGioiTinh.Text;
                DiaChi = txtDiaChi.Text;
                SDT_GV = txtSDT.Text;
                ChucVu = txtChucVu.Text;
                QuocTich = txtQuocTich.Text;
                DanToc = txtDanToc.Text;
                TonGiao = txtTonGiao.Text;
                Email = txtEmail.Text;
                //MaMon = txtMonHoc.Text;
                if(txtMonHoc.Text == "Ngữ Văn")
                {
                    MaMon = "1";
                }
                if (txtMonHoc.Text == "Toán")
                {
                    MaMon = "2";
                }
                if (txtMonHoc.Text == "Giáo Dục Công Dân")
                {
                    MaMon = "3";
                }
                if (txtMonHoc.Text == "Lịch Sử")
                {
                    MaMon = "4";
                }
                if (txtMonHoc.Text == "Địa Lý")
                {
                    MaMon = "5";
                }
                if (txtMonHoc.Text == "Hóa Học")
                {
                    MaMon = "7";
                }
                if (txtMonHoc.Text == "Sinh Học")
                {
                    MaMon = "8";
                }
                if (txtMonHoc.Text == "Công Nghệ")
                {
                    MaMon = "9";
                }
                if (txtMonHoc.Text == "Tin Học")
                {
                    MaMon = "10";
                }
                if (txtMonHoc.Text == "Giáo Dục Thể Chất")
                {
                    MaMon = "11";
                }
                if (txtMonHoc.Text == "Tiếng Anh")
                {
                    MaMon = "12";
                }
                if (txtMonHoc.Text == "Vật Lý")
                {
                    MaMon = "6";
                }

                obj_gv.Update_TT_GiaoVien(MaGV,HoTen, NgaySinh, GioiTinh, DiaChi, SDT_GV, ChucVu, QuocTich, DanToc, TonGiao, Email, MaMon);
                SavePicture(lbID.Text);
                LoadTable();
                if (MessageBox.Show("Chúc Mừng: Bạn đã Update thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    groupBoxAnhGV.Enabled = false;
                    groupBoxThongTinCaNhan.Enabled = false;
                }
            }
           
        }
        /// <summary>
        /// Sự kiện click vào bảng GV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbID.Text = dgvGiaoVien.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgvGiaoVien.CurrentRow.Cells[1].Value.ToString();
            txtNgaySinh.Text = dgvGiaoVien.CurrentRow.Cells[2].Value.ToString();
            txtGioiTinh.Text = dgvGiaoVien.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgvGiaoVien.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dgvGiaoVien.CurrentRow.Cells[5].Value.ToString();
            txtChucVu.Text = dgvGiaoVien.CurrentRow.Cells[6].Value.ToString();
            txtQuocTich.Text = dgvGiaoVien.CurrentRow.Cells[7].Value.ToString();
            txtDanToc.Text = dgvGiaoVien.CurrentRow.Cells[8].Value.ToString();
            txtTonGiao.Text = dgvGiaoVien.CurrentRow.Cells[9].Value.ToString();
            txtEmail.Text = dgvGiaoVien.CurrentRow.Cells[10].Value.ToString();
            // Mở Các Nút Thêm-Sửa-Xóa
            

            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "1")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Ngữ Văn");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "2")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Toán");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "3")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Giáo Dục Công Dân");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "4")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Lịch Sử");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "5")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Địa Lý");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "6")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Vật Lý");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "7")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Hóa Học");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "8")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Sinh Học");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "9")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Công Nghệ");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "10")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Tin Học");

            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "11")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Giáo Dục Thể Chất");
            }
            if (dgvGiaoVien.CurrentRow.Cells[12].Value.ToString() == "11")
            {
                txtMonHoc.Text = txtMonHoc.GetItemText("Tiếng Anh");
            }
            //Che giấu GroupBox
            groupBoxThongTinCaNhan.Enabled = false;
            groupBoxAnhGV.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Show Ảnh 
            Show_Picture(lbID.Text);
            

        }
        //

       

        /// <summary>
        /// Hàm thời gian
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmtTime_Tick(object sender, EventArgs e)
        {
            DateTime tm = DateTime.Now;
            lbTime.Text = tm.ToString("dd/MM/yyyy | hh:mm:ss");
            lbTime_MH.Text= tm.ToString("dd/MM/yyyy | hh:mm:ss");
        }



        /// <summary>
        /// Hàm tìm kiếm 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void pageHoSoGV_Click(object sender, EventArgs e)
        {
            
        }

        private void pageHoSoHS_Click(object sender, EventArgs e)
        {
            
        }

        private void pageHoSoGiangDay_Click(object sender, EventArgs e)
        {
            
        }

        private void pagePhongHoc_Click(object sender, EventArgs e)
        {

        }

        private void pageMonHoc_Click(object sender, EventArgs e)
        {

        }

        private void pageLopHoc_Click(object sender, EventArgs e)
        {

        }

        private void tabpDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
