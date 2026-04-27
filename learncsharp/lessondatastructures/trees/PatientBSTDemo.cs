using System;
namespace learncsharp.lessondatastructures.trees;

public class PatientBSTDemo
{
    public static void Run()
    {

        PatientTree bokingar = new PatientTree();
        bokingar.Boka(1000, "Erik");
        bokingar.Boka(0900, "Anna");
        bokingar.Boka(1100, "Karl");

        Console.WriteLine("Dagens schema:");
        bokingar.VisaAllaBokningar(bokingar.Root);
    }
}