using DVDDatabaseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDDataBaseModel
{
    class MovieCatalogEntities : DbContext
    {
        public MovieCatalogEntities()
              : base("EFRepository")
        {
        }

        public DbSet<DVD> Movies { get; set; }

    }
}
