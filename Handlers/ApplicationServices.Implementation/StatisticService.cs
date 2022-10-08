﻿using ApplicationServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationServices.Implementation
{
    public class StatisticService : IStatisticService
    {
        public Task WriteStatisticAsync(string area, int id)
        {
            return Task.CompletedTask;
        }

        public Task WriteStatisticAsync(string area, IEnumerable<int> productIds)
        {
            return Task.CompletedTask;
        }
    }
}
