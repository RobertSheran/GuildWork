using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using FlooringOrderingSystem.Modles.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlooringOrderingSystem.BLL
{
    public class TaxManager
    {
        private ITaxRepository _taxRepository;
        public TaxManager(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public IEnumerable<Tax> LookupTax(string state)
        {
            return _taxRepository.PullTaxs(state);
        }

        public IEnumerable<Tax> GetTaxs()
        {
            return _taxRepository.PullTaxs();
        }
    }
}
