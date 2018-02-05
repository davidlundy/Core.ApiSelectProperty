using Core.ApiSelectProperty.Sample.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.ApiSelectProperty.Sample.Results
{
    public class CustomContentResult : ActionResult
    {
        public object Value { get; }

        public CustomContentResult(object value)
        {
            Value = value;
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var query = context.HttpContext.Request.Query;
            var desiredProperties = query["select"];

            var jsonResult = JsonConvert.SerializeObject(Value, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new PropertySelectResolver(desiredProperties)
            });

            var byteResult = Encoding.UTF8.GetBytes(jsonResult);

            context.HttpContext.Response.Body.Write(byteResult, 0, byteResult.Length);

            return Task.CompletedTask;
        }
    }
}
