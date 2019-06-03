namespace QL_HSGVTHPT
{
    partial class frmHoSoGiangDay
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
            this.tabControlHoSoGD = new System.Windows.Forms.TabControl();
            this.tabPageNhapDiem = new System.Windows.Forms.TabPage();
            this.gbDS = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonSuaDiem = new System.Windows.Forms.RadioButton();
            this.radioButtonNhapDiem = new System.Windows.Forms.RadioButton();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbDiem = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiem1Tiet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiem15Phut = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiemMieng = new System.Windows.Forms.TextBox();
            this.txtDiemHocKi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHocSinh = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHocKi = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDSMonHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDSLop = new System.Windows.Forms.ComboBox();
            this.radioButtonHocSinh = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonMonHoc = new System.Windows.Forms.RadioButton();
            this.tabPageThongKeDiem = new System.Windows.Forms.TabPage();
            this.tabControlHoSoGD.SuspendLayout();
            this.tabPageNhapDiem.SuspendLayout();
            this.gbDS.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbDiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlHoSoGD
            // 
            this.tabControlHoSoGD.Controls.Add(this.tabPageNhapDiem);
            this.tabControlHoSoGD.Controls.Add(this.tabPageThongKeDiem);
            this.tabControlHoSoGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlHoSoGD.Location = new System.Drawing.Point(0, 0);
            this.tabControlHoSoGD.Name = "tabControlHoSoGD";
            this.tabControlHoSoGD.SelectedIndex = 0;
            this.tabControlHoSoGD.Size = new System.Drawing.Size(1437, 684);
            this.tabControlHoSoGD.TabIndex = 0;
            // 
            // tabPageNhapDiem
            // 
            this.tabPageNhapDiem.Controls.Add(this.gbDS);
            this.tabPageNhapDiem.Controls.Add(this.groupBox2);
            this.tabPageNhapDiem.Controls.Add(this.groupBox1);
            this.tabPageNhapDiem.Location = new System.Drawing.Point(4, 31);
            this.tabPageNhapDiem.Name = "tabPageNhapDiem";
            this.tabPageNhapDiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNhapDiem.Size = new System.Drawing.Size(1429, 649);
            this.tabPageNhapDiem.TabIndex = 0;
            this.tabPageNhapDiem.Text = "Nhập Điểm";
            this.tabPageNhapDiem.UseVisualStyleBackColor = true;
            // 
            // gbDS
            // 
            this.gbDS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbDS.Controls.Add(this.groupBox3);
            this.gbDS.Controls.Add(this.dgvDS);
            this.gbDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDS.Location = new System.Drawing.Point(507, 3);
            this.gbDS.Name = "gbDS";
            this.gbDS.Size = new System.Drawing.Size(315, 643);
            this.gbDS.TabIndex = 2;
            this.gbDS.TabStop = false;
            this.gbDS.Text = "Danh Sách:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.radioButtonSuaDiem);
            this.groupBox3.Controls.Add(this.radioButtonNhapDiem);
            this.groupBox3.Location = new System.Drawing.Point(25, 550);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 87);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lựa Chọn Tính Năng:";
            // 
            // radioButtonSuaDiem
            // 
            this.radioButtonSuaDiem.AutoSize = true;
            this.radioButtonSuaDiem.Location = new System.Drawing.Point(152, 37);
            this.radioButtonSuaDiem.Name = "radioButtonSuaDiem";
            this.radioButtonSuaDiem.Size = new System.Drawing.Size(108, 26);
            this.radioButtonSuaDiem.TabIndex = 12;
            this.radioButtonSuaDiem.TabStop = true;
            this.radioButtonSuaDiem.Text = "Sửa Điểm";
            this.radioButtonSuaDiem.UseVisualStyleBackColor = true;
            // 
            // radioButtonNhapDiem
            // 
            this.radioButtonNhapDiem.AutoSize = true;
            this.radioButtonNhapDiem.Location = new System.Drawing.Point(6, 37);
            this.radioButtonNhapDiem.Name = "radioButtonNhapDiem";
            this.radioButtonNhapDiem.Size = new System.Drawing.Size(120, 26);
            this.radioButtonNhapDiem.TabIndex = 13;
            this.radioButtonNhapDiem.TabStop = true;
            this.radioButtonNhapDiem.Text = "Nhập Điểm";
            this.radioButtonNhapDiem.UseVisualStyleBackColor = true;
            // 
            // dgvDS
            // 
            this.dgvDS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Location = new System.Drawing.Point(25, 28);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(266, 500);
            this.dgvDS.TabIndex = 1;
            this.dgvDS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDS_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.dgvBangDiem);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(822, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 643);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng Điểm :";
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangDiem.Location = new System.Drawing.Point(24, 28);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.Size = new System.Drawing.Size(560, 588);
            this.dgvBangDiem.TabIndex = 1;
            this.dgvBangDiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBangDiem_CellClick);
            this.dgvBangDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBangDiem_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.gbDiem);
            this.groupBox1.Controls.Add(this.txtHocSinh);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtHocKi);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDSMonHoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDSLop);
            this.groupBox1.Controls.Add(this.radioButtonHocSinh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonMonHoc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 643);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin :";
            // 
            // gbDiem
            // 
            this.gbDiem.BackColor = System.Drawing.Color.Gainsboro;
            this.gbDiem.Controls.Add(this.label10);
            this.gbDiem.Controls.Add(this.lbID);
            this.gbDiem.Controls.Add(this.btnNext);
            this.gbDiem.Controls.Add(this.label5);
            this.gbDiem.Controls.Add(this.txtDiem1Tiet);
            this.gbDiem.Controls.Add(this.label4);
            this.gbDiem.Controls.Add(this.txtDiem15Phut);
            this.gbDiem.Controls.Add(this.label6);
            this.gbDiem.Controls.Add(this.txtDiemMieng);
            this.gbDiem.Controls.Add(this.txtDiemHocKi);
            this.gbDiem.Controls.Add(this.label7);
            this.gbDiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbDiem.Location = new System.Drawing.Point(3, 325);
            this.gbDiem.Name = "gbDiem";
            this.gbDiem.Size = new System.Drawing.Size(498, 315);
            this.gbDiem.TabIndex = 13;
            this.gbDiem.TabStop = false;
            this.gbDiem.Text = "ĐIỂM:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 22);
            this.label10.TabIndex = 11;
            this.label10.Text = "ID :";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(327, 16);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(31, 22);
            this.lbID.TabIndex = 10;
            this.lbID.Text = "ID";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(252, 259);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(156, 32);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            this.btnNext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnNext_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "8. Điểm Một Tiết";
            // 
            // txtDiem1Tiet
            // 
            this.txtDiem1Tiet.Location = new System.Drawing.Point(196, 155);
            this.txtDiem1Tiet.Name = "txtDiem1Tiet";
            this.txtDiem1Tiet.Size = new System.Drawing.Size(261, 29);
            this.txtDiem1Tiet.TabIndex = 7;
            this.txtDiem1Tiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDiem1Tiet_KeyDown);
            this.txtDiem1Tiet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiem1Tiet_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "6. Điểm 15 Phút:";
            // 
            // txtDiem15Phut
            // 
            this.txtDiem15Phut.Location = new System.Drawing.Point(196, 54);
            this.txtDiem15Phut.Name = "txtDiem15Phut";
            this.txtDiem15Phut.Size = new System.Drawing.Size(261, 29);
            this.txtDiem15Phut.TabIndex = 7;
            this.txtDiem15Phut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDiem15Phut_KeyDown);
            this.txtDiem15Phut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiem15Phut_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "7. Điểm Miệng:";
            // 
            // txtDiemMieng
            // 
            this.txtDiemMieng.Location = new System.Drawing.Point(196, 108);
            this.txtDiemMieng.Name = "txtDiemMieng";
            this.txtDiemMieng.Size = new System.Drawing.Size(261, 29);
            this.txtDiemMieng.TabIndex = 7;
            this.txtDiemMieng.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDiemMieng_KeyDown);
            this.txtDiemMieng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiemMieng_KeyPress);
            // 
            // txtDiemHocKi
            // 
            this.txtDiemHocKi.Location = new System.Drawing.Point(196, 206);
            this.txtDiemHocKi.Name = "txtDiemHocKi";
            this.txtDiemHocKi.Size = new System.Drawing.Size(261, 29);
            this.txtDiemHocKi.TabIndex = 7;
            this.txtDiemHocKi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDiemHocKi_KeyDown);
            this.txtDiemHocKi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiemHocKi_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "9. Điểm Học KÌ:";
            // 
            // txtHocSinh
            // 
            this.txtHocSinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtHocSinh.FormattingEnabled = true;
            this.txtHocSinh.Location = new System.Drawing.Point(137, 272);
            this.txtHocSinh.Name = "txtHocSinh";
            this.txtHocSinh.Size = new System.Drawing.Size(304, 30);
            this.txtHocSinh.TabIndex = 12;
            this.txtHocSinh.SelectedIndexChanged += new System.EventHandler(this.TxtHocSinh_SelectedIndexChanged);
            this.txtHocSinh.Click += new System.EventHandler(this.TxtHocSinh_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 22);
            this.label9.TabIndex = 11;
            this.label9.Text = "5. Học Sinh:";
            // 
            // txtHocKi
            // 
            this.txtHocKi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtHocKi.FormattingEnabled = true;
            this.txtHocKi.Location = new System.Drawing.Point(137, 219);
            this.txtHocKi.Name = "txtHocKi";
            this.txtHocKi.Size = new System.Drawing.Size(304, 30);
            this.txtHocKi.TabIndex = 10;
            this.txtHocKi.SelectedIndexChanged += new System.EventHandler(this.TxtHocKi_SelectedIndexChanged);
            this.txtHocKi.Click += new System.EventHandler(this.TxtHocKi_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 22);
            this.label8.TabIndex = 9;
            this.label8.Text = "4. Học Kì";
            // 
            // txtDSMonHoc
            // 
            this.txtDSMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDSMonHoc.FormattingEnabled = true;
            this.txtDSMonHoc.Location = new System.Drawing.Point(137, 165);
            this.txtDSMonHoc.Name = "txtDSMonHoc";
            this.txtDSMonHoc.Size = new System.Drawing.Size(304, 30);
            this.txtDSMonHoc.TabIndex = 6;
            this.txtDSMonHoc.SelectedIndexChanged += new System.EventHandler(this.TxtDSMonHoc_SelectedIndexChanged);
            this.txtDSMonHoc.Click += new System.EventHandler(this.TxtDSMonHoc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "3. Môn Học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "2. Lớp :";
            // 
            // txtDSLop
            // 
            this.txtDSLop.BackColor = System.Drawing.SystemColors.Window;
            this.txtDSLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDSLop.FormattingEnabled = true;
            this.txtDSLop.Location = new System.Drawing.Point(137, 109);
            this.txtDSLop.Name = "txtDSLop";
            this.txtDSLop.Size = new System.Drawing.Size(304, 30);
            this.txtDSLop.TabIndex = 3;
            this.txtDSLop.SelectedIndexChanged += new System.EventHandler(this.TxtDSLop_SelectedIndexChanged);
            this.txtDSLop.TextChanged += new System.EventHandler(this.TxtDSLop_TextChanged);
            this.txtDSLop.Click += new System.EventHandler(this.TxtDSLop_Click);
            // 
            // radioButtonHocSinh
            // 
            this.radioButtonHocSinh.AutoSize = true;
            this.radioButtonHocSinh.Location = new System.Drawing.Point(292, 73);
            this.radioButtonHocSinh.Name = "radioButtonHocSinh";
            this.radioButtonHocSinh.Size = new System.Drawing.Size(149, 26);
            this.radioButtonHocSinh.TabIndex = 2;
            this.radioButtonHocSinh.TabStop = true;
            this.radioButtonHocSinh.Text = "Theo Học Sinh";
            this.radioButtonHocSinh.UseVisualStyleBackColor = true;
            this.radioButtonHocSinh.CheckedChanged += new System.EventHandler(this.RadioButtonHocSinh_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Nhập Điểm Theo:";
            // 
            // radioButtonMonHoc
            // 
            this.radioButtonMonHoc.AutoSize = true;
            this.radioButtonMonHoc.Location = new System.Drawing.Point(62, 73);
            this.radioButtonMonHoc.Name = "radioButtonMonHoc";
            this.radioButtonMonHoc.Size = new System.Drawing.Size(151, 26);
            this.radioButtonMonHoc.TabIndex = 0;
            this.radioButtonMonHoc.TabStop = true;
            this.radioButtonMonHoc.Text = "Theo Môn Học";
            this.radioButtonMonHoc.UseVisualStyleBackColor = true;
            this.radioButtonMonHoc.CheckedChanged += new System.EventHandler(this.RadioButtonMonHoc_CheckedChanged);
            // 
            // tabPageThongKeDiem
            // 
            this.tabPageThongKeDiem.Location = new System.Drawing.Point(4, 31);
            this.tabPageThongKeDiem.Name = "tabPageThongKeDiem";
            this.tabPageThongKeDiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThongKeDiem.Size = new System.Drawing.Size(1429, 649);
            this.tabPageThongKeDiem.TabIndex = 1;
            this.tabPageThongKeDiem.Text = "Thống Kê Điểm";
            this.tabPageThongKeDiem.UseVisualStyleBackColor = true;
            // 
            // frmHoSoGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 684);
            this.Controls.Add(this.tabControlHoSoGD);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "frmHoSoGiangDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Hồ Sơ Giảng Dạy";
            this.tabControlHoSoGD.ResumeLayout(false);
            this.tabPageNhapDiem.ResumeLayout(false);
            this.gbDS.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDiem.ResumeLayout(false);
            this.gbDiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlHoSoGD;
        private System.Windows.Forms.TabPage tabPageNhapDiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPageThongKeDiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiemHocKi;
        private System.Windows.Forms.TextBox txtDiemMieng;
        private System.Windows.Forms.TextBox txtDiem1Tiet;
        private System.Windows.Forms.TextBox txtDiem15Phut;
        private System.Windows.Forms.ComboBox txtDSMonHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtDSLop;
        private System.Windows.Forms.RadioButton radioButtonHocSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonMonHoc;
        private System.Windows.Forms.ComboBox txtHocKi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvBangDiem;
        private System.Windows.Forms.GroupBox gbDS;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.ComboBox txtHocSinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbDiem;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioButtonSuaDiem;
        private System.Windows.Forms.RadioButton radioButtonNhapDiem;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}