using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class AttendanceMap : EntityTypeConfiguration<Attendance>
    {
        public AttendanceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.LeaveReason)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Attendances");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.LeaveDate).HasColumnName("LeaveDate");
            this.Property(t => t.LeaveReason).HasColumnName("LeaveReason");
            this.Property(t => t.LeaveType).HasColumnName("LeaveType");
            this.Property(t => t.StaffID).HasColumnName("StaffID");
            this.Property(t => t.StudentID).HasColumnName("StudentID");
            this.Property(t => t.IP).HasColumnName("IP");

            // Relationships
            this.HasRequired(t => t.Staff)
                .WithMany(t => t.Attendances)
                .HasForeignKey(d => d.StaffID);
            this.HasRequired(t => t.Student)
                .WithMany(t => t.Attendances)
                .HasForeignKey(d => d.StudentID);

        }
    }
}
