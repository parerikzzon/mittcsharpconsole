namespace learncsharp.lessondatastructures.hashtables;

public class MyHashTableListBucket
{
    // Buckets är våra "fack". Vi börjar med 11 (ett primtal) för att sprida ut bilarna jämnt.
    private List<Bil>[] buckets = new List<Bil>[11];
    
    // COUNT: Håller koll på totala antalet bilar i hela hashtabellen.
    // Vi behöver detta för att veta när det börjar bli för trångt (Load Factor).
    private int count = 0;

    public MyHashTableListBucket()
    {
        // Vi måste skapa en tom lista i varje fack direkt, annars kraschar Add-metoden (NullReference).
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<Bil>();
        }
    }

    // HASH-FUNKTION: Gör om ett regnr (text) till ett sifferindex (0-10).
    private int GetHash(string regnr)
    {
        int total = 0;
        // Vi kör ToUpper så att "abc" och "ABC" alltid hamnar i samma fack.
        foreach (char c in regnr.ToUpper()) { 
            total += c; 
        }
        // Modulo (%) ser till att siffran vi får alltid får plats i vår array.
        return Math.Abs(total % buckets.Length);
    }

    // RESIZE: Denna metod "bygger ut" hashtabellen när den börjar bli full.
    private void Resize()
    {
        // 1. Spara undan den gamla arrayen så vi kan flytta över bilarna från den.
        var oldBuckets = buckets;

        // 2. Skapa en ny array som är dubbelt så stor (+1 för att få ett udda tal/primtal-ish).
        int newSize = buckets.Length * 2 + 1; 
        buckets = new List<Bil>[newSize];

        // 3. Initiera de nya tomma listorna i den nya arrayen.
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<Bil>();
        }

        // 4. REHASH: Detta är kritiskt! 
        // Eftersom storleken på arrayen har ändrats, kommer GetHash ge helt nya index.
        // Vi måste därför lägga till varje bil på nytt så de hamnar i sina nya rätta fack.
        count = 0; 
        foreach (var bucket in oldBuckets)
        {
            foreach (var bil in bucket)
            {
                this.Add(bil); // Återanvänd Add för att placera bilen i den nya större arrayen.
            }
        }
    }

    public void Add(Bil bil)
    {
        if (bil == null || string.IsNullOrEmpty(bil.Regnr)) return;

        // LOAD FACTOR (Belastning): Om tabellen är fylld till 75% (0.75), förstora den.
        // Vi gör detta för att sökningen ska fortsätta vara blixtsnabb.
        if ((double)count / buckets.Length >= 0.75)
        {
            Resize();
        }

        // Hitta rätt fack och lägg till bilen i listan (Chaining).
        int index = GetHash(bil.Regnr);
        buckets[index].Add(bil);
        
        count++; // Glöm inte att räkna upp antalet bilar!
    }

    public Bil? Get(string regnr)
    {
        if (string.IsNullOrEmpty(regnr)) return null;

        // Gå direkt till rätt fack (O(1) hastighet).
        int index = GetHash(regnr);

        // Om det skett en KOLLISION (flera bilar i samma fack), letar vi i listan.
        foreach (var bil in buckets[index])
        {
            // Kontrollera att det verkligen är rätt bil (nyckeln/regnummer stämmer).
            if (bil.Regnr?.ToUpper() == regnr.ToUpper())
            {
                return bil;
            }
        }
        return null; // Bilen fanns inte i listan.
    }
}