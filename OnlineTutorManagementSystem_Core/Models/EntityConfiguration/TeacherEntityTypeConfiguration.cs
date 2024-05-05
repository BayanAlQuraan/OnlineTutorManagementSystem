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
    internal class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x=>x.PhoneNumber).IsRequired();
            builder.Property(x=>x.Age).IsRequired();

            builder.Property(x=>x.Name).HasMaxLength(256);
            builder.Property(x => x.Email).HasMaxLength(250);

            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.PhoneNumber).IsUnique(true);

            builder.ToTable(x => x.HasCheckConstraint("Ch_Teacher_Name", "len(Name)>2"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Teacher_PhoneNumber", "(len([PhoneNumber])=(10) AND ([PhoneNumber] like '079%' OR [PhoneNumber] like '078%' OR [PhoneNumber] like '077%'))"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Teacher_Email", "Email Like '%@gmail.com%' Or Email Like  '%@outlook.com%' or Email Like '%@yahoo.com%'"));

        }
    }
}
