namespace Hodina_16_10_Rusnak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Slovnik slovnik = new Slovnik();
           slovnik.PridaniSlov("Příliš žluťoučký kůň úpěl ďábelské ódy kun");
            slovnik.Vypis();
            slovnik.VypisKodem();
            Console.Write("Zadejte kód k dekódování (Kazda cislice spravne oddelena mezereiou JAKO jedno slovo):");
            slovnik.dekodovani(Console.ReadLine());

        }
    }
}
