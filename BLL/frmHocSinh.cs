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
        public DataTable Insert_HS(string Ten)
        {
            str = "insert into HocSinh(TenHS) values(N'" + Ten + "')";
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
    }
}
