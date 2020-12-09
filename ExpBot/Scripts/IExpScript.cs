using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpBot.Scripts
{
    public interface IExpScript : IScript
    {
        IList<string> TargetNames { get; set; }
        IList<string> TrustNames { get; set; }
    }
}
