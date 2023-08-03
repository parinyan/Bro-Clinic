using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bbsaha.Data;
using bbsaha.Models.Certificate;
using bbsaha.Models.patient;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace bbsaha.Controllers
{
    public class medicController : Controller
    {
        private IConverter _converter;
        private readonly MysqlDBDataContext _mysqlbro;
        public medicController(MysqlDBDataContext newbrother, IConverter converter)
        {
            //_context = context;
            //_converter = converter;
            //_configuration = configuration;
            _mysqlbro = newbrother;
            _converter = converter;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult medcerti()
        {
            return View();
        }


        public class setdata {
            public int id { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
            public string adr { get; set; }
            public string idcard { get; set; }
            public string ch1 { get; set; }
            public string ch2 { get; set; }
            public string ch3 { get; set; }
            public string ch4 { get; set; }
            //public string ch5 { get; set; }
            public string ch6 { get; set; }
            public string tex1 { get; set; }
            public string tex2 { get; set; }
            public string tex3 { get; set; }
            public string tex4 { get; set; }
            public string tex5 { get; set; }
            public string tex6 { get; set; }
            public string weight { get; set; }
            public string height { get; set; }
            public string blood { get; set; }
            public string pulse { get; set; }
            public string titlen { get; set; }
            public string comment { get; set; }
            public string medtype { get; set; }
            public string time { get; set; }
            public string type { get; set; }
            public DateTime DateCus { get; set; }



        }

        [HttpPost]
        public IActionResult savedata([FromBody] setdata[] model)
        {


            var num = _mysqlbro.CER_Medical.Where(x => x.cerid.Contains(model[0].DateCus.ToString("yyMMdd"))).Select(v => new { v.cerid }).ToList();

            var CER_medical = new cer_medical {

                cerid = model[0].DateCus.ToString("yyMMdd"),
                CerDate = model[0].DateCus,
                FirstNameCus = model[0].fname,
                lastNameCus = model[0].lname,
                AddressCus = model[0].adr,
                Check_1 = (model[0].ch1 == "One" ? false : true),
                Check_2 = (model[0].ch2 == "One" ? false : true),
                Check_3 = (model[0].ch3 == "One" ? false : true),
                Check_4 = (model[0].ch4 == "One" ? false : true),
                Detail_1 = model[0].tex1,
                Detail_2 = model[0].tex2,
                Detail_3 = model[0].tex3,
                Detail_4 = model[0].tex4,
                Detail_5 = model[0].tex5,
                IdcardCus = model[0].idcard,
                WeightCus = (model[0].weight != "" ? Convert.ToDecimal(model[0].weight) : 0),
                HeightCus = (model[0].height != "" ? Convert.ToDecimal(model[0].height) : 0),
                blood_pressureCus = model[0].blood,
                PulseCus = (model[0].pulse != "" ? Convert.ToInt32(model[0].pulse) : 0),
                Body_healthStatusCus = (model[0].ch6 == "One" ? false : true),
                Body_healthDetailCus = model[0].tex6,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                RecordBy = User.Identity.Name,
                Status = "1",
                Runnumber = num.Count() + 1,
                NameComId = 1,
                NametitleCus = model[0].titlen,
                CommentCom = model[0].comment


            };

            _mysqlbro.CER_Medical.Add(CER_medical);
            _mysqlbro.SaveChanges();




            return Json("a");
        }

        [HttpPost]
        public IActionResult Updatedata([FromBody] setdata[] model)
        {


            var num = _mysqlbro.CER_Medical.FirstOrDefault(x => x.ID == model[0].id);

            if (num != null) {

                //num.cerid = model[0].DateCus.ToString("yyMMdd"),
                num.CerDate = model[0].DateCus;
                num.FirstNameCus = model[0].fname;
                num.lastNameCus = model[0].lname;
                num.AddressCus = model[0].adr;
                num.Check_1 = (model[0].ch1 == "One" ? false : true);
                num.Check_2 = (model[0].ch2 == "One" ? false : true);
                num.Check_3 = (model[0].ch3 == "One" ? false : true);
                num.Check_4 = (model[0].ch4 == "One" ? false : true);
                num.Detail_1 = model[0].tex1;
                num.Detail_2 = model[0].tex2;
                num.Detail_3 = model[0].tex3;
                num.Detail_4 = model[0].tex4;
                num.Detail_5 = model[0].tex5;
                num.IdcardCus = model[0].idcard;
                num.WeightCus = (model[0].weight != "" ? Convert.ToDecimal(model[0].weight) : 0);
                num.HeightCus = (model[0].height != "" ? Convert.ToDecimal(model[0].height) : 0);
                num.blood_pressureCus = model[0].blood;
                num.PulseCus = (model[0].pulse != "" ? Convert.ToInt32(model[0].pulse) : 0);
                num.Body_healthStatusCus = (model[0].ch6 == "One" ? false : true);
                num.Body_healthDetailCus = model[0].tex6;              
                num.UpdateDate = DateTime.Now;
                num.RecordBy = User.Identity.Name;
                num.NametitleCus = model[0].titlen;
                num.CommentCom = model[0].comment;



                _mysqlbro.CER_Medical.Update(num);
                _mysqlbro.SaveChanges();



            }



            return Json("suc");
        }


        public IActionResult GetMedicCer() {

            var _data = _mysqlbro.CER_Medical.OrderByDescending(x => x.ID).Where(c => c.Status == "1").ToList();

            //foreach (var dat in _data)
            //   dat.CerDate = dat.CerDate.ToString("yyyy-MM-dd");

            return Json(_data);
        
        }

        public IActionResult GetPrintcertificate(string id)
        {
            //var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("mediccer_report", "medic", new { id = id });

            //var globalSettings = new GlobalSettings()
            //{
            //    ColorMode = ColorMode.Color,
            //    Orientation = Orientation.Portrait,
            //    PaperSize = PaperKind.A4,
            //    Margins = new MarginSettings { Top = 2, Bottom = 2, Right = 5, Left = 5 },
            //    DocumentTitle = "Medical Certificate"
            //};
            //var objectSettings = new ObjectSettings()
            //{
            //    Page = url
            //};
            //var pdf = new HtmlToPdfDocument()
            //{
            //    GlobalSettings = globalSettings,
            //    Objects = { objectSettings }
            //};
            //var file = _converter.Convert(pdf);

            //return File(file, "application/pdf");

            var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("mediccer_report", "medic", new { id = id });

            var _chk = _mysqlbro.CER_Medical.FirstOrDefault(x => x.ID == Convert.ToInt32(id));

            if (_chk.type == "1")
            {
                url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("mediccer_general", "medic", new { id = id });
            }
            else if (_chk.type == "2")
            {
                url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("mediccer_report", "medic", new { id = id });
            }
            else if (_chk.type == "3")
            {
                url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("mediccer_cerfive", "medic", new { id = id });
            }
            else if (_chk.type == "4")
            {
                url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("mediccer_generalfor", "medic", new { id = id });
            }

            //var globalSettings = new GlobalSettings()
            //{
            //    ColorMode = ColorMode.Color,
            //    Orientation = Orientation.Portrait,
            //    PaperSize = PaperKind.A4,
            //    Margins = new MarginSettings { Top = 1, Bottom = 1, Right = 5, Left = 5 },
            //    DocumentTitle = "Medical Certificate"
            //};
            //var objectSettings = new ObjectSettings()
            //{
            //    Page = url
            //};
            //var pdf = new HtmlToPdfDocument()
            //{
            //    GlobalSettings = globalSettings,
            //    Objects = { objectSettings }
            //};
            //var file = _converter.Convert(pdf);

            //return File(file, "application/pdf");

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
            converter.Options.MarginLeft = 15;
            converter.Options.MarginRight = 15;
            converter.Options.MarginTop = 15;
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
        }

        public IActionResult mediccer_report(int id)
        {
            var _datache = _mysqlbro.CER_Medical.Where(x => x.ID == id).ToList();
            var _datahea = _mysqlbro.CER_Header.ToList();

            var _datasum = _datache.Join(_datahea, ae => ae.NameComId, ea => ea.ID, (ae, ea) => new { ae, ea }).ToList();

            List<View_Datacer> listA = new List<View_Datacer>();

            foreach (var dat in _datasum) {

                listA.Add(new View_Datacer
                {
                    NametitleCus = dat.ae.NametitleCus,
                    FirstNameCus = dat.ae.FirstNameCus,
                    lastNameCus = dat.ae.lastNameCus,
                    AddressCus = dat.ae.AddressCus,
                    IdcardCus = dat.ae.IdcardCus,
                    Check_1 = dat.ae.Check_1,
                    Check_2 = dat.ae.Check_2,
                    Check_3 = dat.ae.Check_3,
                    Check_4 = dat.ae.Check_4,
                    Check_5 = dat.ae.Check_5,
                    Detail_1 = dat.ae.Detail_1,
                    Detail_2 = dat.ae.Detail_2,
                    Detail_3 = dat.ae.Detail_3,
                    Detail_4 = dat.ae.Detail_4,
                    Detail_5 = dat.ae.Detail_5,
                    CerDate = dat.ae.CerDate,
                    WeightCus = dat.ae.WeightCus,
                    HeightCus = dat.ae.HeightCus,
                    blood_pressureCus = dat.ae.blood_pressureCus,
                    PulseCus = dat.ae.PulseCus,
                    Body_healthStatusCus = dat.ae.Body_healthStatusCus,
                    Body_healthDetailCus = dat.ae.Body_healthDetailCus,
                    CommentCom = dat.ae.CommentCom,
                    FnameCom = dat.ea.FnameCom,
                    LnameCom = dat.ea.LnameCom,
                    LicenseIdCom = dat.ea.LicenseIdCom,
                    NameClinic = dat.ea.NameClinic,
                    titleCom = dat.ea.titleCom,
                    runnumber = dat.ae.Runnumber.ToString(),
                    cerid = dat.ae.cerid

                });
            
            }

            ViewBag.data = listA.ToArray();
            return View();
        }


        public IActionResult mediccer_cerfive(int id)
        {
            var _datache = _mysqlbro.CER_Medical.Where(x => x.ID == id).ToList();
            var _datahea = _mysqlbro.CER_Header.ToList();

            var _datasum = _datache.Join(_datahea, ae => ae.NameComId, ea => ea.ID, (ae, ea) => new { ae, ea }).ToList();

            List<View_Datacer> listA = new List<View_Datacer>();

            foreach (var dat in _datasum)
            {

                listA.Add(new View_Datacer
                {
                    NametitleCus = dat.ae.NametitleCus,
                    FirstNameCus = dat.ae.FirstNameCus,
                    lastNameCus = dat.ae.lastNameCus,
                    AddressCus = dat.ae.AddressCus,
                    IdcardCus = dat.ae.IdcardCus,
                    Check_1 = dat.ae.Check_1,
                    Check_2 = dat.ae.Check_2,
                    Check_3 = dat.ae.Check_3,
                    Check_4 = dat.ae.Check_4,
                    Check_5 = dat.ae.Check_5,
                    Detail_1 = dat.ae.Detail_1,
                    Detail_2 = dat.ae.Detail_2,
                    Detail_3 = dat.ae.Detail_3,
                    Detail_4 = dat.ae.Detail_4,
                    Detail_5 = dat.ae.Detail_5,
                    CerDate = dat.ae.CerDate,
                    WeightCus = dat.ae.WeightCus,
                    HeightCus = dat.ae.HeightCus,
                    blood_pressureCus = dat.ae.blood_pressureCus,
                    PulseCus = dat.ae.PulseCus,
                    Body_healthStatusCus = dat.ae.Body_healthStatusCus,
                    Body_healthDetailCus = dat.ae.Body_healthDetailCus,
                    CommentCom = dat.ae.CommentCom,
                    FnameCom = dat.ea.FnameCom,
                    LnameCom = dat.ea.LnameCom,
                    LicenseIdCom = dat.ea.LicenseIdCom,
                    NameClinic = dat.ea.NameClinic,
                    titleCom = dat.ea.titleCom,
                    runnumber = dat.ae.Runnumber.ToString(),
                    cerid = dat.ae.cerid

                });

            }

            ViewBag.data = listA.ToArray();
            return View();
        }

        public IActionResult mediccer_general(int id)
        {
            var _datache = _mysqlbro.CER_Medical.Where(x => x.ID == id).ToList();
            var _datahea = _mysqlbro.CER_Header.ToList();

            var _datasum = _datache.Join(_datahea, ae => ae.NameComId, ea => ea.ID, (ae, ea) => new { ae, ea }).ToList();

            List<View_Datacer> listA = new List<View_Datacer>();

            foreach (var dat in _datasum)
            {

                listA.Add(new View_Datacer
                {
                    NametitleCus = dat.ae.NametitleCus,
                    FirstNameCus = dat.ae.FirstNameCus,
                    lastNameCus = dat.ae.lastNameCus,
                    AddressCus = dat.ae.AddressCus,
                    IdcardCus = dat.ae.IdcardCus,
                    Check_1 = dat.ae.Check_1,
                    Check_2 = dat.ae.Check_2,
                    Check_3 = dat.ae.Check_3,
                    Check_4 = dat.ae.Check_4,
                    Check_5 = dat.ae.Check_5,
                    Detail_1 = dat.ae.Detail_1,
                    Detail_2 = dat.ae.Detail_2,
                    Detail_3 = dat.ae.Detail_3,
                    Detail_4 = dat.ae.Detail_4,
                    Detail_5 = dat.ae.Detail_5,
                    CerDate = dat.ae.CerDate,
                    WeightCus = dat.ae.WeightCus,
                    HeightCus = dat.ae.HeightCus,
                    blood_pressureCus = dat.ae.blood_pressureCus,
                    PulseCus = dat.ae.PulseCus,
                    Body_healthStatusCus = dat.ae.Body_healthStatusCus,
                    Body_healthDetailCus = dat.ae.Body_healthDetailCus,
                    CommentCom = dat.ae.CommentCom,
                    FnameCom = dat.ea.FnameCom,
                    LnameCom = dat.ea.LnameCom,
                    LicenseIdCom = dat.ea.LicenseIdCom,
                    NameClinic = dat.ea.NameClinic,
                    titleCom = dat.ea.titleCom,

                });

            }

            ViewBag.data = listA.ToArray();
            return View();
        }
        


        public IActionResult mediccer_generalfor(int id)
        {
            var _datache = _mysqlbro.CER_Medical.Where(x => x.ID == id).ToList();
            var _datahea = _mysqlbro.CER_Header.ToList();

            var _datasum = _datache.Join(_datahea, ae => ae.NameComId, ea => ea.ID, (ae, ea) => new { ae, ea }).ToList();

            List<View_Datacer> listA = new List<View_Datacer>();

            foreach (var dat in _datasum)
            {

                listA.Add(new View_Datacer
                {
                    NametitleCus = dat.ae.NametitleCus,
                    FirstNameCus = dat.ae.FirstNameCus,
                    lastNameCus = dat.ae.lastNameCus,
                    AddressCus = dat.ae.AddressCus,
                    IdcardCus = dat.ae.IdcardCus,
                    Check_1 = dat.ae.Check_1,
                    Check_2 = dat.ae.Check_2,
                    Check_3 = dat.ae.Check_3,
                    Check_4 = dat.ae.Check_4,
                    Check_5 = dat.ae.Check_5,
                    Detail_1 = dat.ae.Detail_1,
                    Detail_2 = dat.ae.Detail_2,
                    Detail_3 = dat.ae.Detail_3,
                    Detail_4 = dat.ae.Detail_4,
                    Detail_5 = dat.ae.Detail_5,
                    CerDate = dat.ae.CerDate,
                    WeightCus = dat.ae.WeightCus,
                    HeightCus = dat.ae.HeightCus,
                    blood_pressureCus = dat.ae.blood_pressureCus,
                    PulseCus = dat.ae.PulseCus,
                    Body_healthStatusCus = dat.ae.Body_healthStatusCus,
                    Body_healthDetailCus = dat.ae.Body_healthDetailCus,
                    CommentCom = dat.ae.CommentCom,
                    FnameCom = dat.ea.FnameCom,
                    LnameCom = dat.ea.LnameCom,
                    LicenseIdCom = dat.ea.LicenseIdCom,
                    NameClinic = dat.ea.NameClinic,
                    titleCom = dat.ea.titleCom,

                });

            }

            ViewBag.data = listA.ToArray();
            return View();
        }

        public IActionResult Getdatadetailfor(int id) {


            var _data = _mysqlbro.CER_Medical.Where(x => x.ID == id).ToList();


            //ViewBag.detaildat = _data.ToArray();

            return Json(_data);
        
        }


        [HttpPost]
        public IActionResult Delmer([FromBody] setdata[] model)
        {


            var num = _mysqlbro.CER_Medical.FirstOrDefault(x => x.ID == model[0].id);

            if (num != null)
            {

                //num.cerid = model[0].DateCus.ToString("yyMMdd"),
                num.Status = "0";



                _mysqlbro.CER_Medical.Update(num);
                _mysqlbro.SaveChanges();



            }



            return Json("suc");
        }

        public IActionResult Getdatamedcer(int id)
        {


            var _data = _mysqlbro.CN_Patient.Where(x => x.ID == id).ToList();


            foreach (var a in _data) {
                var _sd = _mysqlbro.CEN_SubDistrictTH.FirstOrDefault(x => x.SubDistrictID == a.SubDistrict);
                var _dis = _mysqlbro.CEN_DistrictTH.FirstOrDefault(x => x.DistrictID == a.District);
                var _pro = _mysqlbro.CEN_ProvinceTH.FirstOrDefault(x => x.ProvinceID == a.Province);
                var _post = _mysqlbro.CEN_Postcode.FirstOrDefault(x => x.DistrictID == a.District);

                a.District = _dis.DistrictTH;
                a.SubDistrict = _sd.SubDistrictTH;
                a.Province = _pro.ProvinceTH;
                a.Postcode = _post.PostCode;

            }
            //ViewBag.detaildat = _data.ToArray();

            return Json(_data);

        }

        [HttpPost]
        public IActionResult savedatatype1([FromBody] setdata[] model)
        {
            var _chk = 0;
            try
            {
                _chk = _mysqlbro.CN_Detail.Max(x => x.IDrunnumber);
            }
            catch (Exception ex)
            {

            }

            var detail = new cn_detail
            {
                PatientID = model[0].id,
                Height = 0,
                Weight = 0,
                Pulse = "",
                BPM = "",
                Alcohol = "1",
                Cigar = "1",
                DateReg = model[0].DateCus,
                time = model[0].time,
                Customer = "-",
                HisSick = "ไม่มี",
                hisphara = "ไม่มี",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UpdateBy = User.Identity.Name,
                IDrunnumber = _chk + 1 ,
                IDdate = model[0].DateCus.ToString("yyMMdd"),
                medtype = model[0].medtype

            };

            _mysqlbro.CN_Detail.Add(detail);
            _mysqlbro.SaveChanges();

            var num = _mysqlbro.CER_Medical.Where(x => x.cerid.Contains(model[0].DateCus.ToString("yyMMdd"))).Select(v => new { v.cerid }).ToList();

            var CER_medical = new cer_medical
            {

                cerid = model[0].DateCus.ToString("yyMMdd"),
                CerDate = model[0].DateCus,
                FirstNameCus = model[0].fname,
                lastNameCus = model[0].lname,
                AddressCus = model[0].adr,
                Check_1 = (model[0].ch1 == "One" ? false : true),
                Check_2 = (model[0].ch2 == "One" ? false : true),
                Check_3 = (model[0].ch3 == "One" ? false : true),
                Check_4 = (model[0].ch4 == "One" ? false : true),
                Detail_1 = model[0].tex1,
                Detail_2 = model[0].tex2,
                Detail_3 = model[0].tex3,
                Detail_4 = model[0].tex4,
                Detail_5 = model[0].tex5,
                IdcardCus = model[0].idcard,
                WeightCus = (model[0].weight != "" ? Convert.ToDecimal(model[0].weight) : 0),
                HeightCus = (model[0].height != "" ? Convert.ToDecimal(model[0].height) : 0),
                blood_pressureCus = model[0].blood,
                PulseCus = (model[0].pulse != "" ? Convert.ToInt32(model[0].pulse) : 0),
                Body_healthStatusCus = (model[0].ch6 == "One" ? false : true),
                Body_healthDetailCus = model[0].tex6,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                RecordBy = User.Identity.Name,
                Status = "1",
                Runnumber = num.Count() + 1,
                NameComId = 1,
                NametitleCus = model[0].titlen,
                CommentCom = model[0].comment,
                DetailID = detail.ID,
                type = model[0].type


            };

            _mysqlbro.CER_Medical.Add(CER_medical);
            _mysqlbro.SaveChanges();




            return Json("suc");
        }


        [HttpPost]
        public IActionResult savedatatype2([FromBody] setdata[] model)
        {
            var _chk = 0;
            try
            {
                _chk = _mysqlbro.CN_Detail.Max(x => x.IDrunnumber);
            }
            catch (Exception ex)
            {

            }

            var detail = new cn_detail
            {
                PatientID = model[0].id,
                Height = 0,
                Weight = 0,
                Pulse = "",
                BPM = "",
                Alcohol = "1",
                Cigar = "1",
                DateReg = model[0].DateCus,
                time = model[0].time,
                Customer = "-",
                HisSick = "ไม่มี",
                hisphara = "ไม่มี",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UpdateBy = User.Identity.Name,
                IDrunnumber = _chk + 1,
                IDdate = model[0].DateCus.ToString("yyMMdd"),
                medtype = model[0].medtype

            };

            _mysqlbro.CN_Detail.Add(detail);
            _mysqlbro.SaveChanges();

            var num = _mysqlbro.CER_Medical.Where(x => x.cerid.Contains(model[0].DateCus.ToString("yyMMdd"))).Select(v => new { v.cerid }).ToList();

            var CER_medical = new cer_medical
            {

                cerid = model[0].DateCus.ToString("yyMMdd"),
                CerDate = model[0].DateCus,
                FirstNameCus = model[0].fname,
                lastNameCus = model[0].lname,
                AddressCus = model[0].adr,
                Check_1 = (model[0].ch1 == "One" ? false : true),
                Check_2 = (model[0].ch2 == "One" ? false : true),
                Check_3 = (model[0].ch3 == "One" ? false : true),
                Check_4 = (model[0].ch4 == "One" ? false : true),
                Detail_1 = model[0].tex1,
                Detail_2 = model[0].tex2,
                Detail_3 = model[0].tex3,
                Detail_4 = model[0].tex4,
                Detail_5 = model[0].tex5,
                IdcardCus = model[0].idcard,
                WeightCus = (model[0].weight != "" ? Convert.ToDecimal(model[0].weight) : 0),
                HeightCus = (model[0].height != "" ? Convert.ToDecimal(model[0].height) : 0),
                blood_pressureCus = model[0].blood,
                PulseCus = (model[0].pulse != "" ? Convert.ToInt32(model[0].pulse) : 0),
                Body_healthStatusCus = (model[0].ch6 == "One" ? false : true),
                Body_healthDetailCus = model[0].tex6,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                RecordBy = User.Identity.Name,
                Status = "1",
                Runnumber = num.Count() + 1,
                NameComId = 1,
                NametitleCus = model[0].titlen,
                CommentCom = model[0].comment,
                DetailID = detail.ID,
                type = model[0].type


            };

            _mysqlbro.CER_Medical.Add(CER_medical);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }


        [HttpPost]
        public IActionResult savedatatype3([FromBody] setdata[] model)
        {
            var _chk = 0;
            try
            {
                _chk = _mysqlbro.CN_Detail.Max(x => x.IDrunnumber);
            }
            catch (Exception ex)
            {

            }

            var detail = new cn_detail
            {
                PatientID = model[0].id,
                Height = 0,
                Weight = 0,
                Pulse = "",
                BPM = "",
                Alcohol = "1",
                Cigar = "1",
                DateReg = model[0].DateCus,
                time = model[0].time,
                Customer = "-",
                HisSick = "ไม่มี",
                hisphara = "ไม่มี",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UpdateBy = User.Identity.Name,
                IDrunnumber = _chk + 1,
                IDdate = model[0].DateCus.ToString("yyMMdd"),
                medtype = model[0].medtype

            };

            _mysqlbro.CN_Detail.Add(detail);
            _mysqlbro.SaveChanges();

            var num = _mysqlbro.CER_Medical.Where(x => x.cerid.Contains(model[0].DateCus.ToString("yyMMdd"))).Select(v => new { v.cerid }).ToList();

            var CER_medical = new cer_medical
            {

                cerid = model[0].DateCus.ToString("yyMMdd"),
                CerDate = model[0].DateCus,
                FirstNameCus = model[0].fname,
                lastNameCus = model[0].lname,
                AddressCus = model[0].adr,
              
                IdcardCus = model[0].idcard,
                Detail_5 = model[0].tex5,
                Body_healthStatusCus = (model[0].ch6 == "One" ? false : true),
                Body_healthDetailCus = model[0].tex6,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                RecordBy = User.Identity.Name,
                Status = "1",
                Runnumber = num.Count() + 1,
                NameComId = 1,
                NametitleCus = model[0].titlen,
                CommentCom = model[0].comment,
                DetailID = detail.ID,
                type = model[0].type


            };

            _mysqlbro.CER_Medical.Add(CER_medical);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }



        [HttpPost]
        public IActionResult editdatatype3([FromBody] setdata[] model)
        {
            //var _chk = 0;
            //try
            //{
            //    _chk = _mysqlbro.CN_Detail.Max(x => x.IDrunnumber);
            //}
            //catch (Exception ex)
            //{

            //}

            var _dataedit = _mysqlbro.CER_Medical.FirstOrDefault(x => x.ID == model[0].id);


            //_dataedit.CerDate = model[0].DateCus;
            _dataedit.FirstNameCus = model[0].fname;
            _dataedit.lastNameCus = model[0].lname;
            _dataedit.AddressCus = model[0].adr;
            _dataedit.CerDate = model[0].DateCus;
            _dataedit.IdcardCus = model[0].idcard;
            _dataedit.Detail_5 = model[0].tex5;
            _dataedit.Body_healthStatusCus = (model[0].ch6 == "One" ? false : true);
            _dataedit.Body_healthDetailCus = model[0].tex6;
            _dataedit.UpdateDate = DateTime.Now;

            _dataedit.RecordBy = User.Identity.Name;
            _dataedit.CommentCom = model[0].comment;
            _dataedit.NametitleCus = model[0].titlen;
            _dataedit.NameComId = 1;
            //_dataedit.DetailID = detail.ID;
            _dataedit.type = model[0].type;



            //var num = _mysqlbro.CER_Medical.Where(x => x.cerid.Contains(model[0].DateCus.ToString("yyMMdd"))).Select(v => new { v.cerid }).ToList();

            //var CER_medical = new CER_Medical
            //{

            //    cerid = model[0].DateCus.ToString("yyMMdd"),
            //    CerDate = model[0].DateCus,
            //    FirstNameCus = model[0].fname,
            //    lastNameCus = model[0].lname,
            //    AddressCus = model[0].adr,

            //    IdcardCus = model[0].idcard,
            //    Detail_5 = model[0].tex5,
            //    Body_healthStatusCus = (model[0].ch6 == "One" ? false : true),
            //    Body_healthDetailCus = model[0].tex6,
            //    CreateDate = DateTime.Now,
            //    UpdateDate = DateTime.Now,
            //    RecordBy = User.Identity.Name,
            //    Status = "1",
            //    Runnumber = num.Count() + 1,
            //    NameComId = 1,
            //    NametitleCus = model[0].titlen,
            //    CommentCom = model[0].comment,
            //    DetailID = detail.ID,
            //    type = model[0].type


            //};

            _mysqlbro.CER_Medical.Update(_dataedit);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }


        [HttpPost]
        public IActionResult editdatatype2([FromBody] setdata[] model)
        {

            var _dataedit = _mysqlbro.CER_Medical.FirstOrDefault(x => x.ID == model[0].id);


            //_dataedit.CerDate = model[0].DateCus;
            _dataedit.FirstNameCus = model[0].fname;
            _dataedit.lastNameCus = model[0].lname;
            _dataedit.AddressCus = model[0].adr;
            _dataedit.Check_1 = (model[0].ch1 == "One" ? false : true);
            _dataedit.Check_2 = (model[0].ch2 == "One" ? false : true);
            _dataedit.Check_3 = (model[0].ch3 == "One" ? false : true);
            _dataedit.Check_4 = (model[0].ch4 == "One" ? false : true);
            _dataedit.Detail_1 = model[0].tex1;
            _dataedit.Detail_2 = model[0].tex2;
            _dataedit.Detail_3 = model[0].tex3;
            _dataedit.Detail_4 = model[0].tex4;
            _dataedit.Detail_5 = model[0].tex5;
            _dataedit.IdcardCus = model[0].idcard;
            _dataedit.WeightCus = (model[0].weight != "" ? Convert.ToDecimal(model[0].weight) : 0);
            _dataedit.HeightCus = (model[0].height != "" ? Convert.ToDecimal(model[0].height) : 0);
            _dataedit.blood_pressureCus = model[0].blood;
            _dataedit.PulseCus = (model[0].pulse != "" ? Convert.ToInt32(model[0].pulse) : 0);
            _dataedit.Body_healthStatusCus = (model[0].ch6 == "One" ? false : true);
            _dataedit.Body_healthDetailCus = model[0].tex6;
            _dataedit.CerDate = model[0].DateCus;
            //CreateDate = DateTime.Now,
            _dataedit.UpdateDate = DateTime.Now;
            //RecordBy = User.Identity.Name,
            _dataedit.Status = "1";
            //Runnumber = num.Count() + 1,
            _dataedit.NameComId = 1;
            _dataedit.NametitleCus = model[0].titlen;
            _dataedit.CommentCom = model[0].comment;
            //DetailID = detail.ID,
            _dataedit.type = model[0].type;

          

            _mysqlbro.CER_Medical.Update(_dataedit);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }


        [HttpPost]
        public IActionResult editdatatype1([FromBody] setdata[] model)
        {

            var _dataedit = _mysqlbro.CER_Medical.FirstOrDefault(x => x.ID == model[0].id);




            //_dataedit.cerid = model[0].DateCus.ToString("yyMMdd");
            //_dataedit.CerDate = model[0].DateCus;
            _dataedit.FirstNameCus = model[0].fname;
            _dataedit.lastNameCus = model[0].lname;
            _dataedit.AddressCus = model[0].adr;
            _dataedit.Check_1 = (model[0].ch1 == "One" ? false : true);
            _dataedit.Check_2 = (model[0].ch2 == "One" ? false : true);
            _dataedit.Check_3 = (model[0].ch3 == "One" ? false : true);
            _dataedit.Check_4 = (model[0].ch4 == "One" ? false : true);
            _dataedit.Detail_1 = model[0].tex1;
            _dataedit.Detail_2 = model[0].tex2;
            _dataedit.Detail_3 = model[0].tex3;
            _dataedit.Detail_4 = model[0].tex4;
            _dataedit.Detail_5 = model[0].tex5;
            _dataedit.IdcardCus = model[0].idcard;
            _dataedit.WeightCus = (model[0].weight != "" ? Convert.ToDecimal(model[0].weight) : 0);
            _dataedit.HeightCus = (model[0].height != "" ? Convert.ToDecimal(model[0].height) : 0);
            _dataedit.blood_pressureCus = model[0].blood;
            _dataedit.PulseCus = (model[0].pulse != "" ? Convert.ToInt32(model[0].pulse) : 0);
            _dataedit.Body_healthStatusCus = (model[0].ch6 == "One" ? false : true);
            _dataedit.Body_healthDetailCus = model[0].tex6;
            _dataedit.CreateDate = DateTime.Now;
            _dataedit.UpdateDate = DateTime.Now;
            _dataedit.RecordBy = User.Identity.Name;
            _dataedit.Status = "1";
            _dataedit.CerDate = model[0].DateCus;
            //_dataedit.Runnumber = num.Count() + 1;
            _dataedit.NameComId = 1;
            _dataedit.NametitleCus = model[0].titlen;
            _dataedit.CommentCom = model[0].comment;
            //_dataedit.DetailID = detail.ID;
            _dataedit.type = model[0].type;


        

            _mysqlbro.CER_Medical.Update(_dataedit);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }


        public IActionResult Getdatameddetail(string id) {

            var _data = _mysqlbro.CER_Medical.FirstOrDefault(x => x.ID == Convert.ToInt32(id));


            return Json(_data);
        }


     

    }
}
