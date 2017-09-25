using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.Test
{
    public class TestDb
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        public string Nazwa { get; set; }

        [MaxLength(512)]
        public string Opis { get; set; }
    }
}