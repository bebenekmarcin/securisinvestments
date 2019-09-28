using System;
using System.Collections.Generic;
using System.IO;
using AutoFixture;
using FluentAssertions;
using Uploader.Model;
using Uploader.Services;
using Xunit;

namespace Uploader.IntegrationTests.Services
{
    public class CsvServiceShould
    {
        readonly Fixture _fixture;
        readonly CsvService _csvService;
        public CsvServiceShould()
        {
            _csvService = new CsvService();
            _fixture = new Fixture();
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
            Action action = () => _csvService.GetInvestments(@"FileWhichNotExists.csv");

            action.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void SaveInvestmentsToCsvFile()
        {
            var filePath = @"InvestmentsFromDb.csv";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var investments = _fixture.Create<List<Investment>>();
           
            _csvService.SaveInvestments(filePath, investments);

            File.Exists(filePath).Should().BeTrue();
        }
    }
}
