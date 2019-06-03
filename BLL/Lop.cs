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
    public class Lop:SQLServer
    {
        private string str;
        public DataTable Select_Lop()
        {
            str = "select*from Lop";
            return LayDuLieuBang(str);
        }
        public DataTable Search_Lop(string Ten)
        {
            str = "select * from Lop where TenLop like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
        public DataTable Insert_Lop(string TenLop,string SySo,string NiemKhoa)
        {
            str = "Execute Insert_Lop N'"+TenLop+"',N'"+SySo+"',N'"+NiemKhoa+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_Lop(string MaLop,string TenLop, string SySo, string NiemKhoa)
        {
            str = "Execute Update_Lop N'"+MaLop+"',N'" + TenLop + "',N'" + SySo + "',N'" + NiemKhoa + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete_Lop(string MaLop)
        {
            str = "Execute Delete_Lop N'"+MaLop+"'";
            return LayDuLieuBang(str);
        }
    }
}
