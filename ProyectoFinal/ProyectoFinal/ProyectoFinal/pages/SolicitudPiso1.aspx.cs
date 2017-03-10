using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.pages
{
    public partial class SolicitudPiso1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            btnAula1.CssClass = "btn btn-danger";
            btnAula1.Text = "Ocupado";
            btnAula2.CssClass = "btn btn-success";
            btnAula2.Text = "Dispoinble";

        }

        protected void Unnamed2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Unnamed2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}