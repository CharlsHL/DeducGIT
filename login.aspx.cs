using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DeduccionIMP
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string patron = "Estudio1";
        protected void BtnIngresar_Click1(object sender, EventArgs e)
        {
                string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                SqlCommand cmd = new SqlCommand("acceso", sqlConectar)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = tbPassword.Text;
               // cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //Agregamos una sesion de usuario
                    Session["usuariologueado"] = tbUsuario.Text;
                    Response.Redirect("index.html");
                }
                else
                {
                    lblError.Text = "Error de Usuario o Contrasenia";
                }

                cmd.Connection.Close();
        }
    }
 }
