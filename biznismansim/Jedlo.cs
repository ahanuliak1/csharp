public class Jedlo
{
    public string Nazov { get; set; }
    public double Cena { get; set; }
    public int SnizujeHlad { get; set; }

    public Jedlo(string nazov, double cena, int snizujeHlad)
    {
        Nazov = nazov;
        Cena = cena;
        SnizujeHlad = snizujeHlad;
    }
}