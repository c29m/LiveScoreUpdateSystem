﻿using LiveScoreUpdateSystem.Common;
using LiveScoreUpdateSystem.Data.Models.Abstraction;
using LiveScoreUpdateSystem.Data.Models.FootballFixtures.Enums;
using System.ComponentModel.DataAnnotations;

namespace LiveScoreUpdateSystem.Data.Models.FootballFixtures
{
    public class Player : DataModel
    {
        [Required]
        [MinLength(GlobalConstants.MinPlayerNameLength)]
        [MaxLength(GlobalConstants.MaxPlayerNameLength)]
        [RegularExpression(GlobalConstants.LettersMatchingPattern)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinPlayerNameLength)]
        [MaxLength(GlobalConstants.MaxPlayerNameLength)]
        [RegularExpression(GlobalConstants.LettersMatchingPattern)]
        public string LastName { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinPlayerAge)]
        [MaxLength(GlobalConstants.MaxPlayerAge)]
        public int Age { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinPlayerShirtNumber)]
        [MaxLength(GlobalConstants.MaxPlayerShirtNumber)]
        public int ShirtNumber { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public PlayerPosition Position { get; set; }

        [Required]
        public virtual Team Team { get; set; }

        [Required]
        public virtual Country Country { get; set; }
    }
}
