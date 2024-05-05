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
    internal class EvaluationEntityTypeConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("Evaluations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.EvaluationDate).IsRequired();
            builder.Property(x => x.Score).IsRequired();
            builder.Property(x => x.Feedback).IsRequired();

            builder.Property(x => x.Feedback).HasMaxLength(128);

            builder.ToTable(x => x.HasCheckConstraint("Ch_Evaluation_Feedback", "len(Feedback)>5"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Evaluation_Feedback", "QuzziesMark<=25"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Evaluation_Feedback", "AttendanceMark<=25"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Evaluation_Feedback", "ParticipantsMark<=25"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Evaluation_Feedback", "AssignmentsMark<=25"));
            builder.ToTable(x => x.HasCheckConstraint("Ch_Evaluation_Feedback", "score>0"));
        }
    }
}
