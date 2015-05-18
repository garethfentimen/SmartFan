namespace SmartFan.api.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using SmartFan.api.Extensions;

    public class HelpController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage  Get()
        {
            var jsonResult = new JsonContent(new
                {
                    Success = true,
                    Message = "OK we have a working API!"
                });

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = jsonResult };
        }
    }
}
