using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace exaInnovation.Models
{
    public class Metas
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        [Display(Name = "Tareas Completadas")]
        public int TotalTareas { get; set; }
        public double Porcentaje { get; set; }
        [Display(Name ="Fecha Creada")]
        public DateTime FechaCreacion { get; set; }
        public IEnumerable<Tareas> Tareas { get; set; }
    }
}
