using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Autofac;
using Autofac.Core;
using Hunger.DependencyEngine.Engine.Autofac;
using Autofac.Integration.Mef;

namespace Hunger.DependencyEngine.Engine.MEF
{
    //https://kalcik.net/2014/02/09/cooperation-between-the-autofac-and-the-microsoft-extensibility-framework/    
    public class Bootstrapper : IBootstrapper
    {
        [ImportMany(typeof(IModule))]
        private IEnumerable<IModule> _pluginsAutofacModules;
        private AggregateCatalog _aggregateCatalog;
        public IContainer AutofacContainer { get; private set; }

        public Bootstrapper(IEnumerable<string> pluginPaths)
        {
            IEnumerable<DirectoryCatalog> directoryPluginCatalogs =
                pluginPaths.Select(pluginPath => new DirectoryCatalog(pluginPath));

            _aggregateCatalog = new AggregateCatalog(directoryPluginCatalogs);
        }

        public void InitializeApplication()
        {
            InitializeMex();
            InitializeAutofac();
        }

        private void InitializeMex()
        {
            var compositionContainer = new CompositionContainer(_aggregateCatalog);
            compositionContainer.ComposeParts(this);
        }

        private void InitializeAutofac()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            RegisterPluginsAutofacModules(autofacContainerBuilder);

            autofacContainerBuilder.RegisterModule(new AutofacModule());
            //autofacContainerBuilder.RegisterComposablePartCatalog(_aggregateCatalog, new TypedService(typeof(IPluginBusinessLayer)));
            AutofacContainer = autofacContainerBuilder.Build();
        }

        private void RegisterPluginsAutofacModules(ContainerBuilder autofacContainerBuilder)
        {
            foreach (var pluginAutofacModule in _pluginsAutofacModules)
            {
                autofacContainerBuilder.RegisterModule(pluginAutofacModule);
            }
        }
    }
}
