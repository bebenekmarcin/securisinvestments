using System;
using System.IO;
using FluentAssertions;
using Uploader.Services;
using Xunit;

namespace Uploader.IntegrationTests.Services
{
    public class CsvServiceShould
    {
        readonly CsvService _csvService;
        public CsvServiceShould()
        {
            _csvService = new CsvService();
        }

        [Fact]
        public void ReadInvestmentsFromFile()
        {
            var investments = _csvService.GetInvestments(@"Investments.csv");

            investments.Should().NotBeEmpty();
        }

        [Fact]
        public void ThrowException_WhenFileNotExists()
        {
            Action action = () =>  _csvService.GetInvestments(@"FileWhichNotExists.csv");

            action.Should().Throw<FileNotFoundException>();
        }
    }
}
