using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AtBahcesi0._1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        public static double y=0;
        public static string path = Path.GetFullPath(Environment.CurrentDirectory);
        public static string databasename = "AtBahcesi0.1.mdf";
        public static int cost(DateTime a,DateTime b,int c)
        {
            TimeSpan fark = a - b;
            

            double Cost = (fark.Days * 120*c)/(7);
            y = Cost;
            return fark.Days;
        }
    }
}
