using System;
using System.IO;
using System.Net;
namespace LogConvert {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Insira uma URL com o arquivo de log: ");
            string url = Console.ReadLine ();

            Console.Write ("Entre com o diretorio de destino do arquivo(ex: output/file.csv): ");
            string path = Console.ReadLine ();

            WebClient webCliente = new WebClient ();
            Stream stream = webCliente.OpenRead (url);
            StreamReader reader = new StreamReader (stream);
            StreamWriter newFile;

            if (Directory.Exists (Path.GetDirectoryName (path))) {
                newFile = new StreamWriter (path);

            } else {
                DirectoryInfo dir = Directory.CreateDirectory (Path.GetDirectoryName (path));
                newFile = new StreamWriter (path);
            }

            string line;
            while ((line = reader.ReadLine ()) != null) {
                Log log = new Log (line);
                newFile.WriteLine (log.WriteLine ());
            }

            newFile.Close ();
            Console.WriteLine ("Log obtido com sucesso! Pressione qualquer tecla para sair.");
            Console.ReadLine ();
        }
    }
}