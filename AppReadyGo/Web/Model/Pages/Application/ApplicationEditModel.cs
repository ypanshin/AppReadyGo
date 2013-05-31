﻿using System.ComponentModel;
using AppReadyGo.Core.Entities;
using System.Collections.Generic;
using System;
using AppReadyGo.Core.QueryResults.Application;

namespace AppReadyGo.Model.Pages.Application
{
    public class ApplicationEditModel : ApplicationModel
    {
        public string IconPath { get; set; }

        public IEnumerable<string> ScreensPathes { get; set; }

        public IEnumerable<PublishDetailsResult> Publishes { get; set; }

        public PackageModel Package { get; set; }

        public class PackageModel
        {
            public string FileName { get; set; }

            public string Url { get; set; }
        }
    }
}