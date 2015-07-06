using System.ComponentModel.DataAnnotations;

namespace MvcRefactor.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Pwd { get; set; }

        public int RoleId { get; set; }

        public bool Enabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSign { get; set; }
    }
}
