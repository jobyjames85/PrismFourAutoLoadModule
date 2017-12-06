using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using DevExpress.Xpf.NavBar;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto
{
    public class Bootstrapper : UnityBootstrapper
    {
        #region Public Constructors

        public Bootstrapper()
        {
            //var builder = new ConfigurationSourceBuilder();
            //builder.ConfigureLogging()
            //    .WithOptions
            //    .DoNotRevertImpersonation()
            //    .LogToCategoryNamed("Debug")
            //    .SendTo.FlatFile("Basic Log File")
            //    .FormatWith(new FormatterBuilder()
            //                    .TextFormatterNamed("Text Formatter")
            //                    .UsingTemplate(
            //                        "Timestamp: {timestamp}{newline}Message: {message}{newline}Category: {category}{newline}"))
            //    .ToFile("core.log")
            //    .SendTo.RollingFile("Rolling Log files")
            //    .RollAfterSize(1024)
            //    .ToFile("RollingTest.log")
            //    .LogToCategoryNamed("General")
            //        .WithOptions.SetAsDefaultCategory()
            //        .SendTo.SharedListenerNamed("Basic Log File");

            //var configSource = new DictionaryConfigurationSource();
            //builder.UpdateConfigurationWithReplace(configSource);
            //EnterpriseLibraryContainer.Current = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);
            ////Logger.SetLogWriter(new LogWriterFactory().Create());
            ////LogEntry entry = new LogEntry();
            ////entry.Message = "I am logging";
            ////Logger.Write(entry);
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IEventAggregator, EventAggregator>();
            this.Container.RegisterType<object, MainFrameNavigate>("MainFrameNavigate");
            //this.Container.RegisterInstance<EnterpriseLibraryLoggerAdapter>(this._logger);
            //this.Container.RegisterType<object, MainFrameNavigate>("MainFrameNavigate");
            //this.Container.RegisterInstance<CallbackLogger>(this.callbackLogger);
            // register the new navigation service that uses synchronous navigation confirmation instead of the async confirmation.

            ////this.RegisterTypeIfMissing(typeof(IModuleTracker), typeof(ModuleTracker), true);

            ////RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true);
            ////RegisterTypeIfMissing(typeof(IModuleInitializer), typeof(ModuleInitializer), true);
            ////RegisterTypeIfMissing(typeof(IModuleManager), typeof(ModuleManager), true);
            ////RegisterTypeIfMissing(typeof(RegionAdapterMappings), typeof(RegionAdapterMappings), true);
            ////RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
            ////RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);
            ////RegisterTypeIfMissing(typeof(IRegionViewRegistry), typeof(RegionViewRegistry), true);
            ////RegisterTypeIfMissing(typeof(IRegionBehaviorFactory), typeof(RegionBehaviorFactory), true);
            ////RegisterTypeIfMissing(typeof(IRegionNavigationJournalEntry), typeof(RegionNavigationJournalEntry), false);
            ////RegisterTypeIfMissing(typeof(IRegionNavigationJournal), typeof(RegionNavigationJournal), false);
            ////RegisterTypeIfMissing(typeof(IRegionNavigationService), typeof(RegionNavigationService), false);
            ////RegisterTypeIfMissing(typeof(IRegionNavigationContentLoader), typeof(Microsoft.Practices.Prism.UnityExtensions.Regions.UnityRegionNavigationContentLoader), true);
        }

        protected override Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            return base.ConfigureDefaultRegionBehaviors();
        }

        // Just Adding project Module in the ModuleCatalog
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ////ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            ////moduleCatalog.AddModule(typeof(StaffModule));
            ////moduleCatalog.AddModule(typeof(AccountModule));

            // Dynamic dll loading and set Modules ConfigureModuleCatalog ,CreateModuleCatalog,InitializeModules
            // ((DirectoryModuleCatalog)this.ModuleCatalog).ModulePath = @".\Modules";

            ////// Only AggregateModuleCatalog enable in CreateModuleCatalog Method
            ////Type moduleAType = typeof(AccountModule);
            ////ModuleCatalog.AddModule(new ModuleInfo(moduleAType.Name, moduleAType.AssemblyQualifiedName));

            ////// Module C is defined in the code.
            ////Type moduleCType = typeof(StaffModule);
            ////ModuleCatalog.AddModule(new ModuleInfo()
            ////{
            ////    ModuleName = moduleCType.Name,
            ////    ModuleType = moduleCType.AssemblyQualifiedName,
            ////    InitializationMode = InitializationMode.OnDemand
            ////});

            ////// Module B and Module D are copied to a directory as part of a post-build step.
            ////// These modules are not referenced in the project and are discovered by inspecting a directory.
            ////// Both projects have a post-build step to copy themselves into that directory.
            ////DirectoryModuleCatalog directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
            ////((AggregateModuleCatalog)ModuleCatalog).AddCatalog(directoryCatalog);

            ////// Module E and Module F are defined in configuration.
            ////ConfigurationModuleCatalog configurationCatalog = new ConfigurationModuleCatalog();
            ////((AggregateModuleCatalog)ModuleCatalog).AddCatalog(configurationCatalog);
        }

        protected override Microsoft.Practices.Prism.Regions.RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            var regionBehaviorFactory = ServiceLocator.Current.GetInstance<IRegionBehaviorFactory>();
            mappings.RegisterMapping(typeof(NavBarControl), new NavBarControlAdapter.NavBarControlAdapter(regionBehaviorFactory));
            return mappings;
        }

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();
        }

        //Initial IUnity Container
        protected override IUnityContainer CreateContainer()
        {
            return base.CreateContainer();
        }

        // mainly using for dll Dynamic Loading example also Added
        protected override IModuleCatalog CreateModuleCatalog()
        {
            ////var moduleCatalog = new DirectoryModuleCatalog();
            ////moduleCatalog.ModulePath = "Modules";
            ////return moduleCatalog;

            // Dynamic dll loading and set Modules ConfigureModuleCatalog ,CreateModuleCatalog,InitializeModules
            return new DirectoryModuleCatalog();

            //not working return ModuleCatalog.CreateFromXaml(new Uri("/MyProject;component/ModulesCatalog.xaml", UriKind.Relative));

            //// Nothing to do any thing in InitializeModules and ConfigureModuleCatalog
            //DynamicDirectoryModuleCatalog catalog = new DynamicDirectoryModuleCatalog(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules"));
            //return catalog;

            ////// Only AggregateModuleCatalog enable in CreateModuleCatalog Method
            /// return new AggregateModuleCatalog();

            //Default
            //return base.CreateModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            //// this.Container.RegisterType()
            IUnityContainer container = this.Container;
            container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());

            container.RegisterType<IShellViewModel, ShellViewModel>();

            ////return this.Container.TryResolve<ShellView>();
            return ServiceLocator.Current.GetInstance<ShellView>();
        }

        //Initialize the Modules
        protected override void InitializeModules()
        {
            // Dynamic dll loading and set Modules ConfigureModuleCatalog ,CreateModuleCatalog,InitializeModules
            // [ModuleDependency("NavigationModule")]
            //base.InitializeModules();

            //IModule moduleB = Container.Resolve<NavigationModule>();
            //moduleB.Initialize();

            //IModule moduleA = Container.Resolve<StaffModule>();
            //moduleA.Initialize();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        #endregion Protected Methods

        //protected override Microsoft.Practices.Prism.Logging.ILoggerFacade CreateLogger()
        //{
        //    return this._logger;
        //}
        //private static DictionaryConfigurationSource ConfigureLoggingLocationForClickOnce()
        //{
        //    string logFileName = @".\Logs\Client.log";
        //    if (ApplicationDeployment.IsNetworkDeployed)
        //    {
        //        logFileName = ApplicationDeployment.CurrentDeployment.DataDirectory + @"\Logs\Client.log";
        //    }

        //    //Create the config builder for the Fluent APIvar
        //    var source = new FileConfigurationSource(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        //    ConfigurationSourceBuilder configBuilder = new ConfigurationSourceBuilder();

        //    //Get the existing logging config section
        //    var logginConfigurationSection = (LoggingSettings)source.GetSection("loggingConfiguration");

        //    logginConfigurationSection.RevertImpersonation = false;
        //    var _rollingFileListener = new RollingFlatFileTraceListenerData("Rolling Flat File Trace Listener", logFileName, "", "",
        //             20000, "MM/dd/yyyy", RollFileExistsBehavior.Increment,
        //             RollInterval.Day, TraceOptions.Callstack | TraceOptions.None,
        //             "Text Formatter", SourceLevels.Information);

        //    _rollingFileListener.MaxArchivedFiles = 1;

        //    //Add trace listener to current config
        //    logginConfigurationSection.TraceListeners.Add(_rollingFileListener);

        //    //Configure the category source section of config for rolling file
        //    var _rollingFileCategorySource = logginConfigurationSection.TraceSources.Get("General");

        //    //Must be named exactly the same as the flat file trace listener above.
        //    _rollingFileCategorySource.TraceListeners.Add(new TraceListenerReferenceData("Rolling Flat File Trace Listener"));

        //    //Add category source information to current config
        //    logginConfigurationSection.TraceSources.Add(_rollingFileCategorySource);

        //    //Add the loggingConfiguration section to the config.
        //    configBuilder.AddSection("loggingConfiguration", logginConfigurationSection);

        //    //Required code to update the EntLib Configuration with settings set above.
        //    var configSource = new DictionaryConfigurationSource();
        //    configBuilder.UpdateConfigurationWithReplace(configSource);

        //    //Set the Enterprise Library Container for the inner workings of EntLib to use when logging
        //    EnterpriseLibraryContainer.Current = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);

        //    return configSource;
        //}
    }
}