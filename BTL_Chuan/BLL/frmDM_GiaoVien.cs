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
    public class frmDM_GiaoVien:SQLServer
    {
        private string str;
        public DataTable SelectGV()
        {
            str = "Select MaGV N'ID',HoTen AS N'Họ Tên',NgaySinh N'Ngày Sinh',GioiTinh N'Giới Tính',DiaChi N'Địa Chỉ', SDT_GV N'Số Điện Thoại',ChucVu N'Chức Vụ',QuocTich N'Quốc Tịch',DanToc N'Dân Tộc',TonGiao N'Tôn Giáo',Email N'Email',Pictures_GV N'Ảnh GV',MaMon 'Môn Học Đảm Nhiệm' from GiaoVien";
            return LayDuLieuBang(str);
        }
   
        public DataTable Insert_GV(string HoTen, string NgaySinh, string GioiTinh, string DiaChi, string SDT_GV, string ChucVu, string QuocTich,string DanToc, string TonGiao, string Email,string MaMon)
        {
            //str = "Insert Into GiaoVien() Values(N'" + HoTen + "', N'" + NgaySinh + "', N'" + GioiTinh + "', N'" + DiaChi + "', N'" + SDT_GV + "', N'" + ChucVu + "', N'" + QuocTich + "', N'" + DanToc + "', N'" + TonGiao + "', N'" + Email +"',N'NULL', N'" + MaMon + "')";
            str = "Execute Insert_GV N'" + HoTen+"', N'"+NgaySinh+"', N'"+GioiTinh+"', N'"+DiaChi+"', N'"+SDT_GV+"', N'"+ChucVu+"', N'"+QuocTich+"', N'"+DanToc+"', N'"+TonGiao+"', N'"+Email+"', N'"+MaMon+"'";
            return LayDuLieuBang(str);

        } 
        public bool Check_Image(string IDGV)
        {
            str = "Select Pictures_GV from GiaoVien where Pictures_GV IS NULL AND MaGV = N'"+IDGV+"'";
            return sql_KiemTra(str);  
        }

        public bool Check_Name(string Ten,string Ngay,string GioiTinh)
        {
            str = "Select HoTen from GiaoVien where HoTen =N'"+Ten+"' AND NgaySinh =N'"+Ngay+"' AND GioiTinh =N'"+GioiTinh+"'";
            return sql_KiemTra(str);
        }

        public DataTable Update_TT_GiaoVien(string MaGV,string HoTen, string NgaySinh, string GioiTinh, string DiaChi, string SDT_GV, string ChucVu, string QuocTich, string DanToc, string TonGiao, string Email, string MaMon)
        {
            str = "Execute Update_GiaoVien_TT N'"+MaGV+"',N'" + HoTen + "', N'" + NgaySinh + "', N'" + GioiTinh + "', N'" + DiaChi + "', N'" + SDT_GV + "', N'" + ChucVu + "', N'" + QuocTich + "', N'" + DanToc + "', N'" + TonGiao + "', N'" + Email + "', N'"+ MaMon +"'";
            return LayDuLieuBang(str);
        }

        public DataTable Delete_GiaoVien(string MaGV)
        {
            str = "Delete GiaoVien where MaGV = N'"+MaGV+"'";
            return LayDuLieuBang(str);
        }
        public DataTable select_MonHoc()
        {
            str = "select TenMon from MonHoc";
            return LayDuLieuBang(str);
        }
        public DataTable Search(string Ten)
        {
            str = "select * from GiaoVien where HoTen like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
        public bool Check_Search(string Ten)
        {
            str = "select * from GiaoVien where HoTen like N'%"+Ten+"%'";
            return sql_KiemTra(str);
        }
    }
}
