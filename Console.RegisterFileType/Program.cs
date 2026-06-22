//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Lifeprojects.de">
//     Class: Program
//     Copyright © Lifeprojects.de 2026
// </copyright>
// <Template>
// 	Version 3.0.2026.2, 15.04.2026
// </Template>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>22.06.2026 14:02:22</date>
//
// <summary>
// Konsolen Applikation mit Menü
// </summary>
//-----------------------------------------------------------------------

namespace Console.RegisterFileType
{
    /* Imports from NET Framework */
    using System;

    using Console.RegisterFileType.Features;

    public class Program
    {
        public Program()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
        }

        private static void Main(string[] args)
        {
            if (args.Contains("--register"))
            {
                if (FileAssociationManager.IsOwnedByApplication() == false)
                {
                    FileAssociationManager.Register();
                }

                Console.WriteLine("Dateityp registriert.");
                Console.Wait();
                return;
            }

            if (args.Contains("--unregister"))
            {
                if (FileAssociationManager.IsOwnedByApplication() == true)
                {
                    FileAssociationManager.Unregister();
                }

                Console.WriteLine("Dateityp entfernt.");
                Console.Wait();
                return;
            }

            if (args.Length == 0)
            {
                Console.WriteLine("Keine Datei angegeben.");
                return;
            }

            string filePath = args[0];

            Console.WriteLine($"Datei geöffnet: {filePath}");

            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);

                Console.WriteLine();
                Console.WriteLine("=== Inhalt ===");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Datei nicht gefunden.");
            }

            Console.Wait();
        }
    }
}
