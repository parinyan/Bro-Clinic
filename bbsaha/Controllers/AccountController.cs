
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
//using Brother.Models.Account;
using System.Threading.Tasks;
using System.Collections.Generic;
using bbsaha.Data;

using bbsaha.Models.Account;

namespace bbsaha.Controllers
{
    public class AccountController : Controller
    {
        //private readonly BROTHERDataContext _context;
        private readonly MysqlDBDataContext _mysqlbro;
        public AccountController( MysqlDBDataContext newbrother) {
            //_context = context;
            _mysqlbro = newbrother;
        }
        
        public IActionResult Index()
        {
            return View();
        } 
        
      

        private string Encrypt(string password)
        {
            string EncryptionKey = "5uPer@dM1n15Tr@T0r";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }
       

        [HttpPost]
        public IActionResult login(string username,string password,string ReturnUrl = null) 
        {
            try
            {
                ReturnUrl = ReturnUrl ?? Url.Content("~/");

            var pass = Encrypt(password);
            var datauser = _mysqlbro.ACC_Users.Where(ur => ur.Account == username && ur.Password == pass).FirstOrDefault();          
                ClaimsIdentity identity = null;
                bool isAuthenticated = false;
                if (datauser != null) {
                if (datauser.ManPower == true || datauser.TimeAttendance == true || datauser.Staff == true )
                {                 
                        identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "User")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuthenticated = true;
                }
                else if (datauser.SupUser == true)
                {
                 
                        identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuthenticated = true;
                }
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                //return RedirectToAction("Index", "Home");
                return Json("success");
            }
            else {                 
                    return Json("Username and Password Incorrect!");
            }
           
            }            
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                //TempData["error"] = "User not found.";
                return Json(ex.Message);
            }
        }

        public IActionResult Profile()
        {
            var user = HttpContext.User;

            // Get user information
            var userName = user.Identity.Name;
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;
            var profileData = new { userName = userName, userRole = userRole };

            // Return profile data as JSON
            return Json(profileData);
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }


        ////////
        ///

        public IActionResult Register_account() {

            return View();
        }

        [HttpPost]
        public IActionResult saveuser(acc_users users,string confirmpassword) 
        {
            try {
                var pass = Encrypt(users.Password);

                var dt_user = new acc_users
                {
                    Account = users.Account,
                    Password = pass,
                    NickNameEN = "",
                    NickNameTH = "",
                    SupUser = users.SupUser,
                    Refno = "",
                    Staff = users.Staff,
                    Manager = users.Manager,
                    ManPower = users.ManPower,
                    TimeAttendance = users.TimeAttendance,
                    Administration = users.Administration,
                    RecordDate = DateTime.Now,
                    RecordBy = "admin",
                    CreateDate = DateTime.Now,
                    CreateBy = "admin",
                    RowPointer = Guid.NewGuid()
            };

                _mysqlbro.ACC_Users.Add(dt_user);
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

        [HttpPost]
        public IActionResult saveedit(acc_users users)
        {
            try
            {
                var dt_users = _mysqlbro.ACC_Users.FirstOrDefault(ae => ae.RowPointer == users.RowPointer);
               
               
                if (users.Password != "null") 
                    dt_users.Password = Encrypt(users.Password);            
               
                dt_users.SupUser = users.SupUser;
                dt_users.ManPower = users.ManPower;
                dt_users.TimeAttendance = users.TimeAttendance;
                dt_users.Administration = users.Administration;

                _mysqlbro.Update(dt_users);
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

        public IActionResult getdatauser()
        {

            var dt_users = _mysqlbro.ACC_Users.ToList();


            return Json(dt_users);
        }

        public IActionResult getdataedit(string account)
        {

            var dt_users = _mysqlbro.ACC_Users.Where(ae => ae.Account == account).ToList();

            return Json(dt_users);
        }



        [HttpPost]
        public IActionResult dataaccountdelete(string Account) {
            try
            {
                List<string> acclist = new List<string>();
                string[] accli;

                if (Account != null)
                {
                    accli = Account.Split(',');



                    for (var i = 0; i < accli.Count(); i++)
                    {
                       acclist.Add(accli[i].ToString());

                    }

                }
                var dt_users = _mysqlbro.ACC_Users.Where(ae => acclist.Contains(ae.Account)).ToList();
                foreach(var da in dt_users)
                {

                    _mysqlbro.Remove(da);
                    _mysqlbro.SaveChanges();
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

