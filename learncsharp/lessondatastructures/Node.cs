using System;
using System.ComponentModel.DataAnnotations;
namespace learncsharp.lessondatastructures;

// <T> fungerar som en "tom plats" för en datatyp. 
// Det gör att vi kan använda samma kod för både siffror (int), text (string) eller egna klasser (bil).
public class Node<T>
{
    // Data: Själva "lasten" eller föremålet som den här noden bär på.
    // Om T är en bil, så är Data en specifik bil.
    public T Data { get; set; }

    /* Next: Detta är "länken" till nästa låda i kedjan.
       Frågetecknet (?) är en säkerhetsvakt. Den säger:
       1. "Det är okej om den här länken är tom" (t.ex. vid slutet av listan).
       2. "Om vi försöker titta i nästa länk men den inte finns, så kraschar vi inte."
       Utan ? skulle programmet tvärdö om vi råkade peka på något som inte finns. */
    public Node<T>? Next { get; set; }

    // Konstruktor: Detta är "receptet" för hur en ny nod skapas.
    // När vi skriver 'new Node("Hej")', körs koden här under.
    public Node(T data)
    {
        Data = data;   // Lägg in föremålet i noden
        Next = null;   // När noden är ny har den inte hunnit kopplas ihop med någon annan än.
    }

    
}