namespace learncsharp.lessondatastructures;

// <T> är en "platshållare". Det betyder: "Vi vet inte än vad listan ska innehålla, 
// men vad det än är så kallar vi det för T".
public class MyLinkedList<T>
{
    // Head pekar på den första Node<T> i listan.
    // Tack vare <T> vet Head automatiskt om den ska hålla i en Node med en bil eller en sträng.
    public Node<T>? Head { get; set; }

    // Här tar vi emot 'data' av typen T. 
    // Om vi skapade listan som MyLinkedList<Bil>, så förväntar sig Add en Bil här.
    public void Add(T data)
    {
        // 1. Vi skapar en ny "låda" (Node). 
        // Vi stoppar in vårt objekt (data) i lådan.
        Node<T> newNode = new Node<T>(data);

        // 2. Om listan är tom (Head är null), blir den nya lådan startpunkten.
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            // 3. Om det redan finns lådor, måste vi hitta den sista.
            // Vi börjar vid Head och använder 'current' som en pekfinger-guide.
            Node<T> current = Head;

            // Vi tittar på nästa länk. Om den INTE är tom, flyttar vi fingret ett steg framåt.
            while (current.Next != null)
            {
                current = current.Next;
            }

            // 4. Nu pekar 'current' på den sista lådan i kedjan.
            // Vi kopplar ihop den sista lådans 'Next' med vår helt nya låda.
            current.Next = newNode; 
            
            // Nu pekar den gamla sista lådan på newNode, 
            // och newNode.Next är redan null (det sattes i nodens konstruktor).
        }
    }
}