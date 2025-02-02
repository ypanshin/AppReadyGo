﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppReadyGo.Core.QueryResults.Analytics.QueryResults;
using System.Drawing;

namespace AppReadyGo.Core.Queries.Analytics
{
    public class DashboardViewDataQuery : IQuery<DashboardViewDataResult>, IFilterQuery
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public int ApplicationId { get; private set; }
        public DataGrouping DataGrouping { get; private set; }
        public Size? ScreenSize { get; private set; }
        public string Path { get; private set; }
        public string Language { get; private set; }
        public string OperatingSystem { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }

        public DashboardViewDataQuery(
            DateTime from,
            DateTime to,
            int applicationId,
            Size? screenSize,
            string path,
            string language,
            string operatingSystem,
            string country,
            string city,
            DataGrouping dataGrouping)
        {
            this.From = from.StartDay();
            this.To = to.EndDay();
            this.ApplicationId = applicationId;
            this.ScreenSize = screenSize;
            this.Path = path;
            this.Language = language;
            this.OperatingSystem = operatingSystem;
            this.Country = country;
            this.City = city;
            this.DataGrouping = dataGrouping;
        }
    }
}
