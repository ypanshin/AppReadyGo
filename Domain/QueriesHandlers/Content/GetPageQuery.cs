﻿using System.Linq;
using AppReadyGo.Core.Queries.Content;
using AppReadyGo.Core.QueryResults.Content;
using AppReadyGo.Domain.Model.Content;
using NHibernate;
using NHibernate.Linq;

namespace AppReadyGo.Domain.Queries
{
    public class GetPageQueryHandler : IQueryHandler<GetPageQuery, PageResult>
    {
        public PageResult Run(ISession session, GetPageQuery query)
        {
            var page = session.Query<Page>()
                            .Where(p => p.Url.ToLower() == query.Url.ToLower())
                            .Select(p => new PageResult
                            {
                                Id = p.Id,
                                Url = p.Url,
                                ThemeUrl = p.Theme.Url
                            })
                            .SingleOrDefault();

            if (page != null)
            {
                var items = session.Query<Page>()
                                .Where(p => p.Id == page.Id)
                                .SelectMany(p => p.Items)
                                .Select(i => new { i.SubKey, i.Value })
                                .ToArray();

                page.Title = items.Single(i => i.SubKey.ToLower() == "title").Value;
                page.Content = items.Single(i => i.SubKey.ToLower() == "content").Value;
            }

            return page;
        }
    }
}
