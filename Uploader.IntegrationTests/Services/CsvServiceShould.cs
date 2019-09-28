using System;
using System.IO;
using FluentAssertions;
using Uploader.Services;
using Xunit;

namespace Uploader.IntegrationTests.Services
{
    public class CsvServiceShould
    {
        [Fact]
        public void ReadInvestmentsFromFile()
        {
            var csvService = new CsvService();

            var investments = csvService.GetInvestments(@"Investments.csv");

            investments.Should().NotBeEmpty();
        }

        [Fact]
        public void ThrowException_WhenFileNotExists()
        {
            var csvService = new CsvService();

            Action action = () =>  csvService.GetInvestments(@"FileWhichNotExists.csv");

            action.Should().Throw<FileNotFoundException>();
        }
    }
}
