﻿using LiveScoreUpdateSystem.Common;
using LiveScoreUpdateSystem.Data.Models.FootballFixtures;
using LiveScoreUpdateSystem.Data.Models.FootballFixtures.Enums;
using LiveScoreUpdateSystem.Web.Infrastructure.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace LiveScoreUpdateSystem.Web.Areas.Admin.Models
{
    public class GridPlayerViewModel : IMap<Player>, ICustomMapping
    {
        [Required]
        public Guid Id { get; set; }

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
        [Range(GlobalConstants.MinPlayerAge, GlobalConstants.MaxPlayerAge)]
        public int Age { get; set; }

        [Required]
        [Range(GlobalConstants.MinPlayerShirtNumber, GlobalConstants.MaxPlayerShirtNumber)]
        public int ShirtNumber { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public PlayerPosition Position { get; set; }

        [Required]
        public string TeamName { get; set; }

        public string TeamLogo { get; set; }

        [Required]
        public string CountryName { get; set; }

        public string CountryFlagUrl { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Player, GridPlayerViewModel>()
            .ForMember(c => c.TeamName, opt => opt.MapFrom(c => c.Team.Name))
            .ForMember(c => c.TeamLogo, opt => opt.MapFrom(c => c.Team.LogoUrl))
            .ForMember(c => c.CountryFlagUrl, opt => opt.MapFrom(c => c.Country.FlagPictureUrl))
            .ForMember(c => c.CountryName, opt => opt.MapFrom(c => c.Country.Name));
        }
    }
}