using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.EntityConfiguration
{
    internal class PaymentEntityTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.PaymentMethod).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.PaymentDate).IsRequired();
            builder.ToTable(x => x.HasCheckConstraint("Ch_Payment_Amount", "Amount>0"));
        }
    }
}
