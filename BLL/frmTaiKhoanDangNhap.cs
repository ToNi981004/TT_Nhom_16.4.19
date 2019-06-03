using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class frmTaiKhoanDangNhap : SQLServer
    {
        string str;
        public bool Check_Image(string TenTK)
        {
            str = "Select MaGV from GiaoVien where HoTen = N'" + TenTK + "'";
            return sql_KiemTra(str);
        }
        public DataTable Select_DS()
        {
            str = "select HoTen AS N'Tài Khoản',ChucVu N'Chức Vụ' from GiaoVien";
            return LayDuLieuBang(str);
            
        }
        public bool Check_PassWord(string Pass)
        {
            str = "Select MaGV from GiaoVien where MatKhauDN = N'" + Pass + "'";
            return sql_KiemTra(str);
        }
        //
        public DataTable Update_MK(string TenCu,string TenMoi,string PassWord)
        {
            str = "Update GiaoVien set HoTen=N'"+TenMoi+"',MatKhauDN=N'"+PassWord+"' where HoTen=N'"+TenCu+"'";
            return LayDuLieuBang(str);

        }
        public DataTable Delete(string Name)
        {
            str = "Delete GiaoVien where HoTen=N'"+Name+"'";
            return LayDuLieuBang(str);

        }
        public DataTable Insert(string Name, string PassWord,string ChuVu)
        {
            str = "Insert into GiaoVien(HoTen,MatKhauDN,ChucVu) values(N'"+Name+"',N'"+PassWord+"',N'"+ChuVu+"')";
            return LayDuLieuBang(str);

        }
    }

}
