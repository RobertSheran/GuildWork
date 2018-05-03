using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMTransmissionRepo : ITransmissionRepository
    {
        List<Transmission> transmissions = new List<Transmission>()
        {
            new Transmission()
            {
                TransmissionId = 1,
                TransmissionName ="t1"
            },
            new Transmission()
            {
                TransmissionId = 2,
                TransmissionName ="t2"
            },
            new Transmission()
            {
                TransmissionId = 3,
                TransmissionName ="t3"
            },
        };
        public void Add(Transmission transmission)
        {
            transmissions.Add(transmission);
        }

        public Transmission Get(int id)
        {
            return transmissions.Where(tr => tr.TransmissionId == id).FirstOrDefault();
        }

        public List<Transmission> GetAll()
        {
            return transmissions;
        }

        public void Remove(int id)
        {
            transmissions.Remove(transmissions.Where(tr => tr.TransmissionId == id).FirstOrDefault());
        }
    }
}
