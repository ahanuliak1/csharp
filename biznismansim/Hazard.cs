
using System;
using System.Threading;



public class Hazard
{
    
    
    private Random random;  // Na generovanie rand čisel

   
    public Hazard()
    {
        random = new Random();
    }

    
   
    // MENU hazard
    public void ZobrazMenu(Player hrach)
    {
        
        while (true)
        {                 // zrob mi menu kde bude ruleta a hod mincou 
            Console.Clear();
            Console.WriteLine("=== HAZARD - MINIHRU ===");
            Console.WriteLine($"Tvoje peniaze: ${hrach.Peniaze:F2}\n"); //dosad mi tam aby som v console mal ukazane ze kolko mam penazi ked budem v hazard menu 
            Console.WriteLine("Vyber hru:");
            Console.WriteLine("1. Hod mincou (50% na výhru: vyhraš 2x stavenú sumu)");
            Console.WriteLine("2. Ruleta (50% na výhru: vyhraš 3x stavenú sumu)");
            Console.WriteLine("0. Spat");
            Console.Write("\nVol: ");

            string vstup = Console.ReadLine();

            
            switch (vstup)
            {
                case "1":
                    HodMincou(hrach);
                    break;
                
                case "2":
                    SpinRulety(hrach);
                    break;
                case "0":
                    return;  
                default:
                    Console.WriteLine("Nespravna volba");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

   //coin flip
    private void HodMincou(Player hrach)
    {
        Console.Clear();
        Console.WriteLine("=== HOD MINCOU ===");
        Console.WriteLine("Ak padne PANNA, vyhraš 2x svoju stávku!");
        Console.Write("Kolko chceš staviť? (Maš ${0:F2}): ", hrach.Peniaze); //chatgpt zrob mi aby vydeli kolko maju penazi

       
        
        if (!double.TryParse(Console.ReadLine(), out double stavka) || stavka <= 0)
        {
            Console.WriteLine("Nespravny vstup");
            Thread.Sleep(1500);
            return;
        }


        if (stavka > hrach.Peniaze)
        {
            Console.WriteLine("Nemas toľko penazi!");
            Thread.Sleep(1500);
            return;
        }

       
        hrach.Peniaze -= stavka;

       
        int vysledok = random.Next(0, 2);

        Console.WriteLine(" Hádzam mincou...");
        Thread.Sleep(1000);

        
        if (vysledok == 1)
        {
            Console.WriteLine("🎉 PANNA! VYHRAL SI!");
            Console.WriteLine($"Vyhral si ${stavka * 2:F2}");
            hrach.Peniaze += stavka * 2;  
        }
        else
        {
            Console.WriteLine("😢 OROL! haha skus neskor ");
            Console.WriteLine($"Stratil si ${stavka:F2}");
           
        }

        Thread.Sleep(2000);
    }

   
   







    //ruleta
    private void SpinRulety(Player hrach)
    {
        Console.Clear(); //vycistenie consolky skor obrazovky
        Console.WriteLine("=== SPIN RULETY ===");
        Console.WriteLine("Vsadíš na ČIERNU alebo ČERVENÚ?");
        Console.WriteLine("Ak si vyberieš správne farbu, vyhraš 3x!");
        Console.Write("Kolko chceš staviť? (Maš ${0:F2}): ", hrach.Peniaze);

       
        if (!double.TryParse(Console.ReadLine(), out double stavka) || stavka <= 0)
        {
            Console.WriteLine("Nespravny vstup");
            Thread.Sleep(1500);
            return;
        }

   
        if (stavka > hrach.Peniaze)
        {
            Console.WriteLine("Nemas toľko penazi!");
            Thread.Sleep(1500);
            return;
        }

        Console.Write("Zvol si: 1=CIERNA alebo 2=CERVENA: ");

        
        if (!int.TryParse(Console.ReadLine(), out int volba) || (volba != 1 && volba != 2))
        {
            Console.WriteLine("Nespravny vstup");
            Thread.Sleep(1500);
            return;
        }

        hrach.Peniaze -= stavka;

        // Spin rulety random farba (1 alebo 2)
        int vysledok = random.Next(1, 3);

        Console.WriteLine("\n🎡 Ruleta sa točí...");
        Thread.Sleep(1500);

      
        string[] farby = { "", "CIERNA", "CERVENA" };

        Console.WriteLine($"Padla: {farby[vysledok]}");
        Thread.Sleep(1000);

        
        
        if (volba == vysledok)
        {
            Console.WriteLine("🎉 VYHRAL SI!");
            Console.WriteLine($"Vyhral si ${stavka * 3:F2}");
            hrach.Peniaze += stavka * 3;  // Dostane 3x stavenú sumu
        }
        else
        {
            Console.WriteLine("😢 haha smola ");
            Console.WriteLine($"Stratil si ${stavka:F2}");
        }

        Thread.Sleep(2000);
    }
}