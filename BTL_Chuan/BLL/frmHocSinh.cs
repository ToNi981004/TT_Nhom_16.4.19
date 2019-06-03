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
    public class frmHocSinh:SQLServer
    {
        private string str = "";
        public DataTable SelectDSHS()
        {
            str = "select MaHS,TenHS,NgaySinh,GioiTinh,DiaChi,HanhKiem,HocLuc,KhenThuong,KyLuat,Pictures_HS,MaLop from HocSinh";
            return LayDuLieuBang(str);
        }
        
        public DataTable DiemTB_HK(string MaHS)
        {
            str = "execute DiemTBHS_HK N'" + MaHS+"'";
            return LayDuLieuBang(str);
        }
        public bool Check_Image(string IDHS)
        {
            str = "Select Pictures_HS from HocSinh where Pictures_HS IS NULL AND MaHS = N'" + IDHS + "'";
            return sql_KiemTra(str);
        }
        public DataTable Delete_HocSinh(string MaHS)
        {
            str = "Delete HocSinh where MaHS = N'" + MaHS + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete_ChiTietMon_KhiDeleteHS(string TenHS)
        {
            str = "Delete ChiTietMon Where MaHS=(select MaHS from HocSinh where TenHS=N'"+TenHS+"' )";
            return LayDuLieuBang(str);
        }
        public bool Check_Name(string Ten, string Ngay, string GioiTinh)
        {
            str = "Select TenHS from HocSinh where TenHS =N'" + Ten + "' AND NgaySinh =N'" + Ngay + "' AND GioiTinh =N'" + GioiTinh + "'";
            return sql_KiemTra(str);
        }
        public DataTable Insert_HS(string HoTen, string NgaySinh, string GioiTinh,string DiaChi, string HanhKiem, string HocLuc, string KhenThuong, string KyLuat, string MaLop)
        {
            str = "Execute Insert_HS N'" + HoTen + "', N'" + NgaySinh + "', N'" + GioiTinh + "', N'" + DiaChi + "', N'" + HanhKiem + "', N'" + HocLuc + "', N'" + KhenThuong + "', N'" + KyLuat + "', N'" + MaLop + "'";
            return LayDuLieuBang(str);

        }
        public DataTable Update_TT_HocSinh(string MaHS,string HoTen, string NgaySinh, string GioiTinh, string DiaChi, string HanhKiem, string HocLuc, string KhenThuong, string KyLuat, string MaLop)
        {
            str = "execute Update_HocSinh_TT N'"+MaHS+"',N'"+HoTen+"',N'"+NgaySinh+"',N'"+GioiTinh+"',N'"+DiaChi+"',N'"+HanhKiem+"',N'"+HocLuc+"',N'"+KhenThuong+"',N'"+KyLuat+"',N'"+MaLop+"'";
            return LayDuLieuBang(str);
        }
        public DataTable select_MonHoc()
        {
            str = "select TenMon from MonHoc";
            return LayDuLieuBang(str);
        }
        public DataTable select_Lop()
        {
            str = "select TenLop from Lop";
            return LayDuLieuBang(str);
        }
        public DataTable select_SDHS_theo_Lop(string TenLop)
        {
            str = "select TenHS from HocSinh hs,Lop clas where hs.MaLop=clas.MaLop and TenLop='"+TenLop+"'";
            return LayDuLieuBang(str);
        }
        public DataTable select_HocKi()
        {
            str = "select NamHoc from HocKi";
            return LayDuLieuBang(str);
        }
        public DataTable select_DS_HanhKiem()
        {
            str = "select Count(MaHS),HanhKiem from HocSinh group by HanhKiem";
            return LayDuLieuBang(str);
        }
        public DataTable select_DS_HocLuc()
        {
            str = "select Count(MaHS),HocLuc from HocSinh group by HocLuc";
            return LayDuLieuBang(str);
        }
        public DataTable selectDSHS_The_Lop(string TenLop)
        {
            str = "select MaHS,TenHS,NgaySinh,GioiTinh,DiaChi,HanhKiem,HocLuc,KhenThuong,KyLuat,Pictures_HS,TenLop from HocSinh hs,Lop l where hs.MaLop=l.MaLop AND TenLop=N'"+TenLop+"'";
            return LayDuLieuBang(str);
        }
        public DataTable selectDSHS_Theo_Mon(string TenMon)
        {
            str = "select hs.MaHS,TenHS,NgaySinh,GioiTinh,DiaChi,HanhKiem,HocLuc,KhenThuong,KyLuat,Pictures_HS,TenMon from HocSinh hs, MonHoc mh,ChiTietMon ct where hs.MaHS = ct.MaHS AND ct.MaMon = mh.MaMon AND TenMon = N'"+TenMon+"'";
            return LayDuLieuBang(str);
        }
        public DataTable selectDSHS_Theo_HanhKiem(string HanhKiem)
        {
            str = "select hs.MaHS,TenHS,NgaySinh,GioiTinh,DiaChi,HanhKiem,HocLuc,KhenThuong,KyLuat,Pictures_HS,TenLop from HocSinh hs,Lop class Where hs.MaLop=class.MaLop AND HanhKiem=N'"+HanhKiem+"'";
            return LayDuLieuBang(str);
        }
        public DataTable selectDSHS_Theo_HocLuc(string HocLuc)
        {
            str = "select hs.MaHS,TenHS,NgaySinh,GioiTinh,DiaChi,HanhKiem,HocLuc,KhenThuong,KyLuat,Pictures_HS,TenLop from HocSinh hs,Lop class Where hs.MaLop=class.MaLop AND HocLuc=N'"+HocLuc+"'";
            return LayDuLieuBang(str);
        }
        public DataTable select_DSMonHoc(string IDHS,string NamHoc)
        {
            str = "select NamHoc,TenMon from ChiTietMon ct,MonHoc mh,HocKi hk where mh.MaMon=ct.MaMon AND ct.MaHocKi=hk.MaHocKi AND MaHS=N'"+IDHS+"' AND NamHoc=N'"+NamHoc+"'";
            return LayDuLieuBang(str);
        }
        public DataTable DiemTB_HK_CuaHS(string MaHS)
        {
            str = "execute DiemTrungBinhHocKi N'"+MaHS+"'";
            return LayDuLieuBang(str);
        }
        public DataTable DiemTB_HK_HS(string MaHS,string NamHoc)
        {
            str = "execute	Diem_Theo_NamHoc_MaHS N'"+MaHS+"',N'"+NamHoc+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Load_DoThiDiem(string MaHS, string NamHoc)
        {
            str = "execute Load_DoThiDiem N'" + MaHS + "',N'" + NamHoc + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Load_BangDiem(string MaHS, string NamHoc,string TenMon)
        {
            str = "execute Load_BangDiem N'" + MaHS + "',N'" + NamHoc + "',N'"+TenMon+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Search(string Ten)
        {
            str = "select * from HocSinh where TenHS like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
        public bool Check_Search(string Ten)
        {
            str = "select * from HocSinh where TenHS like N'%" + Ten + "%'";
            return sql_KiemTra(str);
        }
        public DataTable DS_Lop(string TenLop)
        {
            str = "select TenHS AS N'Học Sinh',MaHS AS N'ID' from HocSinh hs,Lop clas where  hs.MaLop=clas.MaLop AND TenLop=N'"+TenLop+"'";
            return LayDuLieuBang(str);
        }
        public DataTable insert_BangDiem(string TenMon,string MaHS,string HocKi,string Diem1Tiet,string Diem15Phut,string DiemMieng,string DiemHocKi)
        {
            str = "execute QuickInsert_Diem N'"+TenMon+"',N'"+HocKi+"','"+MaHS+"','"+Diem1Tiet+"','"+Diem15Phut+"','"+DiemMieng+"','"+DiemHocKi+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Select_BangDiem(string TenMon,string HocKi, string TenLop)
        {
            str = "execute Select_Diem N'"+TenMon+"',N'"+HocKi+"',N'"+TenLop+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_BangDiem(string TenMon, string MaHS, string HocKi, string Diem1Tiet, string Diem15Phut, string DiemMieng, string DiemHocKi)
        {
            str = "execute QiuckUpdate_Diem N'" + TenMon + "',N'" + HocKi + "','" + MaHS + "','" + Diem1Tiet + "','" + Diem15Phut + "','" + DiemMieng + "','" + DiemHocKi + "'";
            return LayDuLieuBang(str);
        }
        public DataTable insert_BangDiem_TheoHS(string TenMon, string TenHS, string HocKi, string Diem1Tiet, string Diem15Phut, string DiemMieng, string DiemHocKi)
        {
            str = "execute QiuckInsert_Diem_MonHoc N'" + TenMon + "',N'" + HocKi + "',N'" + TenHS + "','" + Diem1Tiet + "','" + Diem15Phut + "','" + DiemMieng + "','" + DiemHocKi + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_BangDiem_TheoHS(string TenMon, string TenHS, string HocKi, string Diem1Tiet, string Diem15Phut, string DiemMieng, string DiemHocKi)
        {
            str = "execute QiuckUpdate_Diem_MonHoc N'" + TenMon + "',N'" + HocKi + "',N'" + TenHS + "','" + Diem1Tiet + "','" + Diem15Phut + "','" + DiemMieng + "','" + DiemHocKi + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Select_BangDiem_TheoHS(string TenHS, string HocKi, string TenLop)
        {
            str = "execute Select_Diem_TheoTungHS N'" + TenHS + "',N'" + HocKi + "',N'" + TenLop + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Select_TatCaHocSinh()
        {
            str = "Select TenHS from HocSinh";
            return LayDuLieuBang(str);
        }

    }
}
