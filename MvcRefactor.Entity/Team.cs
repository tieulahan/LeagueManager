using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcRefactor.Entity
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public List<Player> Players { get; set; }

        public List<Position> Positions { get; set; }

        public List<Uniform> Uniforms { get; set; }

        public string Description { get; set; }

        public string Records { get; set; }

        public int UserId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
