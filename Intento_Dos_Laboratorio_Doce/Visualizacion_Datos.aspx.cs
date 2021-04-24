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
    public partial class Visualizacion_Datos : System.Web.UI.Page
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
                    GridViewAlumnos.DataSource = estudiante_array;
                    GridViewAlumnos.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccionada = GridViewAlumnos.SelectedIndex;

           GridViewNotas.DataSource = estudiante_array[seleccionada].Vector_curso;
           GridViewNotas.DataBind();

        }
        public void Json()
        {
            string json = JsonConvert.SerializeObject(estudiante_array);
            string archivo = Server.MapPath("Datos.json");
            System.IO.File.WriteAllText(archivo, json);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //eliminar
            int idUniversidad = GridViewAlumnos.SelectedIndex;
            int idAlumno = GridViewNotas.SelectedIndex;


            estudiante_array[idUniversidad].Vector_curso.RemoveAt(idAlumno);




            Json();

            GridViewNotas.DataSource = estudiante_array[idUniversidad].Vector_curso;
            GridViewNotas.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //editar
            int idUniversidad = GridViewAlumnos.SelectedIndex;
            int idAlumno = GridViewNotas.SelectedIndex;

            //LabelNombre.Visible = true;
            //TextBoxNombre.Visible = true;
            //ButtonGuardar.Visible = true;

            TextBox1.Text = estudiante_array[idUniversidad].Vector_curso[idAlumno].Nombre_curso;
            Label1.Text = "Realice los cambios y luego oprima el boton GUARDAR CAMBIOS";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guardar cambios
            int idUniversidad = GridViewAlumnos.SelectedIndex;
            int idAlumno = GridViewNotas.SelectedIndex;

            estudiante_array[idUniversidad].Vector_curso[idAlumno].Nombre_curso = TextBox1.Text;

            Json();

            GridViewNotas.DataSource = estudiante_array[idUniversidad].Vector_curso;
            GridViewNotas.DataBind();

        }
    }
}