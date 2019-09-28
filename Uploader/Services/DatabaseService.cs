using System.Collections.Generic;
using Uploader.Model;

namespace Uploader.Services
{
    public class DatabaseService : IDatabaseService
    {
        public void SaveInvestments(IList<Investment> investments)
        {
            using var db = new DatabaseContext();
            db.Investments.AddRange(investments);
            db.SaveChanges();
        }

        public void SaveInvestmentTotal(InvestmentTotal investmentTotal)
        {
            using var db = new DatabaseContext();
            db.InvestmentTotals.Add(investmentTotal);
            db.SaveChanges();
        }
    }
}
