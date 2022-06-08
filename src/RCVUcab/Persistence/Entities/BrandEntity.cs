using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities
{
    public class BrandEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<ProviderEntity> Providers { get; set; }
    }
}
