using Caliburn.Micro;
using PanuonSetup.Log;
using PanuonSetup.Pack;
using PanuonSetup.Project;
using PanuonSetup.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace PanuonSetup
{
    public class AppBootstrapper : BootstrapperBase
    {
        #region Fields
        private CompositionContainer _container;

        private IWindowManager _windowManager;

        private IEventAggregator _eventAggregator;

        private ILogger _logger;

        private IThemeManager _themeManager;

        private ISetupEngine _setupEngine;

        private IProjectManager _projectManager;
        #endregion

        #region Ctor
        public AppBootstrapper()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void Configure()
        {
            var catalog = new AggregateCatalog(
                    AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>());
            //添加MEF自动发现包含的程序集。
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ILogger).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IThemeManager).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ISetupEngine).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IProjectManager).Assembly));

            var batch = new CompositionBatch();

            _container = new CompositionContainer(catalog);
            batch.AddExportedValue(_container);

            //注入控制反转
            _windowManager = new WindowManager();
            batch.AddExportedValue(_windowManager);
            _eventAggregator = new EventAggregator();
            batch.AddExportedValue(_eventAggregator);
            _logger = _container.GetExportedValue<ILogger>();
            batch.AddExportedValue(_logger);
            _themeManager = _container.GetExportedValue<IThemeManager>();
            batch.AddExportedValue(_themeManager);
            _setupEngine = _container.GetExportedValue<ISetupEngine>();
            batch.AddExportedValue(_setupEngine);
            _projectManager = _container.GetExportedValue<IProjectManager>();
            batch.AddExportedValue(_projectManager);

            _container.Compose(batch);
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            base.OnUnhandledException(sender, e);
            _logger.Error(e.Exception, "发生了未经捕获的异常。");
            MessageBox.Show(e.Exception.Message);
#if !(DEBUG)
            e.Handled = true;
#endif
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Any())
            {
                return exports.First();
            }
            
            throw new Exception($"找不到实例 {contract}。");
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = new List<Assembly>() { Assembly.GetExecutingAssembly() };
            return assemblies;
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }
        #endregion
    }
}
