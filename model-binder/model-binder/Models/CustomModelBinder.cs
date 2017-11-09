using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace model_binder.Models
{
    public class CustomModelBinder : IModelBinder
    {
        public CustomModelBinder()
        {
            
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(TestData))
            {
                return false;
            }

            ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }

            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
                return false;
            }
            TestData result = new TestData();

            // ---
            var parts = key.Split(',');
            var list = new List<string>();
            foreach (var part in parts)
            {
                list.Add(part);
            }
            result = new TestData { Message = list };
            // ---
            
            if (parts.Length > 1)
            {
                bindingContext.Model = result;
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value to TestData");
            return false;
        }
    }
}