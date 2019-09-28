using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Uploader.Model;
using Uploader.Services;
using Xunit;

namespace Uploader.UnitTests.Services
{
    public class AggregatorShould
    {
        readonly Fixture _fixture;
        readonly Aggregator _aggregator;

        public AggregatorShould()
        {
            _fixture = new Fixture();
            _aggregator = new Aggregator();
        }

        [Fact]
        public void CalculateValueTotal()
        {
            List<Investment> investments = _fixture.Create<List<Investment>>();
            var expected = investments.Sum(i => i.Value);

            var investmentTotal = _aggregator.GetTotals(investments);

            investmentTotal.ValueTotal.Should().Be(expected);
        }

        [Fact]
        public void CalculateCollateralTotal()
        {
            List<Investment> investments = _fixture.Create<List<Investment>>();
            var expected = investments.Sum(i => i.Collateral);

            var investmentTotal = _aggregator.GetTotals(investments);

            investmentTotal.CollateralTotal.Should().Be(expected);
        }

        [Fact]
        public void CalculateNetTotal()
        {
            List<Investment> investments = _fixture.Create<List<Investment>>();
            var expected = investments.Sum(i => i.Net);

            var investmentTotal = _aggregator.GetTotals(investments);

            investmentTotal.NetTotal.Should().Be(expected);
        }
    }
}

