using System;
using System.ComponentModel.DataAnnotations;

namespace MvcRefactor.Entity
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }

        [Required]
        public string Subscribe { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Media { get; set; }

        public string Highlights { get; set; }

        public int AuthorId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool Enabled { get; set; }
    }
}
