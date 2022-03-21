using AbstractFactoryBusinessLogic.BusinessLogic;
using AbstructFactoryContracts.BusinessLogicContracts;
using AbstructFactoryContracts.StoragesContracts;
using AbstractFactoryFileImplement;
using AbstractFactoryDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;


namespace AbstructFactoryView
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ApplicationExit += ApplicationExit;
            AppDomain.CurrentDomain.UnhandledException += (o, e) => { if (e.IsTerminating) ApplicationExit(null, null); };
            Application.ThreadException += (o, e) => { Application.Exit(); };

            Application.Run(Container.Resolve<FormMain>());
        }
        private static void ApplicationExit(object sender, EventArgs e)
        {
            FileDataListSingleton.SaveAll();//need to cut
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IEngineStorage,EngineStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDetailStorage, DetailStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDetailLogic, DetailLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEngineLogic, EngineLogic>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }

    }
}