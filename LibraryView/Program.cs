using LibraryBusinessLogic.BusinessLogic;
using LibraryBusinessLogic.Interfaces;
using LibraryDatabaseImplement.Implementations;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace LibraryView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IBookStorage, BookStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAuthorStorage, AuthorStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<BookLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AuthorLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}