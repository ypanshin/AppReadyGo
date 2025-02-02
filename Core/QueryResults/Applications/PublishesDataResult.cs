﻿using AppReadyGo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppReadyGo.Core.QueryResults.Tasks;

namespace AppReadyGo.Core.QueryResults.Applications
{
    public class PublishesDataResult
    {
        public string ApplicationName { get; set; }

        public IEnumerable<TaskDetailsResult> PublishesDetails { get; set; }
    }
}
