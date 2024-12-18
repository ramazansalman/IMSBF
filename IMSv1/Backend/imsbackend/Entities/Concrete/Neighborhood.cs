using System.ComponentModel.DataAnnotations.Schema;

namespace imsbackend.Entities.Concrete
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("DistrictId")]
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
