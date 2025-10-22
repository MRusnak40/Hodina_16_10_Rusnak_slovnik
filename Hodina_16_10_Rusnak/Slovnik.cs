using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Hodina_16_10_Rusnak
{
    public class Slovnik
    {

        Dictionary<int, string> slovnikKodovani;
        int numberOfItems = 0;
        private string slovicko;
        List<string> seznamSlov = new List<string>();
        List<int> seznamKodu = new List<int>();

        public Slovnik()
        {
            slovnikKodovani = new Dictionary<int, string>();

        }




        public void Pridej(string hodnota)
        {

            slovnikKodovani.Add(numberOfItems, hodnota);
            numberOfItems++;
        }



        //vypis slovniku Zakodovaneho
        public void Vypis()
        {
            foreach (var item in slovnikKodovani)
            {
                Console.WriteLine($"Klic: {item.Key}, Hodnota: {item.Value}");
            }
        }

        //pridani slov do slovniku TOlower a odebrani diakritiky
        public void PridaniSlov(String text)
        {
            string[] slova = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string slovo in slova)
            {
                slovo.ToLower();

                /*
                char[] slovoArray = slovo.ToCharArray();

                foreach(char c in slovoArray)
                {
                   
                

                }

                */
                //add here the method for removing diacritics
                slovicko = OdebraniDiakritiy(slovo);
                seznamSlov.Add(slovicko);
                if (!slovnikKodovani.ContainsValue(slovicko))
                {
                    Pridej(slovicko);
                }


            }




        }

        //navrh Visual Studia (funguje)
        //odebirani diakritiky slova
        public string OdebraniDiakritiy(string slovo)
        {

            string normalizedString = slovo.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            string result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
            return result;

        }

        /*
        public static string BezDiakritiky(string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
        */

        public void VypisKodem()
        {
            foreach (var item in seznamSlov)
            {

                foreach (var pair in slovnikKodovani)
                {
                    if (pair.Value == item)
                    {
                        Console.Write($"{pair.Key} ");
                    }
                }




            }
            Console.WriteLine(" ");

        }



        public override bool Equals(object? obj)
        {
            return obj is Slovnik slovnik &&
                   EqualityComparer<Dictionary<int, string>>.Default.Equals(slovnikKodovani, slovnik.slovnikKodovani);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(slovnikKodovani);
        }




        public void dekodovani(string text)
        {
            string[] slova = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Dekódované slovo: ");
            foreach (string slovo in slova)
            {
                try
                {
                    int kod = int.Parse(slovo);
                    if (slovnikKodovani.ContainsKey(kod))
                    {
                        foreach (var pair in slovnikKodovani)
                        {
                            if (pair.Key == kod)
                            {
                                Console.Write($"{pair.Value} ");
                            }

                        }

                    }
                    else { Console.WriteLine($"? "); }


                }

                catch (FormatException)
                {
                    Console.WriteLine($"?");

                }

            }









        }
    }
}