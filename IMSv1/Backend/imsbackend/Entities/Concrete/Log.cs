using System.ComponentModel.DataAnnotations;
using System;

namespace imsbackend.Entities.Concrete
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Status { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string OperationType { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserType { get; set; }
    }
}
