using System;
using System.Collections.Generic;
using System.Text;

namespace WriteModel.Features.Teams.Dtos
{
    public class TeamWriteDto
    {
        public TeamWriteDto(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
