using System;

namespace Uploader.Model
{
    public class InvestmentTotal
    {
        public int InvestmentTotalId { get; set; }
        public long ValueTotal { get; set; }
        public long CollateralTotal { get; set; }
        public long NetTotal { get; set; }
    }
}
