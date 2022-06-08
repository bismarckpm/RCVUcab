using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities
{
    public class ProviderEntity : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<BrandEntity> Brands { get; set; }
    }
}
