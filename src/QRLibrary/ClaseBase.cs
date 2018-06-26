using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AUDoCo.QRCode
{
   public abstract class ClaseBase
   {
      /* DEFINICION JSON_BASE v1.0
      *  {
      *     AUDoCoVersion: "1.0",
      *     TipoDocumento: (string | "FACT"),
      *     WebServiceURL: (string),
      *     Documento: (JObject),
      *  }
      */

      protected JObject newJsonBase()
      {
         JObject jsonObject;

         jsonObject = new JObject();
         jsonObject.Add("AUDoCoVersion", "1.0");
         jsonObject.Add("TipoDocumento", "");
         jsonObject.Add("WebServiceURL", "");
         jsonObject.Add("Documento", null);

         return jsonObject;
      }

      public string AUDoCoVersion
      {
         get { return "1.0"; }
      }

   }
}
