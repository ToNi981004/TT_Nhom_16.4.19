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
    public class MonHoc:SQLServer
    {
        private string str;
        public DataTable Select_MonHoc()
        {
            str = "select MaMon N'ID',TenMon N'Môn Học',HeSo N'Hệ Số Điểm' from MonHoc";
            return LayDuLieuBang(str);
        }
        public DataTable Select_GBBM(string MaMon)
        {
            str = "	select  MaGV,HoTen,ChucVu,TenMon from GiaoVien gv,MonHoc mh where gv.MaMon=mh.MaMon AND gv.MaMon='"+MaMon+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Insert_MH(string TenMon,string HeSo)
        {
            str = "	execute  Insert_MonHoc N'"+TenMon+"',N'"+HeSo+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_MH(string TenMon, string HeSo,string MaMon)
        {
            str = "	execute  Update_MonHoc N'" + MaMon + "',N'" + TenMon + "',N'"+HeSo+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete_MH(string MaMon)
        {
            str = "execute	Delete_MonHoc N'"+MaMon+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Search_MH(string Ten)
        {
            str = "select * from MonHoc where TenMon like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
    }
}
