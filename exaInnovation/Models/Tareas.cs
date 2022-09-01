using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exaInnovation.Models
{
    public class Tareas
    {
        public int Id { get; set; }
        [Display(Name = "Tarea")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha")]
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public bool Prioridad { get; set; }
        public int MetasId {get;set;}
        [ForeignKey(nameof(MetasId))]
        public virtual Metas Metas { get; set; }
    }
}
