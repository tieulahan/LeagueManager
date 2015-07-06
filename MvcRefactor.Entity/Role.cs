using System;
using System.ComponentModel.DataAnnotations;

namespace MvcRefactor.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 1- Admin
        /// 2- Editor    
        /// </summary>
        public int Permission { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Enabled { get; set; }
    }
}
