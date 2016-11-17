using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace MyWebApi.Models
{
    public sealed class TodoModelBinder : IModelBinder
    {
        private const string ContentType = "application/json";

        public TodoModelBinder(bool useModelName = false)
        {
            this.UseModelName = useModelName;
        }

        public bool UseModelName { get; private set; }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var httpContext = bindingContext.ActionContext.HttpContext;

            //var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            //if (valueProviderResult != ValueProviderResult.None)
            {
                //bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                if (bindingContext.ModelType == typeof(TodoItem) &&
                    (httpContext.Request.Headers["Accept"].Any(x => x.StartsWith(ContentType, StringComparison.OrdinalIgnoreCase) == true) &&
                    (httpContext.Request.ContentType.StartsWith(ContentType, StringComparison.OrdinalIgnoreCase) == true)))
                {
                    //httpContext.Request.Body.Position = 0;

                    using (var reader = new StreamReader(httpContext.Request.Body))
                    {
                        var payload = reader.ReadToEnd();

                        if (string.IsNullOrWhiteSpace(payload) == false)
                        {
                            JObject json = JObject.Parse(payload);
                            var model = new TodoItem(json);
                            //bindingContext.ModelState.SetModelValue(bindingContext.ModelName, model);

                            bindingContext.Result = ModelBindingResult.Success(model);
                            return Task.CompletedTask;

                            //return Task.FromResult<ModelBindingResult>(ModelBindingResult.Success(model));
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}