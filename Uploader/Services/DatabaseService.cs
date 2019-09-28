using System.Collections.Generic;
using System.Linq;
using Uploader.Model;

namespace Uploader.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _db;

        public DatabaseService(DatabaseContext db)
        {
            _db = db;
        }

        public IList<Investment> GetInvestments()
        {
            return _db.Investments.ToList();
        }

        public void SaveInvestments(IList<Investment> investments)
        {
            _db.Investments.AddRange(investments);
            _db.SaveChanges();
        }

        public IList<InvestmentTotal> GetInvestmentTotals()
        {
            return _db.InvestmentTotals.ToList();
        }

        public void SaveInvestmentTotal(InvestmentTotal investmentTotal)
        {
            _db.InvestmentTotals.Add(investmentTotal);
            _db.SaveChanges();
        }
    }
}
