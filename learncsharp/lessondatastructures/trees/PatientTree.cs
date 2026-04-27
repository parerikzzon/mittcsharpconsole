namespace learncsharp.lessondatastructures.trees;

public class PatientTree
{
    public PatientNode? Root;

    public void Boka(int tid, string namn)
    {
        if (Root == null)
        {
            Root = new PatientNode(tid, namn);
            return;
        }

        AddRecursively(Root, tid, namn);
    }

    private void AddRecursively(PatientNode current, int tid, string namn)
    {
        if (tid < current.StartTid)
        {
            // Gå till vänster
            if (current.Left == null)
                current.Left = new PatientNode(tid, namn);
            else
                AddRecursively(current.Left, tid, namn);
        }
        else if (tid > current.StartTid)
        {
            // Gå till höger
            if (current.Right == null)
                current.Right = new PatientNode(tid, namn);
            else
                AddRecursively(current.Right, tid, namn);
        }
        else
        {
            Console.WriteLine($"Tiden {tid} är redan bokad av {current.Namn}!");
        }
    }

    // En metod för att skriva ut alla bokningar i tidsordning
    public void VisaAllaBokningar(PatientNode? node)
    {
        if (node == null) return;

        VisaAllaBokningar(node.Left); // Kolla de tidigaste först
        Console.WriteLine($"Kl {node.StartTid}: {node.Namn}");
        VisaAllaBokningar(node.Right); // Kolla de senare sen
    }
}