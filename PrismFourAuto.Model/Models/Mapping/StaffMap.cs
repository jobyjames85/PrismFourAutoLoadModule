using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        {
            // Primary Key
            this.HasKey(t => t.PropleID);

            // Properties
            this.Property(t => t.PropleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Staffs");
            this.Property(t => t.PropleID).HasColumnName("PropleID");
            this.Property(t => t.HighestQualification).HasColumnName("HighestQualification");
            this.Property(t => t.HireDate).HasColumnName("HireDate");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Username).HasColumnName("Username");

            // Relationships
            this.HasRequired(t => t.People)
                .WithOptional(t => t.Staff);

        }
    }
}
