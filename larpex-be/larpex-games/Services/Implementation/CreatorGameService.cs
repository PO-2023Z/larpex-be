using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_games.Domain.Enums;
using larpex_events.contracts.Contracts.DataTransferObjects;
using larpex_events.contracts.Contracts.DataTransferObjects.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.Responses.Game;
using larpex_games.Domain;
using larpex_games.Services.Interface;
using System.Reflection.Metadata.Ecma335;

namespace larpex_games.Services.Implementation;
public class CreatorGameService : ICreatorGameService
{
    private readonly IGamesRepository _gamesRepository;

    public CreatorGameService(IGamesRepository gamesRepository)
    {
        _gamesRepository = gamesRepository;
    }

    public GetCreatorGamesResponse GetGames(string creatorEmail)
    {
        var response = new GetCreatorGamesResponse();
        response.Games = _gamesRepository.GetAll()
            .Where(g => g.OwnerEmail == creatorEmail)
            .Select(g => new GameSummaryDto()
            {
                GameId = g.GameId.ToString(),
                GameName = g.GameName,
                Status = g.State.ToString()
            }).ToList();

        return response;
    }

    public GetCreatorGameResponse? GetGame(Guid gameId, string creatorEmail)
    {
        var response = new GetCreatorGameResponse();
        var game = _gamesRepository.Get(gameId);
        if (game == null)
        {
            return null;
        }

        response.game = new GameDto()
        {
            GameId = game.GameId.ToString(),
            GameName = game.GameName,
            Description = game.Description,
            Status = game.State.ToString(),
            MaximumPlayers = game.MaximumPlayers,
            Difficulty = game.Difficulty,
            MapUrl = game.Map,
            Scenario = game.Scenario,
        };
        return response;
    }

    public void CreateGame(CreateGameRequest request, string creatorEmail)
    {
        var game = new Game()
        {
            GameName = request.Game.GameName,
            Description = request.Game.Description,
            OwnerEmail = creatorEmail,
            State = Domain.Enums.CreationState.UnderDevelopment,
            MaximumPlayers = request.Game.MaximumPlayers,
            Difficulty = request.Game.Difficulty,
            Map = request.Game.MapUrl,
            Scenario = request.Game.Scenario,
            DateOfCreation = DateTime.Now
        };

        _gamesRepository.Add(game);
    }

    public void ModifyGame(UpdateGameDto game, string creatorEmail)
    {
        var gameToModify = _gamesRepository.Get(new Guid(game.GameId))
            ?? throw new Exception($"Game with ID: {game.GameId} does not exist");

        gameToModify.GameName = game.GameName;
        gameToModify.Description = game.Description;
        gameToModify.Difficulty = game.Difficulty;
        gameToModify.MaximumPlayers = game.MaximumPlayers;
        gameToModify.Scenario = game.Scenario;
        gameToModify.Map = game.MapUrl;

        _gamesRepository.Update(gameToModify);
    }

    public void SendGameSuggestion(SendGameSuggestionRequest request, string email)
    {
        var game = _gamesRepository.Get(request.GameId)
            ?? throw new Exception($"Game with ID: {request.GameId} does not exist");

        if (game.OwnerEmail != email)
        {
            throw new Exception($"Person with email: {email} is not authorized to this Game");
        }

        if (game.State != CreationState.UnderDevelopment)
        {
            throw new Exception($"Game with ID: {request.GameId} is not under development");
        }


        game.State = CreationState.AwaitingAcceptation;

        _gamesRepository.Update(game);
    }
}
