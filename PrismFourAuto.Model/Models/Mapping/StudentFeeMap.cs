using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class StudentFeeMap : EntityTypeConfiguration<StudentFee>
    {
        public StudentFeeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("StudentFee");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.DiscountReason).HasColumnName("DiscountReason");
            this.Property(t => t.MasterFeeID).HasColumnName("MasterFeeID");
            this.Property(t => t.StudentID).HasColumnName("StudentID");
            this.Property(t => t.IP).HasColumnName("IP");

            // Relationships
            this.HasRequired(t => t.MasterFee)
                .WithMany(t => t.StudentFees)
                .HasForeignKey(d => d.MasterFeeID);
            this.HasRequired(t => t.Student)
                .WithMany(t => t.StudentFees)
                .HasForeignKey(d => d.StudentID);

        }
    }
}
