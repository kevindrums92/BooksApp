using Constants.Base;
using Domain.Models;
using Domain.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    /// <summary>
    /// Servicio de los books
    /// </summary>
    public class BooksService:BaseServicesModel
    {
        /// <summary>
        /// Obtiene los libros 
        /// </summary>
        /// <param name="query">texto query del filtro</param>
        /// <param name="page">página que se va a configurar</param>
        /// <returns></returns>
        public static async Task<ResponseBooksDto> GetBooksAsync(string query, int page)
        {

            var responseEntity = new ResponseBooksDto();
            try
            {
                var url = string.Format("{0}/search/{1}/page/{2}", GlobalConfig.BASE_URL, query, page);
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                wr.Method = "GET";
                wr.ContentType = "application/json";
                
                using (WebResponse response = await wr.GetResponseAsync())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        string responseString = sr.ReadToEnd();
                        responseEntity = JsonConvert.DeserializeObject<ResponseBooksDto>(responseString);
                        return responseEntity;
                    }
                }
            }
            catch (System.Net.WebException webEx)
            {
                var message = string.Format(ResourcesAgent.GetResource("strWebException"), JsonConvert.SerializeObject(webEx));
                responseEntity.Error = "Ha ocurrido un error";
                return responseEntity;
            }
            catch (Exception ex)
            {
                var message = string.Format(ResourcesAgent.GetResource("strGenericException"), JsonConvert.SerializeObject(ex));
                responseEntity.Error = "Ha ocurrido un error";
                return responseEntity;
            }
        }
    }
}
