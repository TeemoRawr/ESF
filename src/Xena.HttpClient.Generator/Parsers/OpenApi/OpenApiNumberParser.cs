﻿using Microsoft.OpenApi.Models;
using Xena.HttpClient.Generator.Models;

namespace Xena.HttpClient.Generator.Parsers.OpenApi;

public class OpenApiNumberParser : OpenApiBaseParser
{
    public OpenApiNumberParser(OpenApiBaseParser? nextParser) : base(nextParser)
    {
    }

    protected override bool CanParse(OpenApiSchema schema)
    {
        return schema.Type == "number";
    }

    protected override BaseCodeModel InternalParse(string name, OpenApiSchema openApiSchema,
        OpenApiDocument openApiDocument)
    {
        return openApiSchema.Format switch
        {
            "double" => new DoubleCodeModel(name, openApiSchema),
            "float" => new FloatCodeModel(name, openApiSchema),
            _ => new IntCodeModel(name, openApiSchema)
        };
    }
}