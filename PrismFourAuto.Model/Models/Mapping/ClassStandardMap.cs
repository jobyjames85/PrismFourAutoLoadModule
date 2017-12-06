using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class ClassStandardMap : EntityTypeConfiguration<ClassStandard>
    {
        public ClassStandardMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClassStandards");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StandardDivision).HasColumnName("StandardDivision");
            this.Property(t => t.StandardName).HasColumnName("StandardName");
            this.Property(t => t.IP).HasColumnName("IP");
        }
    }
}
