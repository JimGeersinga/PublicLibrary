using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PublicLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LibraryService LibraryService { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            LibraryService = new LibraryService();
        }
    }
}
