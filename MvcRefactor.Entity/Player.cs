using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcRefactor.Entity
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        public string Pwd { get; set; }

        public int UserId { get; set; }

        public string Avatar { get; set; }

        public Int16 Age { get; set; }

        public string Records { get; set; }

        public List<PlayerRating> PlayerRatings { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Enabled { get; set; }
    }
}
