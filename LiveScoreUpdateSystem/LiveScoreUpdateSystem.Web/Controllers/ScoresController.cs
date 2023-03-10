using Bytes2you.Validation;
using LiveScoreUpdateSystem.Common;
using LiveScoreUpdateSystem.Data.Models.FootballFixtures;
using LiveScoreUpdateSystem.Services.Common;
using LiveScoreUpdateSystem.Services.Data.Contracts;
using LiveScoreUpdateSystem.Web.Controllers.Abstraction;
using LiveScoreUpdateSystem.Web.Infrastructure.Extensions;
using LiveScoreUpdateSystem.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

namespace LiveScoreUpdateSystem.Web.Controllers
{
    public class ScoresController : BaseController
    {
        private readonly IFixtureService fixtureService;

        public ScoresController(IFixtureService fixtureService)
        {
            Guard.WhenArgument(fixtureService, "fixtureService").IsNull().Throw();

            this.fixtureService = fixtureService;
        }

        public ActionResult AvailableScores()
        {
            var currentDate = TimeProvider.CurrentProvider.CurrentDate;
            return this.View(currentDate);
        }

        [HttpGet]
        public ActionResult ByDate(DateTime date)
        {
            var targetDate = date == default(DateTime) ?
                TimeProvider.CurrentProvider.CurrentDate :
                date;

            var availableScores = this.fixtureService
             .GetAvailableFixtures(targetDate)
             .ToList()
             .Map<Fixture, AvailableScoreViewModel>()
             .GroupBy(s => s.LeagueName);

            return this.PartialView(PartialViews.AvailableScoresPartial, availableScores);
        }

        public ActionResult ScoreDetails(Guid fixtureId)
        {
            var targetFixture = this.fixtureService
                .GetById(fixtureId);

            if (targetFixture != null)
            {
                var fixtureViewModel = MappingService.MappingProvider.Map<ScoreDetailsViewModel>(targetFixture);
                fixtureViewModel.FixtureEvents = fixtureViewModel.FixtureEvents.OrderByDescending(fe => fe.Minute).ToList();
                return this.View(fixtureViewModel);
            }

            return this.RedirectToAction<ScoresController>(c => c.AvailableScores());
        }
    }
}