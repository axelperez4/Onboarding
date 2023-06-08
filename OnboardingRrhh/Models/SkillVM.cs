using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnboardingRrhh.Models
{
    public class SkillVM
    {
        public int Id { get; set; }
        public string Skill { get; set; }
        public string Descripcion { get; set; }
        public bool PorDefecto { get; set; }
    }
}