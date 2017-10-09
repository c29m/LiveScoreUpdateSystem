﻿using Bytes2you.Validation;
using LiveScoreUpdateSystem.Data.Models.Abstraction;
using LiveScoreUpdateSystem.Data.Models.Contracts;
using LiveScoreUpdateSystem.Data.Repositories.Contracts;
using LiveScoreUpdateSystem.Services.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace LiveScoreUpdateSystem.Services.Data.Abstraction
{
    public class DataService<T>
        where T : class, IAuditable, IDeletable
    {
        public DataService(IEfRepository<T> dataSet)
        {
            Guard.WhenArgument(dataSet, "IEfRepository dataSet").IsNull().Throw();

            this.Data = dataSet;
        }
         
        protected IEfRepository<T> Data { get; private set; }

        public IEnumerable<T> GetAll()
        {
            return this.Data.All.ToList();
        }
    }
}
