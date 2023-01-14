using BookStore.Models;
using BookStore.Repositories;
using BookStore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private ISachRepository _sachRepository;

        public HomeController()
        {
            _sachRepository = new SachRepository();
        }


        public async Task<ActionResult> Index()
        {
            DataSet tbl_sachs = await _sachRepository.GetAllHomePage();

            List<Sach> sachMoi = (from rw in tbl_sachs.Tables[0].AsEnumerable()
                                 select new Sach()
                                 {
                                     sach_id = Convert.ToInt32(rw["sach_id"]),
                                     ten_sach = Convert.ToString(rw["ten_sach"]),
                                     gia = Convert.ToDecimal(rw["gia"]),
                                     trangthai_id = Convert.ToInt32(rw["trangthai_id"]),
                                     nxb_id = Convert.ToInt32(rw["nxb_id"]),
                                     mota = Convert.ToString(rw["mota"]),
                                     sl_conlai = Convert.ToInt32(rw["sl_conlai"]),
                                     ngayst = Convert.ToString(rw["ngayst"])
                                 }).ToList();

            List<Sach> sachBanChay = (from rw in tbl_sachs.Tables[1].AsEnumerable()
                                  select new Sach()
                                  {
                                      sach_id = Convert.ToInt32(rw["sach_id"]),
                                      ten_sach = Convert.ToString(rw["ten_sach"]),
                                      gia = Convert.ToDecimal(rw["gia"]),
                                      trangthai_id = Convert.ToInt32(rw["trangthai_id"]),
                                      nxb_id = Convert.ToInt32(rw["nxb_id"]),
                                      mota = Convert.ToString(rw["mota"]),
                                      sl_conlai = Convert.ToInt32(rw["sl_conlai"]),
                                      ngayst = Convert.ToString(rw["ngayst"])
                                  }).ToList();

            List<Sach> sachPhaiDoc = (from rw in tbl_sachs.Tables[2].AsEnumerable()
                                      select new Sach()
                                      {
                                          sach_id = Convert.ToInt32(rw["sach_id"]),
                                          ten_sach = Convert.ToString(rw["ten_sach"]),
                                          gia = Convert.ToDecimal(rw["gia"]),
                                          trangthai_id = Convert.ToInt32(rw["trangthai_id"]),
                                          nxb_id = Convert.ToInt32(rw["nxb_id"]),
                                          mota = Convert.ToString(rw["mota"]),
                                          sl_conlai = Convert.ToInt32(rw["sl_conlai"]),
                                          ngayst = Convert.ToString(rw["ngayst"])
                                      }).ToList();

            List<Sach> sachTrinhTham = (from rw in tbl_sachs.Tables[3].AsEnumerable()
                                      select new Sach()
                                      {
                                          sach_id = Convert.ToInt32(rw["sach_id"]),
                                          ten_sach = Convert.ToString(rw["ten_sach"]),
                                          gia = Convert.ToDecimal(rw["gia"]),
                                          trangthai_id = Convert.ToInt32(rw["trangthai_id"]),
                                          nxb_id = Convert.ToInt32(rw["nxb_id"]),
                                          mota = Convert.ToString(rw["mota"]),
                                          sl_conlai = Convert.ToInt32(rw["sl_conlai"]),
                                          ngayst = Convert.ToString(rw["ngayst"])
                                      }).ToList();

            List<Sach> sachSelfHelp = (from rw in tbl_sachs.Tables[4].AsEnumerable()
                                      select new Sach()
                                      {
                                          sach_id = Convert.ToInt32(rw["sach_id"]),
                                          ten_sach = Convert.ToString(rw["ten_sach"]),
                                          gia = Convert.ToDecimal(rw["gia"]),
                                          trangthai_id = Convert.ToInt32(rw["trangthai_id"]),
                                          nxb_id = Convert.ToInt32(rw["nxb_id"]),
                                          mota = Convert.ToString(rw["mota"]),
                                          sl_conlai = Convert.ToInt32(rw["sl_conlai"]),
                                          ngayst = Convert.ToString(rw["ngayst"])
                                      }).ToList();

            List<Sach> sachCode = (from rw in tbl_sachs.Tables[5].AsEnumerable()
                                       select new Sach()
                                       {
                                           sach_id = Convert.ToInt32(rw["sach_id"]),
                                           ten_sach = Convert.ToString(rw["ten_sach"]),
                                           gia = Convert.ToDecimal(rw["gia"]),
                                           trangthai_id = Convert.ToInt32(rw["trangthai_id"]),
                                           nxb_id = Convert.ToInt32(rw["nxb_id"]),
                                           mota = Convert.ToString(rw["mota"]),
                                           sl_conlai = Convert.ToInt32(rw["sl_conlai"]),
                                           ngayst = Convert.ToString(rw["ngayst"])
                                       }).ToList();

            ViewBag.sachMoi = sachMoi;
            ViewBag.sachBanChay = sachBanChay;
            ViewBag.sachPhaiDoc = sachPhaiDoc;
            ViewBag.sachTrinhTham = sachTrinhTham;
            ViewBag.sachSelfHelp = sachSelfHelp;
            ViewBag.sachCode = sachCode;
            return View();
        }
    }
}