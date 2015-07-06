using System.ComponentModel.DataAnnotations;

namespace MvcRefactor.Entity
{
    public class Uniform
    {
        [Key]
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string HomeUniforms { get; set; }

        public string AwayUniforms { get; set; }

        public bool Enabled { get; set; }
    }
}
