using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Player playerObj = new Player();
        AchivementPrinter printer = new AchivementPrinter();
        playerObj.Achivement += print;
        playerObj.Achivement += printer.show;
        playerObj.AddPoints(50);
        playerObj.AddPoints(100);
        static void print(int p)
        {
            Console.WriteLine("Achivement Unlocked " + p.ToString());
        }

    }
}

public class AchivementPrinter
{
    public void show(int p)
    {

        Console.WriteLine("Achivement Unlocked from show method" + p.ToString());
    }
}

public class Player
{
    public int Points { get; set; }
    public delegate void printHandeler(int totalPoints);
    public event printHandeler Achivement;

    public void AddPoints(int points)
    {
        Points += points;
        Console.WriteLine("Total Points now " + Points.ToString());

        if (Points > 100)
            Achivement?.Invoke(Points);

    }
}