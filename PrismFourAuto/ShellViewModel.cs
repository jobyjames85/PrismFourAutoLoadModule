using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using PrismFourAuto.Common;
using PrismFourAuto.NavigationInfo;
using PrismFourAuto.SharedData;

namespace PrismFourAuto
{
    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        #region Private Fields

        private readonly IModuleCatalog catalog;
        private readonly IModuleManager moduleManager;

        private UserSnapshot _currentUser;

        #endregion Private Fields

        #region Public Constructors

        public ShellViewModel(IModuleManager moduleManager, IModuleCatalog catalog)
        {
            //IManageStaff manageStaff,CallbackLogger logger  , CallbackLogger logger
            //_manageStaff = manageStaff;
            //var item = _manageStaff.GetStaffsTest();

            //if (logger == null)
            //{
            //    throw new ArgumentNullException("logger");
            //}
            CurrentUser = new UserSnapshot("Joby James", "1", new[] { "admin", "user" });
            LoadModuleCommand = new DelegateCommand(LoadModule);
            this.moduleManager = moduleManager;
            this.catalog = catalog;

            //moduleManager.LoadModule();

            ////this._logger = logger;
            ////this._logger.Log("Test", Microsoft.Practices.Prism.Logging.Category.Info, Priority.Low);

            //LogEntry logEntry=new LogEntry(){Message="Test Hello"};
            //this._logger.Log(logEntry);
        }

        #endregion Public Constructors

        #region Public Properties

        public ICommand BackCommand { get; private set; }

        public UserSnapshot CurrentUser
        {
            get
            {
                return this._currentUser;
            }

            set
            {
                this._currentUser = value;
                this.OnPropertyChanged("CurrentUser");
            }
        }

        public ICommand LoadModuleCommand { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public static IEnumerable<Type> GetAssemblyClasses(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                yield return type;
            }
        }

        public static AuthorizeAttribute GetModuleAttribute(Type type)
        {
            AuthorizeAttribute[] moduleAttributes = GetModuleAttributes(type);
            Console.WriteLine(moduleAttributes.Length);
            if (moduleAttributes != null && moduleAttributes.Length != 0)
                return moduleAttributes[0];
            return null;
        }

        public static AuthorizeAttribute[] GetModuleAttributes(Type type)
        {
            return (AuthorizeAttribute[])type.GetCustomAttributes(typeof(AuthorizeAttribute), true);
        }

        public static bool IsAModule(Type type)
        {
            return GetModuleAttribute(type) != null;
        }

