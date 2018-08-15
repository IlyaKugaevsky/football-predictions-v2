using System;
using System.Collections.Generic;
using System.Text;

namespace WriteModel.Features.Experts.Dtos
{
    public class ExpertInfoWriteDto
    {
        public ExpertInfoWriteDto(string nickname)
        {
            Nickname = nickname;
        }

        public string Nickname { get; }  
    }
}
