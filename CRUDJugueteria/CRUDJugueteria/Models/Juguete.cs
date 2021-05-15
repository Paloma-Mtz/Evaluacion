using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDJugueteria.Models
{
    public class Juguete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Descripcion   { get; set; }

        [Column(TypeName = "int")]
        public int? RestriccionEdad { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Compania { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0,1000)]
        public decimal Precio { get; set; }

    }
}
