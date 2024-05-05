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
    internal class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Details).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.Details).HasMaxLength(500);

            builder.ToTable(x => x.HasCheckConstraint("Ch_Invoice_Amount", "Amount>0"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Invoice_Details", "len(Details)>0"));
            builder.HasOne(i => i.Payment).WithOne(p => p.Invoice).HasForeignKey<Payment>(p => p.InvoiceId);

        }
    }
}
