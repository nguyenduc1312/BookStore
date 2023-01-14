using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Sach
    {
        public int sach_id { get; set; }
        public string ten_sach { get; set; }
        public decimal gia { get; set; }
        public int trangthai_id { get; set; }
        public int nxb_id { get; set; }
        public string mota { get; set; }
        public int sl_conlai { get; set; }
        public string ngayst { get; set; }
    }
}