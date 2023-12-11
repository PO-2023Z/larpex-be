using larpex_db;
using larpex_games.Domain;
using larpex_games.Domain.Enums;
using larpex_games.Services.Interface;

namespace larpex_games.Persistence;

public class GamesRepository : IGamesRepository
{
    private readonly LarpexdbContext _larpexContext;

    public GamesRepository(LarpexdbContext larpexContext)
    {
        _larpexContext = larpexContext;
    }

    public List<Game> GetAll()
    {
        var gamesDTOs = _larpexContext.Games.ToList();
       return gamesDTOs.Select(game => MapToGame(game)).ToList();
    }

    public Game? Get(Guid gameId)
    {
        var gameDto = _larpexContext.Games.FirstOrDefault(game => game.Gameid == gameId);
        if (gameDto == null) return null;
        return MapToGame(gameDto);
    }

    public void Add(Game game)
    {
        var gameDto = MapToGameDTO(game);
        _larpexContext.Games.Add(gameDto);
        _larpexContext.SaveChanges();
    }

    public void Remove(Guid gameId)
    {
        var gameDto = _larpexContext.Games.FirstOrDefault(game => game.Gameid == gameId);
        if (gameDto == null) return;
        _larpexContext.Games.Remove(gameDto);
        _larpexContext.SaveChanges();
    }

    public void Update(Game game)
    {
        var gameDto = MapToGameDTO(game);
        _larpexContext.Games.Update(gameDto);
        _larpexContext.SaveChanges();
    }
    
    private Game MapToGame(larpex_db.Models.Game gameDto)
    {
        return new Game
        {
            GameId = gameDto.Gameid,
            GameName = gameDto.Gamename,
            OwnerEmail = gameDto.Gameauthoremail,
            MaximumPlayers = gameDto.Maximumplayer,
            Difficulty = gameDto.Difficulty,
            Description = gameDto.Description ?? string.Empty,
            Map = gameDto.Map ?? string.Empty,
            Scenario = gameDto.Scenario ?? string.Empty,
            CorrectionNotes = gameDto.Correctionnotes ?? string.Empty,
            VerdictNotes = gameDto.Amendment ?? string.Empty,
            State = (CreationState)Enum.Parse(typeof(CreationState), gameDto.Creationstate),
            DateOfCreation = gameDto.Dateofcreation ?? DateTime.Now
        };
    }
    
    private larpex_db.Models.Game MapToGameDTO(Game game)
    {
        return new larpex_db.Models.Game
        {
            Gameid = game.GameId,
            Gamename = game.GameName,
            Gameauthoremail = game.OwnerEmail,
            Maximumplayer = game.MaximumPlayers,
            Difficulty = game.Difficulty,
            Description = game.Description,
            Map = game.Map,
            Scenario = game.Scenario,
            Amendment = game.VerdictNotes,
            Creationstate = game.State.ToString(),
            Dateofcreation = game.DateOfCreation,
            Correctionnotes = game.CorrectionNotes
        };
    }
}