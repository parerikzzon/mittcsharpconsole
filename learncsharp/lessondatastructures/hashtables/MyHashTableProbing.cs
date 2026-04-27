namespace learncsharp.lessondatastructures.hashtables;

public class MyHashTableProbing
{
    // Här sparar vi bilarna direkt i arrayen. Inga listor behövs!
    private Bil?[] buckets = new Bil[11];
    private int count = 0;

    // HASH-FUNKTION: Precis som förut, ger oss startindexet.
    private int GetHash(string regnr)
    {
        int total = 0;
        foreach (char c in regnr.ToUpper()) { total += c; }
        return Math.Abs(total % buckets.Length);
    }

    // ADD med Linear Probing
    public void Add(Bil bil)
    {
        // 1. Kolla Load Factor. Vid Probing är det ännu viktigare att ha plats.
        // Vi kör Resize redan vid 50% fyllnad för att undvika långa "kluster".
        if ((double)count / buckets.Length >= 0.5)
        {
            Resize();
        }

        int index = GetHash(bil.Regnr!);

        // 2. PROBING: Om platsen är upptagen, gå till nästa (index + 1).
        // Vi använder % buckets.Length för att "snurra runt" till början om vi når slutet.
        while (buckets[index] != null)
        {
            // Om bilen redan finns (samma regnr), uppdatera den eller hoppa över.
            if (buckets[index]!.Regnr == bil.Regnr) return;
            /*
            Raden gör två saker i ett enda steg:
            (index + 1): Den flyttar oss till nästa fack i arrayen. Om fack 5 var upptaget, tittar vi på fack 6.
            % buckets.Length: Detta är Modulo (resten vid division). Den ser till att indexet "snurrar runt" till 0 om vi når slutet av arrayen.
            */
            index = (index + 1) % buckets.Length;
        }

        // 3. Vi hittade en tom plats!
        buckets[index] = bil;
        count++;
    }

    // GET med Linear Probing
    public Bil? Get(string regnr)
    {
        int index = GetHash(regnr);
        int startIndex = index; // Spara var vi började för att undvika eviga loopar

        // Letar så länge facket inte är tomt
        while (buckets[index] != null)
        {
            // Är detta bilen vi söker?
            if (buckets[index]!.Regnr?.ToUpper() == regnr.ToUpper())
            {
                return buckets[index];
            }

            // Gå till nästa fack (Probing)
            index = (index + 1) % buckets.Length;

            // Om vi har snurrat ett helt varv och är tillbaka där vi började
            if (index == startIndex) break;
        }

        return null; // Hittade inget
    }

    private void Resize()
    {
        var oldBuckets = buckets;
        int newSize = buckets.Length * 2 + 1;
        buckets = new Bil[newSize];
        count = 0;

        foreach (var bil in oldBuckets)
        {
            if (bil != null)
            {
                Add(bil); // Rehasha in i den nya större arrayen
            }
        }
    }
}