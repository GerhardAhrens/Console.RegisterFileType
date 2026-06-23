# Console Register File Type

![NET](https://img.shields.io/badge/NET-10.0-green.svg)
![License](https://img.shields.io/badge/License-MIT-blue.svg)
![VS2026](https://img.shields.io/badge/Visual%20Studio-2026-white.svg)
![Version](https://img.shields.io/badge/Version-1.0.2026.0-yellow.svg)

## Projekt 
In dem Beispiel geht es darum, die Endungen zu einer Datei zu registrieren, zu prüfen und 
wenn einen Datei mit einem Doppelklick über den Datei-Explorer aufgerufen wird, das dazu registrierte Programm zu starten.

## Hinweis
Der Source ist soll auch einfache Art und Weise die Funktionen eines Features zeigen. Der Source ist so geschrieben, das so wenig wie möglich zusätzliche NuGet-Pakete benötigt werden.

# Features
- IsRegistered; prüfen ob der Dateityp registriert ist
- IsOwnedByApplication; prüfen ob der Dateityp für genau diese Anwendung registriert ist
- Register(); einen Dateityp gegistrieren
- Unregister(); Registrierung des Dateityp aufgeben (löschen)

## Beispielsource

Das Beispil zeigt, wie ein Datei-Typ geprüft, erstellt und wieder gelöscht werden kann.

```csharp
private static void Main(string[] args)
{
    if (args.Contains("--register"))
    {
        if (FileAssociationManager.IsOwnedByApplication() == false)
        {
            FileAssociationManager.Register();
        }

        Console.WriteLine("Dateityp registriert.");
        return;
    }

    if (args.Contains("--unregister"))
    {
        if (FileAssociationManager.IsOwnedByApplication() == true)
        {
            FileAssociationManager.Unregister();
        }

        Console.WriteLine("Dateityp entfernt.");
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
}
```

# Versionshistorie
![Version](https://img.shields.io/badge/Version-1.0.2026.0-yellow.svg)
- Migration auf NET 10
