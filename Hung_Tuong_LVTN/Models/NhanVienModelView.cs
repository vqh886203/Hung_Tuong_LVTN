using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hung_Tuong_LVTN.Model
{
    class NhanVienModelView
    {
        public IEnumerable<object> DSNV { get; set; }
        public IEnumerable<object> DSNVList { get; set; }

        public databaseDataContext dc = new databaseDataContext();
        public NhanVienModelView()
        {
            this.DSNV = getDSNVView();
            this.DSNVList = getDSNVViewList();
        }


        public IEnumerable<object> getDSNVView()
        {
            return dc.NhanViens.Select(x => new NhanVienView
            {
                nvid = x.nvid,
                tennv = x.tennv,
                diachi = x.diachi,
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                email = x.email,
                sdt = x.sdt.Value,
                tuoi = DateTime.Now.Year - x.ngaysinh.Value.Year,
                hinh = x.hinh.ToString() == null ? null : x.hinh.ToArray(),

            }).ToList();
        }
       
        public IEnumerable<object> getDSNVViewList()
        {
            return dc.NhanViens.Select(x => new NhanVienViewList
            {
                nvid = x.nvid,
                doanhthu=x.doanhthu.Value,
                email=x.email,
                matkhau=x.matkhau,
                gioitinh=x.gioitinh.Value?"Nam" : "Nữ",
                ngaysinh=x.ngaysinh.Value,
                hinh = x.hinh.ToString()==null?null:x.hinh.ToArray(),
                tennv = x.tennv,
                sdt = x.sdt.Value,
                diachi = x.diachi,
                taikhoan = x.taikhoan,
                quyen=x.quyen.Value
            }).ToList();
        }
        public void timnvtheotk(string tk)
        {
           

        }
       
    }


    public class NhanVienViewList
    {
        public int nvid { get; set; }
        public byte[] hinh { get; set; }
        public string tennv { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public double doanhthu { get; set; }
        public string email { get; set; }
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public bool quyen { get; set; }
        
    }
    public class NhanVienView
    {
        public int nvid { get; set; }
        public string tennv { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }
        public string gioitinh { get; set; }
        public int tuoi { get; set; }
        public byte[] hinh { get; set; }
        public byte[] list { get; set; }
    }
   
}

