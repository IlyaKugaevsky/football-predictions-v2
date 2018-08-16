using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WriteModel.Features.Teams.Commands
{
    public class CreateTeam : IRequest<bool>
    {
        public CreateTeam(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }

}
