using System.Collections.Generic;
using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using System.Linq;
using System.IO;

namespace FlooringOrderingSystem.Data
{
    public class FileTaxRepository : ITaxRepository
    {
        private string _filePath;

        public FileTaxRepository(string filePath)
        {
            _filePath = filePath;
        }

        private IEnumerable<Tax> _taxs;

        public void GetTaxsFromFile()
        {
            List<Tax> taxs = new List<Tax>() ;
            using(StreamReader streamReader = new StreamReader(_filePath))
            {
                string line = "";
                streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {               
                    string[] columns = line.Split(',');
                    Tax tax = new Tax
                    {
                        StateAbbreviation = columns[0],
                        StateName = columns[1],
                        TaxRate = decimal.Parse(columns[2])
                    };
                    taxs.Add(tax);
                }
            }
            _taxs = taxs;
        }

        public IEnumerable<Tax> PullTaxs(string state)
        {
            GetTaxsFromFile();
            return _taxs.Where(tax => tax.StateAbbreviation == state);
        }

        public IEnumerable<Tax> PullTaxs()
        {
            GetTaxsFromFile();
            return _taxs;

        }
    }
}