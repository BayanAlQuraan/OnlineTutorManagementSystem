﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineTutorManagmentSystem_Core.Context;

#nullable disable

namespace OnlineTutorManagementSystem_Core.Migrations
{
    [DbContext(typeof(OnlineTutorManagementSystemDbContext))]
    [Migration("20240505043111_Intial")]
    partial class Intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Certificates", null, t =>
                        {
                            t.HasCheckConstraint("Ch_Certificatet_Description", "len(Description)>5");

                            t.HasCheckConstraint("Ch_Certificatet_Name", "len(Name)>5");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Classes", null, t =>
                        {
                            t.HasCheckConstraint("Ch_Class_Address", "len(Address)>2");

                            t.HasCheckConstraint("Ch_Class_Capacity", "Capacity>0");

                            t.HasCheckConstraint("Ch_Class_Name", "len(Name)>2");

                            t.HasCheckConstraint("Ch_Class_NumberOfStudents", "Capacity>=NumberOfStudents");

                            t.HasCheckConstraint("Ch_Class_Time", "StartTime<EndTime");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AssignmentsMark")
                        .HasColumnType("float");

                    b.Property<double>("AttendanceMark")
                        .HasColumnType("float");

                    b.Property<DateTime>("EvaluationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<double>("ParticipantsMark")
                        .HasColumnType("float");

                    b.Property<double>("QuzziesMark")
                        .HasColumnType("float");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Evaluations", null, t =>
                        {
                            t.HasCheckConstraint("Ch_Evaluation_Feedback", "score>0");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Invoice", null, t =>
                        {
                            t.HasCheckConstraint("Ch_Invoice_Amount", "Amount>0");

                            t.HasCheckConstraint("Ch_Invoice_Details", "len(Details)>0");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId")
                        .IsUnique();

                    b.HasIndex("StudentId");

                    b.ToTable("Payments", null, t =>
                        {
                            t.HasCheckConstraint("Ch_Payment_Amount", "Amount>0");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Students", null, t =>
                        {
                            t.HasCheckConstraint("CH_Student_Email", "Email Like '%@gmail.com%' Or Email Like  '%@outlook.com%' or Email Like '%@yahoo.com%'");

                            t.HasCheckConstraint("Ch_Student_FirstName", "len(FirstName)>2");

                            t.HasCheckConstraint("Ch_Student_LastName", "len(LastName)>2");

                            t.HasCheckConstraint("Ch_Student_PhoneNumber", "(len([PhoneNumber])=(10) AND ([PhoneNumber] like '079%' OR [PhoneNumber] like '078%' OR [PhoneNumber] like '077%'))");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.StudentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClasses", (string)null);
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects", null, t =>
                        {
                            t.HasCheckConstraint("Ch_Subject_Name", "len(Name)>2");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Teachers", null, t =>
                        {
                            t.HasCheckConstraint("CH_Teacher_Email", "Email Like '%@gmail.com%' Or Email Like  '%@outlook.com%' or Email Like '%@yahoo.com%'");

                            t.HasCheckConstraint("Ch_Teacher_Name", "len(Name)>2");

                            t.HasCheckConstraint("Ch_Teacher_PhoneNumber", "(len([PhoneNumber])=(10) AND ([PhoneNumber] like '079%' OR [PhoneNumber] like '078%' OR [PhoneNumber] like '077%'))");
                        });
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Certificate", b =>
                {
                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Student", "Student")
                        .WithMany("Certificates")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Subject", "Subject")
                        .WithMany("Certificates")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Class", b =>
                {
                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Evaluation", b =>
                {
                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Student", "Student")
                        .WithMany("Evaluations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Teacher", "Teacher")
                        .WithMany("Evaluations")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Invoice", b =>
                {
                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Student", "Student")
                        .WithMany("Invoices")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Payment", b =>
                {
                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Invoice", "Invoice")
                        .WithOne("Payment")
                        .HasForeignKey("OnlineTutorManagmentSystem_Core.Models.Entities.Payment", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Student", null)
                        .WithMany("Payments")
                        .HasForeignKey("StudentId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.StudentClass", b =>
                {
                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Student", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Subject", b =>
                {
                    b.HasOne("OnlineTutorManagmentSystem_Core.Models.Entities.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Class", b =>
                {
                    b.Navigation("StudentClasses");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Invoice", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Student", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Evaluations");

                    b.Navigation("Invoices");

                    b.Navigation("Payments");

                    b.Navigation("StudentClasses");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Subject", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Classes");
                });

            modelBuilder.Entity("OnlineTutorManagmentSystem_Core.Models.Entities.Teacher", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
