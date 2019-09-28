namespace Uploader.Services
{
    public class UploaderService : IUploaderService
    {
        private readonly ICsvService _csvService;
        private readonly IAggregator _aggregator;
        private readonly IDatabaseService _databaseService;

        public UploaderService(ICsvService csvService, IAggregator aggregator, IDatabaseService databaseService)
        {
            _csvService = csvService;
            _aggregator = aggregator;
            _databaseService = databaseService;
        }

        public void UploadInvestmentsFromCsvToDb(string filePath)
        {
            var investments = _csvService.GetInvestments(filePath);
            var investmentTotal = _aggregator.GetTotals(investments);
            
            _databaseService.SaveInvestments(investments);
            _databaseService.SaveInvestmentTotal(investmentTotal);
        }

        public void UploadInvestmentsFromDbToCsv(string filePath)
        {
            var investments = _databaseService.GetInvestments();
            _csvService.SaveInvestments(filePath, investments);
        }
    }
}
