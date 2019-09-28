namespace Uploader.Services
{
    public interface IUploaderService
    {
        void UploadInvestmentsFromCsvToDb(string filePath);

        void UploadInvestmentsFromDbToCsv(string filePath);
    }
}