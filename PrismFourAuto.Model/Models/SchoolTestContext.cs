using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PrismFourAuto.Model.Models.Mapping;

namespace PrismFourAuto.Model.Models
{
    public partial class SchoolTestContext : DbContext
    {
        static SchoolTestContext()
        {
            Database.SetInitializer<SchoolTestContext>(null);
        }

        public SchoolTestContext()
            : base("Name=SchoolTestContext")
        {
        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ClassStandard> ClassStandards { get; set; }
        public DbSet<ClassStudent> ClassStudents { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<MasterFee> MasterFees { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<ScoreCard> ScoreCards { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StudentFee> StudentFees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AttendanceMap());
            modelBuilder.Configurations.Add(new ClassStandardMap());
            modelBuilder.Configurations.Add(new ClassStudentMap());
            modelBuilder.Configurations.Add(new ClassSubjectMap());
            modelBuilder.Configurations.Add(new ExamMap());
            modelBuilder.Configurations.Add(new MasterFeeMap());
            modelBuilder.Configurations.Add(new PeopleMap());
            modelBuilder.Configurations.Add(new ScoreCardMap());
            modelBuilder.Configurations.Add(new StaffMap());
            modelBuilder.Configurations.Add(new StudentFeeMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new SubjectMap());
        }
    }
}
