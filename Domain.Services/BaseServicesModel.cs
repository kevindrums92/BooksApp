﻿using Domain.Resources;
using System.Net;

namespace Domain.Services
{
    /// <summary>
    /// Clase base de los servicios
    /// </summary>
    public class BaseServicesModel
    {
        public static string HandleWebExceptionErrors(System.Net.WebException webEx)
        {
            var responseException = "";
            switch (webEx.Status)
            {
                case WebExceptionStatus.ConnectFailure:
                    responseException = ResourcesAgent.GetResource("excConnectFailure").ToString();
                    break;
                default:
                    responseException = ResourcesAgent.GetResource("excGenericException").ToString();
                    break;
            }
            return responseException;

        }
    }
}
