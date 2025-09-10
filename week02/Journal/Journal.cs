using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToCsv());
            }
        }
    }

    public void LoadFromFile(string file)
    {
        entries.Clear();
        if (File.Exists(file))
        {
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                entries.Add(Entry.FromCsv(line));
            }
        }
    }
}