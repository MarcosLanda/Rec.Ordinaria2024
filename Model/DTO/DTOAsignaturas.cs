using Refuerzo2024.Model.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuerzo2024.Model.DTO
{
    internal class DTOAsignaturas : dbContext
    {
        private int idAsignaturas;
        private string nombreAsignaruras;
        private string codigo;
        private int idEspecialidad;
        private string nombreEspecialidad;
        private int idFacultad;
        private string Facultad;

        public int IdAsignaturas { get => idAsignaturas; set => idAsignaturas = value; }
        public string NombreAsignaruras { get => nombreAsignaruras; set => nombreAsignaruras = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public string NombreEspecialidad { get => nombreEspecialidad; set => nombreEspecialidad = value; }
        public int IdFacultad { get => idFacultad; set => idFacultad = value; }
        public string Facultad1 { get => Facultad; set => Facultad = value; }
    }
}
