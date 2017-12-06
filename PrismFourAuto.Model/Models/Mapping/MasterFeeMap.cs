using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class MasterFeeMap : EntityTypeConfiguration<MasterFee>
    {
        public MasterFeeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.FeeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MasterFees");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.FeeName).HasColumnName("FeeName");
            this.Property(t => t.IP).HasColumnName("IP");
        }
    }
}