        public void LoadModule()
        {
            DirectoryModuleCatalog directoryCatalog = new DirectoryModuleCatalog() { ModulePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules") };

            var newmodules = directoryCatalog.Modules;

            ((DirectoryModuleCatalog)this.catalog).ModulePath = @".\Modules";
            ((DirectoryModuleCatalog)this.catalog).Load();
            var newModules = ((DirectoryModuleCatalog)this.catalog).Modules;

            ////var FilterModules = newModules.Where(x =>
            ////{
            ////    var attrs = x.GetType().GetCustomAttributes(typeof(AuthorizeAttribute), false).Cast<AuthorizeAttribute>().FirstOrDefault();
            ////    return attrs == null || attrs.Roles.Any(r => CurrentUser.Roles.Any(cr => cr == r));
            ////}).ToList();

            //Type type = a.GetType("Namespace.ClassName", true);

            //System.Reflection.MemberInfo info = type;

            //if(attributes[0] is ValidReleaseToApp){
            //   string value = ((ValidReleaseToApp)attributes[0]).ReleaseToApplication ;
            //   MessageBox.Show(value);

            //var loadCommon=newModules.Where(x => x.ModuleName == "CommonModule");
            //if (loadCommon != null)
            //{
            //    moduleManager.LoadModule(loadCommon.FirstOrDefault().ModuleName);
            //}
            foreach (var item1 in newModules)
            {
                Assembly a = Assembly.LoadFrom(item1.Ref);
                var isModule = GetAssemblyClasses(a);
                var modules = isModule.Where((Type type) => { return IsAModule(type); });

                var attributes = modules.Select(x => x.GetCustomAttributes(typeof(AuthorizeAttribute), false).Cast<AuthorizeAttribute>().FirstOrDefault()).Where(x => x != null);

                if (attributes.Count() > 0 && attributes.FirstOrDefault().Roles.Any(r => CurrentUser.Roles.Any(cr => cr == r)) || item1.ModuleName == "LoginModule")
                {
                    ModuleInfo info = item1;
                    moduleManager.LoadModule(item1.ModuleName);
                }
            }

            //foreach (var item in newModules.OrderBy(x => GetPrimaryOrder(x.ModuleName)).ThenBy(e => e.ModuleName))
            //{
            //    Assembly a = Assembly.LoadFrom(item.Ref);
            //    var isModule = GetAssemblyClasses(a);
            //    var modules = isModule.Where((Type type) => { return IsAModule(type); });

            //    var attributes = modules.Select(x => x.GetCustomAttributes(typeof(AuthorizeAttribute), false).Cast<AuthorizeAttribute>().FirstOrDefault()).Where(x => x != null);

            //    if (attributes.Count() > 0 && attributes.FirstOrDefault().Roles.Any(r => CurrentUser.Roles.Any(cr => cr == r)))
            //    {
            //        ModuleInfo info = item;
            //        moduleManager.LoadModule(item.ModuleName);
            //    }
            //}
            ////foreach (var module in modules)
            ////{
            ////    var authAttribute = module.GetCustomAttributes(typeof(AuthorizeAttribute), false).FirstOrDefault() as AuthorizeAttribute;
            ////    var user = authAttribute == null || authAttribute.Roles.Any(r => CurrentUser.Roles.Any(cr => cr == r));
            ////    if(user)
            ////    {
            ////        ModuleInfo info = item;
            ////        moduleManager.LoadModule(item.ModuleName);
            ////    }
            ////}

            // var user = attributes == null || attributes.Roles.Any(r => CurrentUser.Roles.Any(cr => cr == r));

            //{
            //    Ref = "Module2.dll",
            //    ModuleName = "Module2",
            //    ModuleType = "Module2.ModuleInit, Module2, Version=1.0.0.0",
            //    InitializationMode = InitializationMode.WhenAvailable,
            //};
            //    module.DependsOn.Add("Module1");
            //catalog.AddModule(module);

            //((AggregateModuleCatalog)catalog).AddCatalog((ModuleCatalog)load);
            ///((AggregateModuleCatalog)catalog).AddCatalog((ModuleCatalog));

            //this.catalog.Initialize();

            ////DynamicDirectoryModuleCatalog DDcatalog = new DynamicDirectoryModuleCatalog(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules"));
            ////DDcatalog.Load();
            ////var loadMOdules = DDcatalog.Modules;
            ////foreach (var item in loadMOdules)
            ////{
            ////    catalog.AddModule(item);
            ////}
            ////((AggregateModuleCatalog)catalog).AddCatalog((ModuleCatalog)DDcatalog);

            ////ModuleCatalog catalog = new ModuleCatalog();
            ////catalog.AddModule(typeof(ModuleZooModule));//Channel about Zoo
            ////catalog.AddModule(typeof(ModuleSportModule));//Channel about Sport
            ////catalog.AddModule(typeof(ModuleProgrammingModule));//Channel about Programming

            ////IModuleLoader moduleLoader = Container.TryResolve<IModuleLoader>();
            ////ModuleInfo[] moduleInfo = moduleEnumerator.GetStartupLoadedModules();
            ////moduleLoader.Initialize(moduleInfo);

            ////ModuleInfo module = new ModuleInfo()
            ////{
            ////    Ref = "Module2.dll",
            ////    ModuleName = "Module2",
            ////    ModuleType = "Module2.ModuleInit, Module2, Version=1.0.0.0",
            ////    InitializationMode = InitializationMode.WhenAvailable,
            ////};
            ////module.DependsOn.Add("Module1");
            //catalog.AddModule(module);
            ////
            ////moduleManager.LoadModule("Module2");

            //var load = ((DirectoryModuleCatalog)this.catalog).ModulePath = @".\Modules";
            // DirectoryModuleCatalog directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
            //((AggregateModuleCatalog)catalog).AddCatalog((ModuleCatalog)load);
        }

        #endregion Public Methods

        #region Private Methods

        private static int GetPrimaryOrder(string title)
        {
            switch (title)
            {
                case "SharedDataModule":
                    return 1;

                default:
                    return 5;
            }
        }

        #endregion Private Methods
    }

    public class UserSnapshot
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserSnapshot"/> class.
        /// </summary>
        public UserSnapshot(string name, string id, IEnumerable<string> roles)
        {
            this.FullName = name;
            this.Id = id;
            this.Roles = roles.ToArray();
        }

        #endregion Public Constructors

        #region Public Properties

        public string FullName { get; private set; }
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        /// <value>The user roles.</value>
        public string[] Roles
        {
            get;
            private set;
        }

        #endregion Public Properties
    }
}