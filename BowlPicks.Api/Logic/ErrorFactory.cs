using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BowlPicks.Api.Logic
{
    public interface IErrorFactory
    {
        void SetAuthErrorResponse(string reason);
    }
    public class ErrorFactory :IErrorFactory
    {
        public void SetAuthErrorResponse(string reason)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent(reason),
                ReasonPhrase = "Forbidden"
            });
        }
    }
}