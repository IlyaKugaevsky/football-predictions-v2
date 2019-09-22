using System.Collections.Generic;

namespace ReadModel.Features.HeadToHead.Dtos
{
    public class HeadToHeadTableReadDto
    {
        public HeadToHeadTableReadDto(string tournamentTitle, IEnumerable<HeadToHeadTableLineReadDto> tableLines)
        {
            TournamentTitle = tournamentTitle;
            TableLines = tableLines;
        }

        public string TournamentTitle { get; }
        public IEnumerable<HeadToHeadTableLineReadDto> TableLines { get; }
    }
}