<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TestApp.Test" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="./Content/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
    <h3 style="text-align:center;margin:15px;">AUDoco - Pagina de Prueba</h3>
    <div class="row">
      <div class="col-md-6">
         <div class="card">
            <div class="card-header"><h4>Generar Factura</h4>
               Genera una imagen de una factura con el codigo QR
            </div>
            <div class="card-body">
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">Tipo:</label>
                  <div class="col-sm-8"><strong>B</strong></div>
               </div>
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">PuntoVenta:</label>
                  <div class="col-sm-4">
                  <asp:TextBox class="form-control" runat="server" ID="FactPuntoVenta" MaxLength="3"></asp:TextBox>
                  </div>
               </div>
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">Numero:</label>
                  <div class="col-sm-6">
                     <asp:TextBox class="form-control" runat="server" ID="FactNumero" MaxLength="8"></asp:TextBox>
                  </div>
               </div>
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">Fecha:</label>
                  <div class="col-sm-6">
                     <asp:TextBox class="form-control" runat="server" ID="Fecha" MaxLength="10"></asp:TextBox>
                  </div>
                  <div class="col-sm-2">
                     <small class="text-muted">
                        dd/mm/aaaa
                     </small>
                  </div>
               </div>
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">Razon Social:</label>
                  <div class="col-sm-8">
                     <asp:TextBox class="form-control" runat="server" ID="RazonSocial" MaxLength="100"></asp:TextBox>
                  </div>
               </div>
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">CUIT:</label>
                  <div class="col-sm-8">
                     <asp:TextBox class="form-control" runat="server" ID="CUIT" MaxLength="13"></asp:TextBox>
                  </div>
               </div>
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">Direccion:</label>
                  <div class="col-sm-8">
                     <asp:TextBox class="form-control" runat="server" ID="Direccion"></asp:TextBox>
                  </div>
               </div>
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">Importe Total:</label>
                  <div class="col-sm-6">
                     <asp:TextBox class="form-control" runat="server" ID="ImporteTotal" MaxLength="20"></asp:TextBox>
                  </div>
                  <div class="col-sm-2">
                     <small class="text-muted">
                        #.##
                     </small>
                  </div>
               </div>
               <div class="row form-group">
                  <div class="col-sm-12 text-center">
                     <asp:LinkButton class="btn btn-primary" runat="server" ID="FactEnviar" OnClick="FactEnviar_Click">Enviar</asp:LinkButton>
                  </div>
               </div>
             </div>
         </div>
      </div>
      <div class="col-md-6">
         <div class="card">
            <div class="card-header"><h4>Leer Factura</h4>
               A partir de una imagen de una factura con QR muestra los datos de la misma
            </div>
            <div class="card-body">
               <div class="row form-group">
                  <label class="col-sm-4 col-form-label">Archivo:</label>
                  <div class="col-sm-8">
                     <asp:FileUpload class="form-control-file" runat="server" ID="FileUpload"/>
                  </div>
               </div>
               <div class="row form-group">
                  <div class="col-sm-12 text-center">
                     <asp:LinkButton class="btn btn-primary" runat="server" ID="Consultar" OnClick="Consultar_Click">Consultar</asp:LinkButton>
                  </div>
               </div>
               <div class="row form-group">
                  <div class="col-sm-12 text-center">
                     <asp:TextBox class="form-control" runat="server" ID="Respuesta" TextMode="MultiLine" Rows="10"></asp:TextBox>
                  </div>
               </div>
            </div>
         </div>

      </div>
    </div>

    </form>
    <script src="./Scripts/jquery-3.0.0.slim.min.js"></script>
    <script src="./Scripts/umd/popper.min.js"></script>
    <script src="./Scripts/bootstrap.min.js"></script>
</body>
</html>
