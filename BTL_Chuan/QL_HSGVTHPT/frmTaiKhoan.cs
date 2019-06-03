using BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace QL_HSGVTHPT
{
    public partial class frmTaiKhoan : Form
    {
        private string _HoTen;

        frmTaiKhoanDangNhap obj_tk = new frmTaiKhoanDangNhap();
        DataTable DS = new DataTable();

        

        public frmTaiKhoan(string Name)
        {
            InitializeComponent();
            this._HoTen = Name;
            lbName.Text = _HoTen;
            Show_Picture(_HoTen);
            Status();
            Load_DS();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-G1AOD02;Initial Catalog=QL_GVHSTHPT;Integrated Security=True");
        SqlCommand cmd;
        public void Load_DS()
        {
            DS = obj_tk.Select_DS();
            dgvDS_TaiKhoan.DataSource = DS;
        }
        public void Status()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = false;
            groupBoxThongTin.Enabled = false;
            groupBox2.Enabled = false;
            if(_HoTen=="Admin"|| _HoTen == "admin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                groupBox2.Enabled = true;
            }
        }
        public void Show_Picture(string HoTen)
        {
            try
            {
                // tạo điều kiện mà rỗng thì k hiển thị đc
                if (obj_tk.Check_Image(HoTen) == false)
                {
                    Picture_TaiKhoan.Image = null;
                }
                else
                {
                    string sql = "select Pictures_GV from GiaoVien where HoTen=N'" + HoTen + "'";
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
                                Picture_TaiKhoan.Image = null;
                            else
                            {
                                MemoryStream ms = new MemoryStream(img);
                                Picture_TaiKhoan.Image = Image.FromStream(ms);
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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActiveControl = txtMatKhauCu;
            }
        }

        private void TxtMatKhauCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (obj_tk.Check_PassWord(txtMatKhauCu.Text) == false)
                {
                    MessageBox.Show("Bạn Nhập Sai Mật Khẩu Cũ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = txtMatKhauCu;
                }
                else
                {
                    ActiveControl = txtPassWord1;
                }
            }
            
        }

        private void TxtPassWord1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActiveControl = txtPassWord2;
            }
        }

        private void TxtPassWord2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtPassWord1.Text != txtPassWord2.Text)
                {
                    MessageBox.Show("Bạn Nhập Sai Mật Khẩu Mới,Yêu Cầu Nhập Lại!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = txtPassWord2;
                }
                else if(btnSua.Enabled==false)
                {
                    obj_tk.Update_MK(_HoTen, txtName.Text, txtPassWord2.Text);
                    if(MessageBox.Show("Bạn đổi mật khẩu thành công!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)==DialogResult.OK)
                    {
                        txtName.Text = "";
                        txtPassWord1.Text = "";
                        txtPassWord2.Text = "";
                        txtMatKhauCu.Text = "";
                        btnSua.Enabled = true;
                    }
                }
                else if(btnThem.Enabled==false && _HoTen=="Admin")
                {
                    obj_tk.Insert(txtName.Text, txtPassWord2.Text,"Giáo Viên");
                    if (MessageBox.Show("Thêm Tài Khoản Thành Công!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        txtName.Text = "";
                        txtPassWord1.Text = "";
                        txtPassWord2.Text = "";
                        Load_DS();
                        btnThem.Enabled = true;
                    }
                }
            }
        }

        private void DgvDS_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvDS_TaiKhoan.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            groupBoxThongTin.Enabled = true;
            btnSua.Enabled = false;
            txtName.Text = _HoTen;
            ActiveControl = txtName;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            groupBoxThongTin.Enabled = true;
            txtMatKhauCu.Enabled = false;

        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            if (txtName ==null)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng nào để XÓA!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = txtName;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn XÓA???", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    obj_tk.Delete(txtName.Text);
                    Load_DS();
                    txtName.Text = "";
                    btnXoa.Enabled = true;
                }
            }
        }
    }
}
