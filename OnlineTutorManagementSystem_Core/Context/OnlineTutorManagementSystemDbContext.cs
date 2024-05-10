using Microsoft.EntityFrameworkCore;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using OnlineTutorManagmentSystem_Core.Models.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Context
{
    public class OnlineTutorManagementSystemDbContext : DbContext
    {
        public OnlineTutorManagementSystemDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClassEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentClassEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateEntityTypeConfiguration());
        }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }


    }

}
