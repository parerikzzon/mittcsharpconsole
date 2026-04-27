namespace   learncsharp.lessondatastructures.linkedlists;
// Vi döper klassen till BilNode eftersom den både innehåller 
// information om en bil OCH förmågan att länka till nästa bil i den länkde listan.
public class BilNode
{
    // Marke: Detta är "datat" vi sparar. 
    // Vi har gjort den public så att JSON-verktyget och andra klasser kan se namnet.
    public string? Marke { get; set; }

    // Next: Detta är själva "länken" eller "handen" som pekar på nästa bil.
    // Vi använder BilNode? (med frågetecken) för att tillåta att listan tar slut (null).
    // Det är detta som gör det till en "Länkad lista" istället för en vanlig lista.
    public BilNode? Next { get; set; }

    // Konstruktor: Körs varje gång vi skriver 'new BilNode("Volvo")'
    public BilNode(string marke)
    {
        // Vi sparar märket som skickas in
        Marke = marke;

        // VIKTIGT: Varje ny bil börjar som "singel". 
        // Den pekar på null (ingen) tills vi aktivt kopplar ihop den med någon annan.
        // Det är som att ställa en ny vagn sist i tåget; det finns inget bakom den än.
        Next = null; 
    }
}