﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AppReadyGo.Common;
using AppReadyGo.Model.Master;

namespace AppReadyGo.Model.Pages.Application
{
    public class ScreenModel : AfterLoginMasterModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Width")]
        public int Width { get; set; }

        [Required]
        [DisplayName("Height")]
        public int Height { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Path")]
        public string Path { get; set; }

        public string FileExtention { get; set; }

        public int ApplicationId { get; set; }

        public ScreenReturn ScreenReturn { get; set; }

        public ScreenModel()
            : base(MenuItem.Analytics)
        {
        }
    }

    public class EditScreenModel : ScreenModel
    {
        public string FileName { get; set; }
    }
}