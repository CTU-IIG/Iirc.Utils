namespace Iirc.Utils.SolverFoundations
{
    public interface ISolver<Instance, SolverConfig, SolverResult>
        where Instance : IInstance
        where SolverConfig : ISolverConfig
        where SolverResult : ISolverResult
    {
        SolverResult Solve(SolverConfig solverConfig, Instance instance);
    }
}