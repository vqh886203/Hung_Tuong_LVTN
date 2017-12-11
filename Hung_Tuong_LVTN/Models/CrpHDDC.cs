using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hung_Tuong_LVTN.Models
{
    class CrpHDDC
    {
       
        public string ngaylaphd
        { get; set; }
        //người mua:
        public string tennm
        { get; set; }
        public int cmndnm
        { get; set; }
        public string hokhaunm
        { get; set; }
        public string diachinm
        { get; set; }
        public int sdtnm
        { get; set; }
        //người bán
        public string tennb
        { get; set; }
        public int cmndnb
        { get; set; }
        public string hokhaunb
        { get; set; }
        public string diachinb
        { get; set; }
        public int sdtnb
        { get; set; }
        //Bất động sản:
        public string msch
        { get; set; }
        public double chieurong
        { get; set; }
        public double chieudai
        { get; set; }
        public double dt
        { get; set; }
        public double tonggiatri
        { get; set; }
        //thông tin đặt cọc:
        public double tiencoc
        { get; set; }
        public string ngayhethan
        { get; set; }
        
    }
}
