using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class PeopleMap : EntityTypeConfiguration<People>
    {
        public PeopleMap()
        {
            // Primary Key
            this.HasKey(t => t.PropleID);

            // Properties
            this.Property(t => t.Address)
                .IsRequired();

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Peoples");
            this.Property(t => t.PropleID).HasColumnName("PropleID");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Cast).HasColumnName("Cast");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.EmailID).HasColumnName("EmailID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.Religion).HasColumnName("Religion");
            this.Property(t => t.Sex).HasColumnName("Sex");
        }
    }
}
