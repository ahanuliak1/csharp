using System;
using System.Collections.Generic;
using System.Linq;


public class Player
{
    
    public string Meno { get; set; }               
    public double Peniaze { get; set; }            
    public List<Crypto> Inventar { get; set; }     
    public int Hlad { get; set; }                   
    public int Smad { get; set; }                   

    
    public Player(string meno)
    {
        Meno = meno;
        Peniaze = 100;                          
        Inventar = new List<Crypto>();         
        Hlad = 50;                              
        Smad = 50;                              
    }

   
    public void ZobrazStav()
    {
        Console.WriteLine("\n=== STAV HRACA ===");
        Console.WriteLine($"Meno: {Meno}");
        Console.WriteLine($"Peniaze: ${Peniaze:F2}");  
        Console.WriteLine($"Hlad: {Hlad}/100");
        Console.WriteLine($"Smad: {Smad}/100");
        Console.WriteLine("\n--- INVENTAR ---");

       
        if (Inventar.Count == 0)
        {
            Console.WriteLine("Inventar je prazdny");
        }
        else
        {
            foreach (var crypto in Inventar)
            {
                Console.WriteLine($"{crypto.Nazov}: {crypto.Mnozstvo} ks (${crypto.Cena:F2})");
            }
        }
    }

   
    public void ZvysCas()
    {
        Hlad += 10;  
        Smad += 10;  

        
        if (Hlad > 100) Hlad = 100;
        if (Smad > 100) Smad = 100;
    }

    
    public void UbyCas()
    {
        Hlad -= 5;  
        Smad -= 5;  

        
        if (Hlad < 0) Hlad = 0;
        if (Smad < 0) Smad = 0;
    }
}
