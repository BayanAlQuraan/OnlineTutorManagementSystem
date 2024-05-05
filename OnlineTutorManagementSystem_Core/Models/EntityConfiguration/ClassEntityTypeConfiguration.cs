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
    internal class ClassEntityTypeConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.NumberOfStudents).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Address).HasMaxLength(128);

            builder.ToTable(x => x.HasCheckConstraint("Ch_Class_Name", "len(Name)>2"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Class_Time", "StartTime<EndTime"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Class_Address", "len(Address)>2"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Class_Capacity", "Capacity>0"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Class_NumberOfStudents", "Capacity>=NumberOfStudents"));

           





        }
    }
}
