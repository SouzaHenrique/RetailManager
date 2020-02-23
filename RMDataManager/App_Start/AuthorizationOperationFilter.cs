using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace RMDataManager.App_Start
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        //Add a new parameter to every operation
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if(operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                //The @in defines where we're putting this parameter, in this case in the header of the request.
                @in = "header",
                //It's gonna be how it will appear in our documentation
                description = "access token",
                required = false,
                type = "string"
            });
        }
    }
}