using System.Collections.Generic;
using Uploader.Model;

namespace Uploader.Services
{
    public interface IAggregator
    {
        InvestmentTotal GetTotals(IList<Investment> investments);
    }
}