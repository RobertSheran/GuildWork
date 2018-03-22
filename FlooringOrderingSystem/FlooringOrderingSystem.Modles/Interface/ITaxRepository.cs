using System.Collections.Generic;

namespace FlooringOrderingSystem.Modles.Interface
{
    public interface ITaxRepository
    {
        IEnumerable<Tax> PullTaxs(string state);
        //this is so i can easily display all the available states
        IEnumerable<Tax> PullTaxs();
    }
}
