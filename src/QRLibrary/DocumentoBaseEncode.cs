using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using ZXing.QrCode;
using ZXing.Common;
using ZXing;
using ZXing.QrCode.Internal;

namespace AUDoCo.QRCode
{
   public abstract class DocumentoBaseEncode: ClaseBase
   {

      private Bitmap getImagenQR(string Content)
      {
         QRCodeWriter qrWriter = new QRCodeWriter();
         BitMatrix Matrix = qrWriter.encode(Content, ZXing.BarcodeFormat.QR_CODE, 150, 150);

         BarcodeWriter bcWriter = new BarcodeWriter();
         return bcWriter.Write(Matrix);
      }

      private string getContenidoQR(Bitmap ImageDocumento)
      {
         LuminanceSource source;
         HybridBinarizer binarizer;
         BinaryBitmap binBitmap;

         source = new BitmapLuminanceSource(ImageDocumento);
         binarizer = new HybridBinarizer(source);
         binBitmap = new BinaryBitmap(binarizer);

         QRCodeReader qrReader = new QRCodeReader();
         var result = qrReader.decode(binBitmap);
         if (result == null)
         {
            return null;
         }

         return result.Text;
      }

      private string getDocumentoWebService(string URL)
      {
         string sResult;
         Stream stream;
         StreamReader stReader = null;
         HttpWebRequest externalRequest = null;
         HttpWebResponse externalResponse = null;

         externalRequest = (HttpWebRequest)WebRequest.Create(URL);
         try
         {
            externalRequest.Method = "GET";

            externalResponse = (HttpWebResponse)externalRequest.GetResponse();
            stream = externalResponse.GetResponseStream();
            stReader = new StreamReader(stream);
            sResult = stReader.ReadToEnd();
            
            return sResult;
         }
         catch (WebException exp)
         {
            throw new Exception("Se produjo un error al consultar el webservice del Documentos", exp);
         }
         finally 
         {
            if (externalResponse != null)
            {
               externalResponse.Close();
            }

            if (stReader != null)
            {
               stReader.Close();
            }
         }
      }


      /// <summary>
      /// Genera un Codigo QR que contien un objeto Json con la informacion basica del Documento y la URL del WebService
      /// </summary>
      /// <param name="jsonDocumentoBasico">Objeto Json con los datos basicos del Documento</param>
      /// <param name="WebServiceUniqueURL">URL del Web Service para consultar los datos completos</param>
      /// <returns></returns>
      protected Bitmap generarCodigoQR(JObject jsonDocumentoBasico, string WebServiceUniqueURL, string TipoDocumento)
      {
         JObject jsonObject;

         jsonObject = newJsonBase();

         jsonObject["TipoDocumento"] = TipoDocumento;
         jsonObject["WebServiceURL"] = WebServiceUniqueURL;
         jsonObject["Documento"] = jsonDocumentoBasico;

         return getImagenQR(jsonObject.ToString());
      }


      /// <summary>
      /// Obtiene los datos basicos del Documento contenidos dentro del codigo QR
      /// </summary>
      /// <param name="ImageDocumento">Bitmap del Documento que contiene el codigo QR</param>
      /// <returns></returns>
      protected JObject ObtenerDocumentoBasico(Bitmap ImageDocumento)
      {
         string contentQR;

         contentQR = getContenidoQR(ImageDocumento);
         if (contentQR == null)
         {
            return null;
         }

         return JObject.Parse(contentQR);
      }


      /// <summary>
      /// Obtiene los datos completos del Documento realizando la consulta al webservice
      /// </summary>
      /// <param name="ImageDocumento">Bitmap del Documento que contiene el codigo QR</param>
      /// <returns></returns>
      protected JObject ObtenerDocumento(Bitmap ImageDocumento)
      {
         string contentQR;
         string webServiceResult;
         JObject jsonResult;
         JObject jsonDocumento;

         contentQR = getContenidoQR(ImageDocumento);
         if (contentQR == null)
         {
            return null;
         }

         jsonResult = JObject.Parse(contentQR);

         if (jsonResult["WebServiceURL"] == null || jsonResult["WebServiceURL"].Value<string>() == String.Empty)
         {
            throw new Exception("No se encontro la URL del Webservice para el Doocumento");
         }

         webServiceResult = getDocumentoWebService(jsonResult["WebServiceURL"].Value<string>());
         jsonDocumento = JObject.Parse(webServiceResult);

         return jsonDocumento;
      }
   }
}
