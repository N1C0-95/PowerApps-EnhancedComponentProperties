using GameStore.Auth;
using GameStore.Model;
using GameStore.Repository;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;


namespace GameStore.Endpoints
{
    public static class GameEndpoints
    {
        public static void AddGameEndpoint(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
        }
        public static void UseGameEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("games", CreateGame).WithName("CreateGame").Accepts<Game>("application/json").Produces<Game>(201).Produces<IEnumerable<ValidationFailure>>(400).WithTags("Games");
            app.MapGet("games", GetGames).WithName("GetGames").Produces<Game>(200).WithTags("Games");
            app.MapGet("games/{upc}", GetGameByUpc).WithName("GetGameByUpc").Produces<Game>(200).WithTags("Games");
            app.MapPut("games/{upc}", UpdateGame).WithName("UpdateGame").Accepts<Game>("application/json").Produces<Game>(201).Produces<IEnumerable<ValidationFailure>>(400).WithTags("Games");
            app.MapDelete("games/{upc}", DeleteGame).WithName("DeleteGame").Produces(204).Produces(404).WithTags("Games");
        }
        // Methods
        [Authorize(AuthenticationSchemes = ApiKeySchemeConstant.SchemeName)]
        private static async Task<IResult> CreateGame(Game game, IGameRepository gameRepository, IValidator<Game> validator)
        {
            var validationResult = await validator.ValidateAsync(game);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            bool result = await gameRepository.CreateAsync(game);
            if (!result)
            {
                return Results.BadRequest(new
                {
                    erroreMessage = "Error during creation"
                });
            }
            return Results.Created($"/games/{game.Upc}", game);
        }
        private static async Task<IResult> GetGames (IGameRepository gameRepository, string? searchTerm)
        {
            if (searchTerm is not null && !string.IsNullOrWhiteSpace(searchTerm))
            {
                var matchedGame = await gameRepository.SearchByNameAsync(searchTerm);
                return Results.Ok(matchedGame);
            }
            var result = await gameRepository.GetAllAsync();
            return Results.Ok(result);
        }
        private static async Task<IResult> GetGameByUpc(string upc, IGameRepository gameRepository)
        {
            var game = await gameRepository.GetByUpcAsync(upc);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }
        [Authorize(AuthenticationSchemes = ApiKeySchemeConstant.SchemeName)]
        private static async Task<IResult> UpdateGame(string upc, Game game, IGameRepository gameRepository, IValidator<Game> validator)
        {
            game.Upc = upc;
            var validationResult = await validator.ValidateAsync(game);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            var updated = await gameRepository.UpdateAsync(game);
            return updated ? Results.Ok(game) : Results.NotFound();
        }
        [Authorize(AuthenticationSchemes = ApiKeySchemeConstant.SchemeName)]
        private static async Task<IResult> DeleteGame(string upc, IGameRepository gameRepository)
        {
            var deleted = await gameRepository.DeleteAsync(upc);
            return deleted ? Results.NoContent() : Results.NotFound();  
        }
    }
}
