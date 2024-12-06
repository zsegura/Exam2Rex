using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam2Rex.Models
{
    public class ModelEstudiante
    {
        public string Estudiante { get; set; }
        public decimal? Nota { get; set; }
        public string Distrito { get; set; }
        public string Canton { get; set; }
        public string Provincia { get; set; }
    }
}