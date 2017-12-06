using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrismFourAuto.Model.Models;

namespace PrismFourAuto.Model
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // The EF database context
        private SchoolTestContext context = new SchoolTestContext();

        /// <summary>
        /// true if object is disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Gets the designation repository
        /// </summary>
        private IRepository<Staff> staffRepository;

        /////// <summary>
        /////// Gets the  milestone repository
        /////// </summary>
        ////private IRepository<Milestone> milestoneRepository;

        /////// <summary>
        /////// Gets the  milestone repository
        /////// </summary>
        ////private IRepository<Note> noteRepository;

        /////// <summary>
        /////// Gets the project repository
        /////// </summary>
        ////private IRepository<Project> projectRepository;

        /////// <summary>
        /////// Gets the project priority repository
        /////// </summary>
        ////private IRepository<ProjectPriority> projectPriorityRepository;

        /////// <summary>
        /////// Gets the project status repository
        /////// </summary>
        ////private IRepository<ProjectStatus> projectStatusRepository;

        /////// <summary>
        /////// Gets the project template repository
        /////// </summary>
        ////private IRepository<ProjectTemplate> projectTemplateRepository;

        /////// <summary>
        /////// Gets the project template milestone repository
        /////// </summary>
        ////private IRepository<ProjectTemplateMilestone> projectTemplateMilestoneRepository;

        /////// <summary>
        /////// Gets the project template task repository
        /////// </summary>
        ////private IRepository<ProjectTemplateTask> projectTemplateTaskRepository;

        /////// <summary>
        /////// Gets the project template user repository
        /////// </summary>
        ////private IRepository<ProjectTemplateUser> projectTemplateUserRepository;

        /////// <summary>
        /////// Gets the roles repository
        /////// </summary>
        ////private IRepository<Role> rolesRepository;

        /////// <summary>
        /////// Gets the tasks repository
        /////// </summary>
        ////private IRepository<Task> tasksRepository;

        /////// <summary>
        /////// Gets or sets task priority respository
        /////// </summary>
        ////private IRepository<TaskPriority> taskPriorityRepository;

        /////// <summary>
        /////// Gets the task status repository
        /////// </summary>
        ////private IRepository<TaskStatus> taskStatusRepository;

        /////// <summary>
        /////// Gets the task status update history repository
        /////// </summary>
        ////private IRepository<TaskStatusUpdateHistory> taskStatusUpdateHistoryRepository;

        /////// <summary>
        /////// Gets the users repository
        /////// </summary>
        ////private IRepository<User> usersRepository;

        /////// <summary>
        /////// Gets the user settings repository
        /////// </summary>
        ////private IRepository<UserSetting> userSettingsRepository;

        /////// <summary>
        /////// Gets the workstreams repository
        /////// </summary>
        ////private IRepository<Workstream> workstreamsRepository;

        /////// <summary>
        /////// Gets the project operation status
        /////// </summary>
        ////private IRepository<ProjectOperationStatus> projectOperationStatusRepository;

        /////// <summary>
        /////// Gets the PMC Governance form repository
        /////// </summary>
        ////private IRepository<PMCGovernanceForm> pMCGovernanceFormRepository;

        /////// <summary>
        /////// Gets the RMC Governance form repository
        /////// </summary>
        ////private IRepository<RmcGovernanceForm> rmcGovernanceFormRepository;

        /////// <summary>
        /////// Gets the PMC SRCM form repository
        /////// </summary>
        ////private IRepository<PmcSrcmForm> pmcSrcmFormRepository;

        /////// <summary>
        /////// Gets the RMC SRCM form repository
        /////// </summary>
        ////private IRepository<RmcSrcmForm> rmcSrcmFormRepository;

        /////// <summary>
        /////// Gets the activity repository
        /////// </summary>
        ////private IRepository<Activity> activityRepository;

        /////// <summary>
        /////// Gets the log read alert repository
        /////// </summary>
        ////private IRepository<LogReadAlert> logReadAlertRepository;

        /////// <summary>
        /////// Gets the project alert repository
        /////// </summary>
        ////private IRepository<ProjectAlert> projectAlertRepository;

        /////// <summary>
        /////// Gets the log read activity repository
        /////// </summary>
        ////private IRepository<LogReadActivity> logReadActivityRepository;

        /////// <summary>
        /////// Gets the project type repository
        /////// </summary>
        ////private IRepository<ProjectType> projectTypeRepository;

        /////// <summary>
        /////// Gets the supplier repository
        /////// </summary>
        ////private IRepository<Supplier> supplierRepository;

        /////// <summary>
        /////// Gets the project template form repository
        /////// </summary>
        ////private IRepository<ProjectTemplateForm> projectTemplateFormRepository;

        /////// <summary>
        /////// Gets the project activity type repository
        /////// </summary>
        ////private IRepository<ActivityType> activityTypeRepository;

        /////// <summary>
        /////// Gets the PMC Governance form repository
        /////// </summary>
        ////public IRepository<PMCGovernanceForm> PMCGovernanceFormRepository
        ////{
        ////    get
        ////    {
        ////        if (this.pMCGovernanceFormRepository == null)
        ////        {
        ////            this.pMCGovernanceFormRepository = new Repository<PMCGovernanceForm>(this.context);
        ////        }

        ////        return this.pMCGovernanceFormRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the RMC Governance form repository
        /////// </summary>
        ////public IRepository<RmcGovernanceForm> RmcGovernanceFormRepository
        ////{
        ////    get
        ////    {
        ////        if (this.rmcGovernanceFormRepository == null)
        ////        {
        ////            this.rmcGovernanceFormRepository = new Repository<RmcGovernanceForm>(this.context);
        ////        }

        ////        return this.rmcGovernanceFormRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the PMC SRCM form repository
        /////// </summary>
        ////public IRepository<PmcSrcmForm> PmcSrcmFormRepository
        ////{
        ////    get
        ////    {
        ////        if (this.pmcSrcmFormRepository == null)
        ////        {
        ////            this.pmcSrcmFormRepository = new Repository<PmcSrcmForm>(this.context);
        ////        }

        ////        return this.pmcSrcmFormRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the RMC SRCM form repository
        /////// </summary>
        ////public IRepository<RmcSrcmForm> RmcSrcmFormRepository
        ////{
        ////    get
        ////    {
        ////        if (this.rmcSrcmFormRepository == null)
        ////        {
        ////            this.rmcSrcmFormRepository = new Repository<RmcSrcmForm>(this.context);
        ////        }

        ////        return this.rmcSrcmFormRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the attachment repository
        /////// </summary>
        ////public IRepository<Attachment> AttachmentRepository
        ////{
        ////    get
        ////    {
        ////        if (this.attachmentRepository == null)
        ////        {
        ////            this.attachmentRepository = new Repository<Attachment>(this.context);
        ////        }

        ////        return this.attachmentRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the designation repository
        /////// </summary>
        ////public IRepository<Designation> DesignationRepository
        ////{
        ////    get
        ////    {
        ////        if (this.designationRepository == null)
        ////        {
        ////            this.designationRepository = new Repository<Designation>(this.context);
        ////        }

        ////        return this.designationRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the milestone repository
        /////// </summary>
        ////public IRepository<Milestone> MilestoneRepository
        ////{
        ////    get
        ////    {
        ////        if (this.milestoneRepository == null)
        ////        {
        ////            this.milestoneRepository = new Repository<Milestone>(this.context);
        ////        }

        ////        return this.milestoneRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the note repository
        /////// </summary>
        ////public IRepository<Note> NoteRepository
        ////{
        ////    get
        ////    {
        ////        if (this.noteRepository == null)
        ////        {
        ////            this.noteRepository = new Repository<Note>(this.context);
        ////        }

        ////        return this.noteRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project repository
        /////// </summary>
        ////public IRepository<Project> ProjectRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectRepository == null)
        ////        {
        ////            this.projectRepository = new Repository<Project>(this.context);
        ////        }

        ////        return this.projectRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project status repository
        /////// </summary>
        ////public IRepository<ProjectStatus> ProjectStatusRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectStatusRepository == null)
        ////        {
        ////            this.projectStatusRepository = new Repository<ProjectStatus>(this.context);
        ////        }

        ////        return this.projectStatusRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets or sets project priority repository
        /////// </summary>
        ////public IRepository<ProjectPriority> ProjectPriorityRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectPriorityRepository == null)
        ////        {
        ////            this.projectPriorityRepository = new Repository<ProjectPriority>(this.context);
        ////        }

        ////        return this.projectPriorityRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project template repository
        /////// </summary>
        ////public IRepository<ProjectTemplate> ProjectTemplateRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectTemplateRepository == null)
        ////        {
        ////            this.projectTemplateRepository = new Repository<ProjectTemplate>(this.context);
        ////        }

        ////        return this.projectTemplateRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project template milestone repository
        /////// </summary>
        ////public IRepository<ProjectTemplateMilestone> ProjectTemplateMilestoneRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectTemplateMilestoneRepository == null)
        ////        {
        ////            this.projectTemplateMilestoneRepository = new Repository<ProjectTemplateMilestone>(this.context);
        ////        }

        ////        return this.projectTemplateMilestoneRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project template task repository
        /////// </summary>
        ////public IRepository<ProjectTemplateTask> ProjectTemplateTaskRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectTemplateTaskRepository == null)
        ////        {
        ////            this.projectTemplateTaskRepository = new Repository<ProjectTemplateTask>(this.context);
        ////        }

        ////        return this.projectTemplateTaskRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the roles repository
        /////// </summary>
        ////public IRepository<Role> RolesRepository
        ////{
        ////    get
        ////    {
        ////        if (this.rolesRepository == null)
        ////        {
        ////            this.rolesRepository = new Repository<Role>(this.context);
        ////        }

        ////        return this.rolesRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the tasks repository
        /////// </summary>
        ////public IRepository<Task> TasksRepository
        ////{
        ////    get
        ////    {
        ////        if (this.tasksRepository == null)
        ////        {
        ////            this.tasksRepository = new Repository<Task>(this.context);
        ////        }

        ////        return this.tasksRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the task priority repository
        /////// </summary>
        ////public IRepository<TaskPriority> TaskPriorityRepository
        ////{
        ////    get
        ////    {
        ////        if (this.taskPriorityRepository == null)
        ////        {
        ////            this.taskPriorityRepository = new Repository<TaskPriority>(this.context);
        ////        }

        ////        return this.taskPriorityRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the task status repository
        /////// </summary>
        ////public IRepository<TaskStatus> TaskStatusRepository
        ////{
        ////    get
        ////    {
        ////        if (this.taskStatusRepository == null)
        ////        {
        ////            this.taskStatusRepository = new Repository<TaskStatus>(this.context);
        ////        }

        ////        return this.taskStatusRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the task status update history repository
        /////// </summary>
        ////public IRepository<TaskStatusUpdateHistory> TaskStatusUpdateHistoryRepository
        ////{
        ////    get
        ////    {
        ////        if (this.taskStatusUpdateHistoryRepository == null)
        ////        {
        ////            this.taskStatusUpdateHistoryRepository = new Repository<TaskStatusUpdateHistory>(this.context);
        ////        }

        ////        return this.taskStatusUpdateHistoryRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the users repository
        /////// </summary>
        ////public IRepository<User> UsersRepository
        ////{
        ////    get
        ////    {
        ////        if (this.usersRepository == null)
        ////        {
        ////            this.usersRepository = new Repository<User>(this.context);
        ////        }

        ////        return this.usersRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the user settings repository
        /////// </summary>
        ////public IRepository<UserSetting> UserSettingsRepository
        ////{
        ////    get
        ////    {
        ////        if (this.userSettingsRepository == null)
        ////        {
        ////            this.userSettingsRepository = new Repository<UserSetting>(this.context);
        ////        }

        ////        return this.userSettingsRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the workstreams repository
        /////// </summary>
        ////public IRepository<Workstream> WorkstreamsRepository
        ////{
        ////    get
        ////    {
        ////        if (this.workstreamsRepository == null)
        ////        {
        ////            this.workstreamsRepository = new Repository<Workstream>(this.context);
        ////        }

        ////        return this.workstreamsRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project operation status repository
        /////// </summary>
        ////public IRepository<ProjectOperationStatus> ProjectOperationStatusRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectOperationStatusRepository == null)
        ////        {
        ////            this.projectOperationStatusRepository = new Repository<ProjectOperationStatus>(this.context);
        ////        }

        ////        return this.projectOperationStatusRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the activity repository
        /////// </summary>
        ////public IRepository<Activity> ActivityRepository
        ////{
        ////    get
        ////    {
        ////        if (this.activityRepository == null)
        ////        {
        ////            this.activityRepository = new Repository<Activity>(this.context);
        ////        }

        ////        return this.activityRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the log read activity repository
        /////// </summary>
        ////public IRepository<LogReadActivity> LogReadActivityRepository
        ////{
        ////    get
        ////    {
        ////        if (this.logReadActivityRepository == null)
        ////        {
        ////            this.logReadActivityRepository = new Repository<LogReadActivity>(this.context);
        ////        }

        ////        return this.logReadActivityRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the log read alert repository
        /////// </summary>
        ////public IRepository<LogReadAlert> LogReadAlertRepository
        ////{
        ////    get
        ////    {
        ////        if (this.logReadAlertRepository == null)
        ////        {
        ////            this.logReadAlertRepository = new Repository<LogReadAlert>(this.context);
        ////        }

        ////        return this.logReadAlertRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project alert repository
        /////// </summary>
        ////public IRepository<ProjectAlert> ProjectAlertRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectAlertRepository == null)
        ////        {
        ////            this.projectAlertRepository = new Repository<ProjectAlert>(this.context);
        ////        }

        ////        return this.projectAlertRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project type repository
        /////// </summary>
        ////public IRepository<ProjectType> ProjectTypeRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectTypeRepository == null)
        ////        {
        ////            this.projectTypeRepository = new Repository<ProjectType>(this.context);
        ////        }

        ////        return this.projectTypeRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the supplier repository
        /////// </summary>
        ////public IRepository<Supplier> SupplierRepository
        ////{
        ////    get
        ////    {
        ////        if (this.supplierRepository == null)
        ////        {
        ////            this.supplierRepository = new Repository<Supplier>(this.context);
        ////        }

        ////        return this.supplierRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project template form repository
        /////// </summary>
        ////public IRepository<ProjectTemplateForm> ProjectTemplateFormRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectTemplateFormRepository == null)
        ////        {
        ////            this.projectTemplateFormRepository = new Repository<ProjectTemplateForm>(this.context);
        ////        }

        ////        return this.projectTemplateFormRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the project template user repository
        /////// </summary>
        ////public IRepository<ProjectTemplateUser> ProjectTemplateUserRepository
        ////{
        ////    get
        ////    {
        ////        if (this.projectTemplateUserRepository == null)
        ////        {
        ////            this.projectTemplateUserRepository = new Repository<ProjectTemplateUser>(this.context);
        ////        }

        ////        return this.projectTemplateUserRepository;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the activity type repository
        /////// </summary>
        ////public IRepository<ActivityType> ActivityTypeRepository
        ////{
        ////    get
        ////    {
        ////        if (this.activityTypeRepository == null)
        ////        {
        ////            this.activityTypeRepository = new Repository<ActivityType>(this.context);
        ////        }

        ////        return this.activityTypeRepository;
        ////    }
        ////}

        /// <summary>
        /// Gets the designation repository
        /// </summary>
        public IRepository<Staff> StaffRepository
        {
            get
            {
                if (this.staffRepository == null)
                {
                    this.staffRepository = new Repository<Staff>(this.context);
                }

                return this.staffRepository;
            }
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        /// <param name="disposing">true if disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

    }
}
