using System;
using System.Reflection; // Gör att koden kan "se sig själv" (t.ex. hitta sina egna metoder och dess namn)

namespace learncsharp.lessondatastructures.linkedlists;

public class LinkedListDemo
{
    public static void Run()
    {
        // 1. Fråga klassen vad den heter och spara det i classType
        var classType = typeof(LinkedListDemo);

        // 2. Ta reda på vilken metod vi befinner oss i just nu
        // Vi använder System.Reflection (rad 2) för att slippa skriva hela långa sökvägen
        //skulle annars ha sett ut så här System.Reflection.MethodBase.GetCurrentMethod();
        var method = MethodBase.GetCurrentMethod();

        /* 3. Skriv ut hälsningen dynamiskt.
           {method?.Name} betyder:
           - Finns metoden? Hämta namnet (t.ex. "Run").
           - Är den tom (null)? Stoppa där och krascha inte.

           {classType.Name} hämtar namnet på klassen (t.ex. "DatastructureDemo").
        */
        Console.WriteLine($"Hej från {method?.Name} metoden i klassen {classType.Name}");
        // =========================================================================
        // TEST 1: BilLinkedList (Den specifika listan)
        // VARFÖR: För att visa hur en lista fungerar när den bara kan hantera EN sak (bilar).
        // Det är lättast att förstå i början, men begränsat eftersom vi inte kan ha frukter eller studenter här .
        // =========================================================================
        BilLinkedList bilLista = new BilLinkedList();
        bilLista.Add(new BilNode("Volvo"));
        bilLista.Add(new BilNode("Kia"));

        BilNode? current = bilLista.Head;
        while (current != null)
        {
            Console.WriteLine(current.Marke); // Vi vet att det finns ett 'Marke' eftersom detta är en BilNode.
            current = current.Next;
        }

        // =========================================================================
        // TEST 2: MyLinkedList<string> (Generics med enkla typer)
        // VARFÖR: Här visar vi kraften i Generics! Vi använder samma kodlogik som ovan
        // men nu för vanliga textsträngar. Vi slipper skapa en "FruktLinkedList".
        // =========================================================================
        MyLinkedList<string> fruktLista = new MyLinkedList<string>();
        fruktLista.Add("Äpple");
        fruktLista.Add("Banan");

        Console.WriteLine("--- Min Fruktlista ---");
        Node<string>? nuvarande = fruktLista.Head;
        while (nuvarande != null)
        {
            Console.WriteLine($"Frukt: {nuvarande.Data}"); // Data är här en sträng
            nuvarande = nuvarande.Next;
        }

        // =========================================================================
        // TEST 3: MyLinkedList<Bil> (Generics med komplexa objekt + JSON)
        // VARFÖR: Detta är "slutprovet". Vi kombinerar vår universella lista med 
        // vår rena Bil-klass. Vi visar också hur objektet kan skriva ut sig själv
        // som JSON tack vare override ToString().
        // =========================================================================
        MyLinkedList<Bil> bilLista2 = new MyLinkedList<Bil>();
        bilLista2.Add(new Bil("Mercedes"));
        bilLista2.Add(new Bil("Saab"));

        Console.WriteLine("--- Min Billista (Generisk + JSON) ---");
        Node<Bil>? nuvarande2 = bilLista2.Head;
        while (nuvarande2 != null)
        {
            // Här anropas Bil-klassens ToString() automatiskt.
            // Det gör att vi ser JSON-måsvingarna direkt i konsolen.
            Console.WriteLine($"{nuvarande2.Data}");
            nuvarande2 = nuvarande2.Next;
        }
    }
}
