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
    public class PhongHoc:SQLServer
    {
        private string str = "";
        public DataTable Select_PhongHoc()
        {
            str = "select*from PhongHoc";
            return LayDuLieuBang(str);
        }
        public DataTable Insert_PhongHoc(string TenPhong,string ChoNgoi)
        {
            str = "execute Insert_PH N'"+TenPhong+"',N'"+ChoNgoi+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Update_PhongHoc(string MaPhong,string TenPhong,string ChoNgoi)
        {
            str = "execute Update_PH N'"+MaPhong+"',N'" + TenPhong + "',N'" + ChoNgoi + "'";
            return LayDuLieuBang(str);
        }
        public DataTable Delete_PhongHoc(string MaPhong)
        {
            str = "execute Delete_PH N'"+MaPhong+"'";
            return LayDuLieuBang(str);
        }
        public DataTable Search_PhongHoc(string Ten)
        {
            str = "select * from PhongHoc where TenPhong like N'%" + Ten + "%'";
            return LayDuLieuBang(str);
        }
    }
}
