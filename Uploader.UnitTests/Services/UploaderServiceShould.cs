using System.Collections.Generic;
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
        }

        [Fact]
        public void ReadDataFromCsv_WhenUploadFromCsvToDb()
        {
            _uploaderService.UploadInvestmentsFromCsvToDb(@"Investments.csv");

            _csvServiceMock.Verify(c => c.GetInvestments(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CalculateTotals_WhenUploadFromCsvToDb()
        {
            _uploaderService.UploadInvestmentsFromCsvToDb(@"Investments.csv");

            _aggregatorMock.Verify(c => c.GetTotals(It.IsAny<List<Investment>>()), Times.Once);
        }

        [Fact]
        public void SaveInvestments_WhenUploadFromCsvToDb()
        {
            _uploaderService.UploadInvestmentsFromCsvToDb(@"Investments.csv");

            _databaseServiceMock.Verify(c => c.SaveInvestments(It.IsAny<List<Investment>>()), Times.Once);
        }

        [Fact]
        public void SaveInvestmentTotal_WhenUploadFromCsvToDb()
        {
            _uploaderService.UploadInvestmentsFromCsvToDb(@"Investments.csv");

            _databaseServiceMock.Verify(c => c.SaveInvestmentTotal(It.IsAny<InvestmentTotal>()), Times.Once);
        }

        [Fact]
        public void ReadDataFromDb_WhenUploadFromDbToCsv()
        {
            _uploaderService.UploadInvestmentsFromDbToCsv(@"InvestmentsFromDbToCsv.csv");

            _databaseServiceMock.Verify(c => c.GetInvestments(), Times.Once);
        }

        [Fact]
        public void SaveInvestments_WhenUploadFromDbToCsv()
        {
            _uploaderService.UploadInvestmentsFromDbToCsv(@"InvestmentsFromDbToCsv.csv");

            _csvServiceMock.Verify(c => 
                c.SaveInvestments(It.IsAny<string>(),It.IsAny<List<Investment>>()), 
                Times.Once);
        }
    }
}
