﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppReadyGo.Core.Queries.Analytics;
using NHibernate.Linq;
using NHibernate;
using AppReadyGo.Domain.Model;
using AppReadyGo.Core;
using AppReadyGo.Core.QueryResults.Analytics.QueryResults;
using AppReadyGo.Core.Commands;

namespace AppReadyGo.Domain.Queries.Analytics
{
    public class UsageViewDataQueryHandler : FilterBaseQueryHandler, IQueryHandler<UsageViewDataQuery, UsageViewDataResult>
    {
        private IRepository repository;
        private ISecurityContext securityContext;

        public UsageViewDataQueryHandler(IRepository repository, ISecurityContext securityContext)
        {
            this.repository = repository;
            this.securityContext = securityContext;
        }

        public UsageViewDataResult Run(ISession session, UsageViewDataQuery query)
        {
            var pageViewQuery = session.Query<PageView>()
                                        .Where(pv => pv.Application.Id == query.ApplicationId);

            var pageViews = pageViewQuery.Where(pv => pv.Date >= query.From && pv.Date <= query.To.Date).ToList();
            Dictionary<DateTime, int> result = null;
            switch (query.DataGrouping)
            {
                case DataGrouping.Minute:
                    result = pageViews.GroupBy(g => new DateTime(g.Date.Year, g.Date.Month, g.Date.Day, g.Date.Hour, g.Date.Minute, 0)).ToDictionary(k => k.Key, v => v.Count());
                    break;
                case DataGrouping.Hour:
                    result = pageViews.GroupBy(g => new DateTime(g.Date.Year, g.Date.Month, g.Date.Day, g.Date.Hour, 0, 0)).ToDictionary(k => k.Key, v => v.Count());
                    break;
                case DataGrouping.Day:
                    result = pageViews.GroupBy(g => g.Date.Date).ToDictionary(k => k.Key, v => v.Count());
                    break;
                case DataGrouping.Month:
                    result = pageViews.GroupBy(g => new DateTime(g.Date.Year, g.Date.Month, 1)).ToDictionary(k => k.Key, v => v.Count());
                    break;
                case DataGrouping.Year:
                    result = pageViews.GroupBy(g => new DateTime(g.Date.Year, 1, 1)).ToDictionary(k => k.Key, v => v.Count());
                    break;
            }

            var viewDataResult = GetResult<UsageViewDataResult>(session, securityContext.CurrentUser.Id);
            viewDataResult.Data = result;
            return viewDataResult;
        }
    }
}
