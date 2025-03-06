namespace Catalog.API.Products.GetProductById;
//public record GetProductByIdRequest(Guid Id);
public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
        {
            var query = new GetProductByIdQuery(id);

            var result = await sender.Send(query);

            var response = new GetProductByIdResponse(result.Product);

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id"); ;
    }
}
