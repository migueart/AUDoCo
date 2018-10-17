using AUDoCo.QRCode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using ZXing.Common;
using ZXing.PDF417;
using ZXing.QrCode;

namespace TestApp
{
   public partial class Test : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         //Generar el codigo QR con la informacion y el link

         /*
         var jsonFactura = JObject.Parse(@"{'Clase':'FAC','Id':1419,'Tipo':'X','PuntoDeVenta':1,'Numero':'128','Fecha':'2018 - 05 - 02T00: 00:00','ClienteId':1952,'RazonSocial':'Mapal Quimica','Importe':3660.0}");
         var facturaEncode = new FacturaEncode();
         Bitmap bmp = facturaEncode.generarCodigoQR(jsonFactura, "https://cylarcomconnecting.gestionbos.com/v4/WebServices.aspx?/Facturacion/ListaPedidoComprobantes.aspx?&pedidoId=30");

         Response.ContentType = "image/bmp";
         bmp.Save(Response.OutputStream, ImageFormat.Bmp);
         /**/

         /***********************************************************/

         /*
         System.Drawing.Image img = Bitmap.FromFile(@"C:\Users\migue\Desktop\facturapreview.jpg");
         MemoryStream memoryStream = new MemoryStream();

         Bitmap bmp = new Bitmap(img);

         var facturaEncode = new FacturaEncode();
         var json = facturaEncode.ObtenerDocumentoBasico(bmp);

         img.Dispose();
         bmp.Dispose();

         Response.Write(json);
         /**/

         /***************************************************/


      }

      protected void getFacturaImagen()
      {
         
      }


      protected void getFacturaDatos()
      {
         
      }

      protected void FactEnviar_Click(object sender, EventArgs e)
      {
         JObject jsonFactura = null;

         jsonFactura = new JObject();
         jsonFactura.Add("DocTipo", "B");
         jsonFactura.Add("PtoVta", FactPuntoVenta.Text);
         jsonFactura.Add("DocNro", FactNumero.Text);
         jsonFactura.Add("CbteFch", Fecha.Text);
         jsonFactura.Add("RazonSocial", RazonSocial.Text);
         jsonFactura.Add("CUIT", CUIT.Text);
         jsonFactura.Add("Direccion", Direccion.Text);
         jsonFactura.Add("ImpTotal", ImporteTotal.Text);

         var facturaEncode = new FacturaEncode();
         Bitmap bmpQR = facturaEncode.generarCodigoQR(jsonFactura, "");

         System.Drawing.Image imgFactura = Bitmap.FromFile(Server.MapPath("./img/FacturaB.bmp"));
         var canvas = Graphics.FromImage(imgFactura);

         try 
         {
            canvas.SmoothingMode = SmoothingMode.HighQuality;
            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            canvas.DrawImage(bmpQR, new Rectangle(10, imgFactura.Height - 160, bmpQR.Width, bmpQR.Height), new Rectangle(0,0, bmpQR.Width, bmpQR.Height),GraphicsUnit.Pixel);
            canvas.Save();

            Response.ContentType = "image/png";
            Response.AddHeader("content-disposition", @"attachment;filename=""Factura.png""");
            imgFactura.Save(Response.OutputStream, ImageFormat.Png);
            Response.End();
         }
         finally
         { 
            canvas.Dispose();
            imgFactura.Dispose();
            bmpQR.Dispose();
         }
      }

      protected void Consultar_Click(object sender, EventArgs e)
      {
         Bitmap imgFactura = null;
         Bitmap imgQR = null;
         Graphics canvas = null;

         if (FileUpload.HasFile)
         {
            try
            {
               imgFactura = new Bitmap(FileUpload.FileContent);

               imgQR = new Bitmap(150,150);
               canvas = Graphics.FromImage(imgQR);

               canvas.DrawImage(imgFactura, new Rectangle(0, 0, imgQR.Width, imgQR.Height), new Rectangle(10, imgFactura.Height - 160, 150, 150), GraphicsUnit.Pixel);
               canvas.Save();

               var facturaEncode = new FacturaEncode();
               var json = facturaEncode.ObtenerDocumentoBasico(imgQR);
               if (json != null) 
               { 
                  Respuesta.Text = json.ToString();
               }
               else
               {
                  Respuesta.Text = "No se ha encontrado un codigo QR\r\n";
               }
            }
            catch (Exception ex)
            {
               Respuesta.Text = "Se ha producido un error\r\n" + ex.Message;
            }
            finally
            {
               imgFactura.Dispose();
               canvas.Dispose();
               imgQR.Dispose();
            }
         }         
      }
   }
}