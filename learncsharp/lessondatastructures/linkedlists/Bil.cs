using System.Text.Json; // Glöm inte denna högst upp i filen!
namespace   learncsharp.lessondatastructures.linkedlists;

public class Bil
{
    public string? Marke { get; set; }

    public Bil(string marke)
    {
        Marke = marke;
    }

    // Denna metod körs varje gång någon vill se objektet som text
    public override string ToString()
    {
        // Förvandla hela detta objekt (this) till en JSON-text
        return JsonSerializer.Serialize(this);
    }
}