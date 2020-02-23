using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace RMDataManager.App_Start
{
    /// <summary>
    /// AuthToken Document filter
    /// </summary>
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            //Adds a new route in swagger
            swaggerDoc.paths.Add("/token", new PathItem
            {
                //Defines command type
                post = new Operation
                {
                    //Defines category for this Filter
                    tags = new List<string> { "Auth" },

                    //Defines the type of data that we're a receiving in our parameters
                    consumes = new List<string>
                    {
                        "appliction/x-www-form-urlencoded"
                    },

                    //Definition of parameters
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData",
                            @default = "password"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = true,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = true,
                            @in = "formData"
                        }
                    }
                }
            });
        }
    }
}