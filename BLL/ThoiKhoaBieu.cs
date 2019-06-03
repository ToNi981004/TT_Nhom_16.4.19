using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

using DAL;
namespace BLL
{
    public class ThoiKhoaBieu:SQLServer
    {
        private string str = "";
        public DataTable TKB()
        {
            str = "Execute Select_ThoiKhoaBieu";
            return LayDuLieuBang(str);
        }
        public DataTable TKB_TheoLop(string TenLop)
        {
            str = "Execute Select_TKB N'"+TenLop+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Search(string TenLop)
        {
            str = "Execute Search_TKB N'" + TenLop + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Select_DSLop()
        {
            str = "Select TenLop from Lop";
            return LayDuLieuBang(str);
        }
        public DataTable Select_Thu()
        {
            str = "Select Thu from ThuTrongTuan";
            return LayDuLieuBang(str);
        }
        public DataTable Select_MonHoc()
        {
            str = "Select TenMon from MonHoc";
            return LayDuLieuBang(str);
        }
        public DataTable Select_GiaoVien(string TenMon)
        {
            str = "Select HoTen from GiaoVien gv where MaMon=(select MaMon from MonHoc where TenMon=N'"+TenMon+"')";
            return LayDuLieuBang(str);
        }
        public DataTable Select_TietHoc()
        {
            str = "Select Tiet from TietHoc";
            return LayDuLieuBang(str);
        }
        public DataTable Select_PhongHoc(string TenLop)
        {
            str = "Select TenPhong from PhongHoc where TenPhong like N'"+TenLop+"%'";
            return LayDuLieuBang(str);
        }
        public DataTable Select_PhongMay() 
        {
            str = "Select TenPhong from PhongHoc where  TenPhong like N'Phòng%'";
            return LayDuLieuBang(str);
        }
    public DataTable Select_ThoiGianHoc(string Tiet)
        {
            str = "Select TG_BatDau,TG_KetThuc from TietHoc where Tiet=N'"+Tiet+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete(string TenLop, string TenGV, string Thu, string TietHoc,string TenPhong)
        {
            str = "Execute Delete_TKB N'" + TenLop + "',N'" + TenGV + "',N'" + Thu + "',N'" + TietHoc + "',N'"+TenPhong+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Insert(string TenLop,string TenGV,string Thu,string TietHoc,string TenPhong,string SoTiet)
        {
            str = "Execute Insert_TKB N'"+TenLop+"',N'"+TenGV+"',N'"+Thu+"',N'"+TietHoc+"',N'"+TenPhong+"',N'"+SoTiet+"'";
            return LayDuLieuBang(str);
        }

        public bool Check_TKB(string TenLop, string TenGV, string Thu, string TietHoc, string TenPhong)
        {
            str = "Execute Check_TKB N'"+TenLop+"',N'"+TenGV+"',N'"+Thu+"',N'"+TietHoc+"',N'"+TenPhong+"'";
            return sql_KiemTra(str);
        }

    }
}
