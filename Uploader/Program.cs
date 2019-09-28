using System;
using Uploader.Services;

namespace Uploader
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new DatabaseContext();
            context.Database.EnsureCreated();
            var databaseService = new DatabaseService(context);
            var uploaderService = new UploaderService(new CsvService(), new Aggregator(), databaseService);
            var filePath = @"Investments.csv";
            var filePathFromDb = @"InvestmentsFromDb.csv";

            uploaderService.UploadInvestmentsFromCsvToDb(filePath);
            uploaderService.UploadInvestmentsFromDbToCsv(filePathFromDb);

            Console.WriteLine("Hello World!");
        }
    }
}
