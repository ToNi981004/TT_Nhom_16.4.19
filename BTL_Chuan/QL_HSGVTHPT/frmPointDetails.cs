using BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QL_HSGVTHPT
{
    public partial class frmPointDetails : Form
    {
        frmHocSinh obj_hs = new frmHocSinh();
        private string _IDSH;
        private string _Ten;
        private string _Ngay;
        private string _HanhKiem;
        private string _HocLuc;
        private string _Lop;


        DataTable dtDS_MonHoc = new DataTable();
        DataTable dtDiemHS = new DataTable();
        DataTable dtDSHocKi = new DataTable();
        DataTable dtDiemTBHK = new DataTable();
        DataTable dtLoadDoThiDiem = new DataTable();
        DataTable dtLoadBangDiem = new DataTable();

        public frmPointDetails(string ID,string Ten,string Ngay,string HocLuc,string HanhKiem,string Lop)
        {
            this._IDSH = ID;
            this._Ten = Ten;
            this._Ngay = Ngay;
            this._HanhKiem = HanhKiem;
            this._HocLuc = HocLuc;
            this._Lop = Lop;
            // Show Lên
            
            InitializeComponent();
            Load_Diem(_IDSH);
            Show_Picture_HS(_IDSH);
            lbName.Text = _Ten;
            lbNgaySinh.Text = _Ngay;
            lbHanhKiem.Text = _HanhKiem;
            lbHocLuc.Text = _HocLuc;
            lbLop.Text = _Lop;
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-G1AOD02;Initial Catalog=QL_GVHSTHPT;Integrated Security=True");
        SqlCommand cmd;
        public void Show_Picture_HS(string ID)
        {
            try
            {
                // tạo điều kiện mà rỗng thì k hiển thị đc
                if (obj_hs.Check_Image(_IDSH) == true)
                {
                    pictureAnhHS.Image = null;
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
                       
                        connection.Close();
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Load_Diem(string ID)
        {

            chartDiemHK_HS.ChartAreas["ChartArea1"].AxisX.Title = "Học Kỳ";

            dtDiemHS = obj_hs.DiemTB_HK(ID);
            chartDiemHK_HS.DataSource = dtDiemHS;

            chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].YValueMembers = "DiemKH";
            chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].XValueMember = "MaHocKi";
            chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].Label = "";


            //chartDiemHK_HS.Series["Diểm Trung Bình Học Kì"].Points[]

        }

      
        private void TxtDiem_MonHoc_Click(object sender, EventArgs e)
        {
            dtDS_MonHoc = obj_hs.select_DSMonHoc(_IDSH,txtDiem_HocKi.Text);
            txtDiem_MonHoc.DataSource = dtDS_MonHoc;
            txtDiem_MonHoc.DisplayMember = "TenMon";

        }

        private void TxtDiem_HocKi_SelectedIndexChanged(object sender, EventArgs e)
        {


            dtDiemTBHK = obj_hs.DiemTB_HK_HS(_IDSH, txtDiem_HocKi.Text);
            comboBox1.DataSource = dtDiemTBHK;
            comboBox1.DisplayMember = "DiemKH";


            // đổ dl vào đồ thị
            dtLoadDoThiDiem = obj_hs.Load_DoThiDiem(_IDSH,txtDiem_HocKi.Text);
            chartDiemTheoHocKi.DataSource = dtLoadDoThiDiem;
            chartDiemTheoHocKi.Series["Điểm Trung Bình Môn Học"].XValueMember = "TenMon";
            chartDiemTheoHocKi.Series["Điểm Trung Bình Môn Học"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chartDiemTheoHocKi.Series["Điểm Trung Bình Môn Học"].YValueMembers = "DiemTB";
            chartDiemTheoHocKi.Series["Điểm Trung Bình Môn Học"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        }

        private void TxtDiem_HocKi_Click(object sender, EventArgs e)
        { 
            dtDSHocKi = obj_hs.DiemTB_HK_CuaHS(_IDSH);
            txtDiem_HocKi.DataSource = dtDSHocKi;
            txtDiem_HocKi.DisplayMember = "NamHoc";
           
            
        }

        private void TxtDiem_MonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            dtLoadBangDiem = obj_hs.Load_BangDiem(_IDSH, txtDiem_HocKi.Text, txtDiem_MonHoc.Text);
            dgvDiem_MonHoc.DataSource = dtLoadBangDiem;

            
        }

        private void BtnExit_HS_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Bạn Có Muốn Thoát???","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Close();
            }
        }
    }

}
