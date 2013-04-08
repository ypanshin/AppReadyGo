﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace AppReadyGo.Core
{
    [Serializable]
    public enum ErrorNumber
    {
        None = 0,
        General = 1,
        WrongParameter,
        AccessDenied,
        WrongDescription,
        NotFound,
        WrongFirstName,
        WrongLastName,
        WrongTimeZone
    }
}
