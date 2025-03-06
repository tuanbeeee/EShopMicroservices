﻿namespace Catalog.API.Products.GetProducts;

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = new GetProductsQuery();
            
            var result = await sender.Send(query);
            
            var response = new GetProductsResponse(result.Products);
            
            return Results.Ok(response);
        })
        .WithName("GetProduct")
        .Produces<GetProductsResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product")
        .WithDescription("Get Product"); ;
    }
}
