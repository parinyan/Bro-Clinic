using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bbsaha.Data;
using bbsaha.Models.Account;
using bbsaha.Models.Center;
using bbsaha.Models.Company;
using bbsaha.Models.patient;
using Microsoft.AspNetCore.Mvc;

namespace bbsaha.Controllers
{
    public class ManageController : Controller
    {
        private readonly MysqlDBDataContext _mysqlbro;
        public ManageController(MysqlDBDataContext newbrother)
        {
            //_context = context;
            _mysqlbro = newbrother;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Agency()
        {
            return View();
        }

        public IActionResult Labstype()
        {
            return View();
        }

        public IActionResult getdatacompany()
        {

            var _datacus = _mysqlbro.CUS_Company.OrderByDescending(c => c.ID).ToList();

            foreach (var da in _datacus) {
                var _chk = _mysqlbro.CN_Typehealthmain.FirstOrDefault(x => x.ID.ToString() == da.Type);
                da.Type = _chk.TypeName;
            
            }


            return Json(_datacus);
        }

        public IActionResult getdataagency()
        {

            var _datacus = _mysqlbro.CUS_Agency.OrderByDescending(c => c.ID).ToList();


            return Json(_datacus);
        }

        [HttpPost]
        public IActionResult savecustomer(cus_company users)
        {
            try
            {
                var num = 0;
                 num = Convert.ToInt32(_mysqlbro.CUS_Company.Max(x => x.ID)) + 1;
                //var pass = Encrypt(users.Password);

                var dt_com = new cus_company
                {
                    NameSimple = users.NameSimple,
                    CompanyNameTH = users.CompanyNameTH,
                    CompanyNameEN = users.CompanyNameEN,
                    CompanyCode = (num > 9 ? "0" : (num > 99 ? "" : "00")) + num,
                    Create_by = User.Identity.Name,
                    Create_date = DateTime.Now,
                    Status = users.Status,
                    ComIDTigersoft = _mysqlbro.CUS_Company.Max(x => x.ComIDTigersoft) + 1,
                    Type = users.Type,
                    DateWorking = 6,
                  
                };

                _mysqlbro.CUS_Company.Add(dt_com);
                _mysqlbro.SaveChanges();

                return Json("success");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                //TempData["error"] = "User not found.";
                return Json("failure");
            }

        }

        public IActionResult getdataed(int id)
        {

            var _datacus = _mysqlbro.CUS_Company.FirstOrDefault(x => x.ID == id);


            return Json(_datacus);
        }

        public IActionResult getdataagened(int id)
        {

            var _datacus = _mysqlbro.CUS_Agency.FirstOrDefault(x => x.ID == id);


            return Json(_datacus);
        } 
        public IActionResult getdatatyped(int id)
        {
            var _datatpye = _mysqlbro.CN_CheckType.ToList();

            var _datacus = _mysqlbro.CN_Typehealthmain.Where(x => x.ID == id).ToList();
            var sum = _datacus.GroupJoin(_datatpye, x => x.ID, df => df.TypeLabsID, (x, df) => new { x, df }).SelectMany(c => c.df.DefaultIfEmpty(), (c, y) => new { x = c.x, y = y }).ToList();
                 //var _data = CusSal.GroupJoin(_cushol, x => x.ID, df => df.HolCusConfigSalaryID, (x, df) => new { x, df }).SelectMany(c => c.df.DefaultIfEmpty(), (c, y) => new { x = c.x, y = y }).ToList();

            return Json(sum);
        }

        [HttpPost]
        public IActionResult savedataedit(cus_company users)
        {
            try
            {
                var _data = _mysqlbro.CUS_Company.FirstOrDefault(x => x.ID == users.ID);

                _data.NameSimple = users.NameSimple;
                _data.CompanyNameTH = users.CompanyNameTH;
                _data.CompanyNameEN = users.CompanyNameEN;
                _data.Status = users.Status;
                _data.Type = users.Type;
                //var dt_users = _mysqlbro.ACC_Users.FirstOrDefault(ae => ae.RowPointer == users.RowPointer);
                //dt_users.SupUser = users.SupUser;
                //dt_users.ManPower = users.ManPower;
                //dt_users.TimeAttendance = users.TimeAttendance;
                //dt_users.Administration = users.Administration;
                _mysqlbro.CUS_Company.Update(_data);
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

        [HttpPost]
        public IActionResult savedataagenedit(cus_agency users)
        {
            try
            {
                var _data = _mysqlbro.CUS_Agency.FirstOrDefault(x => x.ID == users.ID);

                _data.AgenName = users.AgenName;              
                _data.Status = users.Status;
                _data.UpdateDate = DateTime.Now;
                _data.UpdateBy = User.Identity.Name;
                //var dt_users = _mysqlbro.ACC_Users.FirstOrDefault(ae => ae.RowPointer == users.RowPointer);
                //dt_users.SupUser = users.SupUser;
                //dt_users.ManPower = users.ManPower;
                //dt_users.TimeAttendance = users.TimeAttendance;
                //dt_users.Administration = users.Administration;
                _mysqlbro.CUS_Agency.Update(_data);
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
        
       

        [HttpPost]
        public IActionResult savedatastatus(cus_company users)
        {
            try
            {
                var _data = _mysqlbro.CUS_Company.FirstOrDefault(x => x.ID == users.ID);

                _data.Status = users.Status;
                //var dt_users = _mysqlbro.ACC_Users.FirstOrDefault(ae => ae.RowPointer == users.RowPointer);
                //dt_users.SupUser = users.SupUser;
                //dt_users.ManPower = users.ManPower;
                //dt_users.TimeAttendance = users.TimeAttendance;
                //dt_users.Administration = users.Administration;
                _mysqlbro.CUS_Company.Update(_data);
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

        [HttpPost]
        public IActionResult savedataagenstatus(cus_company users)
        {
            try
            {
                var _data = _mysqlbro.CUS_Agency.FirstOrDefault(x => x.ID == users.ID);

                _data.Status = users.Status;
                //var dt_users = _mysqlbro.ACC_Users.FirstOrDefault(ae => ae.RowPointer == users.RowPointer);
                //dt_users.SupUser = users.SupUser;
                //dt_users.ManPower = users.ManPower;
                //dt_users.TimeAttendance = users.TimeAttendance;
                //dt_users.Administration = users.Administration;
                _mysqlbro.CUS_Agency.Update(_data);
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


        [HttpPost]
        public IActionResult savedatatypestatus(cn_typehealthmain users)
        {
            try
            {
                var _data = _mysqlbro.CN_Typehealthmain.FirstOrDefault(x => x.ID == users.ID);

                _data.Status = users.Status;
                //var dt_users = _mysqlbro.ACC_Users.FirstOrDefault(ae => ae.RowPointer == users.RowPointer);
                //dt_users.SupUser = users.SupUser;
                //dt_users.ManPower = users.ManPower;
                //dt_users.TimeAttendance = users.TimeAttendance;
                //dt_users.Administration = users.Administration;
                _mysqlbro.CN_Typehealthmain.Update(_data);
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


        [HttpPost]
        public IActionResult saveagency(cus_agency model)
        {
            try
            {
                var num = 0;
                try {
                    num = Convert.ToInt32(_mysqlbro.CUS_Agency.Max(x => x.ID)) + 1;
                }
                catch
                {
                    num = 1;
                }

                //var pass = Encrypt(users.Password);

                var dt_data = new cus_agency
                {
                    AgenCode = (num > 9 ? "0" : (num > 99 ? "" : "00")) + num,
                    AgenName = model.AgenName,
                    Type = "0",
                    Status = "1",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    UpdateBy = User.Identity.Name,

                };

                _mysqlbro.CUS_Agency.Add(dt_data);
                _mysqlbro.SaveChanges();

                return Json("success");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                //TempData["error"] = "User not found.";
                return Json("failure");
            }

        }

        public IActionResult getdatatypmain(int id)
        {

            var _datacus = _mysqlbro.CN_Typehealthmain.ToList();

            return Json(_datacus);
        }

        public IActionResult getdatatypcusmain(int id)
        {

            var _datacus = _mysqlbro.CN_Typehealthmain.Where(x => x.Status == "1").ToList();

            return Json(_datacus);
        }

        public IActionResult getdatatyp()
        {

            var _datacus = _mysqlbro.CEN_TypeLabs.ToList();

            return Json(_datacus);
        }

        public IActionResult savetyp(cn_typehealthmain model, [FromForm] List<string> list)
        {
            

            List<cn_checktype> lista = new List<cn_checktype>();


            var cn = new cn_typehealthmain()
            {
                TypeName = model.TypeName,
                Remark = model.Remark,
                Price = model.Price,
                Status = model.Status,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UpdateBy = User.Identity.Name
                
            };
            _mysqlbro.CN_Typehealthmain.Add(cn);
            _mysqlbro.SaveChanges();

            for (var a = 0; a < list.Count;a++) {

                var savdata = new cn_checktype() {
                    DetailID = Convert.ToInt32(list[a]),
                    TypeLabsID = cn.ID,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreateBy = User.Identity.Name


                };
                _mysqlbro.CN_CheckType.Add(savdata);
                _mysqlbro.SaveChanges();

                //i++;
            }




            //var _datacus = _mysqlbro.CEN_TypeLabs.ToList();

            return Json("success");
        }

        [HttpPost]
        public IActionResult savedatatypedit(cn_typehealthmain model, [FromForm] List<string> list)
        {
            try
            {
                var _data = _mysqlbro.CN_Typehealthmain.FirstOrDefault(x => x.ID == model.ID);

                _data.TypeName = model.TypeName;
                _data.Remark = model.Remark;
                _data.Status = model.Status;
                _data.Price = model.Price;
                _data.UpdateDate = DateTime.Now;
                _data.UpdateBy = User.Identity.Name;
                //var dt_users = _mysqlbro.ACC_Users.FirstOrDefault(ae => ae.RowPointer == users.RowPointer);
                //dt_users.SupUser = users.SupUser;
                //dt_users.ManPower = users.ManPower;
                //dt_users.TimeAttendance = users.TimeAttendance;
                //dt_users.Administration = users.Administration;
                _mysqlbro.CN_Typehealthmain.Update(_data);
                _mysqlbro.SaveChanges();


                var _detdel = _mysqlbro.CN_CheckType.Where(x => x.TypeLabsID == _data.ID).ToList();

                foreach (var da in _detdel)
                {
                    _mysqlbro.CN_CheckType.Remove(da);
                    _mysqlbro.SaveChanges();
                }
                //List<CN_CheckType> lista = new List<CN_CheckType>();
 
                for (var a = 0; a < list.Count; a++)
                {

                    var savdata = new cn_checktype()
                    {
                        DetailID = Convert.ToInt32(list[a]),
                        TypeLabsID = _data.ID,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        CreateBy = User.Identity.Name


                    };
                    _mysqlbro.CN_CheckType.Add(savdata);
                    _mysqlbro.SaveChanges();

                    //i++;
                }

                return Json("success");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                //TempData["error"] = "User not found.";
                return Json(ex.Message);
            }

        }
    }
}
