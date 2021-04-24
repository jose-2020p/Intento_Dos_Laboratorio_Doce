using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intento_Dos_Laboratorio_Doce
{
    public partial class _Default : Page
    {
        static List<Estudiantes_Clase> estudiante_array = new List<Estudiantes_Clase>();
        static List<Curso_Clase> curso_array = new List<Curso_Clase>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string archivo = Server.MapPath("Datos.json");
                StreamReader jsonStream = File.OpenText(archivo);
                string json = jsonStream.ReadToEnd();
                jsonStream.Close();

                if (json.Length > 0)
                {
                    estudiante_array = JsonConvert.DeserializeObject<List<Estudiantes_Clase>>(json);
                }
            }
        }
        public void Json()
        {
            string json = JsonConvert.SerializeObject(estudiante_array);
            string archivo = Server.MapPath("Datos.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        public void estudiantes()
        {
            Estudiantes_Clase busqueda_estudiante = estudiante_array.Find(x => x.Nombre_estudiante == TextBoxEstudiante.Text);

            for (int i = 0; i < estudiante_array.Count(); i++)
            {
                if (estudiante_array[i].Nombre_estudiante == TextBoxEstudiante.Text)
                {
                    for (int a = 0; a < curso_array.Count(); a++) 
                    {
                        //estudiante_array[i].Vector_curso[a] = TextBoxCurso.Text;
                    
                    }
                    // intento 2
                    //Curso_Clase alestudiate = new Curso_Clase();
                    //alestudiate.Nombre_curso = TextBoxCurso.Text;

                    //curso_array.Add(alestudiate);
                    //Json();
                    //curso_array.Clear();

                    //intento 1
                    //Estudiantes_Clase existente = new Estudiantes_Clase();
                    //existente.Nombre_estudiante = busqueda_estudiante.Nombre_estudiante;
                    //existente.Vector_curso = curso_array.ToList();
                    //estudiante_array.Add(existente);
                    //Json();
                    //curso_array.Clear();
                    break;
                }
            }
            
                Estudiantes_Clase nuevo_estudiante = new Estudiantes_Clase();
                nuevo_estudiante.Nombre_estudiante = TextBoxEstudiante.Text;
                nuevo_estudiante.Vector_curso = curso_array.ToList();

                estudiante_array.Add(nuevo_estudiante);
                Json();
                curso_array.Clear();
        }
        public void notas()
        {
            //agregar notas
            Curso_Clase nuevo_curso = new Curso_Clase();
            nuevo_curso.Nombre_curso = TextBoxCurso.Text;

            curso_array.Add(nuevo_curso);
        }

        protected void ButtonEstudiantes_Click(object sender, EventArgs e)
        {
            estudiantes();

            TextBoxEstudiante.Text = ("");
            TextBoxCurso.Text = ("");
        }

        protected void ButtonNotas_Click(object sender, EventArgs e)
        {
            notas();

            TextBoxEstudiante.Text = ("");
            TextBoxCurso.Text = ("");
        }
    }
}