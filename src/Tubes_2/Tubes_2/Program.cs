using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Tubes_2
{
    class Program    {
        [STAThread]
        static void Main(string[] args)
        {
            //udah ke sort semua, jadi ngga bingung tentang alphabetical order dalam search
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}
