using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bbsaha.Data;
using bbsaha.Models.patient;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using WkHtmlToPdfDotNet.Contracts;

namespace bbsaha.Controllers
{
    public class PaymentController : Controller
    {
        private IConverter _converter;
        private readonly MysqlDBDataContext _mysqlbro;
        string db = "bbsaha";
        public PaymentController(MysqlDBDataContext newbrother, IConverter converter)
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
        public IActionResult Paymentsummary()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult paymentcash()
        {
            return View();
        }

        public class Showsummary { 
        
            public string Customer { get; set; }
            public string ccash { get; set; }
            public int scash { get; set; }
            public string cbank { get; set; }
            public int sbank { get; set; }
            public string cinvoice { get; set; }
            public int sinvoice { get; set; }
            public string cper { get; set; }
            public int sper { get; set; }
            
            
          
        
        
        }

        public IActionResult Getdatasum(DateTime startdate, DateTime enddate)
        {
            //var _datapa = _mysqlbro.CN_Patient.ToList();
            //var _datade = _mysqlbro.CN_Detail.ToList();
           
            //var _datase = _mysqlbro.CN_Sales.ToList();

            //var _datath = _mysqlbro.CEN_TypeHealthCheck.ToList();
            //var _datatp = _mysqlbro.CEN_TypePayment.ToList();
            //var _datapr = _mysqlbro.CEN_PerReceive.ToList();


            //var _data = _datase.Join(_datade, ae => ae.DetailID, ea => ea.ID, (ae, ea) => new { ae, ea })
            //  .Join(_datapa, dg => dg.ea.PatientID, gd => gd.ID, (dg, gd) => new { dg, gd })
            //  .Join(_datath, vb => vb.dg.ea.medtype, bv => bv.ID.ToString(), (vb, bv) => new { vb, bv })
            //  .Join(_datatp, xc => xc.vb.dg.ae.TypeName, cx => cx.ID, (xc, cx) => new { xc, cx })
            //  .Join(_datapr, ku => ku.xc.vb.dg.ae.PerReceiver, uk => uk.ID, (ku, uk) => new { ku, uk }).GroupBy(b => b.ku.xc.vb.dg.ea.Customer).Sum(x => (x.Key != null ? 1 : 0));
            
            List<Showsummary> _manapp = new List<Showsummary>();
            using (MySqlConnection con = new MySqlConnection("Data Source=103.30.126.174;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            //using (MySqlConnection con = new MySqlConnection("Data Source=ls-45cff82ac10d1518f2ee0eccea65733beec0ec7c.cwwhyjgyqjh8.ap-southeast-1.rds.amazonaws.com;Initial Catalog=GMP;Persist Security Info=True;User ID=dbmasteruser;Password=gmpsystemm1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            {
                con.Open();
                string query = "";

                query = @"SELECT cd.Customer,count(IF(cs.TypeName = 1  , 1 ,null)) AS COUNTCASH
,SUM(IF(cs.TypeName = 1  , cs.price ,0)) AS SUMCASH
,count(IF(cs.TypeName = 2  , 1 ,null)) AS COUNTBANK
,SUM(IF(cs.TypeName = 2  , cs.price ,0)) AS SUMBANK
,count(IF(cs.TypeName = 3  , 1 ,null)) AS COUNTINVOICE
,SUM(IF(cs.TypeName = 3  , cs.price ,0)) AS SUMINVOICE
,COUNT(IF(cs.TypeName = 1 or cs.TypeName = 2 or cs.TypeName = 3, cs.TypeName,null)) AS COUNTPERSON
,SUM(cs.price) AS SUMPERSON
FROM CN_Sales cs
INNER JOIN  CN_Detail cd ON cd.ID = cs.DetailID
INNER JOIN  CN_Patient cp ON cp.ID = cd.PatientID ?1 GROUP BY cd.Customer ORDER BY cd.Customer ASC";
                if (startdate.ToString("yyyy") != "0001" || enddate.ToString("yyyy") != "0001")
                {
                    query = query.Replace("?1", "Where cd.DateReg between '" + startdate.ToString("yyyy-MM-dd") + "' and '" + enddate.ToString("yyyy-MM-dd") + "'");
                }
                else {
                    query = query.Replace("?1", "");

                }


                MySqlCommand cmd = new MySqlCommand(query, con);


                MySqlDataReader dr = cmd.ExecuteReader();
                //var chkname = 0;
                //var num = 1;
                while (dr.Read())
                {


                    _manapp.Add(new Showsummary
                    {
                        //CompanyName = dr["CompanyNameEN"].ToString(),
                        //Workday = Convert.ToDateTime(dr["WorkDay"].ToString()),
                        Customer = dr["Customer"].ToString(),
                        ccash = dr["COUNTCASH"].ToString(),
                        scash = Convert.ToInt32(dr["SUMCASH"]),
                        cbank = dr["COUNTBANK"].ToString(),
                        sbank = Convert.ToInt32(dr["SUMBANK"]),
                        cinvoice = dr["COUNTINVOICE"].ToString(),
                        sinvoice = Convert.ToInt32(dr["SUMINVOICE"]),
                        cper = dr["COUNTPERSON"].ToString(),
                        sper = Convert.ToInt32(dr["SUMPERSON"]),
                       



                    });

                }
                con.Close();
            }
           

            return Json(_manapp);


            //return Json(_data);
        }

        public IActionResult Getdatacom(DateTime startdate, DateTime enddate)
        {
            var _datacusgrop = _mysqlbro.CN_Detail.GroupBy(xx => new { xx.Customer, xx.DateReg }).OrderBy(o => o.Key.Customer).Where(v => v.Key.DateReg >= startdate && v.Key.DateReg <= enddate).Select(k => k.Key).ToList() ;
               
            List<Showsummary> _manapp = new List<Showsummary>();
            using (MySqlConnection con = new MySqlConnection("Data Source=103.30.126.174;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            //using (MySqlConnection con = new MySqlConnection("Data Source=ls-45cff82ac10d1518f2ee0eccea65733beec0ec7c.cwwhyjgyqjh8.ap-southeast-1.rds.amazonaws.com;Initial Catalog=GMP;Persist Security Info=True;User ID=dbmasteruser;Password=gmpsystemm1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            {
                con.Open();
                string query = "";

                query = @"SELECT a.Customer
                            FROM bbsaha.CN_Detail a
                            ?1
                            group by a.Customer
                            Order BY a.Customer ASC";
                if (startdate.ToString("yyyy") != "0001" || enddate.ToString("yyyy") != "0001")
                {
                    query = query.Replace("?1", "Where DateReg between '" + startdate.ToString("yyyy-MM-dd") + "' and '" + enddate.ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    query = query.Replace("?1", "");

                }


                MySqlCommand cmd = new MySqlCommand(query, con);


                MySqlDataReader dr = cmd.ExecuteReader();
                //var chkname = 0;
                //var num = 1;
                while (dr.Read())
                {


                    _manapp.Add(new Showsummary
                    {
                        //CompanyName = dr["CompanyNameEN"].ToString(),
                        //Workday = Convert.ToDateTime(dr["WorkDay"].ToString()),
                        Customer = dr["Customer"].ToString(),
                       

                    });

                }
                con.Close();
            }



            return Json(_manapp);
        }

        public IActionResult Getdatacash(DateTime startdate, DateTime enddate)
        {

            List<Showsummary> _manapp = new List<Showsummary>();
            using (MySqlConnection con = new MySqlConnection("Data Source=103.30.126.174;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            //using (MySqlConnection con = new MySqlConnection("Data Source=ls-45cff82ac10d1518f2ee0eccea65733beec0ec7c.cwwhyjgyqjh8.ap-southeast-1.rds.amazonaws.com;Initial Catalog=GMP;Persist Security Info=True;User ID=dbmasteruser;Password=gmpsystemm1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
            {
               
                string query = "";

                query = @"SELECT cd.DateReg
,SUM(IF(cs.TypeName = 1  , cs.price ,0)) AS SUMCASH,ps.Amount,ps.Comment
FROM CN_Sales cs
INNER JOIN  CN_Detail cd ON cd.ID = cs.DetailID
LEFT JOIN PAY_Cash ps ON ps.Dateclear = cd.DateReg
INNER JOIN  CN_Patient cp ON cp.ID = cd.PatientID ?1 GROUP BY cd.DateReg ORDER BY cd.DateReg ASC";
                if (startdate.ToString("yyyy") != "0001" || enddate.ToString("yyyy") != "0001")
                {
                    query = query.Replace("?1", "Where cd.DateReg between '" + startdate.ToString("yyyy-MM-dd") + "' and '" + enddate.ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    query = query.Replace("?1", "");

                }




               
                //var chkname = 0;
                int num = 0,count = 1;
                for (var dt = startdate; dt <= enddate; dt = dt.AddDays(1))
                {
                    int chk = 0;
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(query, con);


                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime a = Convert.ToDateTime(dr["DateReg"]);
                        if (dt == Convert.ToDateTime(dr["DateReg"]))
                        {
                            if (count == 1)
                            {
                                num = Convert.ToInt32(dr["SUMCASH"]);
                                if (dr["Amount"] is not DBNull)
                                    num -= Convert.ToInt32(dr["Amount"]);
                            }
                            else
                            {
                                num = Convert.ToInt32(dr["SUMCASH"]) + num;
                                if (dr["Amount"] is not DBNull)
                                    num -= Convert.ToInt32(dr["Amount"]);

                            }

                            _manapp.Add(new Showsummary
                            {
                                //CompanyName = dr["CompanyNameEN"].ToString(),
                                //Workday = Convert.ToDateTime(dr["WorkDay"].ToString()),
                                Customer = Convert.ToDateTime(dr["DateReg"]).ToString("yyyy-MM-dd"),
                                scash = Convert.ToInt32(dr["SUMCASH"]),
                                sbank = num,
                                ccash = (dr["Amount"] is DBNull ? null : dr["Amount"].ToString()),
                                cper = dr["Comment"].ToString()


                            });
                            chk = 1;
                            count++;
                        }
                       



                    }

                    if (chk == 0) {
                        _manapp.Add(new Showsummary
                        {
                            //CompanyName = dr["CompanyNameEN"].ToString(),
                            //Workday = Convert.ToDateTime(dr["WorkDay"].ToString()),
                            Customer = dt.ToString("yyyy-MM-dd"),
                            scash = 0,
                            sbank = 0,
                            ccash = 0.ToString(),
                            cper = ""


                        });

                    }
                    con.Close();



                }
                
            }


            return Json(_manapp);
        }
        public class View_salesreport
        {
            public int id { get; set; }
            public DateTime date { get; set; }
            public string sper { get; set; }
            public string cper { get; set; }
          



        }


        public IActionResult Savepayreport(List<View_salesreport> collection)
        {

            foreach (var data in collection)
            {
              
                var _dataa = _mysqlbro.PAY_Cash.ToList();
                var _data = _mysqlbro.PAY_Cash.FirstOrDefault(x => x.Dateclear >= data.date && x.Dateclear <= data.date);

            

                if (_data != null)
                {
                    _data.Amount = (data.sper == "" || data.sper == null ? 0 : Convert.ToDecimal(data.sper));
                    _data.Comment = (data.cper == "" || data.cper == null ? null : data.cper);
                    _mysqlbro.PAY_Cash.Update(_data);
                    _mysqlbro.SaveChanges();
                }
                else {
                    if (data.sper != null) {
                        var Pay = new pay_cash
                        {
                            Dateclear = Convert.ToDateTime(data.date),
                            Amount = Convert.ToDecimal(data.sper),
                            Comment = data.cper,
                            Status = "1",
                            CreateDate = DateTime.Now,
                            UpdateBy = User.Identity.Name,
                            UpdateDate = DateTime.Now,
                            DetailID = 0
                        };
                        _mysqlbro.PAY_Cash.Add(Pay);
                        _mysqlbro.SaveChanges();
                    }
                }

               
            }



            return Json("success");

        }


        public IActionResult Exportex(DateTime enddate, DateTime startdate)
        {


           


            var stream = new MemoryStream();
            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Dashboard");
                var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                namedStyle.Style.Font.UnderLine = true;

                using (var r = worksheet.Cells["A1:R1"])
                {
                    //r.Merge = true;
                    //r.Style.Font.Color.SetColor(Color.White);
                    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                    r.Style.Font.Bold = true;
                    //r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                }

                //worksheet.Cells["A1"].Value = "Date";
                //worksheet.Cells["B1"].Value = "Name";
                //worksheet.Cells["C1"].Value = "Shift";
                //worksheet.Cells["D1"].Value = "Request";
                //worksheet.Cells["E1"].Value = "TTL";
                //worksheet.Cells["F1"].Value = "Working";
                //worksheet.Cells["G1"].Value = "Lack";
                //worksheet.Cells["H1"].Value = "SL";
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
                worksheet.Cells[2, 1, 3, 2].Value = "Company";
                worksheet.Cells[2, 3, 2, 4].Value = "Cash";
                worksheet.Cells[2, 5, 2, 6].Value = "Bank Tranfer";
                worksheet.Cells[2, 7, 2, 8].Value = "Invoice";
                worksheet.Cells[2, 9, 2, 10].Value = "Total";

                worksheet.Cells[3, 3].Value = "Count of Person";
                worksheet.Cells[3, 4].Value = "Count of Amount";
                worksheet.Cells[3, 5].Value = "Count of Person";
                worksheet.Cells[3, 6].Value = "Count of Amount";
                worksheet.Cells[3, 7].Value = "Count of Person";
                worksheet.Cells[3, 8].Value = "Count of Amount";
                worksheet.Cells[3, 9].Value = "Total of Person";
                worksheet.Cells[3, 10].Value = "Total of Amount";
                worksheet.Cells[4, 1].Value = "Sum";



                worksheet.Cells[3, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[3, 4].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[3, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[3, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 6].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[3, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[3, 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[3, 9].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 9].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 9].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[3, 10].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 10].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 10].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[3, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


               

                //var com = _mysqlbro.Showdataex.FromSqlRaw(query).ToList();
                //var time = _mysqlbro.Showdashboard2.FromSqlRaw(query2).ToList();


                //var comv = _mysqlbro.Showdataex.FromSqlRaw(queryw).ToList();


                int row = 5;
                int row2 = 4;
               


                using (MySqlConnection con = new MySqlConnection("Data Source=103.30.126.174;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
                {
                    //con.Open();
                    //MySqlCommand cmd = new MySqlCommand(query2, con);
                    //var total = worksheet.Cells[2, 2];
                    //total.Value = "Total";
                    //var totald = worksheet.Cells[2, 3];
                    //totald.Value = "DAY";
                    //var totaln = worksheet.Cells[3, 3];
                    //totaln.Value = "NIGHT";
                    //var totalt = worksheet.Cells[4, 3];
                    //totalt.Value = "TOTAL";
                    //DAY


                    con.Open();
                    string query = "";

                    query = @"SELECT Customer 
FROM bbsaha.CN_Detail 
?1
group by Customer 
Order BY Customer ASC";
                    if (startdate.ToString("yyyy") != "0001" || enddate.ToString("yyyy") != "0001")
                    {
                        query = query.Replace("?1", "Where DateReg between '" + startdate.ToString("yyyy-MM-dd") + "' and '" + enddate.ToString("yyyy-MM-dd") + "'");
                    }
                    else
                    {
                        query = query.Replace("?1", "");

                    }

                   
                    MySqlCommand cmd2 = new MySqlCommand(query, con);


                    MySqlDataReader dr2 = cmd2.ExecuteReader();

                    //MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr2.Read())
                    {

                        worksheet.Cells[2, 1, 3, 2].Merge = true;
                        worksheet.Cells[2, 3, 2, 4].Merge = true;
                        worksheet.Cells[2, 5, 2, 6].Merge = true;
                        worksheet.Cells[2, 7, 2, 8].Merge = true;
                        worksheet.Cells[2, 9, 2, 10].Merge = true;
                        worksheet.Cells[4, 1, 4, 2].Merge = true;
                        worksheet.Cells[row, 1, row, 2].Merge = true;
                        worksheet.Column(1).Width = 50;
                        worksheet.Column(3).Width = 20;
                        worksheet.Column(4).Width = 20;
                        worksheet.Column(5).Width = 20;
                        worksheet.Column(6).Width = 20;
                        worksheet.Column(7).Width = 20;
                        worksheet.Column(8).Width = 20;
                        worksheet.Column(9).Width = 20;
                        worksheet.Column(10).Width = 20;

                        worksheet.Cells[2, 1, 3, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 1, 3, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 1, 3, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 1, 3, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        worksheet.Cells[2, 3, 2, 4].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 3, 2, 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 3, 2, 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 3, 2, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                        worksheet.Cells[2, 5, 2, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 5, 2, 6].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 5, 2, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 5, 2, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                        worksheet.Cells[2, 7, 2, 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 7, 2, 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 7, 2, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 7, 2, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                        worksheet.Cells[2, 9, 2, 10].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 9, 2, 10].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 9, 2, 10].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[2, 9, 2, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                        worksheet.Cells[4, 1, 4, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[4, 1, 4, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[4, 1, 4, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[4, 1, 4, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                        //worksheet.Cells[3, 1, 3, 2].Merge = true;
                        //worksheet.Cells[1, 2].Merge = true;
                        //worksheet.Cells[2, 2, 3, 2].Merge = true;
                        //worksheet.Cells[2, 3, 3, 3].Merge = true;

                        //worksheet.Cells[row2 + 1, 1, row2 + 2, 1].Merge = true;
                        //worksheet.Cells[row2 + 1, 2, row2 + 2, 2].Merge = true;
                        //worksheet.Cells[row2 + 1, 3, row2 + 2, 3].Merge = true;

                        var no = worksheet.Cells[row, 1];
                        no.Value = dr2["Customer"].ToString();

                        //var name = worksheet.Cells[row2 + 1, 2];
                        //name.Value = dr2["NameSimple"].ToString();
                        using (MySqlConnection con2 = new MySqlConnection("Data Source=103.30.126.174;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;"))
                        {

                            con2.Open();
                            string query2 = "";

                            query2 = @"SELECT cd.Customer,count(IF(cs.TypeName = 1  , 1 ,null)) AS COUNTCASH
,SUM(IF(cs.TypeName = 1  , cs.price ,0)) AS SUMCASH
,count(IF(cs.TypeName = 2  , 1 ,null)) AS COUNTBANK
,SUM(IF(cs.TypeName = 2  , cs.price ,0)) AS SUMBANK
,count(IF(cs.TypeName = 3  , 1 ,null)) AS COUNTINVOICE
,SUM(IF(cs.TypeName = 3  , cs.price ,0)) AS SUMINVOICE
,COUNT(IF(cs.TypeName = 1 or  cs.TypeName = 2, cs.TypeName,null)) AS COUNTPERSON
,SUM(cs.price) AS SUMPERSON
FROM CN_Sales cs
INNER JOIN  CN_Detail cd ON cd.ID = cs.DetailID
INNER JOIN  CN_Patient cp ON cp.ID = cd.PatientID ?1 GROUP BY cd.Customer ORDER BY cd.Customer ASC";
                            if (startdate.ToString("yyyy") != "0001" || enddate.ToString("yyyy") != "0001")
                            {
                                query2 = query2.Replace("?1", "Where cd.DateReg between '" + startdate.ToString("yyyy-MM-dd") + "' and '" + enddate.ToString("yyyy-MM-dd") + "'");
                            }
                            else
                            {
                                query2 = query2.Replace("?1", "");

                            }

                            MySqlCommand cmd = new MySqlCommand(query2, con2);


                            MySqlDataReader dr = cmd.ExecuteReader();
                            int number = 1;

                            while (dr.Read())
                            {
                        //Customer = dr["Customer"].ToString(),
                        //ccash = dr["COUNTCASH"].ToString(),
                        //scash = Convert.ToInt32(dr["SUMCASH"]),
                        //cbank = dr["COUNTBANK"].ToString(),
                        //sbank = Convert.ToInt32(dr["SUMBANK"]),
                        //cinvoice = dr["COUNTINVOICE"].ToString(),
                        //sinvoice = Convert.ToInt32(dr["SUMINVOICE"]),
                        //cper = dr["COUNTPERSON"].ToString(),
                        //sper = Convert.ToInt32(dr["SUMPERSON"]),
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString() )
                                {
                                    var COUNTCASH = worksheet.Cells[row, 3];
                                    COUNTCASH.Value = dr["COUNTCASH"];
                                   

                                }
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString())
                                {
                                    var SUMCASH = worksheet.Cells[row, 4];
                                    SUMCASH.Value = dr["SUMCASH"];


                                }
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString())
                                {
                                    var COUNTBANK = worksheet.Cells[row, 5];
                                    COUNTBANK.Value = dr["COUNTBANK"];


                                }
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString())
                                {
                                    var SUMBANK = worksheet.Cells[row, 6];
                                    SUMBANK.Value = dr["SUMBANK"];


                                }
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString())
                                {
                                    var COUNTINVOICE = worksheet.Cells[row, 7];
                                    COUNTINVOICE.Value = dr["COUNTINVOICE"];


                                }
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString())
                                {
                                    var SUMINVOICE = worksheet.Cells[row, 8];
                                    SUMINVOICE.Value = dr["SUMINVOICE"];


                                }
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString())
                                {
                                    var COUNTPERSON = worksheet.Cells[row, 9];
                                    COUNTPERSON.Value = dr["COUNTPERSON"];


                                }
                                if (dr["Customer"].ToString() == dr2["Customer"].ToString())
                                {
                                    var SUMPERSON = worksheet.Cells[row, 10];
                                    SUMPERSON.Value = dr["SUMPERSON"];


                                }

                                worksheet.Cells[row, number].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[row, number].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[row, number].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[row, number].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                                number++;

                                if (number == 11) { number = 3; }
                            }
                            //DAY
                         

                            //totalpayt.Formula = "+SUM(" + worksheet.Cells[2, 18] + ")+SUM(" + worksheet.Cells[3, 18] + ")";



                            con2.Close();

                           
                        }
                        
                        row += 1;
                        row2 += 2;
                      
                     
                    }

                   

                    worksheet.Cells["C4"].Formula = "=SUM(C5:C" + row + ")";
                    worksheet.Cells["D4"].Formula = "=SUM(D5:D" + row + ")";
                    worksheet.Cells["E4"].Formula = "=SUM(E5:E" + row + ")";
                    worksheet.Cells["F4"].Formula = "=SUM(F5:F" + row + ")";
                    worksheet.Cells["G4"].Formula = "=SUM(G5:G" + row + ")";
                    worksheet.Cells["H4"].Formula = "=SUM(H5:H" + row + ")";
                    worksheet.Cells["I4"].Formula = "=SUM(I5:I" + row + ")";
                    worksheet.Cells["J4"].Formula = "=SUM(J5:J" + row + ")";

                    worksheet.Cells["C4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["C4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["C4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["C4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells["D4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["D4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["D4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["D4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells["E4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["E4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["E4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["E4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells["F4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["F4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["F4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["F4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells["G4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["G4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["G4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["G4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells["H4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["H4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["H4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["H4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells["I4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["I4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["I4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["I4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells["J4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["J4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["J4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["J4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    //worksheet.Cells["C4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    //worksheet.Cells[row, number].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    //worksheet.Cells[row, number].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    //worksheet.Cells[row, number].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                    con.Close();
                }

                //worksheet.Column(2).Width = 20;
                //worksheet.Column(3).Width = 20;

                xlPackage.Save();
                // Response.Clear();
                //}
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dashboard_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx");


        }
    }
}
