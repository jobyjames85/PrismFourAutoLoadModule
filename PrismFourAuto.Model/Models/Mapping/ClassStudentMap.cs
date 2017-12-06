using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrismFourAuto.Model.Models.Mapping
{
    public class ClassStudentMap : EntityTypeConfiguration<ClassStudent>
    {
        public ClassStudentMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClassStudents");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClassRollNo).HasColumnName("ClassRollNo");
            this.Property(t => t.ClassStandardID).HasColumnName("ClassStandardID");
            this.Property(t => t.FromYear).HasColumnName("FromYear");
            this.Property(t => t.PreiousYear).HasColumnName("PreiousYear");
            this.Property(t => t.StaffID).HasColumnName("StaffID");
            this.Property(t => t.StudentID).HasColumnName("StudentID");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.IP).HasColumnName("IP");
            this.Property(t => t.ClassStandard_ID).HasColumnName("ClassStandard_ID");
            this.Property(t => t.Student_ID).HasColumnName("Student_ID");
            this.Property(t => t.Staff_ID).HasColumnName("Staff_ID");

            // Relationships
            this.HasOptional(t => t.ClassStandard)
                .WithMany(t => t.ClassStudents)
                .HasForeignKey(d => d.ClassStandard_ID);
            this.HasOptional(t => t.Staff)
                .WithMany(t => t.ClassStudents)
                .HasForeignKey(d => d.Staff_ID);
            this.HasOptional(t => t.Student)
                .WithMany(t => t.ClassStudents)
                .HasForeignKey(d => d.Student_ID);

        }
    }
}
