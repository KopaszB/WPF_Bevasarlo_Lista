using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlKonyvtarbol
{
    class Program
    {
        static void Main(string[] args)
        {
            string mappa = @"C:\Users\user\source\repos\WPF_Bevasarlo_Lista\fajlKonyvtarbol\bin\Debug";
            List<string> fajlNevek = new List<string>();
            if (Directory.Exists(mappa))
            {
                string[] txtFajlok = Directory.GetFiles(mappa, "*.txt");
                foreach (var item in txtFajlok)
                {
                    fajlNevek.Add(Path.GetFileName(item));
                }
                foreach (var item in fajlNevek)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("A megadott mappa nem létezik!");
            }

            
            Console.ReadKey();
        }
    }
}
