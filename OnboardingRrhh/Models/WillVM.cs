using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnboardingRrhh.Models
{
    public class WillVM
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Peso { get; set; }
        public string Will { get; set; }
        public bool PorDefecto { get; set; }
    }
}