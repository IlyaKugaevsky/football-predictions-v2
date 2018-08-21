using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ReadModel.Features.Experts.Queries
{
    public class GetIdByNickname : IRequest<int?>
    {
        public GetIdByNickname(string nickname)
        {
            Nickname = nickname;
        }

        public string Nickname { get; }
    }
}
