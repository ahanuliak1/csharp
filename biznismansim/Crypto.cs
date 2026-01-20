using System;

public class Crypto
{
    public string Nazov { get; set; }
    public double Cena { get; set; }
    public double PociatocnaCena { get; set; }
    public int Mnozstvo { get; set; }

    public Crypto(string nazov, double cena)
    {
        Nazov = nazov;
        Cena = cena;
        PociatocnaCena = cena;
        Mnozstvo = 0;
    }

    public void ZmeniCenu()
    {
        Random rand = new Random();
        double zmena = (rand.NextDouble() - 0.5) * 0.4;
        Cena = Cena * (1 + zmena);

        if (Cena < PociatocnaCena * 0.1)
            Cena = PociatocnaCena * 0.1;
    }
}