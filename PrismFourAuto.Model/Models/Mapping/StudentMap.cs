using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.PropleID);

            // Properties
            this.Property(t => t.PropleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FatherName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Students");
            this.Property(t => t.PropleID).HasColumnName("PropleID");
            this.Property(t => t.AppoimentDate).HasColumnName("AppoimentDate");
            this.Property(t => t.CertificateAttached).HasColumnName("CertificateAttached");
            this.Property(t => t.Donation).HasColumnName("Donation");
            this.Property(t => t.FatherName).HasColumnName("FatherName");
            this.Property(t => t.FormNumber).HasColumnName("FormNumber");
            this.Property(t => t.LastMark).HasColumnName("LastMark");
            this.Property(t => t.LastResult).HasColumnName("LastResult");
            this.Property(t => t.lastSchool).HasColumnName("lastSchool");
            this.Property(t => t.MotherName).HasColumnName("MotherName");
            this.Property(t => t.Recommendation).HasColumnName("Recommendation");
            this.Property(t => t.RecommendationDetails).HasColumnName("RecommendationDetails");
            this.Property(t => t.Sports).HasColumnName("Sports");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.TransferReason).HasColumnName("TransferReason");
            this.Property(t => t.ClassStandardID).HasColumnName("ClassStandardID");

            // Relationships
            this.HasRequired(t => t.ClassStandard)
                .WithMany(t => t.Students)
                .HasForeignKey(d => d.ClassStandardID);
            this.HasRequired(t => t.People)
                .WithOptional(t => t.Student);

        }
    }
}
