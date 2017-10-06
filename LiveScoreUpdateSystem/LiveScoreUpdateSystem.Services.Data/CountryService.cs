﻿using Bytes2you.Validation;
using LiveScoreUpdateSystem.Data.Models.FootballFixtures;
using LiveScoreUpdateSystem.Data.Repositories.Contracts;
using LiveScoreUpdateSystem.Services.Data.Abstraction;
using LiveScoreUpdateSystem.Services.Data.Contracts;
using System.Collections.Generic;

namespace LiveScoreUpdateSystem.Services.Data
{
    public class CountryService : DataService<Country>, ICountryService
    {
        public CountryService(IEfRepository<Country> dataSet) 
            : base(dataSet)
        {
        }

        public void Add(Country country)
        {
            Guard.WhenArgument(country, "Country").IsNull().Throw();

            this.Data.Add(country);
        }

        public IEnumerable<Country> GetAll()
        {
            return this.Data.All;
        }
    }
}
