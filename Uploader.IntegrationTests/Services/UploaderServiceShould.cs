using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Uploader.Model;
using Uploader.Services;
using Xunit;

namespace Uploader.IntegrationTests.Services
{
    public class UploaderServiceShould
    {
        private UploaderService _uploaderService;
        private DatabaseService _databaseService;

        [Fact]
        public void SaveInvestmentsInDb()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            try
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlite(connection)
                    .Options;
                using var context = new DatabaseContext(options);
                context.Database.EnsureCreated();
                _databaseService = new DatabaseService(context);
                _uploaderService = new UploaderService(new CsvService(), new Aggregator(), _databaseService);

                _uploaderService.UploadInvestmentsFromCsvToDb(@"Investments.csv");

                var investmentsAfter = _databaseService.GetInvestments();
                investmentsAfter.Should().NotBeEmpty();
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void SaveInvestmentTotalsInDb()
        {
            var filePath = @"Investments.csv";
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            try
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlite(connection)
                    .Options;
                using var context = new DatabaseContext(options);
                context.Database.EnsureCreated();
                _databaseService = new DatabaseService(context);
                var csvService = new CsvService();
                _uploaderService = new UploaderService(csvService, new Aggregator(), _databaseService);

                _uploaderService.UploadInvestmentsFromCsvToDb(filePath);

                var investmentsAfter = _databaseService.GetInvestmentTotals();
                investmentsAfter.SingleOrDefault().Should().NotBeNull();
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void SaveInvestmentsInCsv()
        {
            var fixture = new Fixture();
            List<Investment> investmentsExpected = fixture.Create<List<Investment>>();
            var filePath = @"InvestmentsFromDb.csv";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            try
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlite(connection)
                    .Options;
                using var context = new DatabaseContext(options);
                context.Database.EnsureCreated();
                _databaseService = new DatabaseService(context);
                _databaseService.SaveInvestments(investmentsExpected);
                var csvService = new CsvService();

                _uploaderService = new UploaderService(csvService, new Aggregator(), _databaseService);

                _uploaderService.UploadInvestmentsFromDbToCsv(filePath);


                var investmentsInCsv = csvService.GetInvestments(filePath);

                investmentsInCsv
                    .Select(i => (i.Fund, i.Value, i.Collateral))
                    .Should().BeEquivalentTo(investmentsExpected
                    .Select(i => (i.Fund, i.Value, i.Collateral)));
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
