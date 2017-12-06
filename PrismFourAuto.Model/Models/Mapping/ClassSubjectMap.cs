using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class ClassSubjectMap : EntityTypeConfiguration<ClassSubject>
    {
        public ClassSubjectMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClassSubject");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClassStandardID).HasColumnName("ClassStandardID");
            this.Property(t => t.StaffID).HasColumnName("StaffID");
            this.Property(t => t.SubjectID).HasColumnName("SubjectID");
            this.Property(t => t.IP).HasColumnName("IP");

            // Relationships
            this.HasRequired(t => t.ClassStandard)
                .WithMany(t => t.ClassSubjects)
                .HasForeignKey(d => d.ClassStandardID);
            this.HasRequired(t => t.Staff)
                .WithMany(t => t.ClassSubjects)
                .HasForeignKey(d => d.StaffID);
            this.HasRequired(t => t.Subject)
                .WithMany(t => t.ClassSubjects)
                .HasForeignKey(d => d.SubjectID);

        }
    }
}
