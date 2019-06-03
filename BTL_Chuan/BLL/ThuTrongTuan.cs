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
    public class ThuTrongTuan:SQLServer
    {
        private string str = "";
        public DataTable Select_ThuTronhTuan()
        {
            str = "Select*from ThuTrongTuan";
            return LayDuLieuBang(str);
        }
        public DataTable Insert_Day(string Thu)
        {
            str = "execute Insert_Day N'" + Thu + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_Day(string Thu,string MaNgay)
        {
            str = "execute Update_Day N'" + Thu + "',N'" + MaNgay + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete_Day(string MaNgay)
        {
            str = "execute Delete_Day N'" + MaNgay + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Search_Day(string Ten)
        {
            str = "select * from ThuTrongTuan where Thu like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
    }
}
