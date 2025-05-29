using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlokListabaOlvasasa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> txtFajlok = new List<string>();
            string mappa = @"C:\Users\user\source\repos\WPF_Bevasarlo_Lista\fajlokListabaOlvasasa\bin\Debug";
            if (Directory.Exists(mappa))
            {
                string[] fajlok = Directory.GetFiles(mappa,"*.txt");
                foreach (var item in fajlok)
                {
                    txtFajlok.Add(Path.GetFileName(item));
                }
                foreach (var item in txtFajlok)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen mappa");
            }
            Console.ReadKey();
        }
    }
}
