using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Uploader.Model;

namespace Uploader.Services
{
    public class CsvService : ICsvService
    {
        public IList<Investment> GetInvestments(string filePath)
        {


            using (var reader = new StreamReader(filePath))
            {
                var investments = new List<Investment>();

                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    investments.Add(
                        new Investment
                        {
                            Fund = values[0],
                            Value = long.Parse(values[1]),
                            Collateral = long.Parse(values[2])
                        });
                }

                return investments;
            }
        }

        public void SaveInvestments(string filePath, IList<Investment> investments)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var csv = new StringBuilder();
            csv.AppendLine("Fund,Value,Collateral");

            foreach (var investment in investments)
            {
                var newLine = $"{investment.Fund},{investment.Value},{investment.Collateral}";
                csv.AppendLine(newLine);
            }

            File.WriteAllText(filePath, csv.ToString());
        }
    }
}
