namespace Iirc.Utils.SolverFoundations
{
    using System;
    using System.Collections.Generic;

    public interface ISolverConfig
    {
        TimeSpan? TimeLimit { get; set; }

        Dictionary<string, object> SpecializedSolverConfig { get; set; }
    }
}