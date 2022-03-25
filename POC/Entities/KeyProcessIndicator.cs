using OfficeOpenXml;
using POC.Exceptions;
using POC.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            DateTime currentReference = ValidadeReferenceData(reference);

            var file = File.OpenRead(Directory.GetCurrentDirectory() + "/Assets/Dados KPI.xlsx");

            using var memoryStream = new MemoryStream();
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
                    var period = baseLine.AddDays(int.Parse(excelWorksheet.Cells[i, 1].Value.ToString())).Date;
                    if (period > DateTime.Now.Date)
                    {
                        if (++i > totalRows)
                        {
                            break;
                        }
                        continue;
                    }
                    if (period < currentReference) break;
                    Period.Add(period);

                    var delivery = int.Parse((excelWorksheet.Cells[i, 2].Value.ToString()));
                    Deliverys.Add(delivery);

                    var lateDelivery = int.Parse((excelWorksheet.Cells[i, 3].Value.ToString()));
                    LateDeliveries.Add(lateDelivery);

                    var middleTime = int.Parse((excelWorksheet.Cells[i, 4].Value.ToString()));
                    MiddleTimeBetweenDeliveries.Add(middleTime);

                    var cityQuantity = int.Parse((excelWorksheet.Cells[i, 5].Value.ToString()));
                    CityQuantity.Add(cityQuantity);

                    var revenues = double.Parse((excelWorksheet.Cells[i, 6].Value.ToString()));
                    Revenues.Add(revenues);
                    string revenueString = revenues.ToString().Replace(",", ".");

                    retorno = retorno + period + "," + delivery + "," + lateDelivery + "," + middleTime + "," + cityQuantity + "," + revenueString + "\n";

                    if (++i > totalRows)
                    {
                        break;
                    }
                }

                Console.Write(retorno);
            }

            return retorno;
        }

        public string GetDataToFunction(DateTime reference)
        {
            DateTime currentReference = ValidadeReferenceData(reference);
            var fileByte = FileMock.GetFile();
            var fileString = Encoding.UTF8.GetString(fileByte);
            List<string> lines = fileString.Split(Environment.NewLine).ToList();

            var csv = new StringBuilder();
            string retorno = ";Entregas Realizadas;Entregas com Atraso;Tempo Médio Entrega (Dias);Municipios Atendidos;Faturamento" + "\n";
            csv.Append(retorno);

            foreach (string line in lines)
            {
                var elements = line.Split(";");
                var period = DateTime.Parse(elements[0]).Date;

                if(period > DateTime.Now.Date)
                {
                    continue;
                }
                if (period < currentReference) break;

                Period.Add(period);

                var delivery = int.Parse(elements[1]);
                Deliverys.Add(delivery);

                var lateDelivery = int.Parse(elements[2]);
                LateDeliveries.Add(lateDelivery);

                var middleTime = int.Parse(elements[3]);
                MiddleTimeBetweenDeliveries.Add(middleTime);

                var cityQuantity = int.Parse(elements[4]);
                CityQuantity.Add(cityQuantity);

                var revenues = double.Parse(elements[5]);
                Revenues.Add(revenues);

                retorno = period.ToString() + ";" + delivery + ";" + lateDelivery + ";" + middleTime + ";" + cityQuantity + ";" + revenues + "\n";
                csv.Append(retorno);
            }

            return csv.ToString().Replace("\n","!").Replace("!", Environment.NewLine);
        }

        private static DateTime ValidadeReferenceData(DateTime reference)
        {
            var currentReference = new DateTime(reference.Year, reference.Month, 1);
            if (currentReference > DateTime.Now)
            {
                throw new BoaEntregaException("Data de corte inválida");
            }

            return currentReference;
        }
    }
}
