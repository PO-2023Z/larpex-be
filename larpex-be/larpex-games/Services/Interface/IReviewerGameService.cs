using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_contracts.contracts.Contracts.Responses.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_games.contracts.Contracts.Requests.Game;
using larpex_games.contracts.Contracts.Responses.Game;

namespace larpex_games.Services.Interface;
public interface IReviewerGameService
{
    BrowseGamesSuggestionResponse GetSuggestions(BrowseGamesSuggestionsRequest request);
    GetGameSuggestionDetailsResponse GetSuggestionDetails(GetGameSuggestionDetailsRequest request);
    void GiveVerdict(GiveVerdictRequest request);
    void AddCorrection(AddCorrectionRequest request);
}
