using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.pages
{
    public partial class SolicitudPiso3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            btnAula1Piso3.CssClass = "btn btn-danger";
            btnAula1Piso3.Text = "Ocupado";
            btnAula2Piso3.CssClass = "btn btn-success";
            btnAula2Piso3.Text = "Dispoinble";
        }

        protected void Unnamed2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}