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
   
    public class HocKi:SQLServer
    {
        private string str = "";
        public DataTable Select_HocKi()
        {
            str = "Select*from HocKi";
            return LayDuLieuBang(str);
        }
        public DataTable Insert_HocKi(string NamHoc,string TG_BatDau,string TG_KetThuc)
        {
            str = "execute Insert_HK N'" + NamHoc + "',N'" + TG_BatDau + "',N'" + TG_KetThuc + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_HocKi(string MaHK,string NamHoc, string TG_BatDau, string TG_KetThuc)
        {
            str = "execute Update_HK N'" + MaHK + "',N'" + NamHoc + "',N'" + TG_BatDau + "',N'" + TG_KetThuc + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete_HocKi(string MaHK)
        {
            str = "execute Delete_HK N'" + MaHK + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Search_HocKi(string Ten)
        {
            str = "select * from HocKi where NamHoc like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
    }
}
