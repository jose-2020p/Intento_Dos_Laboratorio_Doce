using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intento_Dos_Laboratorio_Doce
{
    public class Estudiantes_Clase
    {
        string nombre_estudiante;
        List<Curso_Clase> vector_curso = new List<Curso_Clase>();

        public string Nombre_estudiante { get => nombre_estudiante; set => nombre_estudiante = value; }
        public List<Curso_Clase> Vector_curso { get => vector_curso; set => vector_curso = value; }

        public Estudiantes_Clase() 
        {
            vector_curso = new List<Curso_Clase>();
        }
    }
    public class Curso_Clase 
    {
        string nombre_curso;

        public string Nombre_curso { get => nombre_curso; set => nombre_curso = value; }
    }
}