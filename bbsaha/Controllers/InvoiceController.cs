using bbsaha.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bbsaha.Models.Invoice;
using SelectPdf;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ClosedXML.Excel;

namespace bbsaha.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly MysqlDBDataContext _mysqlbro;
        //private IConverter _converter;
        string db = "bbsaha";

        public InvoiceController(MysqlDBDataContext newbrother)
        {
            //_context = context;
            //_converter = converter;
            //_configuration = configuration;
            _mysqlbro = newbrother;

        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult Invoice()
        {
            return View();
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult InvoiceForm()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Getcompany()
        {

            DateTime myDateTime = DateTime.Now;
            string year = myDateTime.Year.ToString();
            var dt_com = _mysqlbro.CUS_Company.Where(x => x.Status != "2").OrderBy(ae => ae.NameSimple).ToList();

            return Json(dt_com);

        }

        [HttpGet]
        public IActionResult Getinvoiceid(int id, string InvDate, string idcode)
        {
            var datet = DateTime.Parse(InvDate).ToString("yyMMdd");
            //AMN_Invoices.Select(dg => new { num1 = dg.InvInvoiceID.Substring(10, 1), num2 = dg.InvInvoiceID.Substring(11, 1), dg.InvCustID, dg.InvInvoiceID }).OrderByDescending(er => er.num1).ThenByDescending(n => n.num2).FirstOrDefault(ae => ae.InvCustID == "ATA" && ae.InvInvoiceID.StartsWith("GATA211124"))

         
            
            var dt_numinvoice = _mysqlbro.INV_Invoice.Select(dg => new { num1 = dg.InvID.Substring(10, 1), num2 = dg.InvID.Substring(11, 1), dg.CusID, dg.InvID }).OrderByDescending(er => er.num1).ThenByDescending(n => n.num2).FirstOrDefault(ae => ae.CusID == id && ae.InvID.StartsWith("H" + idcode + datet));

        

            var sum_suc = "";


            if (dt_numinvoice != null)
            {
                //2023.11.06 최희문 주석 처리
                //int num1 = 0;

                //2023.11.06 최희문 추가 - 인보이스 오류 수정을 위한 순번 다시 구하기
                //
                var lsize = dt_numinvoice.InvID.Length;
                //십의자리
                var tnum1 = dt_numinvoice.InvID.Substring(lsize - 2, 1);
                //일의 자리
                var tnum2 = dt_numinvoice.InvID.Substring(lsize - 1, 1);

                int num1 = Convert.ToInt32(tnum1);

                int num2 = Convert.ToInt32(dt_numinvoice.num2) + 1;
                if (num2 >= 10)
                {
                    num1 += 1;
                    num2 = 0;
                }
                sum_suc = "H" + idcode + datet + num1 + num2;
            }
            else
            {
                sum_suc = "H" + idcode + datet + "00";
            }


            //var dt_status = _mysqlbro.AMN_Invoice.Select(gf => new { gf.InvApprove, gf.InvCustID, gf.InvInvoiceID }).FirstOrDefault(sc => sc.InvCustID == id && sc.InvInvoiceID == dt_numinvoice.InvInvoiceID);

            return Json(sum_suc);

        }

        public class invoicesav {

            public DateTime date { get; set; }

            public string name { get; set; }
            public string namel { get; set; }
            public string service { get; set; }
            public string company { get; set; }
            public decimal amount { get; set; }

            public int Customer { get; set; }
            public string Address { get; set; }
            public string Tax { get; set; }
            public DateTime Dateinv { get; set; }
            public string number { get; set; }

        }

        public class invoicesavE
        {

            public DateTime dateE { get; set; }
            public string date { get; set; }

            public string firstnameTH { get; set; }
            public string lastNameTH { get; set; }
            public string service { get; set; }
            public string cusName { get; set; }
            public decimal amount { get; set; }

            public int Customer { get; set; }
            public string Address { get; set; }
            public string Tax { get; set; }
            public string invid { get; set; }
            public string number { get; set; }
            public DateTime Dateinv { get; set; }

        }



        [HttpPost]
        public IActionResult savedatainv([FromBody] invoicesav[] model)
        {
            var chk = _mysqlbro.INV_Invoice.Count();
            var dt_maxbill = 0;
            if (chk != 0)
                dt_maxbill = _mysqlbro.INV_Invoice.Select(fg => Convert.ToInt32(fg.BillNo)).Max() + 1;
            else
                dt_maxbill = 1;

            try
            {
                decimal sum = 0;
                foreach (var dat in model)
                {
                    sum += dat.amount;
                }

                var INV_Invoice = new inv_invoice
                {
                    InvDate = model[0].Dateinv,
                    InvID = model[0].number,
                    CusID = model[0].Customer,
                    Address = model[0].Address,
                    TaxID = model[0].Tax,
                    CreateDate = DateTime.Now,
                    Updatedate = DateTime.Now,
                    BillNo = dt_maxbill,
                    Rewrite = 0,
                    //Datereceive = model[0].Dateinv,
                    Totalprice = sum,
                    Status = "1",
                    Datereceipt = DateTime.Now


                };
                _mysqlbro.INV_Invoice.Add(INV_Invoice);
                _mysqlbro.SaveChanges();


                foreach (var dat in model)
                {

                    var INV_Detaillist = new inv_detaillist
                    {
                        Date = dat.date,
                        CusName = dat.company,
                        InvID = INV_Invoice.ID,
                        FirstnameTH = dat.name,
                        LastNameTH = dat.namel,
                        Service = dat.service,
                        Amount = dat.amount,
                        Createdate = DateTime.Now,
                        updatedate = DateTime.Now,
                        Status = "1"





                    };
                    _mysqlbro.INV_Detaillist.Add(INV_Detaillist);
                    _mysqlbro.SaveChanges();
                }


                return Json("suc");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }

        [HttpPost]
        public IActionResult savedatainvE([FromBody] invoicesavE[] model)
        {

            var _dataE = _mysqlbro.INV_Invoice.Where(x => x.InvID == model[0].invid).Max(c => c.Rewrite);
            var _datadateE = _mysqlbro.INV_Invoice.FirstOrDefault(x => x.InvID == model[0].invid);
            var chk = _mysqlbro.INV_Invoice.Count();
            //var dt_maxbill = 0;
            //if (chk != 0)
            //    dt_maxbill = _mysqlbro.INV_Invoice.Select(fg => Convert.ToInt32(fg.BillNo)).Max() + 1;
            //else
            //    dt_maxbill = 1;

            try
            {
                decimal sum = 0;
                foreach (var dat in model)
                {
                    sum += dat.amount;
                }

                var INV_Invoice = new inv_invoice
                {
                    InvDate = _datadateE.InvDate,
                    InvID = _datadateE.InvID,
                    CusID = _datadateE.CusID,
                    Address = model[0].Address,
                    TaxID = model[0].Tax,
                    CreateDate = DateTime.Now,
                    Updatedate = DateTime.Now,
                    BillNo = _datadateE.BillNo,
                    Rewrite = _dataE + 1,
                    //Datereceive = model[0].Dateinv,
                    Totalprice = sum,
                    Status = "1",
                    Datereceipt = DateTime.Now


                };
                _mysqlbro.INV_Invoice.Add(INV_Invoice);
                _mysqlbro.SaveChanges();


                foreach (var dat in model)
                {

                    var INV_Detaillist = new inv_detaillist
                    {
                        Date = dat.dateE,
                        CusName = dat.cusName,
                        InvID = INV_Invoice.ID,
                        FirstnameTH = dat.firstnameTH,
                        LastNameTH = dat.lastNameTH,
                        Service = dat.service,
                        Amount = dat.amount,
                        Createdate = DateTime.Now,
                        updatedate = DateTime.Now,
                        Status = "1"

                    };
                    _mysqlbro.INV_Detaillist.Add(INV_Detaillist);
                    _mysqlbro.SaveChanges();
                }


                return Json("suc");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            //return Json("suc");
        }
        public class datareceipt {

            public DateTime date { get; set; }
            public int id { get; set; }
}

        [HttpPost]
        public IActionResult savedateinv([FromBody] datareceipt[] model)
        {
           

            try
            {
                var _data = _mysqlbro.INV_Invoice.FirstOrDefault(x => x.ID == model[0].id);

                _data.Datereceipt = model[0].date;

                _mysqlbro.INV_Invoice.Update(_data);
                _mysqlbro.SaveChanges();

                return Json("suc");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }
        public IActionResult GetPrintinvoice(string id, string invoiceid, string invrw, string GridHtml)
        {
            var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("Invoice_report", "Invoice", new { id = id, invoiceid = invoiceid, inrw = invrw });



            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);


            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = 1024;
            converter.Options.WebPageHeight = 0;
            //converter.Options.MarginLeft = 15;
            //converter.Options.MarginRight = 15;
            converter.Options.MarginTop = 10;
            //converter.Options.MarginBottom = 15;
            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);
            MemoryStream ms = new MemoryStream();
            // save pdf document
            doc.Save(ms);

            // close pdf document
            doc.Close();
            ms.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            //fileStreamResult.FileDownloadName = "sample.pdf";

            //return File(file, "application/pdf");
            return fileStreamResult;

            //return File(file, "application/pdf");

        }
        public IActionResult GetPrintrec(string id, string invoiceid, string invrw, string GridHtml)
        {
            var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("Invoice_receipt", "Invoice", new { id = id, invoiceid = invoiceid, inrw = invrw });



            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);


            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = 1024;
            converter.Options.WebPageHeight = 0;
            //converter.Options.MarginLeft = 15;
            //converter.Options.MarginRight = 15;
            converter.Options.MarginTop = 10;
            //converter.Options.MarginBottom = 15;
            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);
            MemoryStream ms = new MemoryStream();
            // save pdf document
            doc.Save(ms);

            // close pdf document
            doc.Close();
            ms.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            //fileStreamResult.FileDownloadName = "sample.pdf";

            //return File(file, "application/pdf");
            return fileStreamResult;

            //return File(file, "application/pdf");

        }

        public IActionResult invoice_report(int id, string invoiceid, string inrw)
        {

            var cus = _mysqlbro.CUS_Company.ToList();
            var inv = _mysqlbro.INV_Invoice.ToList();
            var invdetail = _mysqlbro.INV_Detaillist.ToList();

            //var dt_rw = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.InvID == invoiceid && ve.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();
            var dt_rw = inv.Join(cus, ae => ae.CusID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Where(ve => ve.ae.CusID == id && ve.ae.InvID == invoiceid && ve.ae.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();

            List<showheadinv> App = new List<showheadinv>();
            foreach (var data in dt_rw)
            {

                App.Add(new showheadinv
                {
                    InvDate = data.ae.InvDate.ToString("dd/MMM/yyyy"),
                    InvID = data.ae.InvID,
                    CusID = data.ae.CusID,
                    Address = data.ae.Address,
                    TaxID = data.ae.TaxID,
                    Cusname = data.ea.CompanyNameEN



                });



            }

            //ViewBag.datainvoice = App.ToArray();

            //if(idcus != null && invoiceidcus != null && inrwcus != null)
            //{
            //    invoiceid = invoiceidcus;
            //    id = idcus;
            //    inrw = inrwcus;
            //}
           

            //var dt_rw = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.InvID == invoiceid && ve.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();
            var dt_rwb = inv.Join(cus, ae => ae.CusID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Join(invdetail, fg => fg.ae.ID, gf => gf.InvID, (fg, gf) => new { fg, gf })
                .Where(ve => ve.fg.ae.CusID == id && ve.fg.ae.InvID == invoiceid && ve.fg.ae.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();

            List<showdetailinv> Appb = new List<showdetailinv>();
            foreach (var data in dt_rwb)
            {

                Appb.Add(new showdetailinv
                {
                    Date = data.gf.Date.ToString("dd/MM/yyyy"),
                    CusName = data.gf.CusName,
                    FirstnameTH = data.gf.FirstnameTH,
                    LastNameTH = data.gf.LastNameTH,
                    Service = data.gf.Service,
                    Amount = data.gf.Amount



                });

            }

            ViewBag.dt_rw = App;
            ViewBag.dt_rwb = Appb;
            ViewBag.dt_rwbcount = Appb.Count();
            return View();
        }

        public IActionResult invoice_receipt(int id, string invoiceid, string inrw)
        {

            var cus = _mysqlbro.CUS_Company.ToList();
            var inv = _mysqlbro.INV_Invoice.ToList();
            var invdetail = _mysqlbro.INV_Detaillist.ToList();

            //var dt_rw = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.InvID == invoiceid && ve.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();
            var dt_rw = inv.Join(cus, ae => ae.CusID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Where(ve => ve.ae.CusID == id && ve.ae.InvID == invoiceid && ve.ae.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();

            List<showheadinv> App = new List<showheadinv>();
            foreach (var data in dt_rw)
            {

                App.Add(new showheadinv
                {
                    InvDate = data.ae.InvDate.ToString("dd MMM yyyy"),
                    InvID = data.ae.InvID,
                    CusID = data.ae.CusID,
                    Address = data.ae.Address,
                    TaxID = data.ae.TaxID,
                    Cusname = data.ea.CompanyNameEN,
                    Datereceive = data.ae.Datereceipt.ToString("dd/MMM/yyyy")




                });



            }

            //ViewBag.datainvoice = App.ToArray();

            //if(idcus != null && invoiceidcus != null && inrwcus != null)
            //{
            //    invoiceid = invoiceidcus;
            //    id = idcus;
            //    inrw = inrwcus;
            //}


            //var dt_rw = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.InvID == invoiceid && ve.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();
            var dt_rwb = inv.Join(cus, ae => ae.CusID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Join(invdetail, fg => fg.ae.ID, gf => gf.InvID, (fg, gf) => new { fg, gf })
                .Where(ve => ve.fg.ae.CusID == id && ve.fg.ae.InvID == invoiceid && ve.fg.ae.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();

            List<showdetailinv> Appb = new List<showdetailinv>();
            foreach (var data in dt_rwb)
            {

                Appb.Add(new showdetailinv
                {
                    Date = data.gf.Date.ToString("dd/MM/yyyy"),
                    CusName = data.gf.CusName,
                    FirstnameTH = data.gf.FirstnameTH,
                    LastNameTH = data.gf.LastNameTH,
                    Service = data.gf.Service,
                    Amount = data.gf.Amount



                });

            }

            ViewBag.dt_rw = App;
            ViewBag.dt_rwb = Appb;

            return View();
        }

        [HttpGet]
        public IActionResult Getinv()
        {
            var _dt = _mysqlbro.INV_Invoice.ToList();
            var Cus = _mysqlbro.CUS_Company.ToList();
            var inv_com = Cus.Join(_dt, ce => ce.ID, ec => ec.CusID, (ce, ec) => new { ce, ec }).Select(x=>new { x.ce.CompanyNameEN,x.ce.ID,x.ec.Status }).Where(x=>x.Status == "1").Distinct().ToList();

            


            return Json(inv_com);

        }

        [HttpGet]
        public IActionResult Getinvdata(int id)
        {
           

            var invo = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.Status != "0").Select(df => new { df.CusID, df.InvID, df.InvDate }).Distinct().OrderByDescending(gf => gf.InvID).ToList();


            return Json(invo);

        }
        public class rewite
        {

            public string InvRewrite { get; set; }
            public string InvInvoiceID { get; set; }
            public int? Invrw { get; set; }

        }

        [HttpGet]
        public IActionResult GetRewiteinvoice(int id, string invoiceid)
        {
            var dt_rw = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.InvID == invoiceid).Select(df => new { df.Rewrite, df.InvID }).OrderByDescending(gf => gf.Rewrite).ToList();
            var textrw = "";
            List<rewite> App = new List<rewite>();
            foreach (var data in dt_rw)
            {
                if (data.Rewrite < 10)
                    textrw = "RW0" + data.Rewrite;
                App.Add(new rewite
                {

                    InvRewrite = textrw,
                    InvInvoiceID = data.InvID,
                    Invrw = data.Rewrite

                });



            }



            return Json(App);
        }

        public class showheadinv
        {
            public string InvDate { get; set; }
            public string Datereceive { get; set; }
            public string Daterecep { get; set; }
            public string InvID { get; set; }
            public int CusID { get; set; }
            public string Address { get; set; }
            public string TaxID { get; set; }
            public string Cusname { get; set; }
            public int idinvoice { get; set; }



        }

        [HttpGet]
        public IActionResult Getfullinvoice(int id, string invoiceid, string inrw)
        {
            //if(idcus != null && invoiceidcus != null && inrwcus != null)
            //{
            //    invoiceid = invoiceidcus;
            //    id = idcus;
            //    inrw = inrwcus;
            //}
            var cus = _mysqlbro.CUS_Company.ToList();
            var inv = _mysqlbro.INV_Invoice.ToList();
            var invdetail = _mysqlbro.INV_Detaillist.ToList();

            //var dt_rw = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.InvID == invoiceid && ve.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();
            var dt_rw = inv.Join(cus,ae => ae.CusID, ea=>ea.ID,(ae,ea) => new {ae,ea})
               
                .Where(ve => ve.ae.CusID == id && ve.ae.InvID == invoiceid && ve.ae.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();

            List<showheadinv> App = new List<showheadinv>();
            foreach (var data in dt_rw)
            {

                App.Add(new showheadinv
                {
                   InvDate = data.ae.InvDate.ToString("dd/MMM/yyyy"),
                   InvID = data.ae.InvID,
                   CusID = data.ae.CusID,
                   Address = data.ae.Address,
                   TaxID = data.ae.TaxID,
                   Cusname = data.ea.CompanyNameEN,
                   idinvoice = data.ae.ID,
                   Daterecep = data.ae.Datereceipt.ToString("yyyy-MM-dd")



                });



            }



            return Json(App);
        }




        public class showdetailinv { 
        public string Date { get; set; }
        public string DateE { get; set; }
        public string CusName { get; set; }
        public string FirstnameTH { get; set; }
        public string LastNameTH { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
        public int id { get; set; }

        
        
        }


        [HttpGet]
        public IActionResult Getfulldetailinv(int id, string invoiceid, string inrw)
        {
            //if(idcus != null && invoiceidcus != null && inrwcus != null)
            //{
            //    invoiceid = invoiceidcus;
            //    id = idcus;
            //    inrw = inrwcus;
            //}
            var cus = _mysqlbro.CUS_Company.ToList();
            var inv = _mysqlbro.INV_Invoice.ToList();
            var invdetail = _mysqlbro.INV_Detaillist.ToList();

            //var dt_rw = _mysqlbro.INV_Invoice.Where(ve => ve.CusID == id && ve.InvID == invoiceid && ve.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();
            var dt_rw = inv.Join(cus, ae => ae.CusID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Join(invdetail, fg => fg.ae.ID, gf => gf.InvID, (fg, gf) => new { fg, gf })
                .Where(ve => ve.fg.ae.CusID == id && ve.fg.ae.InvID == invoiceid && ve.fg.ae.Rewrite == Convert.ToInt32(inrw.Replace("RW0", ""))).ToList();

            List<showdetailinv> App = new List<showdetailinv>();
            foreach (var data in dt_rw)
            {

                App.Add(new showdetailinv
                {
                   Date = data.gf.Date.ToString("dd/MM/yyyy"),
                   CusName = data.gf.CusName,
                   FirstnameTH = data.gf.FirstnameTH,
                   LastNameTH = data.gf.LastNameTH,
                   Service = data.gf.Service,
                   Amount = data.gf.Amount,
                   id = data.gf.ID,
                   DateE = data.gf.Date.ToString("yyyy-MM-dd")



                });

            }
            return Json(App);
        }

        [HttpGet]
        public IActionResult Getcompany_detail(int id)
        {
            var dt_invoice = _mysqlbro.INV_Invoice.Select(dg => new { dg.Address, dg.CusID, dg.TaxID,  dg.InvDate }).OrderByDescending(fr => fr.InvDate).FirstOrDefault(ae => ae.CusID == id);

            return Json(dt_invoice);

        }

        [HttpGet]
        public IActionResult invoice_summary()
        {


            return View();

        }

        public IActionResult Getyearsummary()
        {
            var year = _mysqlbro.INV_Invoice.Select(ae => new { year = ae.InvDate.Year }).Distinct().OrderByDescending(er => er.year).ToList();

            return Json(year);

        }

        public IActionResult Getcomsummary()
        {
            var dt_ko = _mysqlbro.INV_Invoice.ToList();
            var dt_ke = _mysqlbro.CUS_Company.ToList();
            var com = dt_ke.Join(dt_ke, gn => gn.CompanyCode, ng => ng.CompanyCode, (gn, ng) => new { gn, ng }).Select(mf => new { mf.ng.ID, mf.ng.NameSimple }).Distinct().ToList();
            return Json(com);

        }

        public class invoicesummary { 
        
        public string Datereceipt { get; set; }
        public string NameSimple { get; set; }
        public string InvoiceID { get; set; }
        public string Customer { get; set; }
        public string IssueDate { get; set; }
        public string Transfer { get; set; }
        public string Receive { get; set; }
        public string CompanyCode { get; set; }
        public string Rewrite { get; set; }
        public string status { get; set; }
        public string billno { get; set; }
        public string Datereceive { get; set; }
        public string id { get; set; }
        
        
        
        }

        public IActionResult Getsummamry(string year, string company, string month, string type)
        {
            using (MySqlConnection con = new MySqlConnection("Data Source=103.30.126.174;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            {

                con.Open();
                var query = "SELECT Datereceipt"+
", NameSimple" +
", InvID as InvoiceID" +
",NameSimple as Customer" +
",InvDate as IssueDate" +

",FORMAT(IFNULL(iv.Totalprice, '0'), '#,##0.00') Transfer" +
",FORMAT(IFNULL(iv.Receiveamount, '0'), '#,##0.00') Receive" +
",CompanyCode" +
",Rewrite,cc.ID,iv.InvDate,Appov,iv.Datereceive,iv.BillNo " +

"FROM INV_Invoice iv " +
"LEFT OUTER JOIN CUS_Company cc ON cc.ID = iv.CusID " +
"WHERE YEAR(iv.InvDate) = '" + year + "' AND iv.Rewrite = (SELECT MAX(Rewrite) " +
"FROM INV_Invoice vo " +
"WHERE Status = '1' AND YEAR(vo.InvDate) = '" + year + "' ?1 AND vo.InvID = iv.InvID) ?1 " +
"?2 " +
"?3 " +
"ORDER BY InvDate DESC ";  
                
//                var query2 = "SELECT InvReceiptDate,NameSimple ,InvInvoiceID as InvoiceID,NameSimple as Customer ,InvDate as IssueDate,FORMAT(IFNULL(InvSalaryB,'0'),'#,##0.00') as Salary,FORMAT(IFNULL(InvOTB,'0'),'#,##0.00') as OT,FORMAT(IFNULL(InvWelfareB,'0'),'#,##0.00') as Welfare,FORMAT(IFNULL(InvChargeSalaryB,'0') + IFNULL(InvChargeOTB,'0') + IFNULL(InvChargeWelfareB,'0') + IFNULL(InvChargeOtherB,'0'),'#,##0.00') as Charge,FORMAT(IFNULL(InvTotalPriceB,'0'),'#,##0.00') Total,FORMAT(IFNULL(InvVatB,'0'),'#,##0.00')  Vat ,FORMAT(IFNULL(InvTaxB,'0'),'#,##0.00') WidthHold,FORMAT(IFNULL(InvTotalAmountB,'0'),'#,##0.00') Transfer,FORMAT(IFNULL(InvReceiveB,'0'),'#,##0.00') Receive,InvDateReceive DateReceive,InvBillNo as ReceiptID,CASE WHEN InvApprove IS NULL THEN 'NOT' ELSE 'OK' END as Status,FORMAT(IFNULL(InvE_SSO,0) + IFNULL(InvC_SSO,0),'#,##0.00') as SSO,FORMAT(IFNULL(InvE_SSO,'0'),'#,##0.00') as E_SSO,FORMAT(IFNULL(InvC_SSO,'0'),'#,##0.00') as C_SSO,CompanyCode,InvRewrite,Timelog " +
//"FROM AMN_Invoice iv " +
//"LEFT OUTER JOIN CUS_Company ON InvCustID = CompanyCode " +
//"WHERE YEAR(InvDate) = '" + year + "' AND InvRewrite = (SELECT MAX(InvRewrite) " +
//"FROM AMN_Invoice vo " +
//"WHERE Status = '1' AND YEAR(InvDate) = '" + year + "' ?1 AND vo.InvInvoiceID = iv.InvInvoiceID) ?1 " +
//"?2 " +
//"?3 " +
//"ORDER BY IssueDate ";
                //_mysqlbro.Database.ExecuteSqlRaw(query);
                if (month == null)
                {
                    query = query.Replace("?1", "");
                }
                else if (month != null)
                {
                    query = query.Replace("?1", "AND MONTH(InvDate) = '" + month + "' ");
                }
                if (company == null)
                {
                    query = query.Replace("?2", "");
                }
                else if (company != null)
                {
                    query = query.Replace("?2", "AND CusID = '" + company + "' ");
                }
                else if (company == "all")
                {
                    query = query.Replace("?2", "AND CusID IN (SELECT ID FROM CUS_Company ");
                }

                if (type == null)
                {
                    query = query.Replace("?3", "");
                }
                else if (type != null)
                {
                    if (type == "0")
                        query = query.Replace("?3", "");
                    else if (type == "1")
                        query = query.Replace("?3", "AND IFNULL(Receiveamount,0) > 0  ");
                    else if (type == "2")
                        query = query.Replace("?3", "AND IFNULL(Receiveamount,0) < 1  ");
                }

                //if (company == null)
                //{
                //    query = query.Replace("?2", "");
                //}
                //else if (company != null)
                //{
                //    query = query.Replace("?2", "AND InvCustID = '" + company + "' ");
                //}

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader row = cmd.ExecuteReader();
                List<invoicesummary> list = new List<invoicesummary>();
                while (row.Read())
                {
                    list.Add(new invoicesummary()
                    {
                        Datereceipt = row["Datereceipt"].ToString(),
                        NameSimple = row["Customer"].ToString(),
                        InvoiceID = row["InvoiceID"].ToString(),
                        IssueDate = Convert.ToDateTime(row["IssueDate"]).ToString("yyyy-MM-dd"),
                        Transfer = row["Transfer"].ToString(),
                        Receive = row["Receive"].ToString(),
                        CompanyCode = row["CompanyCode"].ToString(),
                        Rewrite = row["Rewrite"].ToString(),
                        status = (row["Appov"].ToString() == "1"? "OK": "NOT"),
                        billno = "RE" + Convert.ToDateTime(row["Datereceipt"]).ToString("yyyy") + "-" + (row["BillNo"].ToString().Length > 2 ? null : (row["BillNo"].ToString().Length == 1 ? "00" : "0" )) + row["BillNo"].ToString(),
                        Datereceive = (row["Datereceive"] is DBNull ? row["Datereceive"].ToString().Replace("0001-01-01", "") : Convert.ToDateTime(row["Datereceive"]).ToString("yyyy-MM-dd")),
                        id = row["ID"].ToString()

                        //customer = row["Customer"].ToString(),
                        //InvoiceID = row["InvoiceID"].ToString(),
                        //IssueDate = Convert.ToDateTime(row["IssueDate"].ToString()).ToString("yyyy-MM-dd"),
                        //Salary = row["Salary"].ToString(),
                        //ot = row["OT"].ToString(),
                        //Welfare = row["Welfare"].ToString(),
                        //Charge = row["Charge"].ToString(),
                        //Total = row["Total"].ToString(),
                        //Vat = row["Vat"].ToString(),
                        //Withhold = row["WidthHold"].ToString(),
                        //Transfer = row["Transfer"].ToString(),
                        //Receive = row["Receive"].ToString(),
                        //DataReceive = (row["DateReceive"] is DBNull ? row["DateReceive"].ToString().Replace("0001-01-01", "") : Convert.ToDateTime(row["DateReceive"].ToString()).ToString("yyyy-MM-dd")),
                        //ReceiptID = "RE" + Convert.ToDateTime(row["Datereceipt"]).ToString("yyyy") + "-0" + row["ReceiptID"].ToString(),
                        //Status = row["Status"].ToString(),
                        //CustID = row["CompanyCode"].ToString(),
                        //invrw = row["InvRewrite"].ToString(),
                        //SSO = row["SSO"].ToString(),
                        //E_SSO = row["E_SSO"].ToString(),
                        //C_SSO = row["C_SSO"].ToString(),
                        //Timelog = (row["Timelog"] is DBNull ? "" : Convert.ToDateTime(row["Timelog"].ToString()).ToString("yyyy-MM-dd"))



                    });
                }

                //ViewBag.PlaceBirthList = list.ToArray();
                return Json(list);
            }

           
        }
        public IActionResult Approve(string id)
        {

            var query = "UPDATE INV_Invoice " +
            "SET Appov = 1" +
            ",DateAppov = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' " +
            "WHERE " +
            "InvID = '" + id + "' ";
            _mysqlbro.Database.ExecuteSqlRaw(query);

            return Json("success");

        }

        public IActionResult DeleteInv(string id)
        {

            var query = "DELETE FROM INV_Invoice " +
            "WHERE " +
            "InvID = '" + id + "' ";
            _mysqlbro.Database.ExecuteSqlRaw(query);

            return Json("success");

        }

        public IActionResult NotApprove(string id)
        {

            var query = "UPDATE INV_Invoice " +
            "SET Appov = NULL" +
            ",DateAppov = NULL " +
            "WHERE " +
            "InvID = '" + id + "' ";
            _mysqlbro.Database.ExecuteSqlRaw(query);

            return Json("success");

        }


        public IActionResult Exportex(string year, string company, string month, string type)
        {
            DataTable dt = new DataTable("Invoice_report");
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Customer"),
                                        new DataColumn("Invoice"),
                                        new DataColumn("Issue Date"),
                                        //new DataColumn("Edit Date") ,
                                      
                                        new DataColumn("Total Amount") ,
                                        new DataColumn("Received Payment") ,
                                        new DataColumn("Payment Date") ,
                                        new DataColumn("Receipt") ,
                                        new DataColumn("Status") ,
                                      


            });



            using (MySqlConnection con = new MySqlConnection("Data Source=103.30.126.174;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            {
                con.Open();
                var query = "SELECT Datereceipt" +
", NameSimple" +
", InvID as InvoiceID" +
",NameSimple as Customer" +
",InvDate as IssueDate" +

",FORMAT(IFNULL(iv.Totalprice, '0'), '#,##0.00') Transfer" +
",FORMAT(IFNULL(iv.Receiveamount, '0'), '#,##0.00') Receive" +
",CompanyCode" +
",Rewrite,cc.ID,iv.InvDate,Appov,iv.Datereceive,iv.BillNo,CASE WHEN Appov IS NULL THEN 'NOT' ELSE 'OK' END as Status " +

"FROM INV_Invoice iv " +
"LEFT OUTER JOIN CUS_Company cc ON cc.ID = iv.CusID " +
"WHERE YEAR(iv.InvDate) = '" + year + "' AND iv.Rewrite = (SELECT MAX(Rewrite) " +
"FROM INV_Invoice vo " +
"WHERE Status = '1' AND YEAR(vo.InvDate) = '" + year + "' ?1 AND vo.InvID = iv.InvID) ?1 " +
"?2 " +
"?3 " +
"ORDER BY InvDate DESC ";
                //_mysqlbro.Database.ExecuteSqlRaw(query);
                if (month == "null")
                {
                    query = query.Replace("?1", "");
                }
                else if (month != "null")
                {
                    query = query.Replace("?1", "AND MONTH(InvDate) = '" + month + "' ");
                }
                if (company == "null")
                {
                    query = query.Replace("?2", "");
                }
                else if (company != "null")
                {
                    query = query.Replace("?2", "AND CusID = '" + company + "' ");
                }
                else if (company == "all")
                {
                    query = query.Replace("?2", "AND CusID IN (SELECT ID FROM CUS_Company ");
                }

                if (type == "null")
                {
                    query = query.Replace("?3", "");
                }
                else if (type != "null")
                {
                    if (type == "0")
                        query = query.Replace("?3", "");
                    else if (type == "1")
                        query = query.Replace("?3", "AND IFNULL(Receiveamount,0) > 0  ");
                    else if (type == "2")
                        query = query.Replace("?3", "AND IFNULL(Receiveamount,0) < 1  ");
                }

                //if (company == null)
                //{
                //    query = query.Replace("?2", "");
                //}
                //else if (company != null)
                //{
                //    query = query.Replace("?2", "AND InvCustID = '" + company + "' ");
                //}
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter rowe = new MySqlDataAdapter(cmd);
                //SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtt = new DataTable();
                rowe.Fill(dtt);
                List<invoicesummary> list = new List<invoicesummary>();
                decimal totalA = 0, Recepay = 0;
                foreach (DataRow data in dtt.Rows)
                {
                    
                    totalA += Convert.ToDecimal(data["Transfer"].ToString());
                    Recepay += Convert.ToDecimal(data["Receive"].ToString());
                   
                }
                dt.Rows.Add(
                        "",
                        "",
                        "",
                        
                        totalA.ToString("#,##0.00"),
                        Recepay.ToString("#,##0.00"),
                        "",
                        "",
                        ""
                       
                        //row["CustID"].ToString(),
                        //row["InvRewrite"].ToString(),
                       
                    );

                foreach (DataRow row in dtt.Rows)
                {
                    dt.Rows.Add(
                        row["Customer"].ToString(),
                        row["InvoiceID"].ToString(),
                        Convert.ToDateTime(row["IssueDate"]).ToString("yyyy-MM-dd"),
                       
                        row["Transfer"].ToString(),
                        row["Receive"].ToString(),
                        (row["Datereceive"] is DBNull ? row["Datereceive"].ToString() : Convert.ToDateTime(row["Datereceive"]).ToString("yyyy-MM-dd")),
                        "RE" + Convert.ToDateTime(row["Datereceipt"]).ToString("yyyy") + "-"+ (row["BillNo"].ToString().Length > 2 ? null : (row["BillNo"].ToString().Length == 1 ? "00" : "0")) + row["BillNo"].ToString(),
                        row["Status"].ToString()
                        //row["CustID"].ToString(),
                        //row["InvRewrite"].ToString(),
                     
                    );

                }


                using (XLWorkbook wb = new XLWorkbook())
                {
                    IXLWorksheet ws = wb.Worksheets.Add(dt);
                    //ws.Column(4).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(5).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(6).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(7).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(8).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(9).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(10).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(11).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(12).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(16).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(17).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);
                    //ws.Column(18).Cells("3:" + dtt.Rows.Count + 1).SetDataType(XLDataType.Number);

                    ws.Column(4).CellsUsed().Style.NumberFormat.Format = "#,##0.00";
                    ws.Column(5).CellsUsed().Style.NumberFormat.Format = "#,##0.00";
                   

                    ws.Column(1).Width = 12;
                    ws.Column(2).Width = 12;
                    ws.Column(3).Width = 12;
                    ws.Column(4).Width = 12;
                    ws.Column(5).Width = 12;
                    ws.Column(6).Width = 12;
                    ws.Column(7).Width = 12;
                    ws.Column(8).Width = 12;
                    ws.Column(9).Width = 12;
                    ws.Column(10).Width = 12;
                    ws.Column(11).Width = 12;
                    ws.Column(12).Width = 12;
                    ws.Column(13).Width = 12;
                    ws.Column(14).Width = 12;
                    ws.Column(15).Width = 12;
                    ws.Column(16).Width = 12;
                    ws.Column(17).Width = 12;
                    ws.Column(18).Width = 12;

                    ws.Name = "Invoice_report";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Invoice_report-" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx");
                    }
                }
            }

        }



        public IActionResult Savesummary(List<invoicesummary> collection)
        {

            //var query = "UPDATE AMN_Invoice " +
            //"SET InvApprove = NULL" +
            //",InvDateApprove = NULL " +
            //"WHERE " +
            //"InvInvoiceID = '" + id + "' ";
            //_mysqlbro.Database.ExecuteSqlRaw(query);
            foreach (var data in collection)
            {
                var query = "UPDATE INV_Invoice " +
            "SET " +
            "Receiveamount = " + data.Receive.Replace(",", "") + " " +
          
            "?1 " +
            "WHERE InvID = '" + data.InvoiceID + "' ";
                if (data.Datereceive == null)
                {
                    query = query.Replace("?1", ",Datereceive = NULL ");
                }
                else if (data.Datereceive != null)
                {
                    query = query.Replace("?1", ",Datereceive = '" + DateTime.Parse(data.Datereceive).ToString("yyyy-MM-dd 00:00:00") + "' ");
                }
                _mysqlbro.Database.ExecuteSqlRaw(query);
            }



            return Json("success");

        }

        public IActionResult editper(string id, [FromBody] invoicesav[] model)
        {
            var chk = _mysqlbro.INV_Invoice.Count();
            var dt_maxbill = 0;
            if (chk != 0)
                dt_maxbill = _mysqlbro.INV_Invoice.Select(fg => Convert.ToInt32(fg.BillNo)).Max() + 1;
            else
                dt_maxbill = 1;

            try
            {
                decimal sum = 0;
                foreach (var dat in model)
                {
                    sum += dat.amount;
                }

                var INV_Invoice = new inv_invoice
                {
                    InvDate = model[0].Dateinv,
                    InvID = model[0].number,
                    CusID = model[0].Customer,
                    Address = model[0].Address,
                    TaxID = model[0].Tax,
                    CreateDate = DateTime.Now,
                    Updatedate = DateTime.Now,
                    BillNo = dt_maxbill,
                    Rewrite = 0,
                    //Datereceive = model[0].Dateinv,
                    Totalprice = sum,
                    Status = "1",
                    Datereceipt = DateTime.Now


                };
                _mysqlbro.INV_Invoice.Add(INV_Invoice);
                _mysqlbro.SaveChanges();


                foreach (var dat in model)
                {

                    var INV_Detaillist = new inv_detaillist
                    {
                        Date = dat.date,
                        CusName = dat.company,
                        InvID = INV_Invoice.ID,
                        FirstnameTH = dat.name,
                        LastNameTH = dat.namel,
                        Service = dat.service,
                        Amount = dat.amount,
                        Createdate = DateTime.Now,
                        updatedate = DateTime.Now,
                        Status = "1"





                    };
                    _mysqlbro.INV_Detaillist.Add(INV_Detaillist);
                    _mysqlbro.SaveChanges();
                }


                return Json("suc");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public IActionResult editinvoice() {


            return View();
        }

    }
}
