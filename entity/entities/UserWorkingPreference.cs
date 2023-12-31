﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class UserWorkingPreference
    {
        public int Id { get; set; }

        public virtual UserExt UserExt { get; set; }
        public int UserExtId { get; set; }
        public virtual WorkingPreference WorkingPreference { get; set; }
        public int WorkingPreferenceId { get; set; }
    }
}
