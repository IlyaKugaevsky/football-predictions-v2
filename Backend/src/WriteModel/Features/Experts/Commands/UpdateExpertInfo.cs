using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WriteModel.Features.Experts.Commands
{
    public class UpdateExpertInfo : IRequest<bool>
    {
        public UpdateExpertInfo(int id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }

        public string Nickname { get; }
        public int Id { get; }
    }

}
