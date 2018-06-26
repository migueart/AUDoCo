using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AUDoCo.QRCode
{
   public abstract class DocumentoBaseService: DocumentoBaseEncode
   {
      public DocumentoBaseService(string URLServicio, string ClientToken, string SecretToken)
      {
         //TODO: Autenticacion
      }

      /// <summary>
      /// Publica los datos del documento con una URL unica de webservice y genera un Codigo QR que contien un objeto Json con la informacion basica del Documento y la URL del WebService
      /// </summary>
      /// <param name="jsonDocumento">Objeto Json con los datos completos del Documento</param>
      /// <returns></returns>
      protected Bitmap enviarDocumento(JObject jsonDocumentoBasico, JObject jsonDocumento, string TipoDocumento)
      {
         string sURLwebService = String.Empty;

         //TODO: Publicar documento y obtener URL

         return generarCodigoQR(jsonDocumentoBasico, sURLwebService, TipoDocumento);
      }
   }
}
