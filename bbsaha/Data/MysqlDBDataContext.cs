
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

using bbsaha.Models;
using bbsaha.Models.Company;
using bbsaha.Models.Invoice;
using bbsaha.Models.Account;
using bbsaha.Models.Certificate;
using bbsaha.Models.Center;
using bbsaha.Models.patient;
using bbsaha.Models.Center.View;
using static bbsaha.Controllers.PatientController;

namespace bbsaha.Data
{
    public class MysqlDBDataContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public MysqlDBDataContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public MysqlDBDataContext(DbContextOptions<MysqlDBDataContext> options)
          : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to mysql with connection string from app settings
        //    var connectionString = Configuration.GetConnectionString("MysqlDBbbsaha");
        //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //}

      
        public DbSet<cus_company> CUS_Company { get; set; }
        public DbSet<inv_invoice> INV_Invoice { get; set; }
        public DbSet<inv_detaillist> INV_Detaillist { get; set; }
        public DbSet<acc_users> ACC_Users { get; set; }
        public DbSet<cer_medical> CER_Medical { get; set; }
        public DbSet<cer_header> CER_Header { get; set; }
        public DbSet<cen_typehealthcheck> CEN_TypeHealthCheck { get; set; }
        public DbSet<cen_typepayment> CEN_TypePayment { get; set; }
        public DbSet<cn_detail> CN_Detail { get; set; }
        public DbSet<cn_patient> CN_Patient { get; set; }
        public DbSet<cn_sales> CN_Sales { get; set; }
        public DbSet<cen_provinceth> CEN_ProvinceTH { get; set; }
        public DbSet<cen_districtth> CEN_DistrictTH { get; set; }
        public DbSet<cen_subdistrictth> CEN_SubDistrictTH { get; set; }
        public DbSet<cen_postcode> CEN_Postcode { get; set; }
        public DbSet<cen_perreceive> CEN_PerReceive { get; set; }
        public DbSet<pay_cash> PAY_Cash { get; set; }
        public DbSet<cus_agency> CUS_Agency { get; set; }
       
        public DbSet<cen_typelabs> CEN_TypeLabs { get; set; }
        public DbSet<cn_checktype> CN_CheckType { get; set; }
        public DbSet<cn_typehealthmain> CN_Typehealthmain { get; set; }

        public DbSet<DataLab> DataLab { get; set; }
        public DbSet<DataPayment> DataPayment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataLab>().HasNoKey();
            modelBuilder.Entity<DataPayment>().HasNoKey();
        }

    }
}
