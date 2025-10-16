using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hodina_16_10_Rusnak
{
    public class Slovnik
    {

        Dictionary<int, string> slovnik;
        int numberOfItems = 0;

        public Slovnik()
        {
            slovnik = new Dictionary<int, string>();
        }




        public void Pridej(string hodnota)
        {

            slovnik.Add(numberOfItems, hodnota);
            numberOfItems++;
        }




        public void Vypis()
        {
            foreach (var item in slovnik)
            {
                Console.WriteLine($"Klic: {item.Key}, Hodnota: {item.Value}");
            }
        }


        public void PridaniSlov(String text)
        {
            string[] slova = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var slovo in slova)
            {
                slovo.ToLower();

                /*
                char[] slovoArray = slovo.ToCharArray();

                foreach(char c in slovoArray)
                {
                   
                

                }

                */
                //add here the method for removing diacritics

            }




        }

        //navrh Visual Studia
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
    }
}
