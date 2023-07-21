using entity.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access
{
    public interface IRepository
    {
        List<District> districts { get; }
        List<Motivation> motivations { get; }
        List<WorkingPreference> workingPreferences { get; }

    }
}
