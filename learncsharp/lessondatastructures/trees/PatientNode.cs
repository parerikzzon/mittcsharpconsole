using System;
namespace  learncsharp.lessondatastructures.trees;

public class PatientNode
{
    public int StartTid; // t.ex. 1030
    public string Namn;
    public PatientNode? Left;  // Tidigare tider
    public PatientNode? Right; // Senare tider

    public PatientNode(int tid, string namn)
    {
        StartTid = tid;
        Namn = namn;
        Left = null;
        Right = null;
    }
}