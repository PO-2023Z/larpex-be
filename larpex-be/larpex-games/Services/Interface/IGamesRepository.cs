using larpex_games.Domain;

namespace larpex_games.Services.Interface;
public interface IGamesRepository
{
    List<Game> GetAll();
    Game? Get(Guid gameId);
    void Add(Game game);
    void Remove(Guid gameId);
    void Update(Game game);
}
