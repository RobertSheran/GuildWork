using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FlooringOrderingSystem.Data
{
    public class TaxTestRepository : ITaxRepository
    {
        private static Tax _tax = new Tax
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 6.25M
        };
        private static Tax _tax2 = new Tax
        {
            StateAbbreviation = "WA",
            StateName = "Washington",
            TaxRate = 5.25M
        };
        private static Tax _tax3 = new Tax
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 5.25M
        };
        private static Tax _tax4 = new Tax
        {
            StateAbbreviation = "PA",
            StateName = "Pennsylvania",
            TaxRate = 6.5M
        };
        private IEnumerable<Tax> _taxs = new List<Tax>
        {
            _tax,
            _tax2,
            _tax3,
            _tax4
        };

        public IEnumerable<Tax> PullTaxs(string state)
        {
            return _taxs.Where(tax => tax.StateAbbreviation == state);
        }

        public IEnumerable<Tax> PullTaxs()
        {
            return _taxs;
        }
    }
}
