using System.Diagnostics;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*bool isAsault = 1;
            Console.WriteLine(isAsault);

            int myAge = 15;
            Console.WriteLine(myAge);

            float pi = 3.14f;
            Console.WriteLine(pi);

            string name = "Jakub";
            Console.WriteLine(name);

            char gender = 'M';
            Console.WriteLine(gender);
            */










            //scitavanie vsetkeho poznamky

            int birthday = 25;
            int birthmonth = 7;
            int birthyear = 2010;
            //scitanie tych troch
            /*int birthsum = birthday + birthmonth + birthyear;
           Console.WriteLine(birthsum);

        int birthsum2 = (birthsum * 10);
        Console.WriteLine(birthsum2);
            */

            //scitanie datum n mesiac a prenasobitň
            int sum3 = (birthday + birthmonth)* birthyear;
           
            Console.WriteLine(sum3);
            
            //float na desatine sa pridav f
            Console.WriteLine(5f/6f);
            //vytvor premenu mooje meno a scitat ju z datumom narodenia
            string name = "alex";
            Console.WriteLine(name+birthyear);
            sum3 = (birthday + birthmonth);

            //vypis meno sucet dna a mesiaca
            Console.WriteLine(sum3 + name);


            bool result = 6 != 6;
                 Console.WriteLine(result);
 








































        }









    }


}