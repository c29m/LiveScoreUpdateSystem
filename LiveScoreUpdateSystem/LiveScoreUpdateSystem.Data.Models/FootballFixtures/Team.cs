﻿using LiveScoreUpdateSystem.Common;
using LiveScoreUpdateSystem.Data.Models.Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveScoreUpdateSystem.Data.Models.FootballFixtures
{
    public class Team : DataModel
    {
        [Required]
        [MinLength(GlobalConstants.MinTeamNameLength)]
        [MaxLength(GlobalConstants.MaxTeamNameLength)]
        [RegularExpression(GlobalConstants.AlphaNumericalPattern)]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        public int SeasonPoints { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual League League { get; set; }
    }
}
