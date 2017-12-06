using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class ScoreCardMap : EntityTypeConfiguration<ScoreCard>
    {
        public ScoreCardMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ScoreCards");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClassStandardID).HasColumnName("ClassStandardID");
            this.Property(t => t.ExamDate).HasColumnName("ExamDate");
            this.Property(t => t.ExamID).HasColumnName("ExamID");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.ReportedStaffID).HasColumnName("ReportedStaffID");
            this.Property(t => t.StudentID).HasColumnName("StudentID");
            this.Property(t => t.SubjectID).HasColumnName("SubjectID");
            this.Property(t => t.IP).HasColumnName("IP");
            this.Property(t => t.ClassSubject_ID).HasColumnName("ClassSubject_ID");

            // Relationships
            this.HasRequired(t => t.ClassStandard)
                .WithMany(t => t.ScoreCards)
                .HasForeignKey(d => d.ClassStandardID);
            this.HasOptional(t => t.ClassSubject)
                .WithMany(t => t.ScoreCards)
                .HasForeignKey(d => d.ClassSubject_ID);
            this.HasRequired(t => t.Exam)
                .WithMany(t => t.ScoreCards)
                .HasForeignKey(d => d.ExamID);
            this.HasRequired(t => t.Staff)
                .WithMany(t => t.ScoreCards)
                .HasForeignKey(d => d.ReportedStaffID);
            this.HasRequired(t => t.Student)
                .WithMany(t => t.ScoreCards)
                .HasForeignKey(d => d.StudentID);
            this.HasRequired(t => t.Subject)
                .WithMany(t => t.ScoreCards)
                .HasForeignKey(d => d.SubjectID);

        }
    }
}
