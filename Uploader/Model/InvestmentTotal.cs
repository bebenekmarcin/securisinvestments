using System;

namespace Uploader.Model
{
    public class InvestmentTotal
    {
        public Guid InvestmentTotalId { get; set; }
        public long ValueTotal { get; set; }
        public long CollateralTotal { get; set; }
        public long NetTotal { get; set; }
    }
}
