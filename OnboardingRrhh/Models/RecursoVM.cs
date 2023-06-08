using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnboardingRrhh.Models
{
    public class RecursoVM
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public bool PorDefecto { get; set; }
    }
}