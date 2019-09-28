using System.Collections.Generic;
using Uploader.Model;

namespace Uploader.Services
{
    public interface IDatabaseService
    {
        IList<Investment> GetInvestments();
        void SaveInvestments(IList<Investment> investments);
        void SaveInvestmentTotal(InvestmentTotal investmentTotal);
    }
}