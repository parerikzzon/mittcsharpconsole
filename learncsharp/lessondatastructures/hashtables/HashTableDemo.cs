using System;
namespace learncsharp.lessondatastructures.hashtables;
public class HashTableDemo
{
    public static void Run()
    {
        // --- TEST 1: CHAINING (List Bucket) ---
        Console.WriteLine("======= TEST: CHAINING (ListBucket) =======");
        MyHashTableListBucket listTable = new MyHashTableListBucket();

        // Vi lägger till bilar
        listTable.Add(new Bil("Volvo", "AAA111"));
        listTable.Add(new Bil("Saab","BBB222"));
        
        // Testa att hämta
        Bil? b1 = listTable.Get("AAA111");
        Console.WriteLine(b1 != null ? $"Hittade: {b1.Marke}" : "Bilen saknas!");

        // Testa Load Factor / Resize (vi lägger till många för att tvinga fram en Resize)
        for (int i = 0; i < 15; i++)
        {
            listTable.Add(new Bil("Testbil " + i,"REG" + i));
        }
        Console.WriteLine($"Lagt till 15 bilar till. Tabellen har nu växt (Resized).");
        Console.WriteLine($"Söker efter REG10: {listTable.Get("REG10")?.Marke ?? "Hittades ej"}");
        Console.WriteLine();


        // --- TEST 2: LINEAR PROBING ---
        Console.WriteLine("======= TEST: LINEAR PROBING =======");
        MyHashTableProbing probingTable = new MyHashTableProbing();

        probingTable.Add(new Bil("Tesla", "TES123" ));
        probingTable.Add(new Bil("Audi","AUDI01"));

        // Testa sökning
        Bil? b2 = probingTable.Get("TES123");
        Console.WriteLine(b2 != null ? $"Hittade: {b2.Marke}" : "Bilen saknas!");

        // Testa att söka efter något som inte finns (viktigt för Probing-loopen!)
        Bil? b3 = probingTable.Get("OSYNLIG");
        if (b3 == null) Console.WriteLine("Korrekt: 'OSYNLIG' hittades inte.");

        Console.WriteLine("===========================================");
        
    }
}
