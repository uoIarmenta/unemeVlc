using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UnemeVlc());

            /*
             * 
             *  
             DirectoryInfo dinfo = new DirectoryInfo(@"C:\Program Files (x86)\VideoLAN\VLC");
            // FolderBrowserDialog fdia = new FolderBrowserDialog();
            //DialogResult result = fdia.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    dinfo = new DirectoryInfo(fdia.SelectedPath);
            //}
            vlcControl1.VlcLibDirectory = dinfo;
            vlcControl2.VlcLibDirectory = dinfo;*/
        }
    }
}
