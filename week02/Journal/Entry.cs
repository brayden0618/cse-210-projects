using System;
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
    public void Display()
    {
        Console.WriteLine($"{Date.ToShortDateString()} - {Prompt}");
        Console.WriteLine(Response);
        Console.WriteLine();
    }
    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Prompt}\n{Response}\n";
    }
    public string ToCsv()
    {
        return $"{Date:yyyy-MM-dd},{Prompt.Replace(",", " ")},{Response.Replace(",", " ")}";
    }
    public static Entry FromCsv(string csvLine)
    {
        var parts = csvLine.Split(",");
        return new Entry
        {
            Date = DateTime.Parse((parts[0])),
            Prompt = parts[1],
            Response = parts[2]
        };
    }
}