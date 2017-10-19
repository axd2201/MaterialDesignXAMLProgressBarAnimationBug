using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXAMLProgressBug
{
    using System.Windows;
    using System.Windows.Threading;

    using Caliburn.Micro;

    using MaterialDesignXAMLProgressBug.ViewModels;

    public class Bootstrapper : BootstrapperBase
    {
        #region Constructors and Destructors

        public Bootstrapper()
        {
            //Initializes WPF
            this.Initialize();
        }

        #endregion

        #region Methods

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //Open the Login Window
            this.DisplayRootViewFor<MainViewModel>();
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.ToString());
        }

        #endregion
    }
}
