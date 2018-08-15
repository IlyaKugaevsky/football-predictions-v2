using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WriteModel.Features.Experts.Commands
{
    public class CreateExpert : IRequest<bool>
    {
        public CreateExpert (string nickname)
        {
            Nickname = nickname;
        }

        public string Nickname { get; }
    }
}
