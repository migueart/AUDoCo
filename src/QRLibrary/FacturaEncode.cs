using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace AUDoCo.QRCode
{
   public class FacturaEncode: DocumentoBaseEncode
   {
      private const string TIPO_DOCUMENTO = "FAC";

      /// <summary>
      /// Genera un Codigo QR que contien un objeto Json con la informacion basica de la Factura y la URL del WebService
      /// </summary>
      /// <param name="jsonFacturaBasico">Objeto Json con los datos de la Factura</param>
      /// <param name="WebServiceUniqueURL">URL del Web Service para consultar los datos completos</param>
      /// <returns></returns>
      public Bitmap generarCodigoQR(JObject jsonFacturaBasico, string WebServiceUniqueURL)
      {
         //TODO: Validaciones de datos de factura basicos para el json

         return base.generarCodigoQR(jsonFacturaBasico, WebServiceUniqueURL, TIPO_DOCUMENTO);
      }

      /// <summary>
      /// Obtiene los datos basicos de la Factura contenidos dentro del codigo QR
      /// </summary>
      /// <param name="ImageFactura">Bitmap de la Factura que contiene el codigo QR</param>
      /// <returns></returns>
      public new JObject ObtenerDocumentoBasico(Bitmap ImageFactura)
      {
         //TODO: Validaciones de datos de factura basicos para el json incluido en el QR

         return base.ObtenerDocumentoBasico(ImageFactura);
      }

      /// <summary>
      /// Obtiene los datos completos de la Factura realizando la consulta al webservice
      /// </summary>
      /// <param name="ImageFactura">Bitmap de la Factura que contiene el codigo QR</param>
      /// <returns></returns>
      public new JObject ObtenerDocumento(Bitmap ImageFactura)
      {
         //TODO: Validaciones de datos de factura para el json devuelto por el webservice

         return base.ObtenerDocumento(ImageFactura);
      }
   }
}
