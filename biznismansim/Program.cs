class Program
{
    static void Main()
    {
        ZobrazLoading();

        Console.Clear();
        Console.WriteLine("=== WELCOME TO BUSINESS SIMULATOR ===");
        Console.Write("Ako sa volas? ");
        string meno = Console.ReadLine();

        Player hrach = new Player(meno);
        Shop shop = new Shop();

        HlavnaSlucka(hrach, shop);
    }

    static void ZobrazLoading()
    {
        Console.Clear();
        Console.WriteLine("LOADING...");
        for (int i = 0; i < 5; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Thread.Sleep(1000);
    }

    static void HlavnaSlucka(Player hrach, Shop shop)
    {
        while (true)
        {
            Console.Clear();
            hrach.ZobrazStav();

            if (hrach.Hlad > 80)
                Console.WriteLine("\n[!] Mas velky hlad!");
            if (hrach.Smad > 80)
                Console.WriteLine("\n[!] Mas velky smad!");

            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Ist do obchodu");
            Console.WriteLine("2. Spat (noc)");
            Console.WriteLine("3. Odpocivat");
            Console.WriteLine("4. Koniec");
            Console.Write("\nVol: ");

            string vstup = Console.ReadLine();

            switch (vstup)
            {
                case "1":
                    MenuObchodu(hrach, shop);
                    break;
                case "2":
                    MenuPredaj(hrach, shop);
                    break;
                case "3":
                    Console.WriteLine("Odpocnes si chvilu...");
                    hrach.ZvysCas();
                    Thread.Sleep(2000);
                    break;
                case "4":
                    Console.WriteLine("Dakujeme za hru!");
                    return;
                default:
                    Console.WriteLine("Nespravny vstup");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void MenuObchodu(Player hrach, Shop shop)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== OBCHOD ===");
            Console.WriteLine("1. Kupit kryptomeny");
            Console.WriteLine("2. Predaj kryptomeny");
            Console.WriteLine("3. Kupit jedlo");
            Console.WriteLine("4. Spat");
            Console.Write("\nVol: ");

            string vstup = Console.ReadLine();

            switch (vstup)
            {
                case "1":
                    MenuKryptomien(hrach, shop);
                    break;
                case "2":
                    MenuPredaj(hrach, shop);
                    break;
                case "3":
                    MenuObchodu(hrach, shop);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Nespravny vstup");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void MenuKryptomien(Player hrach, Shop shop)
    {
        while (true)
        {
            Console.Clear();
            shop.ZobrazKryptomeny();
            Console.Write("\nVol: ");

            if (!int.TryParse(Console.ReadLine(), out int vol))
            {
                Console.WriteLine("Nespravny vstup");
                Thread.Sleep(1500);
                continue;
            }

            if (vol == 0) return;
            if (vol > 0 && vol <= shop.Kryptomeny.Count)
            {
                shop.KupiKrypto(hrach, vol - 1);
            }
            else
            {
                Console.WriteLine("Nespravna volba");
                Thread.Sleep(1500);
            }
        }
    }

    static void MenuPredaj(Player hrach, Shop shop)
    {
        while(true) 
        {
            Console.Clear();
            shop.ZobrazPredaj();
            Console.Write("\nVol: ");

            if (!int.TryParse(Console.ReadLine(), out int vol))
            {
                Console.WriteLine("Nespravny vstup");
                Thread.Sleep(1500);
                continue;
            }

            if (vol == 0) return;
            if (vol > 0 && vol <= shop.Kryptomeny.Count)
            {
                shop.PredajKrypto(hrach, vol - 1);
            }
            else
            {
                Console.WriteLine("Nespravna volba");
                Thread.Sleep(1500);
            }
        }
        {
            Console.WriteLine("\nIdesh spat...");
            Thread.Sleep(1500);

            Console.WriteLine("Pocas noci sa zmeny ceny kryptomien...\n");
            foreach (var crypto in shop.Kryptomeny)
            {
                double stara = crypto.Cena;
                crypto.ZmeniCenu();
                string smer = crypto.Cena > stara ? "RAST" : "POKLES";
                Console.WriteLine($"{crypto.Nazov}: ${stara:F2} -> ${crypto.Cena:F2} ({smer})");
                Thread.Sleep(500);
            }

            hrach.Hlad = 30;
            hrach.Smad = 30;

            Console.WriteLine("\nZabudol si! Musis jest a pit!");
            Thread.Sleep(2500);
        }
    }
}


