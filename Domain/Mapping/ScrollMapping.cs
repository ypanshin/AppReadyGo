﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.ByCode.Conformist;
using AppReadyGo.Domain.Model;
using NHibernate.Mapping.ByCode;

namespace AppReadyGo.Domain.Mapping
{
    internal class ScrollMapping : ClassMapping<Scroll>
    {

        public ScrollMapping()
        {
            Table("Scrolls");
            Id(p => p.Id, map => map.Generator(Generators.Identity));
            ManyToOne(p => p.FirstTouch, map =>
            {
                map.Cascade(Cascade.All);
                map.NotNullable(true);
                map.Column("FirstTouchId");
            });
            ManyToOne(p => p.LastTouch, map =>
            {
                map.Cascade(Cascade.All);
                map.NotNullable(true);
                map.Column("LastTouchId");
            });
            ManyToOne(p => p.PageView, map =>
            {
                map.Cascade(Cascade.All);
                map.NotNullable(true);
                map.Column("PageViewId");
            });
        
        }
    }
}
