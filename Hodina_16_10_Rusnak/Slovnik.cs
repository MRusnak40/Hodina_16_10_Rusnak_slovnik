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

        Dictionary<int, string> slovnikKodovani;
        int numberOfItems = 0;


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
                slovo = OdebraniDiakritiy(slovo);
                Pridej(slovo);

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


    }
    


    





}
