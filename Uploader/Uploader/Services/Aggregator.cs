using System.Collections.Generic;
using System.Linq;
using Uploader.Model;

namespace Uploader.Services
{
    public class Aggregator : IAggregator
    {
        public InvestmentTotal GetTotals(IList<Investment> investments)
        {
            return new InvestmentTotal
            {
                ValueTotal = investments.Sum(i => i.Value),
                CollateralTotal = investments.Sum(i => i.Collateral),
                NetTotal = investments.Sum(i => i.Net)
            };
        }
    }
}
