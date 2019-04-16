using BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QL_HSGVTHPT
{
    public partial class frmDanhMuc : Form
    {
        frmDM_GiaoVien obj_gv = new frmDM_GiaoVien();
        frmHocSinh obj_hs = new frmHocSinh();
        DataTable dtGV = new DataTable();
        DataTable dtGV_HS = new DataTable();
        DataTable dtDiemHS = new DataTable();
       


        private string TrungGian="";
        private string TrungGian_HS = "";
        private string MaGV,HoTen, NgaySinh, GioiTinh, DiaChi, SDT_GV, ChucVu, QuocTich, DanToc, TonGiao, Email, MaMon;
        private string MaHS,TenHS, NgaySinh_HS, GioiTinh_HS, DiaChi_HS, HanhKiem, HocLuc, KhenThuong, KyLuat,MaLop;
        private string imgLocation = "";
        public int str;
        // kết nối với SQL để lưu file ảnh
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HFIR0F6;Initial Catalog=QL_GVHSTHPT;Integrated Security=True");
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

            // Khi load form thì vị trí con trỏ nằm trên thanh tìm kiếm
            ActiveControl = txtSearch;


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
            
            chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].YValueMembers = "DiemKH";
            chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].XValueMember = "MaHocKi";
          
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
         
        //int n = dgvGiaoVien.Rows.Count -1;
        // mở Group để thao tác
            groupBoxThongTinCaNhan.Enabled = true;
        //Tăng ID lên 1
        //   lbID.Text = Convert.ToString(n+1);
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
                            MessageBox.Show("Đối Tượng Được chọn Rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                for (int i = 0; i < dgvGiaoVien.Rows.Count - 1; i++)
                {
                    if (ChuanHoa(txtSearch.Text) == dgvGiaoVien.Rows[i].Cells[1].Value.ToString())
                    {
                        dgvGiaoVien.CurrentCell = dgvGiaoVien.Rows[i].Cells[1];
                    }
                    else
                    {
                        MessageBox.Show("Không Tìm Thấy: '" + txtSearch.Text + "' Trong Hệ Thống.", "Thông Báo :", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                }
            }
        }

        private void btnSua_HS_Click(object sender, EventArgs e)
        {
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
                    Load_SD_HS();
                }
            }
        }

        private void btnExit_HS_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_HS_Click(object sender, EventArgs e)
        {
            // sét điều kiện nếu có ID thì là thực hiện sửa, nếu ID= Rỗng thì là thêm
            if (lbID_HS.Text == "ID")
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
            else
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
                for (int i = 0; i < dgvHocSinh.Rows.Count - 1; i++)
                {
                    if (ChuanHoa(txtSearch_HS.Text) == dgvHocSinh.Rows[i].Cells[1].Value.ToString())
                    {
                        dgvHocSinh.CurrentCell = dgvHocSinh.Rows[i].Cells[1];
                    }
                    else
                    {
                        MessageBox.Show("Không Tìm Thấy: '" + txtSearch_HS.Text + "' Trong Hệ Thống.", "Thông Báo :", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
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
                            MessageBox.Show("Đối Tượng Được chọn Rỗng","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
            Close();
        }

        private void btnThem_HS_Click(object sender, EventArgs e)
        {

           
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
            // Show Ảnh 
            Show_Picture_HS(lbID_HS.Text);
            // Load Điểm Học Sinh
            Load_Diem(lbID_HS.Text);
        }

        //Hàm lưu 
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // sét điều kiện nếu có ID thì là thực hiện sửa, nếu ID= Rỗng thì là thêm
            if (lbID.Text == "ID")
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
            else
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
            //  txtMonHoc.Text = dgvGiaoVien.CurrentRow.Cells[12].Value.ToString();
            

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
            // Show Ảnh 
            Show_Picture(lbID.Text);
            // show ra GrouBoxThongTinNhanVien Khi click vào bảng GV
            //groupBoxThongTinCaNhan.Visible = true;

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
