using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common.Intefaces
{
    public interface IStatus
    {
        int HP { get; set; }
        int DS { get; set; }
        int DE { get; set; }
        int AT { get; set; }
    }
}