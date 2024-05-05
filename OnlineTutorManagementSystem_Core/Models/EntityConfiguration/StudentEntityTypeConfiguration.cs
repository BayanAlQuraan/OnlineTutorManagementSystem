using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.EntityConfiguration
{
    internal class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Age).IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(128);
            builder.Property(x => x.LastName).HasMaxLength(128);
            builder.Property(x => x.Email).HasMaxLength(250);

            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.PhoneNumber).IsUnique(true);

            builder.ToTable(x => x.HasCheckConstraint("Ch_Student_FirstName", "len(FirstName)>2"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Student_LastName", "len(LastName)>2"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Student_PhoneNumber", "(len([PhoneNumber])=(10) AND ([PhoneNumber] like '079%' OR [PhoneNumber] like '078%' OR [PhoneNumber] like '077%'))"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Student_Email", "Email Like '%@gmail.com%' Or Email Like  '%@outlook.com%' or Email Like '%@yahoo.com%'"));

        }
    }
}
