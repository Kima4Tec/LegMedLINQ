using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace LegMedLINQ
{
    internal class ExcelData
    {

            public static void HentFraExcel()
            {

                Application excel = new Application();
                Workbook workbook = excel.Workbooks.Open(@"C:\dev\MyExcelFile.xlsx");
                Worksheet worksheet = workbook.Worksheets[1];

            Range range = worksheet.UsedRange;
                int rowCount = range.Rows.Count;
                int columnCount = range.Columns.Count;

            string[,] dataArray = new string[rowCount, columnCount];

                // Loop igennem rækkerne og kolonnerne i regnearket og tilføj dataene til arrayet
                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= columnCount; j++)
                    {
                        Range cell = range.Cells[i, j];
                        if (cell.Value2 != null)
                        {
                            dataArray[i - 1, j - 1] = cell.Value2.ToString();
                        }
                    }
                }
                // loop igennem rækker og kolonner i arrayet og udskriv hver værdi
                for (int i = 0; i < dataArray.GetLength(0); i++)
                {
                    for (int j = 0; j < dataArray.GetLength(1); j++)
                    {
                        Console.Write(dataArray[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                var alder1 = Convert.ToInt32(dataArray[1, 3]);
                var alder2 = Convert.ToInt32(dataArray[2, 3]);
                var alder3 = Convert.ToInt32(dataArray[3, 3]);

                List<int> alderListe = new List<int> { alder1, alder2, alder3 };
                var lowNums = from a in alderListe
                              where a < 40
                              select a;

                Console.WriteLine("Alder < 40:");
                foreach (var x in lowNums)
                {
                    Console.WriteLine(x);
                }

            //List<Product> products = GetProductList();

            //var soldOutProducts = from prod in products
            //                      where prod.UnitsInStock == 0
            //                      select prod;

            //Console.WriteLine("Sold out products:");
            //foreach (var product in soldOutProducts)
            //{
            //    Console.WriteLine($"{product.ProductName} is sold out!");
            //}

            ////Hent alt i Excel-arket(1) og vis på skærm
            //for (int i = 1; i <= rowCount; i++)
            //{
            //    for (int j = 1; j <= columnCount; j++)
            //    {
            //        if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
            //        {
            //            Console.Write(range.Cells[i, j].Value2.ToString() + "\t");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //Output på skærm: værdi af celle(2, 2)
            //Range celleValue = worksheet.Cells[2, 2];
            //string cellValue = celleValue.Value2.ToString();
            //Console.WriteLine(cellValue);

            //Luk Excel-filen og frigør ressourcerne
            workbook.Close();
            excel.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
        }
        }
}
