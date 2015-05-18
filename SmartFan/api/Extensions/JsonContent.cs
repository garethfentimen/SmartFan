using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SmartFan.api.Extensions
{
    public class JsonContent : HttpContent
    {

        private readonly MemoryStream _Stream = new MemoryStream();

        public JsonContent(object value)
        {

            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jw = new JsonTextWriter(new StreamWriter(this._Stream));
            jw.Formatting = Formatting.Indented;
            var serializer = new JsonSerializer();
            serializer.Serialize(jw, value);
            jw.Flush();
            this._Stream.Position = 0;

        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return this._Stream.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = this._Stream.Length;
            return true;
        }
    }
}