using System.Collections.Generic;

namespace exaInnovation.Models.ViewModels
{
    public class TareasViewModel
    {
        public Metas _metas { get; set; }
        public Tareas _tareas { get; set; }
        public IEnumerable<Tareas> _TareasList { get; set; }
    }
}
