using OfficeOpenXml;
using POC.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace POC.Entities
{
    public class KeyProcessIndicator
    {
        public List<DateTime> Period { get; set; }
        public List<int> Deliverys { get; set; }
        public List<int> LateDeliveries { get; set; }
        public List<int> MiddleTimeBetweenDeliveries { get; set; }
        public List<int> CityQuantity { get; set; }
        public List<double> Revenues { get; set; }

        public KeyProcessIndicator()
        {
            Period = new List<DateTime>();
            Deliverys = new List<int>();
            LateDeliveries = new List<int>();
            MiddleTimeBetweenDeliveries = new List<int>();
            CityQuantity = new List<int>();
            Revenues = new List<double>();
        }

        public async Task<string> GetData(DateTime reference)
        {
            string retorno;
            var currentReference = new DateTime(reference.Year, reference.Month, 1);
            if (currentReference > DateTime.Now)
            {
                { throw new BoaEntregaException("Data de corte inválida"); }
            }

            var file = File.OpenRead("Assets/Dados KPI.xlsx");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var arquivoParametros = new ExcelPackage(memoryStream))
                {

                    var excelWorksheet = arquivoParametros.Workbook
                        .Worksheets["Data"];

                    var totalRows = excelWorksheet.Dimension?.Rows;
                    int i = 2;

                    DateTime baseLine = new DateTime(1900, 01, 01);

                    retorno = ",Entregas Realizadas,Entregas com Atraso,Tempo Médio Entrega (Dias),Municipios Atendidos,Faturamento\n";

                    while (excelWorksheet.Cells[i, 1].Value != null
                       && !string.IsNullOrEmpty(excelWorksheet.Cells[i, 1].ToString()))
                    {
                        var period = baseLine.AddDays(Int32.Parse(excelWorksheet.Cells[i, 1].Value.ToString())).Date;
                        if (period > DateTime.Now.Date)
                        {
                            if (++i > totalRows)
                            {
                                break;
                            }
                            continue;
                        };
                        if (period < currentReference) break;
                        Period.Add(period);

                        var delivery = Int32.Parse((excelWorksheet.Cells[i, 2].Value.ToString()));
                        Deliverys.Add(delivery);

                        var lateDelivery = Int32.Parse((excelWorksheet.Cells[i, 3].Value.ToString()));
                        LateDeliveries.Add(lateDelivery);

                        var middleTime = Int32.Parse((excelWorksheet.Cells[i, 4].Value.ToString()));
                        MiddleTimeBetweenDeliveries.Add(middleTime);

                        var cityQuantity = Int32.Parse((excelWorksheet.Cells[i, 5].Value.ToString()));
                        CityQuantity.Add(cityQuantity);

                        var revenues = Double.Parse((excelWorksheet.Cells[i, 6].Value.ToString()));
                        Revenues.Add(revenues);
                        string revenueString = revenues.ToString().Replace(",", ".");

                        retorno = retorno + period + "," + delivery +"," + lateDelivery + "," + middleTime + "," + cityQuantity + "," + revenueString + "\n";

                        if (++i > totalRows)
                        {
                            break;
                        }
                    }

                    Console.Write(retorno);
                }

                return retorno;
            }
        }
    }
}
