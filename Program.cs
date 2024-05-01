using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using static LegMedLINQ.DataListe;

namespace LegMedLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UdTilExcel.GemDataIExcel();
            //ExcelData.HentFraExcel();
            HttpClientTest starter = new HttpClientTest();
            starter.MainStart();

            List<PersonData> personList = Person.PersonListe;

            //Tag kun de første 3 fra denne liste ved brug af Take(3)
            var kunTre = personList.Take(3);
            var skipTre = personList.Skip(3);

            Console.WriteLine($"Disse tre personer er de første tre i listen: ");
            foreach (var kun in kunTre)
            {
                Console.WriteLine(kun.Navn);
            }
            Console.WriteLine();

            Console.WriteLine($"Her er de første tre i listen skippet: ");
            foreach (var kun in skipTre)
            {
                Console.WriteLine(kun.Navn);
            }
            Console.WriteLine();

            var yngrePersoner = from pers in Person.PersonListe
                                  where pers.Alder < 40 && pers.Løn > 40000 && pers.Køn == "kvinde"
                                  select pers;
 
            Console.WriteLine("Yngre kvinder med høj løn:");
            foreach (var p in yngrePersoner)
            {
                Console.WriteLine($"{p.Navn} er {p.Alder} år og tjener {p.Løn} kr. om måneden.");
            }


            Console.WriteLine("\n");
            var ungdom = Person.PersonListe.Where(c => (c.Alder < 40));
            Console.WriteLine($"Disse personer er under 40 år:");
            foreach (var p in ungdom) 
            {
                Console.WriteLine(p.Navn);
            };

            //TakeWhile filtrerer ud fra en betingelse og stopper, når den når data, som ikke opfylder betingelsen.
            Console.WriteLine( );
            var mellemLøn = personList.TakeWhile(n => n.Løn < 50000);
            Console.WriteLine($"Filter viser de første personer med løn under 50000 kr/md:");
            foreach (var p in mellemLøn)
            {
                Console.WriteLine(p.Navn);
            };

            Console.WriteLine();
            //sorteret liste
            var sortedReversePersoner = (from pers in Person.PersonListe
                                 orderby pers.Alder
                                 select pers)
                                 .Reverse(); //man kan også bruge descent
            Console.WriteLine("Sorteret efter alder (start med den ældste:)");
            foreach (var p in sortedReversePersoner)
            {
                Console.WriteLine(p.Navn);
            };
            Console.WriteLine();
            //sorteret liste
            var sortedPersoner = from pers in Person.PersonListe
                                 orderby pers.Alder                                 
                                 select pers;
            Console.WriteLine("Sorteret efter alder (start med yngste:)");
            foreach (var p in sortedPersoner)
            {
                Console.WriteLine(p.Navn);
            };

            Console.WriteLine();
            //sortering først efter alder og så navn. Se fx Jens og Anja, der er lige gamle
            Console.WriteLine("Sorteret efter alder og derefter navn");
            var toBetingelser = Person.PersonListe
                                .OrderBy(alder => alder.Alder)
                                .ThenBy(alder => alder.Navn);
            foreach (var p in toBetingelser)
            {
                Console.WriteLine(p.Navn);
            };

            Console.WriteLine();
            //GroupBy
            //groupby liste
            var grupper = from pers in Person.PersonListe
                                 group pers.Navn by pers.Stilling into g
                                 select (Navne: g, Stilling: g.Key );
            Console.WriteLine("Gruppering efter stilling");
            foreach (var g in grupper)
            {
                Console.WriteLine($"Stilling '{g.Stilling}':");
                foreach (var w in g.Navne)
                {
                    Console.WriteLine(w);
                }
            }
            Console.WriteLine();
            //Kun en af hver
            var aldre = from pers in Person.PersonListe
                        orderby pers.Alder
                        select pers.Alder;
            var uniqueAlder = aldre.Distinct();


            Console.WriteLine("De forskellige aldre:");
            foreach (var f in uniqueAlder)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine();

            //Union sammenlægger to samlinger og samler dem i en. (OR)
            //Intersect finder ligheder mellem to samlinger. (AND)
            //Except finder at alle de tal, der ikke har et lignende tal i den anden samling. (XOR)
            //ToArray konverterer til array
            //ToList konverterer til liste

            //brug af dictionary
            var navnet = "Jens Olsen";
            var lønning = from pers in Person.PersonListe
                                        select pers;
            var lønningDict = lønning.ToDictionary(sr => sr.Navn);

            Console.WriteLine($"Navn     \t: {lønningDict[navnet].Navn}\nLøn      \t: {lønningDict[navnet].Løn:C}\nStilling\t: {lønningDict[navnet].Stilling}" );

            Console.WriteLine();
            //sortering af type

            var intValues = Person.PersonListe
                .SelectMany(p => new object[] { p.ID, p.Køn, p.Navn, p.Telefon, p.By, p.Alder, p.Løn }) // flad listen ud
                .OfType<int>(); // filtrer efter int-værdier

            foreach (var intValue in intValues)
            {
                Console.WriteLine(intValue);
            }

            var kvinder = (from pers in Person.PersonListe
                                 where pers.Køn == "kvinde"
                                 select pers)
                     .First();

            Console.WriteLine(kvinder.Navn);


            //find første navn der starter med H
            var strings = from pers in Person.PersonListe
                          select pers;
            var starterMedH = strings.First(s => s.Navn.Substring(0,1) == "H");

            Console.WriteLine($"Første navn, der starter med 'H': {starterMedH.Navn}");

            //FirstOrDefault viser første værdi eller null hvis der ikke er noget
            int[] numbers = { };

            int firstNumOrDefault = numbers.FirstOrDefault();
            Console.WriteLine(firstNumOrDefault);


            //ElementAt og .Count og .Sum() .Max() .Min() .Average()
            int[] numrene = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int etTal = (
                from n in numrene
                where n > 5
                select n)
                .ElementAt(1);  // second number is index 1 because sequences use 0-based indexing            
            Console.WriteLine($"Andet nummer > 5: {etTal}");
            Console.WriteLine($"Der er {numrene.Count()} numre i datalisten");
            Console.WriteLine($"Summen af alle tallene i datalisten er: {numrene.Sum()}");

            //find ord der indeholder noget bestemt. Man kan fx søge om man er udgået for et produkt
            var søgning = from pers in Person.PersonListe
                          select pers.Navn;
            bool søgEfterKim = søgning.Any(s => s.Contains("Kim"));
            Console.WriteLine($"Er der et navn, der indeholder 'Kim'?: {søgEfterKim}");


            //Man kan bruge forskellige muligheder til at kombinere to datasæt: zip, concat, union
            int[] vectorA = { 0, 2, 4, 5, 6 };
            int[] vectorB = { 1, 3, 5, 7, 8 };

            int dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();

            Console.WriteLine($"Dot product: {dotProduct}");

            Console.WriteLine();
            //join: This sample shows how to efficiently
            //join elements of two sequences based on equality between key expressions over the two.

            string[] categories = {
                "Projektleder",
                "Pædagog",
                "Seniordesigner",
                "Flyleder",
                "Gartner"
            };

            //List<Product> products = GetProductList();

            //var q = from c in categories
            //        join p in products on c equals p.Category
            //        select (Category: c, p.ProductName);

            //foreach (var v in q)
            //{
            //    Console.WriteLine(v.ProductName + ": " + v.Category);
            //}
            Console.ReadLine();
        }
    }
}
