namespace learncsharp.lessondatastructures.linkedlists;

public class BilLinkedList
{
    // Head är listans startpunkt (första bilen i kön).
    // Om Head är null betyder det att garaget/listan är helt tom.
    public BilNode? Head { get; set; }

    // Add-metoden tar en färdig BilNode och placerar den på rätt plats.
    public void Add(BilNode nyBil)
    {
        // Vi skapar en tillfällig variabel för att kunna "vandra" genom listan.
        BilNode current;

        // STEG 1: Kolla om listan är helt tom.
        if (Head == null)
        {
            // Om det inte finns någon bil än, blir den här nya bilen den första (Head).
            Head = nyBil;
        }
        else
        {
            // STEG 2: Om det redan finns bilar, börja vid den första (Head).
            current = Head;

            // STEG 3: "Vandringen" (while-loopen).
            // Så länge den bil vi tittar på HAR en bil efter sig (Next != null)...
            while (current.Next != null)
            {
                // ...så flyttar vi oss framåt till nästa bil i kedjan.
                current = current.Next;
            }

            // STEG 4: Kopplingen.
            // Nu har vi nått den sista bilen (den som pekar på null).
            // Vi säger åt den sista bilen att börja peka på vår nya bil istället.
            current.Next = nyBil;
        }
    }
}