using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactor.Entity
{
    public class News
    {
        [Key]
        public int IdNews { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string SmallImage { get; set; }

        public string Meida { get; set; }

        public string Description { get; set; }

        public bool IsHot { get; set; }

        public bool Enabled { get; set; }

        public string Source { get; set; }

        public int Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}