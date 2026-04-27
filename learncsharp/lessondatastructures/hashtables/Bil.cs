using System.Text.Json; // Glöm inte denna högst upp i filen!
namespace   learncsharp.lessondatastructures.hashtables;

public class Bil
{
    public string? Marke { get; set; }
     public string? Regnr { get; set; }

    public Bil(string? regnr,string? marke)
    {
        Marke = marke;
        Regnr=regnr;
    }

    // Denna metod körs varje gång någon vill se objektet som text
    public override string ToString()
    {
        // Förvandla hela detta objekt (this) till en JSON-text
        return JsonSerializer.Serialize(this);
    }
}