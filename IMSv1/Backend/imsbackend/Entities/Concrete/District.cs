using System.ComponentModel.DataAnnotations.Schema;

namespace imsbackend.Entities.Concrete
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City { get; set; }
    }

}
