﻿using LiveScoreUpdateSystem.Common;
using LiveScoreUpdateSystem.Data.Models.FootballFixtures;
using LiveScoreUpdateSystem.Web.Infrastructure.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace LiveScoreUpdateSystem.Web.Areas.Admin.Models
{
    public class GridLeagueViewModel : IMap<League>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public CountryViewModel Country { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLeagueNameLength, ErrorMessage = "Invalid league name length", MinimumLength = GlobalConstants.MinLeagueNameLength)]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.MinLeagueSeasonValue, GlobalConstants.MaxLeagueSeasonValue)]
        public int Season { get; set; }
    }
}