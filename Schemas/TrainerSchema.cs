using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TrainerCardBackEnd.DTOs;

public class SwaggerExampleSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(TrainerUpdateDto))
        {
            schema.Example = new OpenApiObject
            {
                ["name"] = new OpenApiString("Seth"),
                ["username"] = new OpenApiString("Sephiroth"),
                ["password"] = new OpenApiString("suaSenhaSecreta"),
                ["birth"] = new OpenApiString("03/10/2024"),
                ["region"] = new OpenApiInteger(1),
                ["city"] = new OpenApiInteger(1),
                ["type"] = new OpenApiInteger(1),
                ["photo"] = new OpenApiString("base64-encoded-image-string")
            };
        }
        else if (context.Type == typeof(TrainerCreateDto))
        {

            schema.Example = new OpenApiObject
            {
                ["name"] = new OpenApiString("Seth"),
                ["username"] = new OpenApiString("Sephiroth"),
                ["password"] = new OpenApiString("suaSenhaSecreta"),
                ["birth"] = new OpenApiString("03/10/2024"),
                ["region"] = new OpenApiInteger(1),
                ["city"] = new OpenApiInteger(1),
                ["type"] = new OpenApiInteger(1),
                ["photo"] = new OpenApiString("base64-encoded-image-string"),
                ["myPokeBox"] = new OpenApiObject
                {
                    ["pokemonsIds"] = new OpenApiArray
                    {
                        new OpenApiInteger(1),
                        new OpenApiInteger(2),
                        new OpenApiInteger(3)
                    }
                }
            };
        }
    }
}