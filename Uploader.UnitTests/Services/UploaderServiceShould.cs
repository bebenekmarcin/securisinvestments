using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Uploader.Model;
using Uploader.Services;
using Xunit;

namespace Uploader.UnitTests.Services
{
    public class UploaderServiceShould
    {
        readonly Mock<ICsvService> _csvServiceMock;
        readonly Mock<IAggregator> _aggregatorMock;
        readonly Mock<IDatabaseService> _databaseServiceMock;
        readonly UploaderService _uploaderService;

        public UploaderServiceShould()
        {
            _csvServiceMock = new Mock<ICsvService>();
            _aggregatorMock = new Mock<IAggregator>();
            _databaseServiceMock = new Mock<IDatabaseService>();
            _uploaderService = new UploaderService(_csvServiceMock.Object, _aggregatorMock.Object, _databaseServiceMock.Object);

            _uploaderService.UploadInvestmentsFromCsvToDb(@"Investments.csv");
        }

        [Fact]
        public void ReadDataFromCsv()
        {
            _csvServiceMock.Verify(c => c.GetInvestments(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CalculateTotals()
        {
            _aggregatorMock.Verify(c => c.GetTotals(It.IsAny<List<Investment>>()), Times.Once);
        }

        [Fact]
        public void SaveInvestments()
        {
            _databaseServiceMock.Verify(c => c.SaveInvestments(It.IsAny<List<Investment>>()), Times.Once);
        }

        [Fact]
        public void SaveInvestmentTotal()
        {
            _databaseServiceMock.Verify(c => c.SaveInvestmentTotal(It.IsAny<InvestmentTotal>()), Times.Once);
        }

    }
}
