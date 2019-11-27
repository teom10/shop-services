

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace rest_application.helpers
{
    public class JsonFormatter : TextOutputFormatter
    {
        public JsonFormatter()
        {
            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            this.SupportedEncodings.Add(Encoding.UTF8);
            this.SupportedEncodings.Add(Encoding.Unicode);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            if (context.Object is string)
            {
                return response.WriteAsync(context.Object.ToString());
            }
            return response.WriteAsync("No se pudo serializar el tipo: " + context.Object.GetType().FullName);
        }
    }
}
