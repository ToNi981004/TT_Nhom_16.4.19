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
    public class frmThongTinGiangDay:SQLServer
    {
        string str;
        public DataTable HSGD()
        {
            str = "Select TenHS N'Tên Học Sinh',TenMon N'Môn Học',NamHoc N'Học Kì',Diem15Phut,DiemMieng,DiemMotTiet,DiemCuoiHK from ChiTietMon ct, HocSinh hs,MonHoc mh, HocKi hk where ct.MaHS = hs.MaHS AND ct.MaMon = mh.MaMon AND ct.MaHocKi = hk.MaHocKi";
            return LayDuLieuBang(str);
        }
        public DataTable Search(string Ten)
        {
            str = "Select TenHS N'Tên Học Sinh',TenMon N'Môn Học',NamHoc N'Học Kì',Diem15Phut,DiemMieng,DiemMotTiet,DiemCuoiHK from ChiTietMon ct, HocSinh hs,MonHoc mh, HocKi hk where ct.MaHS = hs.MaHS AND ct.MaMon = mh.MaMon AND ct.MaHocKi = hk.MaHocKi AND TenHS like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_ChiTietMon(string TenMon,string TenHS,string NamHoc,string Diem15p,string DiemMieng,string DiemMotTiet,string DiemHK)
        {
            str = "Execute Update_ChiTietMon N'"+TenMon+"',N'"+TenHS+"',N'"+NamHoc+"',N'"+Diem15p+"',N'"+DiemMieng+"',N'"+DiemMotTiet+"',N'"+DiemHK+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete_ChiTietMon(string TenMon, string TenHS, string NamHoc)
        {
            str = "Execute Delete_ChiTietMon N'" + TenMon + "',N'" + TenHS + "',N'" + NamHoc + "'";
            return LayDuLieuBang(str);
        }
        public DataTable BoLoc_ChiTieMonHoc(string TenMon, string TenLop, string NamHoc)
        {
            str = "execute BoLoc_ChiMonHoc N'"+TenLop+"',N'"+NamHoc+"',N'"+TenMon+"'";
            return LayDuLieuBang(str);
        }

    }
}
