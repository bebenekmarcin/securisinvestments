using System.Collections.Generic;
using Uploader.Model;

namespace Uploader.Services
{
    public interface ICsvService
    {
        IList<Investment> GetInvestments(string filePath);

        void SaveInvestments(string filePath, IList<Investment> investments);
    }
}