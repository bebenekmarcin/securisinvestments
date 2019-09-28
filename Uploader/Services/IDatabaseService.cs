using System.Collections.Generic;
using Uploader.Model;

namespace Uploader.Services
{
    public interface IDatabaseService
    {
        void SaveInvestments(IList<Investment> investments);
        void SaveInvestmentTotal(InvestmentTotal investmentTotal);
    }
}