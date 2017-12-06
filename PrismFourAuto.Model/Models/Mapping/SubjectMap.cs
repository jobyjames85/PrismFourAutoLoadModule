using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class SubjectMap : EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SubjectName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Subjects");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SubjectDescription).HasColumnName("SubjectDescription");
            this.Property(t => t.SubjectName).HasColumnName("SubjectName");
            this.Property(t => t.IP).HasColumnName("IP");
            this.Property(t => t.Subject_ID).HasColumnName("Subject_ID");

            // Relationships
            this.HasOptional(t => t.Subject1)
                .WithMany(t => t.Subjects1)
                .HasForeignKey(d => d.Subject_ID);

        }
    }
}
