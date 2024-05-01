using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegMedLINQ
{
    internal class DataListe
    {
        public class PersonData
        {
            public int ID { get; set; }
            public string Køn { get; set; }
            public string Navn { get; set; }
            public string Telefon { get; set; }
            public string PostNr { get; set; }
            public string By { get; set; }
            public int Alder { get; set; }
            public string Stilling { get; set; }
            public decimal Løn { get; set; }

        }

        public static class Person
        {
            public static List<PersonData> PersonListe { get; } =
                new List<PersonData>
            {
                new PersonData {ID = 1, Køn = "mand", Navn = "Jens Olsen",    Telefon = "22722877", PostNr = "2800", By = "Lyngby", Alder = 39, Stilling = "Gartner", Løn = 29000 },
                new PersonData {ID = 2, Køn = "mand", Navn = "Hans Hansen",   Telefon = "26267123", PostNr = "2900", By = "Hellerup", Alder = 28, Stilling = "Projektleder", Løn = 42000},
                new PersonData {ID = 3, Køn = "mand", Navn = "Peter Sørensen",Telefon = "42462124", PostNr = "3400", By = "Hillerød", Alder = 56, Stilling = "Flyleder", Løn = 54000},
                new PersonData {ID = 4, Køn = "kvinde", Navn = "Pia Hansen",Telefon = "23543467", PostNr = "2900", By = "Hellerup", Alder = 53, Stilling = "Pædagog", Løn = 32000},
                new PersonData {ID = 5, Køn = "kvinde", Navn = "Sofie Sølvtoft",Telefon = "25098978", PostNr = "2750", By = "Ballerup", Alder = 35, Stilling = "Seniordesigner", Løn = 52000},
                new PersonData {ID = 6, Køn = "kvinde", Navn = "Anja Larsen",Telefon = "27743475", PostNr = "2300", By = "København S", Alder = 39, Stilling = "Projektleder", Løn = 43000}
            };
        }

    }
}
