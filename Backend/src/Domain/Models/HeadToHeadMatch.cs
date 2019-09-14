using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]

    public class HeadToHeadMatch: Entity
    {
        protected HeadToHeadMatch()
        {
        }
        
        public int HeadToHeadTourId { get; private set; }
        [ForeignKey("HeadToHeadTourId")]
        public HeadToHeadTour HeadToHeadTour { get; private set; }

//        public int HeadToHeadMatchId { get; private set; }


        public int HomeExpertId { get; private set; }
        public int AwayExpertId { get; private set; }

        [ForeignKey("HomeExpertId")]
        public Expert HomeExpert { get; private set; }

        [ForeignKey("AwayExpertId")]
        public Expert AwayExpert { get; private set; }

        public byte HomeGoals { get; private set; }
        public byte AwayGoals { get; private set; }

        public bool IsOver { get; private set; }
    }
}
