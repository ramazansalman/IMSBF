using System.ComponentModel.DataAnnotations.Schema;

namespace imsbackend.Entities.Concrete
{
    public class Immovable
    {
        public int Id { get; set; }
        public string Block { get; set; } // Ada translated as Block
        public string Parcel { get; set; }
        public string Type { get; set; } // Land, Field, Residence
        public string Coordinates { get; set; }

        [ForeignKey("NeighborhoodId")]
        public int NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
