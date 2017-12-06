using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class ExamMap : EntityTypeConfiguration<Exam>
    {
        public ExamMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ExamName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Exams");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ExamDescription).HasColumnName("ExamDescription");
            this.Property(t => t.ExamName).HasColumnName("ExamName");
            this.Property(t => t.IP).HasColumnName("IP");
        }
    }
}
