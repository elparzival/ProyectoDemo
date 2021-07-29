using System;
using System.IO;
using Services;
using Newtonsoft.Json;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.OutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}Configuracion");
            string path = Helper.OutputDir.ToString() + @"\config.json";
            if (System.IO.File.Exists(path))
            {
                using (StreamReader jsonStream = File.OpenText(path))
                {
                    var json = jsonStream.ReadToEnd();

                    ParametrosConn s = JsonConvert.DeserializeObject<ParametrosConn>(json);
                    ParametrosConn._sqlserver = s.sqlserver;
                    ParametrosConn._mysql = s.mysql;
                }
            }
            else
            {
                Console.WriteLine("No existe archivo de configuración para las inyecciones de dependencias");
            }
        }
    }
}
