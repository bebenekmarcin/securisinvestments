using System.Collections.Generic;
using Uploader.Model;

namespace Uploader.Services
{
    public interface ICsvService
    {
        IList<Investment> GetInvestments();

        void SaveInvestments(IList<Investment> investments);
    }
}