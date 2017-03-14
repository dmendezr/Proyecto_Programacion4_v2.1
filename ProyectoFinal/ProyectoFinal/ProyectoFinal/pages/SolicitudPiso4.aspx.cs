using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.pages
{
    public partial class SolicitudPiso4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            btnAula1Piso4.CssClass = "btn btn-danger";
            btnAula1Piso4.Text = "Ocupado";
            btnAula2Piso4.CssClass = "btn btn-success";
            btnAula2Piso4.Text = "Dispoinble";
        }

        protected void Unnamed2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Para el examen
        //linqu
        //mas semana 10
    }
}