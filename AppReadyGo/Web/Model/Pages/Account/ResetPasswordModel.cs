﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppReadyGo.Model.Pages.Account
{
    public class ResetPasswordModel
    {
        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}