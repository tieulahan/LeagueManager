using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactor.Entity
{
    public class PlayerRating
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public int PointOfMatch { get; set; }

        public DateTime DateCreated { get; set; }
      
        public int UserId { get; set; }
    }
}
