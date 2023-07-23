using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.entities;


namespace data.access.Context
{
    public interface IContext
    {
        public List<UserExt> _Users { get; set; }
        public List<District> _Districts { get; set; }
        public List<Motivation> _Motivations { get; set; }
        public List<WorkingPreference> _WorkingPreferences { get; set; }

    }
}
