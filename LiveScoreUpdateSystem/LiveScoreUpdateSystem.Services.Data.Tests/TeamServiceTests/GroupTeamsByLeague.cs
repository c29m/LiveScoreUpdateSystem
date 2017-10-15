﻿using LiveScoreUpdateSystem.Data.Models.FootballFixtures;
using LiveScoreUpdateSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveScoreUpdateSystem.Services.Data.Tests.TeamServiceTests
{
    [TestFixture]
    public class GroupTeamsByLeague
    {
        [Test]
        public void ReturnAllTeamsCorrectlyGroupByLeague_WhenInvoked()
        {
            // arrange
            var teamsRepo = new Mock<IEfRepository<Team>>();
            var leaguesRepo = new Mock<IEfRepository<League>>();

            var firstLeague = new League() { Name = "someName" };
            var secondLeague = new League() { Name = "otherName" };

            var teams = new List<Team>()
            {
                new Team(){Name = "Team1", League = firstLeague},
                new Team(){Name = "Team2", League = secondLeague},
                new Team(){Name = "Team3", League = firstLeague},
            };

            teamsRepo.Setup(t => t.All).Returns(teams.AsQueryable());

            var teamService = new TeamService(teamsRepo.Object, leaguesRepo.Object);

            // act
            var result = teamService.GroupTeamsByLeague().OrderBy(x => x.Count());

            // assert
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result.First().Count(), 1);
        }
    }
}
