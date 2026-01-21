using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


public class Shop
{
    
    public List<Crypto> Kryptomeny { get; set; }   
    public List<Jedlo> Jedlo { get; set; }         

    
    public Shop()
    {
        
        Kryptomeny = new List<Crypto>
        {
            new Crypto("Bitcoin", 5000),    
            new Crypto("Ethereum", 2000),
            new Crypto("Ripple", 500),
            new Crypto("Dogecoin", 50),     
            new Crypto("Cardano", 250)
        };

       
        Jedlo = new List<Jedlo>
        {
            new Jedlo("Chlieb", 2, 20),         
            new Jedlo("Mlieko", 1.5, 15),
            
          
        };
    }

    
    public void ZobrazKryptomeny()
    {
        Console.WriteLine("\n=== KUPIT KRYPTOMENY ===");

        for (int i = 0; i < Kryptomeny.Count; i++)
        {
           
            Console.WriteLine($"{i + 1}. {Kryptomeny[i].Nazov} - ${Kryptomeny[i].Cena:F2}");
        }
        Console.WriteLine("0. Spat");
    }

   
    public void ZobrazPredaj()
    {
        Console.WriteLine("\n=== PREDAJ KRYPTOMIEN ===");

        // For cyklus - podľa AppsLab-016-Loops
        for (int i = 0; i < Kryptomeny.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Kryptomeny[i].Nazov} - ${Kryptomeny[i].Cena:F2} za kus");
        }
        Console.WriteLine("0. Spat");
    }

    
    public void ZobrazJedlo()
    {
        Console.WriteLine("\n=== KUPIT JEDLO ===");

        // For cyklus - podľa AppsLab-016-Loops
        for (int i = 0; i < Jedlo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Jedlo[i].Nazov} - ${Jedlo[i].Cena:F2}");
        }
        Console.WriteLine("0. Spat");
    }

    
    public void KupiKrypto(Player hrach, int index)
    {
       
        if (index < 0 || index >= Kryptomeny.Count)
            return;  

        Crypto crypto = Kryptomeny[index];  

        Console.Write($"\nKolko kusov {crypto.Nazov}? ");

        
        if (!int.TryParse(Console.ReadLine(), out int pocet) || pocet <= 0)
        {
            Console.WriteLine("Nespravny vstup");
            return;
        }

        double cena = crypto.Cena * pocet;  // Celková cena = jednotková cena * počet

        
        // Ak hráč nemá dosť peňazí
        if (hrach.Peniaze < cena)
        {
            Console.WriteLine("Nemas dostatok penazi!");
            Thread.Sleep(1500);
            return;
        }

        hrach.Peniaze -= cena;  // Odpočítame peniaze hráčovi

       
        var existujuca = hrach.Inventar.FirstOrDefault(c => c.Nazov == crypto.Nazov);

        
        if (existujuca != null)  
        {
            existujuca.Mnozstvo += pocet;  
        }
        else  
        {
            var nova = new Crypto(crypto.Nazov, crypto.Cena);
            nova.Mnozstvo = pocet;
            hrach.Inventar.Add(nova); 
        }

        Console.WriteLine($"Kupil si {pocet} ks {crypto.Nazov} za ${cena:F2}");
        Thread.Sleep(1500);
    }

    
    public void PredajKrypto(Player hrach, int index)
    {
        
        if (index < 0 || index >= Kryptomeny.Count)
            return;

        Crypto shopCrypto = Kryptomeny[index];  

    
        var vlastniKrypto = hrach.Inventar.FirstOrDefault(c => c.Nazov == shopCrypto.Nazov);

       
        
        if (vlastniKrypto == null || vlastniKrypto.Mnozstvo == 0)
        {
            Console.WriteLine("Nemas tuto kryptoMenu!");
            Thread.Sleep(1500);
            return;
        }

        Console.Write($"\nKolko kusov {shopCrypto.Nazov} chces predat? (Mas {vlastniKrypto.Mnozstvo})? ");

        
        if (!int.TryParse(Console.ReadLine(), out int pocet) || pocet <= 0)
        {
            Console.WriteLine("Nespravny vstup");
            return;
        }

        
        if (pocet > vlastniKrypto.Mnozstvo)
        {
            Console.WriteLine("Nemas tolko!");
            Thread.Sleep(1500);
            return;
        }

        
        double cena = shopCrypto.Cena * pocet;
        hrach.Peniaze += cena;  
        vlastniKrypto.Mnozstvo -= pocet;  

       
        if (vlastniKrypto.Mnozstvo == 0)
        {
            hrach.Inventar.Remove(vlastniKrypto);
        }

        Console.WriteLine($"Predal si {pocet} ks {shopCrypto.Nazov} za ${cena:F2}");
        Thread.Sleep(1500);
    }

    
    public void KupiJedlo(Player hrach, int index)
    {
       
        if (index < 0 || index >= Jedlo.Count)
            return;

        Jedlo jedlo = Jedlo[index];

        Console.Write($"\nKolko {jedlo.Nazov}? ");

       
        if (!int.TryParse(Console.ReadLine(), out int pocet) || pocet <= 0)
        {
            Console.WriteLine("Nespravny vstup");
            return;
        }

        double cena = jedlo.Cena * pocet;

       
        if (hrach.Peniaze < cena)
        {
            Console.WriteLine("Nemas dostatok penazi!");
            Thread.Sleep(1500);
            return;
        }

        hrach.Peniaze -= cena;
        hrach.Hlad -= pocet * jedlo.SnizujeHlad;  

        
        if (hrach.Hlad < 0)
            hrach.Hlad = 0;

        Console.WriteLine($"Zjedol si {pocet} x {jedlo.Nazov}");
        Thread.Sleep(1500);
    }
}

