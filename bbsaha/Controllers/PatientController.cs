using bbsaha.Data;
using bbsaha.Models.Center.View;
using bbsaha.Models.patient;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using OfficeOpenXml;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
using static bbsaha.Controllers.InvoiceController;
using static bbsaha.Controllers.medicController;

namespace bbsaha.Controllers
{
    public class PatientController : Controller
    {
        private IConverter _converter;
        private readonly MysqlDBDataContext _mysqlbro;
        string db = "bbsaha";
        public PatientController(MysqlDBDataContext newbrother, IConverter converter)
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
        [Authorize(Roles = "Admin,User")]
        public IActionResult Patient()
        {
            return View();
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult Paymentreport()
        {
            return View();
        }

        public class setdata
        {
            public int id { get; set; }
            public string titlename { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }

            public string adr0 { get; set; }
            public string adr { get; set; }

            public string adr1 { get; set; }
            public string adr2 { get; set; }
            public string adr3 { get; set; }

            public string adr4 { get; set; }

            public string idcard { get; set; }
            public string idpart { get; set; }
            //public string tanon { get; set; }
            public string tambon { get; set; }
            public string ampur { get; set; }
            public string province { get; set; }
            public string postcode { get; set; }
            public string career { get; set; }
            public string tel { get; set; }
            public int gender { get; set; }
            public string titlen { get; set; }

            public string birthday { get; set; }

            public string idpat { get; set; }
            public string idrun { get; set; }

        }

        public class setdatasel
        {
            public int id { get; set; }
            public int medser { get; set; }
            public int paymenty { get; set; }
            public int totalprice { get; set; }
            public int moneyre { get; set; }
            public string remark { get; set; }
            public string repaydat { get; set; }
            public string deducsaldat { get; set; }
            public string recommen { get; set; }
            public string company { get; set; }


        }


        public class setdata_detail
        {
            public int id { get; set; }
            public string date { get; set; }
            public string time { get; set; }
            public int number { get; set; }
            public string company { get; set; }
            public string height { get; set; }
            public string weight { get; set; }
            public string bloodgr { get; set; }
            public string pulse { get; set; }
            public string bloodpr { get; set; }
            public string hissick { get; set; }
            public string hisphara { get; set; }
            public string cigar { get; set; }
            public string alcohol { get; set; }
            public string sodium { get; set; }
            public string potassium { get; set; }
            public string chloride { get; set; }
            public string totalc02 { get; set; }
            public string uricacid { get; set; }
            public string bun { get; set; }
            public string creatinine { get; set; }
            public string choiesterol { get; set; }
            public string triglyceride { get; set; }
            public string hdlc { get; set; }
            public string ldlc { get; set; }
            public string totalpro { get; set; }
            public string albumin { get; set; }
            public string globulin { get; set; }
            public string fbs { get; set; }
            public string amphetamine { get; set; }
            public string pregnancy { get; set; }
            public string hbsag { get; set; }
            public string hbsagb { get; set; }
            public string antihavtotal { get; set; }
            public string antihavigm { get; set; }
            public string vdrl { get; set; }
            public string antihiv { get; set; }
            public string tsh { get; set; }
            public string freet3 { get; set; }
            public string freet4 { get; set; }
            public string t3 { get; set; }
            public string t4 { get; set; }
            public string hemoglobin { get; set; }
            public string hematocrit { get; set; }
            public string wbc { get; set; }
            public string lym { get; set; }
            public string gran { get; set; }
            public string mid { get; set; }
            public string platelet { get; set; }
            public string eyecolor { get; set; }
            public string xray { get; set; }
            public string s1 { get; set; }
            public string s2 { get; set; }
            public string s2xray_comment { get; set; }
            public string s3 { get; set; }
            public string s4 { get; set; }
            public string s5 { get; set; }
            public string s6 { get; set; }
            public string s7 { get; set; }
            public string s8 { get; set; }
            public string alk { get; set; }
            public string totalbilirubin { get; set; }
            public string direct { get; set; }
            public string color { get; set; }
            public string ph { get; set; }
            public string protien { get; set; }
            public string sg { get; set; }
            public string glucose { get; set; }
            public string ketone { get; set; }
            public string bilirubin { get; set; }
            public string urobilinogen { get; set; }
            public string blood { get; set; }
            public string leukocyte { get; set; }
            public string nitrite { get; set; }
            public string urin1 { get; set; }
            public string stoolex { get; set; }
            public string stoolcul { get; set; }
            public string hissickbody { get; set; }
            public string hisfood { get; set; }
            public string hissickwork { get; set; }
            public string dif4 { get; set; }
            public string dif5 { get; set; }
            public int medtype { get; set; }
            public string ascorbic { get; set; }
            public string sgot { get; set; }
            public string sgpt { get; set; }

            public string diff4 { get; set; }
            public string diff5 { get; set; }
            public string clarity { get; set; }

            public string mcv { get; set; }
            public string mch { get; set; }
            public string mchc { get; set; }
            //public string sgpt { get; set; }
            //public string sgpt { get; set; }

            //2023.11.07 최희문 필드 추가 
            public string ekg { get; set; }

            //2023.11.19 최희문 필드 추가 
            public string Others_ekg { get; set; }
            public string Others_hearing { get; set; }
            public string Others_pulmonary { get; set; }


        }


        public class View_detail
        {
            public int id { get; set; }
            public DateTime date { get; set; }
            public string time { get; set; }
            public int number { get; set; }
            public string company { get; set; }
            public string height { get; set; }
            public string weight { get; set; }
            public string bloodgr { get; set; }
            public string pulse { get; set; }
            public string bloodpr { get; set; }
            public string hissick { get; set; }
            public string hisphara { get; set; }
            public string cigar { get; set; }
            public string alcohol { get; set; }
            public string sodium { get; set; }
            public string potassium { get; set; }
            public string chloride { get; set; }
            public string totalc02 { get; set; }
            public string uricacid { get; set; }
            public string bun { get; set; }
            public string creatinine { get; set; }
            public string choiesterol { get; set; }
            public string triglyceride { get; set; }
            public string hdlc { get; set; }
            public string ldlc { get; set; }
            public string totalpro { get; set; }
            public string albumin { get; set; }
            public string globulin { get; set; }
            public string fbs { get; set; }
            public string amphetamine { get; set; }
            public string pregnancy { get; set; }
            public string hbsag { get; set; }
            public string hbsagb { get; set; }
            public string antihavtotal { get; set; }
            public string antihavigm { get; set; }
            public string vdrl { get; set; }
            public string antihiv { get; set; }
            public string tsh { get; set; }
            public string freet3 { get; set; }
            public string freet4 { get; set; }
            public string t3 { get; set; }
            public string t4 { get; set; }
            public string hemoglobin { get; set; }
            public string hematocrit { get; set; }
            public string wbc { get; set; }
            public string lym { get; set; }
            public string gran { get; set; }
            public string mid { get; set; }
            public string platelet { get; set; }
            public string eyecolor { get; set; }
            public string xray { get; set; }
            public string s1 { get; set; }
            public string s2 { get; set; }
            public string s3 { get; set; }
            public string s4 { get; set; }
            public string s5 { get; set; }
            public string s6 { get; set; }
            public string s7 { get; set; }
            public string s8 { get; set; }
            public string alk { get; set; }
            public string totalbilirubin { get; set; }
            public string direct { get; set; }
            public string sgot { get; set; }
            public string sgpt { get; set; }


        }

        [HttpPost]
        public IActionResult savedatadetail([FromBody] setdata_detail[] model)
        {
            var _chk = 0;
            try
            {
                _chk = _mysqlbro.CN_Detail.Max(x => x.IDrunnumber);
            }
            catch (Exception ex)
            {

            }


            List<cn_patient> cnp = new List<cn_patient>();

            var cnpsave = new cn_detail()
            {
                DateReg = Convert.ToDateTime(model[0].date),
                time = model[0].time,
                PatientID = Convert.ToInt32(model[0].number),
                Customer = model[0].company,
                Height = (model[0].height == "" ? 0 : Convert.ToDecimal(model[0].height)),
                Weight = (model[0].weight == "" ? 0 : Convert.ToDecimal(model[0].weight)),
                bloodgr = model[0].bloodgr,
                Pulse = model[0].pulse,
                BPM = model[0].bloodpr,
                HisSick = model[0].hissick,
                hisphara = model[0].hisphara,
                Cigar = model[0].cigar,
                Alcohol = model[0].alcohol,
                sodium = model[0].sodium,
                potassium = model[0].potassium,
                chloride = model[0].chloride,
                totalco2 = model[0].totalc02,
                uricacid = model[0].uricacid,
                bun = model[0].bun,
                creatinine = model[0].creatinine,
                choiesterol = model[0].choiesterol,
                triglyceride = model[0].triglyceride,
                hdlc = model[0].hdlc,
                ldlc = model[0].ldlc,
                totalpro = model[0].totalpro,
                albumin = model[0].albumin,
                globulin = model[0].globulin,
                fbs = model[0].fbs,
                amphetamine = model[0].amphetamine,
                pregnancy = model[0].pregnancy,
                hbsag = model[0].hbsag,
                hbsagb = model[0].hbsagb,
                antihavtotal = model[0].antihavtotal,
                antihavlgm = model[0].antihavigm,
                vdrl = model[0].vdrl,
                antihiv = model[0].antihiv,
                tsh = model[0].tsh,
                freet3 = model[0].freet3,
                freet4 = model[0].freet4,
                t3 = model[0].t3,
                t4 = model[0].t4,
                hemoglobin = model[0].hemoglobin,
                hematocrit = model[0].hematocrit,
                wbc = model[0].wbc,
                lym = model[0].lym,
                gran = model[0].gran,
                mid = model[0].mid,
                platelet = model[0].platelet,
                eyecolor = model[0].eyecolor,
                xray = model[0].xray,
                s1 = model[0].s1,
                s2xray = model[0].s2,
                s3cbc = model[0].s3,
                s4cigar = model[0].s4,
                s5chid = model[0].s5,
                s6viral = model[0].s6,
                s7cbc = model[0].s7,
                s8 = model[0].s8,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UpdateBy = User.Identity.Name,
                IDdate = Convert.ToDateTime(model[0].date).ToString("yyMMdd"),
                IDrunnumber = _chk + 1,
                color = model[0].color,
                ph = model[0].ph,
                protien = model[0].protien,
                sg = model[0].sg,
                glucose = model[0].glucose,
                ketone = model[0].ketone,
                bilirubin = model[0].bilirubin,
                urobilinogen = model[0].urobilinogen,
                blood = model[0].blood,
                leukocyte = model[0].leukocyte,
                nitrite = model[0].nitrite,
                urin1 = model[0].urin1,
                stoolex = model[0].stoolex,
                stoolcul = model[0].stoolcul,
                hissickbody = model[0].hissickbody,
                hisfood = model[0].hisfood,
                hissickwork = model[0].hissickwork,
                medtype = model[0].medtype.ToString(),
                ascorbic = model[0].ascorbic,
                dif4 = model[0].diff4,
                dif5 = model[0].diff5,
                alk = model[0].alk,
                direct = model[0].direct,
                sgot = model[0].sgot,
                sgpt = model[0].sgpt,
                totalbilirubin = model[0].totalbilirubin,
                mcv = model[0].mcv,
                mch = model[0].mch,
                mchc = model[0].mchc,
                status = "1",
                type = "",
                clarity = model[0].clarity,

            /*2023.11.19 최희문 추가 필드 항목 추가 */
            Ekg = model[0].ekg,
            Others_ekg = model[0].Others_ekg,
            Others_hearing = model[0].Others_hearing,
            Others_pulmonary = model[0].Others_pulmonary


        };

            _mysqlbro.CN_Detail.Add(cnpsave);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }

        [HttpPost]
        public IActionResult savedatadeedit([FromBody] setdata_detail[] model)
        {

            var _data = _mysqlbro.CN_Detail.FirstOrDefault(x => x.ID == model[0].id);

            List<cn_patient> cnp = new List<cn_patient>();

            _data.DateReg = Convert.ToDateTime(model[0].date);
            _data.time = model[0].time;
            //_data.PatientID = Convert.ToInt32(model[0].number);
            _data.Customer = model[0].company;
            _data.Height = Convert.ToDecimal(model[0].height);
            _data.Weight = Convert.ToDecimal(model[0].weight);
            _data.bloodgr = model[0].bloodgr;
            _data.Pulse = model[0].pulse;
            _data.BPM = model[0].bloodpr;
            _data.HisSick = model[0].hissick;
            _data.hisphara = model[0].hisphara;
            _data.Cigar = model[0].cigar;
            _data.Alcohol = model[0].alcohol;
            _data.sodium = model[0].sodium;
            _data.potassium = model[0].potassium;
            _data.chloride = model[0].chloride;
            _data.totalco2 = model[0].totalc02;
            _data.uricacid = model[0].uricacid;
            _data.bun = model[0].bun;
            _data.creatinine = model[0].creatinine;
            _data.choiesterol = model[0].choiesterol;
            _data.triglyceride = model[0].triglyceride;
            _data.hdlc = model[0].hdlc;
            _data.ldlc = model[0].ldlc;
            _data.totalpro = model[0].totalpro;
            _data.albumin = model[0].albumin;
            _data.globulin = model[0].globulin;
            _data.fbs = model[0].fbs;
            _data.amphetamine = model[0].amphetamine;
            _data.pregnancy = model[0].pregnancy;
            _data.hbsag = model[0].hbsag;
            _data.hbsagb = model[0].hbsagb;
            _data.antihavtotal = model[0].antihavtotal;
            _data.antihavlgm = model[0].antihavigm;
            _data.vdrl = model[0].vdrl;
            _data.antihiv = model[0].antihiv;
            _data.tsh = model[0].tsh;
            _data.freet3 = model[0].freet3;
            _data.freet4 = model[0].freet4;
            _data.t3 = model[0].t3;
            _data.t4 = model[0].t4;
            _data.hemoglobin = model[0].hemoglobin;
            _data.hematocrit = model[0].hematocrit;
            _data.wbc = model[0].wbc;
            _data.lym = model[0].lym;
            _data.gran = model[0].gran;
            _data.mid = model[0].mid;
            _data.platelet = model[0].platelet;
            _data.eyecolor = model[0].eyecolor;
            _data.xray = model[0].xray;
            _data.s1 = model[0].s1;
            _data.s2xray = model[0].s2;
            _data.s2xray_comment = model[0].s2xray_comment;
            _data.s3cbc = model[0].s3;
            _data.s4cigar = model[0].s4;
            _data.s5chid = model[0].s5;
            _data.s6viral = model[0].s6;
            _data.s7cbc = model[0].s7;
            _data.s8 = model[0].s8;

            _data.UpdateDate = DateTime.Now;
            _data.UpdateBy = User.Identity.Name;

            _data.color = model[0].color;
            _data.ph = model[0].ph;
            _data.protien = model[0].protien;
            _data.sg = model[0].sg;
            _data.glucose = model[0].glucose;
            _data.ketone = model[0].ketone;
            _data.bilirubin = model[0].bilirubin;
            _data.urobilinogen = model[0].urobilinogen;
            _data.blood = model[0].blood;
            _data.leukocyte = model[0].leukocyte;
            _data.nitrite = model[0].nitrite;
            _data.urin1 = model[0].urin1;
            _data.stoolex = model[0].stoolex;
            _data.stoolcul = model[0].stoolcul;
            _data.hissickbody = model[0].hissickbody;
            _data.hisfood = model[0].hisfood;
            _data.hissickwork = model[0].hissickwork;
            _data.medtype = model[0].medtype.ToString();
            _data.ascorbic = model[0].ascorbic;
            _data.dif4 = model[0].diff4;
            _data.dif5 = model[0].diff5;
            _data.alk = model[0].alk;
            _data.direct = model[0].direct;
            _data.sgot = model[0].sgot;
            _data.sgpt = model[0].sgpt;
            _data.clarity = model[0].clarity;
            _data.totalbilirubin = model[0].totalbilirubin;
            _data.medtype = model[0].medtype.ToString();

            _data.mch = model[0].mch;
            _data.mcv = model[0].mcv;
            _data.mchc = model[0].mchc;

            /*2023.11.19 최희문 추가 필드 항목 추가 */
            _data.Ekg = model[0].ekg;
            _data.Others_ekg = model[0].Others_ekg;
            _data.Others_hearing = model[0].Others_hearing;
            _data.Others_pulmonary = model[0].Others_pulmonary;

            _mysqlbro.CN_Detail.Update(_data);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }

        [HttpPost]
        public IActionResult savedata([FromBody] setdata[] model)
        {
            List<cn_patient> cnp = new List<cn_patient>();

            try
            {

                var cnpsave = new cn_patient()
                {
                    IDPatient = model[0].idpat,
                    IDrunnumber = Convert.ToInt32(model[0].idrun),
                    Fname = model[0].fname,
                    Lname = model[0].lname,
                    birthday = model[0].birthday,
                    Age = 0,
                    Gender = (model[0].gender == 1 ? "ชาย" : "หญิง"),
                    IDCard = (model[0].idcard == null || model[0].idcard == "" ? model[0].idpart : model[0].idcard),

                    address0 = model[0].adr0,
                    address = model[0].adr,

                    address1 = model[0].adr1,
                    fname1 = model[0].adr2,
                    titlename1 = model[0].adr3,
                    skinCus = model[0].adr4,

                    Tel = model[0].tel,
                    SubDistrict = model[0].tambon,
                    District = model[0].ampur,
                    Province = model[0].province,
                    career = model[0].career,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    UpdateBy = User.Identity.Name,
                    Postcode = model[0].postcode,
                    titlename = model[0].titlen,
                    Status = "1",
                    Type = "1"
                    

                };

                _mysqlbro.CN_Patient.Add(cnpsave);
                _mysqlbro.SaveChanges();


                return Json("suc");

            }
            catch (Exception ex)
            {
                return Json("err");
            }
        }


        [HttpPost]
        public IActionResult updatedata([FromBody] setdata[] model)
        {
            List<cn_patient> cnp = new List<cn_patient>();

            try {
                var _dataup = _mysqlbro.CN_Patient.FirstOrDefault(x => x.ID == model[0].id);

                //_dataup.DPatient = model[0].idpat,
                //_dataup.IDrunnumber = Convert.ToInt32(model[0].idrun);
                _dataup.Fname = model[0].fname;
                _dataup.Lname = model[0].lname;
                _dataup.birthday = model[0].birthday;
                //_dataup.Age = 0;
                _dataup.Gender = (model[0].gender == 1 ? "ชาย" : "หญิง");
                _dataup.IDCard = (model[0].idcard == null || model[0].idcard == "" ? model[0].idpart : model[0].idcard);

                //_dataup.IDpart = model[0].idpart;
                _dataup.address0 = model[0].adr0;
                _dataup.address = model[0].adr;

                _dataup.address1 = model[0].adr1;
                _dataup.fname1 = model[0].adr2;
                _dataup.titlename1 = model[0].adr3;
                _dataup.skinCus = model[0].adr4;

                _dataup.Tel = model[0].tel;
                _dataup.SubDistrict = model[0].tambon;
                _dataup.District = model[0].ampur;
                _dataup.Province = model[0].province;
                _dataup.career = model[0].career;
                //_dataup.CreateDate = DateTime.Now;
                _dataup.UpdateDate = DateTime.Now;
                _dataup.UpdateBy = User.Identity.Name;
                _dataup.Postcode = model[0].postcode;
                _dataup.titlename = model[0].titlen;



                _mysqlbro.CN_Patient.Update(_dataup);
                _mysqlbro.SaveChanges();


                return Json("suc");

            }
            catch (Exception ex) {
                return Json("err");
            }


        }



        [HttpPost]
        public IActionResult savedatasel([FromBody] setdatasel[] model)
        {

            var _chk = 0;
            try
            {
                _chk = _mysqlbro.CN_Sales.Max(x => x.IDrunnumber);
            }
            catch (Exception ex)
            {

            }
            var cnpsave = new cn_sales()
            {
                MedType = 0,
                DetailID = Convert.ToInt32(model[0].id),
                TypeName = Convert.ToInt32(model[0].paymenty),
                Price = Convert.ToDecimal(model[0].totalprice),
                Remark = model[0].remark,
                ReceivePayDate = Convert.ToDateTime(model[0].repaydat),
                ReceiveDeDate = (model[0].deducsaldat == "" ? null : Convert.ToDateTime(model[0].deducsaldat)),
                Recommend = (model[0].recommen == "null" || model[0].recommen == null ? "" : model[0].recommen),
                PerReceiver = model[0].moneyre,
                Company = model[0].company,
                CreateDate = DateTime.Now,
                UpdateBy = User.Identity.Name,
                UpdateDate = DateTime.Now,
                IDreciept = DateTime.Now.ToString("yyMMdd"),
                IDrunnumber = _chk + 1



            };

            _mysqlbro.CN_Sales.Add(cnpsave);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }

        [HttpPost]
        public IActionResult editdatasel([FromBody] setdatasel[] model)
        {

            var _data = _mysqlbro.CN_Sales.FirstOrDefault(x => x.DetailID == model[0].id);


            //_data.MedType = Convert.ToInt32(model[0].medser);
            _data.DetailID = Convert.ToInt32(model[0].id);
            _data.TypeName = Convert.ToInt32(model[0].paymenty);
            _data.Price = Convert.ToDecimal(model[0].totalprice);
            _data.Remark = model[0].remark;
            _data.ReceivePayDate = Convert.ToDateTime(model[0].repaydat);
            _data.ReceiveDeDate = (model[0].deducsaldat == "" ? null : Convert.ToDateTime(model[0].deducsaldat));
            _data.Recommend = model[0].recommen;
            _data.PerReceiver = model[0].moneyre;
            _data.Company = model[0].company;
            _data.UpdateBy = User.Identity.Name;
            _data.UpdateDate = DateTime.Now;



            _mysqlbro.CN_Sales.Update(_data);
            _mysqlbro.SaveChanges();


            return Json("suc");
        }
        public IActionResult GetdataCN(string id)
        {

            var _datachk = _mysqlbro.CN_Patient.FirstOrDefault(x => x.IDCard == id || x.IDpart == id);
            var aw = DateTime.Now.ToString("yyMMdd");
            var _data = _mysqlbro.CN_Patient.Where(x => x.IDPatient == aw).ToList();

            var chk = _data.Count();
            var numberID = "";
            int runID = 0;
            List<cn_patient> sum = new List<cn_patient>();

            if (_datachk == null)
            {

                if (chk != 0)
                {
                    var nummax = _data.Max(x => x.IDrunnumber);

                    numberID = DateTime.Now.ToString("yyMMdd");
                    runID = nummax + 1;

                }
                else
                {

                    numberID = DateTime.Now.ToString("yyMMdd");
                    runID = 1;

                }

            }





            return Json((_datachk == null ? numberID + "/" + runID : _datachk));
        }


        public IActionResult Getprovince(string id)
        {

            var _data = _mysqlbro.CEN_ProvinceTH.ToList();


            return Json(_data);
        }

        public IActionResult GetDistrict(string id)
        {

            var _data = _mysqlbro.CEN_DistrictTH.Where(x => x.ProvinceID == id).ToList();


            return Json(_data);
        }

        public IActionResult GetSubDistrict(string id)
        {

            var _data = _mysqlbro.CEN_SubDistrictTH.Where(x => x.DistrictID == id).ToList();


            return Json(_data);
        }

        public IActionResult GetPostcode(string id)
        {

            var _data = _mysqlbro.CEN_Postcode.Where(x => x.DistrictID == id).ToList();


            return Json(_data);
        }

        public IActionResult Getdatapatient(string id, string sercon)
        {

            var _data = _mysqlbro.CN_Patient.OrderByDescending(x => x.ID).ToList();

            if (sercon != "" && sercon != null) {
                _data = _data.Where(x => x.IDCard.Contains(sercon) || x.Fname.Contains(sercon) || x.Lname.Contains(sercon) || x.IDPatient.Contains(sercon)).OrderByDescending(x => x.ID).ToList();

            }
            _data = _data.Where(x => x.Status == "1").Take(50).ToList();

            //_data = _data.ToList();
            return Json(_data);
        }

        public IActionResult Getdatadetail(int id)
        {
            var _datade = _mysqlbro.CN_Detail.Where(x => x.PatientID == id).OrderBy(x => x.ID).OrderByDescending(i => i.ID).ToList();
            var _datamed = _mysqlbro.CER_Medical.ToList();

            var _data = _datade.GroupJoin(_datamed, x => x.ID, c => c.DetailID, (x, c) => new { x, c })
                .SelectMany(a => a.c.DefaultIfEmpty(), (a, y) => new { x = a.x, y = y }).ToList();
            //_datacus.GroupJoin(_datatpye, x => x.ID, df => df.TypeLabsID, (x, df) => new { x, df })
            //.SelectMany(c => c.df.DefaultIfEmpty(), (c, y) => new { x = c.x, y = y }).ToList()


            foreach (var da in _data)
            {
                var _datasel = _mysqlbro.CN_Sales.FirstOrDefault(x => x.DetailID == da.x.ID);
                da.x.direct = da.x.DateReg.ToString("dd/MM/yyyy");
                da.x.urin2 = (_datasel == null ? "0" : "1");
                da.x.alk = (_datasel == null ? "0" : _datasel.ID.ToString());
            }
            return Json(_data);
        }



        public IActionResult Getdatadig(int id)
        {

            var _data = _mysqlbro.CN_Patient.Where(x => x.ID == id).ToList();


            return Json(_data);
        }



        public IActionResult GetPrintmed(string id)
        {
            var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("med_report", "Patient", new { id = id });


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

        public IActionResult GetPrintReportXray(string id)
        {
            var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("ReportXray", "Patient", new { id = id });


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


        public IActionResult med_report(int id)
        {
            var _datapt = _mysqlbro.CN_Patient.ToList();
            var _datadt = _mysqlbro.CN_Detail.Where(x => x.ID == id).ToList();

            var _datasum = _datadt.Join(_datapt, ae => ae.PatientID, ea => ea.ID, (ae, ea) => new { ae, ea }).ToList();

            List<View_report> listA = new List<View_report>();

            foreach (var dat in _datasum)
            {

                var today = DateTime.Today;
                int age = 0;
                if (dat.ea.birthday != "" && dat.ea.birthday != null)
                    age = (int)((DateTime.Now - Convert.ToDateTime(dat.ea.birthday)).TotalDays / 365.242199);
                //var age = today.Year - Convert.ToDateTime(dat.ea.birthday).Year;
                listA.Add(new View_report
                {
                    date = dat.ae.DateReg.ToString("dd/MM/yyyy"),
                    time = dat.ae.time,
                    company = dat.ae.Customer,

                    birthday = dat.ea.birthday,

                    height = Convert.ToInt32(dat.ae.Height).ToString(),
                    weight = Convert.ToInt32(dat.ae.Weight).ToString(),
                    bloodgr = dat.ae.bloodgr,
                    pulse = dat.ae.Pulse,
                    bloodpr = dat.ae.BPM,
                    hissick = dat.ae.HisSick,
                    hisphara = dat.ae.hisphara,
                    cigar = (dat.ae.Cigar == "1" ? "ปฏิเสธ" : "สูบบุหรี่"),
                    alcohol = (dat.ae.Alcohol == "1" ? "ปฏิเสธ" : "ดื่มแอลกอฮอล์"),
                    sodium = dat.ae.sodium,
                    potassium = dat.ae.potassium,
                    chloride = dat.ae.chloride,
                    totalc02 = dat.ae.totalco2,
                    uricacid = dat.ae.uricacid,
                    bun = dat.ae.bun,
                    creatinine = dat.ae.creatinine,
                    choiesterol = dat.ae.choiesterol,
                    triglyceride = dat.ae.triglyceride,
                    hdlc = dat.ae.hdlc,
                    ldlc = dat.ae.ldlc,
                    totalpro = dat.ae.totalpro,
                    albumin = dat.ae.albumin,
                    globulin = dat.ae.globulin,
                    fbs = dat.ae.fbs,
                    amphetamine = dat.ae.amphetamine,
                    pregnancy = dat.ae.pregnancy,
                    hbsag = dat.ae.hbsag,
                    hbsagb = dat.ae.hbsagb,
                    antihavtotal = dat.ae.antihavtotal,
                    antihavigm = dat.ae.antihavlgm,
                    vdrl = dat.ae.vdrl,
                    antihiv = dat.ae.antihiv,
                    tsh = dat.ae.tsh,
                    freet3 = dat.ae.freet3,
                    freet4 = dat.ae.freet4,
                    t3 = dat.ae.t3,
                    t4 = dat.ae.t4,
                    hemoglobin = dat.ae.hemoglobin,
                    hematocrit = dat.ae.hematocrit,
                    wbc = dat.ae.wbc,
                    lym = dat.ae.lym,
                    gran = dat.ae.gran,
                    mid = dat.ae.mid,
                    platelet = dat.ae.platelet,
                    eyecolor = dat.ae.eyecolor,
                    xray = dat.ae.xray,
                    s1 = (dat.ae.s1 == "1" ? "ผลปกติ" : (dat.ae.s1 == "2" ? "ความดันโลหิตสูง" :  (dat.ae.s1 == "3" ? "ความดันโลหิตต่ำ" : ""))),
                    s2 = (dat.ae.s2xray == "1" ? "ผลปกติ" : (dat.ae.s2xray == "2" ? "ไม่ปกติ" : "")),
                    s3 = (dat.ae.s3cbc == "1" ? "ผลปกติ" : (dat.ae.s3cbc == "2" ? "ไม่ปกติ" : "")),
                    s4 = (dat.ae.s4cigar == "1" ? "พบสารเสพติด" : (dat.ae.s4cigar == "2" ? "ไม่พบสารเสพติด" : "")),
                    s5 = (dat.ae.s5chid == "1" ? "พบการตั้งครรภ์" : (dat.ae.s5chid == "2" ? "ไม่พบการตั้งครรภ์" : "")),
                    s6 = (dat.ae.s6viral == "1" ? "ผลปกติ" : (dat.ae.s6viral == "2" ? "ไม่ปกติ" : "")),
                    s7 = (dat.ae.s7cbc == "1" ? "ผลปกติ" : (dat.ae.s7cbc == "2" ? "ไม่ปกติ" : "")),
                    s8 = (dat.ae.s8 == "1" ? "ผลปกติ" : (dat.ae.s8 == "2" ? "ไม่ปกติ" : (dat.ae.s8 == "3" ? "แปลผลไม่ได้" : ""))),
                    
                    name = dat.ea.titlename + " " + dat.ea.Fname + " " + dat.ea.Lname,
                    gender = dat.ea.Gender,
                    refno = dat.ae.IDdate + "-" + (dat.ae.IDrunnumber > 999 ? "" : (dat.ae.IDrunnumber > 99 ? "0" : (dat.ae.IDrunnumber > 9 ? "00" : "000"))) + dat.ae.IDrunnumber,
                    age = age.ToString(),
                    color = dat.ae.color,
                    ph = dat.ae.ph,
                    protein = dat.ae.protien,
                    sg = dat.ae.sg,
                    glucose = dat.ae.glucose,
                    ketone = dat.ae.ketone,
                    bilirubin = dat.ae.bilirubin,
                    urobilinogen = dat.ae.urobilinogen,
                    blood = dat.ae.blood,
                    leukocyte = dat.ae.leukocyte,
                    nitrite = dat.ae.nitrite,
                    urin1 = dat.ae.urin1,
                    stoolex = dat.ae.stoolex,
                    stoolcul = dat.ae.stoolcul,
                    hissickbody = dat.ae.hissickbody,
                    hisfood = dat.ae.hisfood,
                    hissickwork = dat.ae.hissickwork,
                    dif4 = dat.ae.dif4,
                    dif5 = dat.ae.dif5,
                    ascorbic = dat.ae.ascorbic,
                    direct = dat.ae.direct,
                    sgot = dat.ae.sgot,
                    clarity = dat.ae.clarity,
                    sgpt = dat.ae.sgpt,
                    alk = dat.ae.alk,
                    totalbilirubin = dat.ae.totalbilirubin,
                    mcv = dat.ae.mcv,
                    mch = dat.ae.mch,
                    mchc = dat.ae.mchc,

                    /*2023.11.19 최희문 추가 필드 항목 추가 */
                    //Ekg = (dat.ae.Ekg == "1" ? "ผลปกติ" : (dat.ae.Ekg == "2" ? "ไม่ปกติ" : "")),
                    Ekg = dat.ae.Ekg,
                    Others_ekg =dat.ae.Others_ekg,
                    
                    Others_hearing =dat.ae.Others_hearing,
                    Others_pulmonary=dat.ae.Others_pulmonary





                });

            }

            ViewBag.data = listA.ToArray();
            return View();
        }

        public IActionResult ReportXray(int id)
        {
            var _datapt = _mysqlbro.CN_Patient.ToList();
            var _datadt = _mysqlbro.CN_Detail.Where(x => x.ID == id).ToList();

            var _datasum = _datadt.Join(_datapt, ae => ae.PatientID, ea => ea.ID, (ae, ea) => new { ae, ea }).ToList();

            List<View_report> listA = new List<View_report>();

            foreach (var dat in _datasum)
            {

                var today = DateTime.Today;
                int age = 0;
                if (dat.ea.birthday != "" && dat.ea.birthday != null)
                    age = (int)((DateTime.Now - Convert.ToDateTime(dat.ea.birthday)).TotalDays / 365.242199);
                //var age = today.Year - Convert.ToDateTime(dat.ea.birthday).Year;
                listA.Add(new View_report
                {
                    date = dat.ae.DateReg.ToString("dd/MM/yyyy"),
                    time = dat.ae.time,
                    company = dat.ae.Customer,

                    birthday = dat.ea.birthday,

                    height = Convert.ToInt32(dat.ae.Height).ToString(),
                    weight = Convert.ToInt32(dat.ae.Weight).ToString(),
                    bloodgr = dat.ae.bloodgr,
                    pulse = dat.ae.Pulse,
                    bloodpr = dat.ae.BPM,
                    hissick = dat.ae.HisSick,
                    hisphara = dat.ae.hisphara,
                    cigar = (dat.ae.Cigar == "1" ? "ปฏิเสธ" : "สูบบุหรี่"),
                    alcohol = (dat.ae.Alcohol == "1" ? "ปฏิเสธ" : "ดื่มแอลกอฮอล์"),
                    sodium = dat.ae.sodium,
                    potassium = dat.ae.potassium,
                    chloride = dat.ae.chloride,
                    totalc02 = dat.ae.totalco2,
                    uricacid = dat.ae.uricacid,
                    bun = dat.ae.bun,
                    creatinine = dat.ae.creatinine,
                    choiesterol = dat.ae.choiesterol,
                    triglyceride = dat.ae.triglyceride,
                    hdlc = dat.ae.hdlc,
                    ldlc = dat.ae.ldlc,
                    totalpro = dat.ae.totalpro,
                    albumin = dat.ae.albumin,
                    globulin = dat.ae.globulin,
                    fbs = dat.ae.fbs,
                    amphetamine = dat.ae.amphetamine,
                    pregnancy = dat.ae.pregnancy,
                    hbsag = dat.ae.hbsag,
                    hbsagb = dat.ae.hbsagb,
                    antihavtotal = dat.ae.antihavtotal,
                    antihavigm = dat.ae.antihavlgm,
                    vdrl = dat.ae.vdrl,
                    antihiv = dat.ae.antihiv,
                    tsh = dat.ae.tsh,
                    freet3 = dat.ae.freet3,
                    freet4 = dat.ae.freet4,
                    t3 = dat.ae.t3,
                    t4 = dat.ae.t4,
                    hemoglobin = dat.ae.hemoglobin,
                    hematocrit = dat.ae.hematocrit,
                    wbc = dat.ae.wbc,
                    lym = dat.ae.lym,
                    gran = dat.ae.gran,
                    mid = dat.ae.mid,
                    platelet = dat.ae.platelet,
                    eyecolor = dat.ae.eyecolor,
                    xray = dat.ae.xray,
                    s1 = (dat.ae.s1 == "1" ? "ผลปกติ" : (dat.ae.s1 == "2" ? "ความดันโลหิตสูง" : (dat.ae.s1 == "3" ? "ความดันโลหิตต่ำ" : ""))),
                    s2 = (dat.ae.s2xray == "1" ? "ผลปกติ" : (dat.ae.s2xray == "2" ? "ไม่ปกติ" : "")),
                    s3 = (dat.ae.s3cbc == "1" ? "ผลปกติ" : (dat.ae.s3cbc == "2" ? "ไม่ปกติ" : "")),
                    s4 = (dat.ae.s4cigar == "1" ? "พบสารเสพติด" : (dat.ae.s4cigar == "2" ? "ไม่พบสารเสพติด" : "")),
                    s5 = (dat.ae.s5chid == "1" ? "พบการตั้งครรภ์" : (dat.ae.s5chid == "2" ? "ไม่พบการตั้งครรภ์" : "")),
                    s6 = (dat.ae.s6viral == "1" ? "ผลปกติ" : (dat.ae.s6viral == "2" ? "ไม่ปกติ" : "")),
                    s7 = (dat.ae.s7cbc == "1" ? "ผลปกติ" : (dat.ae.s7cbc == "2" ? "ไม่ปกติ" : "")),
                    s8 = (dat.ae.s8 == "1" ? "ผลปกติ" : (dat.ae.s8 == "2" ? "ไม่ปกติ" : (dat.ae.s8 == "3" ? "แปลผลไม่ได้" : ""))),

                    name = dat.ea.titlename + " " + dat.ea.Fname + " " + dat.ea.Lname,
                    gender = dat.ea.Gender,
                    refno = dat.ae.IDdate + "-" + (dat.ae.IDrunnumber > 999 ? "" : (dat.ae.IDrunnumber > 99 ? "0" : (dat.ae.IDrunnumber > 9 ? "00" : "000"))) + dat.ae.IDrunnumber,
                    age = age.ToString(),
                    color = dat.ae.color,
                    ph = dat.ae.ph,
                    protein = dat.ae.protien,
                    sg = dat.ae.sg,
                    glucose = dat.ae.glucose,
                    ketone = dat.ae.ketone,
                    bilirubin = dat.ae.bilirubin,
                    urobilinogen = dat.ae.urobilinogen,
                    blood = dat.ae.blood,
                    leukocyte = dat.ae.leukocyte,
                    nitrite = dat.ae.nitrite,
                    urin1 = dat.ae.urin1,
                    stoolex = dat.ae.stoolex,
                    stoolcul = dat.ae.stoolcul,
                    hissickbody = dat.ae.hissickbody,
                    hisfood = dat.ae.hisfood,
                    hissickwork = dat.ae.hissickwork,
                    dif4 = dat.ae.dif4,
                    dif5 = dat.ae.dif5,
                    ascorbic = dat.ae.ascorbic,
                    direct = dat.ae.direct,
                    sgot = dat.ae.sgot,
                    clarity = dat.ae.clarity,
                    sgpt = dat.ae.sgpt,
                    alk = dat.ae.alk,
                    totalbilirubin = dat.ae.totalbilirubin,
                    mcv = dat.ae.mcv,
                    mch = dat.ae.mch,
                    mchc = dat.ae.mchc,

                    /*2023.11.19 최희문 추가 필드 항목 추가 */
                    //Ekg = (dat.ae.Ekg == "1" ? "ผลปกติ" : (dat.ae.Ekg == "2" ? "ไม่ปกติ" : "")),
                    Ekg = dat.ae.Ekg,
                    Others_ekg = dat.ae.Others_ekg,

                    Others_hearing = dat.ae.Others_hearing,
                    Others_pulmonary = dat.ae.Others_pulmonary





                });

            }

            ViewBag.data = listA.ToArray();
            return View();
        }


        public IActionResult GetPrintreciept(string id)
        {
            var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("med_reciept", "Patient", new { id = id });


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

        public IActionResult med_reciept(int id)
        {
            var _datapa = _mysqlbro.CN_Patient.ToList();
            var _datade = _mysqlbro.CN_Detail.ToList();
            var _datase = _mysqlbro.CN_Sales.Where(x => x.ID == id).ToList();

            var _datath = _mysqlbro.CEN_TypeHealthCheck.ToList();
            var _datatp = _mysqlbro.CEN_TypePayment.ToList();
            var _datapr = _mysqlbro.CEN_PerReceive.ToList();

            var _data = _datase.Join(_datade, ae => ae.DetailID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Join(_datapa, dg => dg.ea.PatientID, gd => gd.ID, (dg, gd) => new { dg, gd })
                .Join(_datath, vb => vb.dg.ea.medtype, bv => bv.ID.ToString(), (vb, bv) => new { vb, bv })
                .Join(_datatp, xc => xc.vb.dg.ae.TypeName, cx => cx.ID, (xc, cx) => new { xc, cx })
                .Join(_datapr, ku => ku.xc.vb.dg.ae.PerReceiver, uk => uk.ID, (ku, uk) => new { ku, uk }).ToList();

            List<View_salesreciept> listA = new List<View_salesreciept>();

            foreach (var dat in _data)
            {

                //var today = DateTime.Today;
                //int age = (int)((DateTime.Now - Convert.ToDateTime(dat.ea.birthday)).TotalDays / 365.242199);
                //var age = today.Year - Convert.ToDateTime(dat.ea.birthday).Year;
               
                var _datpro = _mysqlbro.CEN_ProvinceTH.FirstOrDefault(x => x.ProvinceID == dat.ku.xc.vb.gd.Province);
                var _datdis = _mysqlbro.CEN_DistrictTH.FirstOrDefault(x => x.DistrictID == dat.ku.xc.vb.gd.District);
                var _datsub = _mysqlbro.CEN_SubDistrictTH.FirstOrDefault(x => x.SubDistrictID == dat.ku.xc.vb.gd.SubDistrict);
                var _datpost = _mysqlbro.CEN_Postcode.FirstOrDefault(x => x.PostCode == dat.ku.xc.vb.gd.Postcode);


                



                //2023.11.06 최희문 수정
                //_datpost 값이 null 인경우 오류 발생으로 null 값 로직 구분 추가

                if (_datpost == null)
                {

                    listA.Add(new View_salesreciept()
                    {
                        fname = dat.ku.xc.vb.gd.Fname + " " + dat.ku.xc.vb.gd.Lname,

                        //update view for new field
                        adr0 = dat.ku.xc.vb.gd.address0,
                        adr = dat.ku.xc.vb.gd.address,

                        adr1 = dat.ku.xc.vb.gd.address1,
                        adr2 = dat.ku.xc.vb.gd.fname1,
                        adr3 = dat.ku.xc.vb.gd.titlename1,
                        adr4 = dat.ku.xc.vb.gd.skinCus,

                        Tel = dat.ku.xc.vb.gd.Tel,
                        refno = "RE" + dat.ku.xc.vb.dg.ae.IDreciept + "-" + (dat.ku.xc.vb.dg.ae.IDrunnumber > 9 ? "00" : (dat.ku.xc.vb.dg.ae.IDrunnumber > 99 ? "0" : (dat.ku.xc.vb.dg.ae.IDrunnumber > 999 ? "" : "000"))) + dat.ku.xc.vb.dg.ae.IDrunnumber,
                        datereg = Convert.ToDateTime(dat.ku.xc.vb.dg.ae.ReceivePayDate).ToString("dd/MM/yyyy"),
                        detail = dat.ku.xc.bv.TypeName,
                        price = dat.ku.xc.vb.dg.ae.Price,
                        paytype = dat.ku.cx.ID


                        //pro = _datpro.ProvinceTH,
                        //dis = _datdis.DistrictTH,
                        //subdis = _datsub.SubDistrictTH

                      




                    });

                }
                else
                {

                    listA.Add(new View_salesreciept()
                    {
                        fname = dat.ku.xc.vb.gd.Fname + " " + dat.ku.xc.vb.gd.Lname,

                        //update view for new field
                        adr0 = dat.ku.xc.vb.gd.address0,
                        adr = dat.ku.xc.vb.gd.address,

                        adr1 = dat.ku.xc.vb.gd.address1,
                        adr2 = dat.ku.xc.vb.gd.fname1,
                        adr3 = dat.ku.xc.vb.gd.titlename1,
                        adr4 = dat.ku.xc.vb.gd.skinCus,

                        Tel = dat.ku.xc.vb.gd.Tel,
                        refno = "RE" + dat.ku.xc.vb.dg.ae.IDreciept + "-" + (dat.ku.xc.vb.dg.ae.IDrunnumber > 9 ? "00" : (dat.ku.xc.vb.dg.ae.IDrunnumber > 99 ? "0" : (dat.ku.xc.vb.dg.ae.IDrunnumber > 999 ? "" : "000"))) + dat.ku.xc.vb.dg.ae.IDrunnumber,
                        datereg = Convert.ToDateTime(dat.ku.xc.vb.dg.ae.ReceivePayDate).ToString("dd/MM/yyyy"),
                        detail = dat.ku.xc.bv.TypeName,
                        price = dat.ku.xc.vb.dg.ae.Price,
                        paytype = dat.ku.cx.ID,

                        pro = _datpro.ProvinceTH,
                        dis = _datdis.DistrictTH,
                        subdis = _datsub.SubDistrictTH,
                        postcode = _datpost.PostCode


                    });


                }
                

                
               


            }

            ViewBag.data = listA.ToArray();
            return View();
        }


        public IActionResult GetPrintrecieptfor(string id)
        {
            var url = $"{this.Request.Scheme}://{this.Request.Host}" + Url.Action("med_recieptfor", "Patient", new { id = id });


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

        public IActionResult med_recieptfor(int id)
        {
            var _datapa = _mysqlbro.CN_Patient.ToList();
            var _datade = _mysqlbro.CN_Detail.ToList();
            var _datase = _mysqlbro.CN_Sales.Where(x => x.ID == id).ToList();

            var _datath = _mysqlbro.CEN_TypeHealthCheck.ToList();
            var _datatp = _mysqlbro.CEN_TypePayment.ToList();
            var _datapr = _mysqlbro.CEN_PerReceive.ToList();


            var _data = _datase.Join(_datade, ae => ae.DetailID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Join(_datapa, dg => dg.ea.PatientID, gd => gd.ID, (dg, gd) => new { dg, gd })
                .Join(_datath, vb => vb.dg.ea.medtype, bv => bv.ID.ToString(), (vb, bv) => new { vb, bv })
                .Join(_datatp, xc => xc.vb.dg.ae.TypeName, cx => cx.ID, (xc, cx) => new { xc, cx })
                .Join(_datapr, ku => ku.xc.vb.dg.ae.PerReceiver, uk => uk.ID, (ku, uk) => new { ku, uk }).ToList();

            List<View_salesreciept> listA = new List<View_salesreciept>();

            foreach (var dat in _data)
            {

                //var today = DateTime.Today;
                //int age = (int)((DateTime.Now - Convert.ToDateTime(dat.ea.birthday)).TotalDays / 365.242199);
                //var age = today.Year - Convert.ToDateTime(dat.ea.birthday).Year;
                var _datpro = _mysqlbro.CEN_ProvinceTH.FirstOrDefault(x => x.ProvinceID == dat.ku.xc.vb.gd.Province);
                var _datdis = _mysqlbro.CEN_DistrictTH.FirstOrDefault(x => x.DistrictID == dat.ku.xc.vb.gd.District);
                var _datsub = _mysqlbro.CEN_SubDistrictTH.FirstOrDefault(x => x.SubDistrictID == dat.ku.xc.vb.gd.SubDistrict);
                var _datpost = _mysqlbro.CEN_Postcode.FirstOrDefault(x => x.PostCode == dat.ku.xc.vb.gd.Postcode);

                listA.Add(new View_salesreciept()
                {
                    fname = dat.ku.xc.vb.gd.Fname + " " + dat.ku.xc.vb.gd.Lname,

                    adr0 = dat.ku.xc.vb.gd.address0,
                    adr = dat.ku.xc.vb.gd.address,

                    adr1 = dat.ku.xc.vb.gd.address1,
                    adr2 = dat.ku.xc.vb.gd.fname1,
                    adr3 = dat.ku.xc.vb.gd.titlename1,
                    adr4 = dat.ku.xc.vb.gd.skinCus,

                    Tel = dat.ku.xc.vb.gd.Tel,
                    refno = "RE" + dat.ku.xc.vb.dg.ae.IDreciept + "-" + (dat.ku.xc.vb.dg.ae.IDrunnumber > 9 ? "00" : (dat.ku.xc.vb.dg.ae.IDrunnumber > 99 ? "0" : (dat.ku.xc.vb.dg.ae.IDrunnumber > 999 ? "" : "000"))) + dat.ku.xc.vb.dg.ae.IDrunnumber,
                    datereg = Convert.ToDateTime(dat.ku.xc.vb.dg.ae.ReceivePayDate).ToString("dd/MM/yyyy"),
                    detail = dat.ku.xc.bv.TypeName,
                    price = dat.ku.xc.vb.dg.ae.Price,
                    paytype = dat.ku.cx.ID,
                    pro = _datpro.ProvinceTH,
                    dis = _datdis.DistrictTH,
                    subdis = _datsub.SubDistrictTH,
                    postcode = _datpost.PostCode



                });


            }

            ViewBag.data = listA.ToArray();
            return View();
        }



        public IActionResult Getdatapay(int id)
        {
            var _datapt = _mysqlbro.CN_Patient.ToList();
            var _datadt = _mysqlbro.CN_Detail.Where(x => x.ID == id).ToList();
            var _datatype = _mysqlbro.CEN_TypeHealthCheck.ToList();

            var _datasum = _datadt.Join(_datapt, ae => ae.PatientID, ea => ea.ID, (ae, ea) => new { ae, ea })
                                 .Join(_datatype, df => df.ae.medtype, fd => fd.ID.ToString(), (df, fd) => new { df, fd }).ToList();

            List<View_report> listA = new List<View_report>();

            foreach (var dat in _datasum)
            {
                var _datasel = _mysqlbro.CN_Sales.FirstOrDefault(x => x.DetailID == id);
                var today = DateTime.Today;
                //int age = 0;
                //if (dat.df.ea.birthday != "" && dat.df.ea.birthday != null)
                //    age = (int)((DateTime.Now - Convert.ToDateTime(dat.df.ea.birthday)).TotalDays / 365.242199);
                var price = _mysqlbro.CUS_Company.FirstOrDefault(c => c.CompanyNameTH == dat.df.ae.Customer);
                if (_datasel != null)
                {
                    listA.Add(new View_report
                    {
                        date = dat.df.ae.DateReg.ToString("yyyy-MM-dd"),
                        time = dat.df.ae.time,
                        company = dat.df.ae.Customer,
                        
                        name = dat.df.ea.Lname,
                        direct = dat.df.ea.titlename,
                        mid = dat.df.ea.Fname,
                        
                        gender = dat.df.ea.Gender,
                        refno = dat.df.ae.IDdate + "-" + (dat.df.ae.IDrunnumber > 9 ? "00" : (dat.df.ae.IDrunnumber > 99 ? "0" : (dat.df.ae.IDrunnumber > 999 ? "" : "000"))) + dat.df.ae.IDrunnumber,
                        age = "BB-" + dat.df.ea.IDPatient + "-" + (dat.df.ea.IDrunnumber > 9 ? "00" : (dat.df.ea.IDrunnumber > 99 ? "0" : (dat.df.ea.IDrunnumber > 999 ? "" : "000"))) + dat.df.ea.IDrunnumber,
                        id = dat.df.ae.ID,
                        medtyse = _datasel.MedType,
                        paytyse = _datasel.TypeName,
                        moneyse = _datasel.PerReceiver,
                        remarkse = _datasel.Remark,
                        rededatese = Convert.ToDateTime(_datasel.ReceiveDeDate).ToString("yyy-MM-dd"),
                        repaydatese = Convert.ToDateTime(_datasel.ReceivePayDate).ToString("yyy-MM-dd"),
                        reccomse = _datasel.Recommend,
                        totalse = _datasel.Price,
                        //medtype = (dat.ae.medtype == "1" ? "ตรวจสุขภาพก่อนเริ่มงาน" : (dat.ae.medtype == "2" ? "ATK" : (dat.ae.medtype == "3" ? "ตรวจสุขภาพพนักงงานประจำปี" : (dat.ae.medtype == "4" ? "ตรวจทั่วไป" : "ใบขับขี่"))))
                        medtype = dat.fd.TypeName




                    });

                }
                else {
                    listA.Add(new View_report
                    {
                        date = dat.df.ae.DateReg.ToString("yyyy-MM-dd"),
                        time = dat.df.ae.time,
                        company = dat.df.ae.Customer,
                        name = dat.df.ea.Lname,
                        direct = dat.df.ea.titlename,
                        mid = dat.df.ea.Fname,
                        gender = dat.df.ea.Gender,
                        refno = dat.df.ae.IDdate + "-" + (dat.df.ae.IDrunnumber > 9 ? "00" : (dat.df.ae.IDrunnumber > 99 ? "0" : (dat.df.ae.IDrunnumber > 999 ? "" : "000"))) + dat.df.ae.IDrunnumber,
                        age = "BB-" + dat.df.ea.IDPatient + "-" + (dat.df.ea.IDrunnumber > 9 ? "00" : (dat.df.ea.IDrunnumber > 99 ? "0" : (dat.df.ea.IDrunnumber > 999 ? "" : "000"))) + dat.df.ea.IDrunnumber,
                        id = dat.df.ae.ID,
                        medtype = dat.fd.TypeName,
                        repaydatese = DateTime.Now.ToString("yyyy-MM-dd"),
                        //totalse = (price != null ? (price.Type == "1" ? 200 : (price.Type == "2" ? 790 : (price.Type == "3" ? 500 : (price.Type == "4" ? 350 : (price.Type == "5" ? 400 : (price.Type == "6" ? 200 : 0)))))) : 0)
                        totalse = 0




                    });
                }


            }


            return Json(listA);
        }

        public IActionResult Getdataeditdetail(int id)
        {

            var _data = _mysqlbro.CN_Detail.Where(x => x.ID == id).ToList();

            foreach (var da in _data)
            {
                var _chk = _mysqlbro.CUS_Company.FirstOrDefault(x => x.CompanyNameTH == da.Customer);
                da.labinves = da.DateReg.ToString("yyyy-MM-dd");
                da.Service = (_chk == null ? "191" : _chk.Type);
            }

            return Json(_data);
        }

        public IActionResult Getdatarec(int id)
        {

            var _data = _mysqlbro.CN_Sales.Select(x => x.Recommend).Distinct().ToList();


            return Json(_data);
        }

        public IActionResult Getdatamedt(int id)
        {

            var _data = _mysqlbro.CEN_TypeHealthCheck.ToList();


            return Json(_data);
        }

        public IActionResult Getdatapayt(int id)
        {

            var _data = _mysqlbro.CEN_TypePayment.ToList();


            return Json(_data);
        }
        public IActionResult Getdataret(int id)
        {

            var _data = _mysqlbro.CEN_PerReceive.ToList();


            return Json(_data);
        }


        public class View_salesreport
        {
            public int id { get; set; }
            public string datereg { get; set; }
            public string refno { get; set; }
            public string titlename { get; set; }
            public string fname { get; set; }

            
            public string fname1 { get; set; }
            public string titlename1 { get; set; }

            public string lname { get; set; }
            public string medservice { get; set; }
            public string customer { get; set; }
            public string paytype { get; set; }
            public decimal totalamount { get; set; }
            public string moneyrev { get; set; }
            public string remark { get; set; }
            public string revinvdat { get; set; }
            public string deductdate { get; set; }
            public string recommend { get; set; }
            public decimal pricerec { get; set; }



        }

        public class View_salesreciept
        {
            public int id { get; set; }
            public string datereg { get; set; }
            public string refno { get; set; }
            public string detail { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
            public decimal price { get; set; }
            public string totalsum { get; set; }
            public int paytype { get; set; }

            public string Tel { get; set; }
            public string revinvdat { get; set; }
            public string deductdate { get; set; }

            public string adr0 { get; set; }
            public string adr { get; set; }

            public string adr1 { get; set; }
            public string adr2 { get; set; }
            public string adr3 { get; set; }

            public string adr4 { get; set; }

            public string pro { get; set; }
            public string dis { get; set; }
            public string subdis { get; set; }
            public string postcode { get; set; }




        }
        public IActionResult Getdatapm(int payty, int perrev, int medser, string rec, DateTime startdate, DateTime enddate)
        {

            var _datapa = _mysqlbro.CN_Patient.ToList();
            var _datade = _mysqlbro.CN_Detail.ToList();
            var _datase = _mysqlbro.CN_Sales.ToList();

            var _datath = _mysqlbro.CEN_TypeHealthCheck.ToList();
            var _datatp = _mysqlbro.CEN_TypePayment.ToList();
            var _datapr = _mysqlbro.CEN_PerReceive.ToList();


            var _data = _datase.Join(_datade, ae => ae.DetailID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Join(_datapa, dg => dg.ea.PatientID, gd => gd.ID, (dg, gd) => new { dg, gd })
                .Join(_datath, vb => vb.dg.ea.medtype, bv => bv.ID.ToString(), (vb, bv) => new { vb, bv })
                .Join(_datatp, xc => xc.vb.dg.ae.TypeName, cx => cx.ID, (xc, cx) => new { xc, cx })
                .Join(_datapr, ku => ku.xc.vb.dg.ae.PerReceiver, uk => uk.ID, (ku, uk) => new { ku, uk });

            if (payty != 0)
                _data = _data.Where(c => c.ku.xc.vb.dg.ae.TypeName == payty);
            if (perrev != 0)
                _data = _data.Where(c => c.ku.xc.vb.dg.ae.PerReceiver == perrev);
            if (medser != 0)
                _data = _data.Where(c => c.ku.xc.vb.dg.ae.MedType == medser);
            if (rec != "null")
                _data = _data.Where(c => c.ku.xc.vb.dg.ae.Recommend == rec);
            if (startdate.ToString("yyyy") != "0001" && enddate.ToString("yyyy") != "0001")
                _data = _data.Where(c => c.ku.xc.vb.dg.ea.DateReg >= startdate && c.ku.xc.vb.dg.ea.DateReg <= enddate);
            if (enddate.ToString("yyyy") != "0001")
                _data = _data.Where(c => c.ku.xc.vb.dg.ea.DateReg <= enddate);


            _data = _data.OrderByDescending(x => x.ku.xc.vb.dg.ae.ID);
            List<View_salesreport> list = new List<View_salesreport>();
            foreach (var da in _data) {

                list.Add(new View_salesreport
                {
                    datereg = da.ku.xc.vb.dg.ea.DateReg.ToString("dd/MM/yyyy"),
                    refno = "BB-" + da.ku.xc.vb.gd.IDPatient + (da.ku.xc.vb.gd.IDrunnumber > 9 ? "-00" : (da.ku.xc.vb.gd.IDrunnumber > 99 ? "-0" : (da.ku.xc.vb.gd.IDrunnumber > 999 ? "-0" : "-000"))) + da.ku.xc.vb.gd.IDrunnumber,
                    titlename = da.ku.xc.vb.gd.titlename,
                    fname = da.ku.xc.vb.gd.Fname,
                    lname = da.ku.xc.vb.gd.Lname,
                    medservice = da.ku.xc.bv.TypeName,
                    customer = da.ku.xc.vb.dg.ae.Company,
                    paytype = da.ku.cx.TypeName,
                    totalamount = da.ku.xc.vb.dg.ae.Price,
                    moneyrev = da.uk.Name,
                    remark = da.ku.xc.vb.dg.ae.Remark,
                    revinvdat = Convert.ToDateTime(da.ku.xc.vb.dg.ae.ReceivePayDate).ToString("dd/MM/yyyy"),
                    deductdate = (da.ku.xc.vb.dg.ae.ReceiveDeDate != null ? Convert.ToDateTime(da.ku.xc.vb.dg.ae.ReceiveDeDate).ToString("dd/MM/yyyy") : ""),
                    recommend = da.ku.xc.vb.dg.ae.Recommend,
                    id = da.ku.xc.vb.dg.ae.ID,
                    pricerec = da.ku.xc.vb.dg.ae.Pricerec

                });

            }

            return Json(list);
        }
        public IActionResult Savepayreport(List<View_salesreport> collection)
        {

            
            foreach (var data in collection)
            {
     

                var _data = _mysqlbro.CN_Sales.FirstOrDefault(x => x.ID == data.id);

                //_data.ReceivePayDate = (data.revinvdat == "" || data.revinvdat == null ? null : Convert.ToDateTime(data.revinvdat));
                _data.Pricerec = Convert.ToDecimal(data.pricerec);

                _mysqlbro.CN_Sales.Update(_data);
                _mysqlbro.SaveChanges();
            }



            return Json("success");

        }
        public IActionResult Getdatacom(int id)
        {

            var _data = _mysqlbro.CUS_Company.Where(x => x.Status == "1").OrderBy(c => c.NameSimple).ToList();


            return Json(_data);
        }

        public IActionResult Gettyperec()
        {

            var _data = _mysqlbro.CUS_Agency.Where(x => x.Status == "1").OrderBy(c => c.ID).ToList();


            return Json(_data);
        }
        public IActionResult Exportex(int payty, int perrev, int medser, DateTime enddate, DateTime startdate)
        {
            DataTable dt = new DataTable("Invoice_report");
            dt.Columns.AddRange(new DataColumn[15] {
                                        new DataColumn("No"),
                                        new DataColumn("ServiceDate"),
                                        new DataColumn("CN"),
                                        new DataColumn("titlename"),
                                        //new DataColumn("Edit Date") ,
                                      
                                        new DataColumn("Firstname") ,
                                        new DataColumn("LastName") ,
                                        new DataColumn("Medical Service") ,
                                        new DataColumn("Company") ,
                                        new DataColumn("PaymentType") ,
                                        new DataColumn("TotalAmount") ,
                                        new DataColumn("Money Receiver") ,
                                        new DataColumn("Remark") ,
                                        new DataColumn("ReceivePaymentDate") ,
                                        new DataColumn("Reccommender") ,
                                        new DataColumn("Status") ,



            });

            var _datapa = _mysqlbro.CN_Patient.ToList();
            var _datade = _mysqlbro.CN_Detail.ToList();
            var _datase = _mysqlbro.CN_Sales.ToList();

            var _datath = _mysqlbro.CEN_TypeHealthCheck.ToList();
            var _datatp = _mysqlbro.CEN_TypePayment.ToList();
            var _datapr = _mysqlbro.CEN_PerReceive.ToList();


            var _data = _datase.Join(_datade, ae => ae.DetailID, ea => ea.ID, (ae, ea) => new { ae, ea })
                .Join(_datapa, dg => dg.ea.PatientID, gd => gd.ID, (dg, gd) => new { dg, gd })
                .Join(_datath, vb => vb.dg.ea.medtype, bv => bv.ID.ToString(), (vb, bv) => new { vb, bv })
                .Join(_datatp, xc => xc.vb.dg.ae.TypeName, cx => cx.ID, (xc, cx) => new { xc, cx })
                .Join(_datapr, ku => ku.xc.vb.dg.ae.PerReceiver, uk => uk.ID, (ku, uk) => new { ku, uk });

            if (payty != 0)
                _data = _data.Where(c => c.ku.xc.vb.dg.ae.TypeName == payty);
            if (perrev != 0)
                _data = _data.Where(c => c.ku.xc.vb.dg.ae.PerReceiver == perrev);
            if (medser != 0)
                _data = _data.Where(c => c.ku.xc.vb.dg.ae.MedType == medser);
            if (startdate.ToString("yyyy") != "0001" && enddate.ToString("yyyy") != "0001")
                _data = _data.Where(c => c.ku.xc.vb.dg.ea.DateReg >= startdate && c.ku.xc.vb.dg.ea.DateReg <= enddate);
            if (enddate.ToString("yyyy") != "0001")
                _data = _data.Where(c => c.ku.xc.vb.dg.ea.DateReg <= enddate);

            List<View_salesreport> list = new List<View_salesreport>();
            foreach (var da in _data)
            {

                list.Add(new View_salesreport
                {
                    datereg = da.ku.xc.vb.dg.ea.DateReg.ToString("dd/MM/yyyy"),
                    refno = "BB-" + da.ku.xc.vb.gd.IDPatient + (da.ku.xc.vb.gd.IDrunnumber > 9 ? "-00" : (da.ku.xc.vb.gd.IDrunnumber > 99 ? "-0" : (da.ku.xc.vb.gd.IDrunnumber > 999 ? "-0" : "-000"))) + da.ku.xc.vb.gd.IDrunnumber,
                    titlename = da.ku.xc.vb.gd.titlename,
                    fname = da.ku.xc.vb.gd.Fname,
                    lname = da.ku.xc.vb.gd.Lname,
                    medservice = da.ku.xc.bv.TypeName,
                    customer = da.ku.xc.vb.dg.ae.Company,
                    paytype = da.ku.cx.TypeName,
                    totalamount = da.ku.xc.vb.dg.ae.Price,
                    moneyrev = da.uk.Name,
                    remark = da.ku.xc.vb.dg.ae.Remark,
                    revinvdat = Convert.ToDateTime(da.ku.xc.vb.dg.ae.ReceivePayDate).ToString("dd/MM/yyyy"),
                    deductdate = (da.ku.xc.vb.dg.ae.ReceiveDeDate != null ? Convert.ToDateTime(da.ku.xc.vb.dg.ae.ReceiveDeDate).ToString("dd/MM/yyyy") : ""),
                    recommend = da.ku.xc.vb.dg.ae.Recommend,
                    id = da.ku.xc.vb.dg.ae.ID

                });

            }
            decimal totalA = 0;
            foreach (var da in _data)
            {

                totalA += Convert.ToDecimal(da.ku.xc.vb.dg.ae.Price);


            }
            dt.Rows.Add(
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    totalA.ToString("#,##0.00"),
                    "",
                    "",
                    "",
                    "",
                    ""

                //row["CustID"].ToString(),
                //row["InvRewrite"].ToString(),

                );

            int rowCount = dt.Rows.Count;


            foreach (var da in _data)
            {

                dt.Rows.Add(
                    dt.Rows.Count,
                     da.ku.xc.vb.dg.ea.DateReg.ToString("dd/MM/yyyy"),
                    "BB-" + da.ku.xc.vb.gd.IDPatient + (da.ku.xc.vb.gd.IDrunnumber > 9 ? "-00" : (da.ku.xc.vb.gd.IDrunnumber > 99 ? "-0" : (da.ku.xc.vb.gd.IDrunnumber > 999 ? "-0" : "-000"))) + da.ku.xc.vb.gd.IDrunnumber,
                    da.ku.xc.vb.gd.titlename,
                    da.ku.xc.vb.gd.Fname,
                    da.ku.xc.vb.gd.Lname,
                    da.ku.xc.bv.TypeName,
                    da.ku.xc.vb.dg.ae.Company,
                    da.ku.cx.TypeName,
                    da.ku.xc.vb.dg.ae.Price,
                    da.uk.Name,
                    da.ku.xc.vb.dg.ae.Remark,
                    Convert.ToDateTime(da.ku.xc.vb.dg.ae.ReceivePayDate).ToString("dd/MM/yyyy"),

                    //Convert.ToDateTime(da.ku.xc.vb.dg.ae.ReceiveDeDate).ToString("dd/MM/yyyy"),
                    da.ku.xc.vb.dg.ae.Recommend,
                    ""


                );

            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                IXLWorksheet ws = wb.Worksheets.Add(dt);



                ws.Column(8).CellsUsed().Style.NumberFormat.Format = "#,##0.00";


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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Payment_report-" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx");
                }
            }


        }

        public IActionResult Gettypechk(int id)
        {

            var _data = _mysqlbro.CN_CheckType.Where(x => x.TypeLabsID == id).OrderBy(c => c.DetailID).ToList();


            return Json(_data);
        }


        [HttpPost]
        public IActionResult deldatapatient(cn_typehealthmain model, [FromForm] List<string> list)
        {
            try
            {
                var _data = _mysqlbro.CN_Patient.FirstOrDefault(x => x.ID == model.ID);

                //_data.Status = "0";
                _mysqlbro.CN_Patient.Remove(_data);
                _mysqlbro.SaveChanges();

                return Json("success");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                //TempData["error"] = "User not found.";
                return Json(ex.Message);
            }

        }

        public IActionResult deldetail(string id)
        {

            var _data = _mysqlbro.CN_Detail.FirstOrDefault(x => x.ID == Convert.ToInt32(id));

            var _data2 = _mysqlbro.CN_Sales.FirstOrDefault(x => x.DetailID == Convert.ToInt32(id));

            if (_data2 != null)
                _mysqlbro.CN_Sales.Remove(_data2);

            _mysqlbro.CN_Detail.Remove(_data);

            _mysqlbro.SaveChanges();


            return Json("suc");
        }



        public IActionResult delpay(string id)
        {


            var _data2 = _mysqlbro.CN_Sales.FirstOrDefault(x => x.ID == Convert.ToInt32(id));

            _mysqlbro.CN_Sales.Remove(_data2);
          

            _mysqlbro.SaveChanges();


            return Json("suc");
        }  
        
        
        public IActionResult Exportpatient(string id)
        {
            var stream = new MemoryStream();
            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Patient");
                var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                namedStyle.Style.Font.UnderLine = true;

                //using (var r = worksheet.Cells["A1:R1"])
                //{
                //    //r.Merge = true;
                //    //r.Style.Font.Color.SetColor(Color.White);
                //    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                //    r.Style.Font.Bold = true;
                //    //r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    //r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                //}

                worksheet.Cells["A1"].Value = "Dateincome";
                worksheet.Cells["B1"].Value = "ID number";
                worksheet.Cells["C1"].Value = "FirstName";
                worksheet.Cells["D1"].Value = "LastName";
                worksheet.Cells["E1"].Value = "Weight";
                worksheet.Cells["F1"].Value = "Height";
                worksheet.Cells["G1"].Value = "Age";
                worksheet.Cells["H1"].Value = "Company";
                //worksheet.Cells["I1"].Value = "BL";
                //worksheet.Cells["J1"].Value = "AB";
                //worksheet.Cells["K1"].Value = "VA";
                //worksheet.Cells["L1"].Value = "RS";
                //worksheet.Cells["M1"].Value = "TD";
                //worksheet.Cells["N1"].Value = "OFF";
                //worksheet.Cells["O1"].Value = "Holiday";
                //worksheet.Cells["P1"].Value = "New";
                //worksheet.Cells["Q1"].Value = "Parttime";
                //worksheet.Cells["R1"].Value = "Pay75%";
                //worksheet.Cells[2, 1, 3, 2].Value = "Company";
                //worksheet.Cells[2, 3, 2, 4].Value = "Cash";
                //worksheet.Cells[2, 5, 2, 6].Value = "Bank Tranfer";
                //worksheet.Cells[2, 7, 2, 8].Value = "Invoice";
                //worksheet.Cells[2, 9, 2, 10].Value = "Total";

                //worksheet.Cells[3, 3].Value = "Count of Person";
                //worksheet.Cells[3, 4].Value = "Count of Amount";
                //worksheet.Cells[3, 5].Value = "Count of Person";
                //worksheet.Cells[3, 6].Value = "Count of Amount";
                //worksheet.Cells[3, 7].Value = "Count of Person";
                //worksheet.Cells[3, 8].Value = "Count of Amount";
                //worksheet.Cells[3, 9].Value = "Total of Person";
                //worksheet.Cells[3, 10].Value = "Total of Amount";
                //worksheet.Cells[4, 1].Value = "Sum";



                //worksheet.Cells[3, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //worksheet.Cells[3, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                //worksheet.Cells[3, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                //worksheet.Cells[3, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;




                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;

                //var com = _mysqlbro.Showdataex.FromSqlRaw(query).ToList();
                //var time = _mysqlbro.Showdashboard2.FromSqlRaw(query2).ToList();


                //var comv = _mysqlbro.Showdataex.FromSqlRaw(queryw).ToList();


                int row = 2;
                //int col = 4;

                var _data1 = _mysqlbro.CN_Patient.ToList();
                var _data2 = _mysqlbro.CN_Detail.ToList();


                var sumdata = _data1.Join(_data2, ae => ae.ID, ea => ea.PatientID, (ae, ea) => new { ae, ea }).ToList();

                foreach (var a in sumdata)
                {


                    var date = worksheet.Cells[row, 1];
                    date.Value = a.ea.DateReg.ToString("dd//MM/yyyy");

                    var idn = worksheet.Cells[row, 2];
                    idn.Value = a.ae.IDCard;


                    var fir= worksheet.Cells[row, 3];
                    fir.Value = a.ae.Fname;

                    var las = worksheet.Cells[row, 4];
                    las.Value = a.ae.Lname;

                    var wei  = worksheet.Cells[row, 5];
                    wei.Value = a.ea.Weight;

                    var hei = worksheet.Cells[row, 6];
                    hei.Value = a.ea.Height;

                    var age = worksheet.Cells[row, 7];
                    age.Value = (a.ae.birthday != "" && a.ae.birthday != null && a.ae.birthday != "#N/A" ? (int)((DateTime.Now - Convert.ToDateTime(a.ae.birthday)).TotalDays / 365.242199) : ""); 

                    var com = worksheet.Cells[row, 8];
                    com.Value = a.ea.Customer;


                    row++;

                }





                xlPackage.Save();
                // Response.Clear();
                //}
            }
           

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Patient" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx");



        }

        public IActionResult ExportExcel2(string id)
        {
            var workbook = new XLWorkbook("D:\\Programming\\1.Web\\BRO\\Programming\\Bro-Clinic\\bbsaha\\wwwroot\\asset\\Template\\temp.xlsx");
            var worksheet = workbook.Worksheet("sheet1");

            // Add data to the worksheet
            worksheet.Cell("A1").Value = "Name";
            worksheet.Cell("B1").Value = "Age";

            // Example data
            var data = new[]
            {
                new { Name = "John Doe", Age = 30 },
                new { Name = "Jane Smith", Age = 25 }
            };

            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cell("A" + row).Value = item.Name;
                worksheet.Cell("B" + row).Value = item.Age;
                row++;
            }

            // Write workbook to response stream
            using (var memoryStream = new System.IO.MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                MemoryStream ms2 = new MemoryStream(memoryStream.ToArray());
                return File(ms2, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Patient" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx");
            }
        }



    }

}
