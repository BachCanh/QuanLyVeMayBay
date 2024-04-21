using QuanLyVeMayBay;
using QuanLyVeMayBay.Properties;
using System.Runtime.Intrinsics.X86;

namespace VeMayBay
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FLogin());
        }
    }
}