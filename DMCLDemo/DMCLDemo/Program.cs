using dmcldll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DMCLDemo
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

            // Initalise some Documentum stuff here 
            int resint = DMCL.dmAPIInit();

            Application.Run(new Form1());
        }
    }
}
