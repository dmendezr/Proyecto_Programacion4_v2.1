<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudPiso1.aspx.cs" Inherits="ProyectoFinal.pages.SolicitudPiso1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Solicitud</title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <!-- Bootstrap Core CSS -->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../vendor/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Morris Charts CSS -->
    <link href="../vendor/morrisjs/morris.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- Personalize CSS -->

    <link href="../styles/style1.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
        <% Response.WriteFile("Navigationheader.aspx"); %>
        <% Response.WriteFile("opcionesNavegacion.aspx"); %>
              
         <!-- page Wrapper -->
         <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Solicitud de Laboratorio</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-book fa-5x" aria-hidden="true"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">Piso 1</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-book fa-5x" aria-hidden="true"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">Piso 2</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-book fa-5x" aria-hidden="true"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">Piso 3</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-book fa-5x" aria-hidden="true"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">Piso 4</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i> Mapa de Piso
                            <div class="pull-right">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                        Actions
                                        <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu pull-right" role="menu">
                                        <li><a href="#">Action</a>
                                        </li>
                                        <li><a href="#">Another action</a>
                                        </li>
                                        <li><a href="#">Something else here</a>
                                        </li>
                                        <li class="divider"></li>
                                        <li><a href="#">Separated link</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class ="col-md-8">
                                <div class="PanelMapa">
                                    <img class="img-responsive" id ="mapaDePiso1" src="../img/Piso.png" alt="Alternate Text" />
                                    <asp:Button ID="btnAula1"  runat="server"  Text="Button" />
                                    <asp:Button ID="btnAula2"  runat="server"  Text="Button" />
                                    <asp:Button ID="btnAula3"  runat="server"  Text="Button" />
                                    <asp:Button ID="btnAula4"  runat="server"  Text="Button" />
                                    <asp:Button ID="btnAula5" class="BotonesAulas" runat="server"  Text="Button" />
                                    <asp:Button ID="btnAula6" class="BotonesAulas" runat="server" Text="Button" />
                                    <div class ="clear"></div>
                                </div>
                            </div>
                            <div class=".col-md-4">
                                <p class="text-info">Indique la fecha y el turno que desea solicitar el laboratorio</p>
                                <p class="auto-style1">
                                <br class="auto-style1" />
                                      <label for="ejemplo_email_2">Turno</label>
                                      <asp:DropDownList runat="server" OnSelectedIndexChanged="Unnamed2_SelectedIndexChanged" OnTextChanged="Unnamed2_TextChanged">
                                          <asp:ListItem>Turno 1</asp:ListItem>
                                          <asp:ListItem>Turno 2</asp:ListItem>
                                          <asp:ListItem>Turno 3</asp:ListItem>
                                          <asp:ListItem>Turno 4</asp:ListItem>
                                    </asp:DropDownList>       
                                </p>
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                            </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->                                                         
                </div>
                <!-- /.col-lg-8 -->
               
            </div>
            <!-- /.row -->
        </div>
         <!--/page Wrapper -->

        </div>
        <% Response.WriteFile("llamadaScripts.aspx"); %>
    </form>
</body>
</html>
