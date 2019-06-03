namespace QL_HSGVTHPT
{
    partial class frmThoiKhoaBieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer timer_TKB;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThoiKhoaBieu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTG_KT = new System.Windows.Forms.ComboBox();
            this.txtTG_BĐ = new System.Windows.Forms.ComboBox();
            this.txtPhongHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTietHoc = new System.Windows.Forms.ComboBox();
            this.txtGiaoVien = new System.Windows.Forms.ComboBox();
            this.txtMonHoc = new System.Windows.Forms.ComboBox();
            this.txtThu = new System.Windows.Forms.ComboBox();
            this.txtSoTiet = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_ThoiKhoaBieu = new System.Windows.Forms.DataGridView();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnDangKiPhongMay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.txtDS_Lop = new System.Windows.Forms.ComboBox();
            this.lbTime_TKB = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            timer_TKB = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThoiKhoaBieu)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_TKB
            // 
            timer_TKB.Enabled = true;
            timer_TKB.Interval = 1000;
            timer_TKB.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.txtTG_KT);
            this.groupBox1.Controls.Add(this.txtTG_BĐ);
            this.groupBox1.Controls.Add(this.txtPhongHoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTietHoc);
            this.groupBox1.Controls.Add(this.txtGiaoVien);
            this.groupBox1.Controls.Add(this.txtMonHoc);
            this.groupBox1.Controls.Add(this.txtThu);
            this.groupBox1.Controls.Add(this.txtSoTiet);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin:";
            // 
            // txtTG_KT
            // 
            this.txtTG_KT.FormattingEnabled = true;
            this.txtTG_KT.Location = new System.Drawing.Point(656, 67);
            this.txtTG_KT.Name = "txtTG_KT";
            this.txtTG_KT.Size = new System.Drawing.Size(271, 30);
            this.txtTG_KT.TabIndex = 29;
            // 
            // txtTG_BĐ
            // 
            this.txtTG_BĐ.FormattingEnabled = true;
            this.txtTG_BĐ.Location = new System.Drawing.Point(656, 21);
            this.txtTG_BĐ.Name = "txtTG_BĐ";
            this.txtTG_BĐ.Size = new System.Drawing.Size(271, 30);
            this.txtTG_BĐ.TabIndex = 29;
            // 
            // txtPhongHoc
            // 
            this.txtPhongHoc.FormattingEnabled = true;
            this.txtPhongHoc.Location = new System.Drawing.Point(151, 212);
            this.txtPhongHoc.Name = "txtPhongHoc";
            this.txtPhongHoc.Size = new System.Drawing.Size(271, 30);
            this.txtPhongHoc.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 27;
            this.label3.Text = "5.Phòng Học:";
            // 
            // txtLop
            // 
            this.txtLop.FormattingEnabled = true;
            this.txtLop.Location = new System.Drawing.Point(656, 164);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(271, 30);
            this.txtLop.TabIndex = 26;
            this.txtLop.SelectedIndexChanged += new System.EventHandler(this.TxtLop_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "9. Lớp:";
            // 
            // txtTietHoc
            // 
            this.txtTietHoc.FormattingEnabled = true;
            this.txtTietHoc.Location = new System.Drawing.Point(151, 160);
            this.txtTietHoc.Name = "txtTietHoc";
            this.txtTietHoc.Size = new System.Drawing.Size(271, 30);
            this.txtTietHoc.TabIndex = 24;
            this.txtTietHoc.SelectedIndexChanged += new System.EventHandler(this.TxtTietHoc_SelectedIndexChanged);
            // 
            // txtGiaoVien
            // 
            this.txtGiaoVien.FormattingEnabled = true;
            this.txtGiaoVien.Location = new System.Drawing.Point(151, 115);
            this.txtGiaoVien.Name = "txtGiaoVien";
            this.txtGiaoVien.Size = new System.Drawing.Size(271, 30);
            this.txtGiaoVien.TabIndex = 24;
            // 
            // txtMonHoc
            // 
            this.txtMonHoc.FormattingEnabled = true;
            this.txtMonHoc.Location = new System.Drawing.Point(151, 68);
            this.txtMonHoc.Name = "txtMonHoc";
            this.txtMonHoc.Size = new System.Drawing.Size(271, 30);
            this.txtMonHoc.TabIndex = 23;
            this.txtMonHoc.SelectedIndexChanged += new System.EventHandler(this.TxtMonHoc_SelectedIndexChanged);
            // 
            // txtThu
            // 
            this.txtThu.FormattingEnabled = true;
            this.txtThu.Location = new System.Drawing.Point(151, 22);
            this.txtThu.Name = "txtThu";
            this.txtThu.Size = new System.Drawing.Size(271, 30);
            this.txtThu.TabIndex = 22;
            // 
            // txtSoTiet
            // 
            this.txtSoTiet.Location = new System.Drawing.Point(656, 117);
            this.txtSoTiet.Name = "txtSoTiet";
            this.txtSoTiet.Size = new System.Drawing.Size(271, 29);
            this.txtSoTiet.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(447, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(195, 22);
            this.label15.TabIndex = 8;
            this.label15.Text = "7.Thời Gian Kêt Thúc:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(447, 117);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(94, 22);
            this.label29.TabIndex = 9;
            this.label29.Text = "8. So Tiet:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(20, 71);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(111, 22);
            this.label30.TabIndex = 10;
            this.label30.Text = "2. Môn Học:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "4. Tiết Học";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(20, 30);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(69, 22);
            this.label31.TabIndex = 11;
            this.label31.Text = "1. Thứ:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(20, 118);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(116, 22);
            this.label32.TabIndex = 12;
            this.label32.Text = "3. Giáo Viên:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(447, 29);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(182, 22);
            this.label33.TabIndex = 13;
            this.label33.Text = "6.Thời gian Bắt Đầu:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.dgv_ThoiKhoaBieu);
            this.groupBox2.Location = new System.Drawing.Point(12, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1594, 507);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thời Khóa Biểu Lớp:";
            // 
            // dgv_ThoiKhoaBieu
            // 
            this.dgv_ThoiKhoaBieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ThoiKhoaBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ThoiKhoaBieu.Location = new System.Drawing.Point(19, 28);
            this.dgv_ThoiKhoaBieu.Name = "dgv_ThoiKhoaBieu";
            this.dgv_ThoiKhoaBieu.Size = new System.Drawing.Size(1554, 462);
            this.dgv_ThoiKhoaBieu.TabIndex = 1;
            this.dgv_ThoiKhoaBieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_ThoiKhoaBieu_CellClick);
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.LightGray;
            this.groupBox11.Controls.Add(this.btnDangKiPhongMay);
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.Controls.Add(this.btnXuatExcel);
            this.groupBox11.Controls.Add(this.btnLuu);
            this.groupBox11.Controls.Add(this.button2);
            this.groupBox11.Controls.Add(this.btnExit);
            this.groupBox11.Controls.Add(this.txtSearch);
            this.groupBox11.Controls.Add(this.btnThem);
            this.groupBox11.Controls.Add(this.btnXoa);
            this.groupBox11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(12, 281);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(1594, 84);
            this.groupBox11.TabIndex = 9;
            this.groupBox11.TabStop = false;
            // 
            // btnDangKiPhongMay
            // 
            this.btnDangKiPhongMay.Image = global::QL_HSGVTHPT.Properties.Resources.date_time_settings;
            this.btnDangKiPhongMay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangKiPhongMay.Location = new System.Drawing.Point(828, 15);
            this.btnDangKiPhongMay.Name = "btnDangKiPhongMay";
            this.btnDangKiPhongMay.Size = new System.Drawing.Size(220, 61);
            this.btnDangKiPhongMay.TabIndex = 53;
            this.btnDangKiPhongMay.Text = "Đăng Kí Phòng Máy";
            this.btnDangKiPhongMay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangKiPhongMay.UseVisualStyleBackColor = true;
            this.btnDangKiPhongMay.Click += new System.EventHandler(this.BtnDangKiPhongMay_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 19);
            this.label6.TabIndex = 52;
            this.label6.Text = "( Tìm Kiếm Theo Tên Lớp)";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Image = global::QL_HSGVTHPT.Properties.Resources.file_excel;
            this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatExcel.Location = new System.Drawing.Point(1054, 15);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(164, 61);
            this.btnXuatExcel.TabIndex = 29;
            this.btnXuatExcel.Text = "Xuất File Excel";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.BtnXuatExcel_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1224, 17);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(83, 60);
            this.btnLuu.TabIndex = 51;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Search :";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1491, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 60);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(321, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(501, 26);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(1313, 16);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(83, 60);
            this.btnThem.TabIndex = 46;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(1402, 17);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(83, 60);
            this.btnXoa.TabIndex = 48;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Controls.Add(this.txtDS_Lop);
            this.groupBox3.Controls.Add(this.lbTime_TKB);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label46);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(970, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(636, 270);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(291, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Hotline: 094343689           https://myedu.vn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(422, 22);
            this.label7.TabIndex = 29;
            this.label7.Text = "PHẦN MỀM QUẢN LÝ TRƯỜNG HỌC MYEDU";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(73, 232);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(78, 22);
            this.label51.TabIndex = 13;
            this.label51.Text = "HÀ NỘI";
            // 
            // txtDS_Lop
            // 
            this.txtDS_Lop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDS_Lop.FormattingEnabled = true;
            this.txtDS_Lop.Location = new System.Drawing.Point(239, 156);
            this.txtDS_Lop.Name = "txtDS_Lop";
            this.txtDS_Lop.Size = new System.Drawing.Size(243, 30);
            this.txtDS_Lop.TabIndex = 28;
            this.txtDS_Lop.SelectedIndexChanged += new System.EventHandler(this.TxtDS_Lop_SelectedIndexChanged);
            this.txtDS_Lop.TextChanged += new System.EventHandler(this.TxtDS_Lop_TextChanged);
            // 
            // lbTime_TKB
            // 
            this.lbTime_TKB.AutoSize = true;
            this.lbTime_TKB.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime_TKB.Location = new System.Drawing.Point(285, 225);
            this.lbTime_TKB.Name = "lbTime_TKB";
            this.lbTime_TKB.Size = new System.Drawing.Size(68, 31);
            this.lbTime_TKB.TabIndex = 11;
            this.lbTime_TKB.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 40);
            this.label5.TabIndex = 27;
            this.label5.Text = "THỜI KHÓA BIỂU";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(157, 232);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(109, 22);
            this.label46.TabIndex = 12;
            this.label46.Text = "Ngày / Giờ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 22);
            this.label4.TabIndex = 27;
            this.label4.Text = "LỚP:";
            // 
            // frmThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1618, 890);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "frmThoiKhoaBieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThoiKhoaBieu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThoiKhoaBieu)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgv_ThoiKhoaBieu;
        private System.Windows.Forms.TextBox txtSoTiet;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox txtPhongHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtTietHoc;
        private System.Windows.Forms.ComboBox txtGiaoVien;
        private System.Windows.Forms.ComboBox txtMonHoc;
        private System.Windows.Forms.ComboBox txtThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox txtDS_Lop;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lbTime_TKB;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtTG_KT;
        private System.Windows.Forms.ComboBox txtTG_BĐ;
        private System.Windows.Forms.Button btnDangKiPhongMay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}