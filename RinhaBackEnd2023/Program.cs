
using Entities;
using Services.Validation;

namespace RinhaBackEnd2023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddSingleton<ValidadorPessoa>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.MapPost("/pessoas", (HttpContext httpContext, Pessoa pessoa, ValidadorPessoa validadorPessoa, CancellationToken cancellationToken) =>
            {
                var validationResult = validadorPessoa.Validate(pessoa);
                if(!validationResult.IsValid)
                    TypedResults.UnprocessableEntity(pessoa);
                return TypedResults.Created();
            })
            .WithName("GetWeatherForecast");

            app.Run();
        }
    }
}
