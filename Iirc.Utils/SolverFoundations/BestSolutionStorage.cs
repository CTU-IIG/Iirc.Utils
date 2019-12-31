// ---------------------------------------------------------------------------------------------------------------------
// <copyright file="BestSolutionStorage.cs" company="Czech Technical University in Prague">
//   Copyright (c) 2019 Czech Technical University in Prague
// </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Iirc.Utils.SolverFoundations
{
    using System;
    using System.Diagnostics;

    public class BestSolutionStorage<T> where T: IHasObjective
    {
        private Stopwatch timeToBestClock;
        private long timeToBest;
        private T bestSolution;
        
        public BestSolutionStorage()
        {
            this.timeToBestClock = new Stopwatch();
            this.timeToBestClock.Restart();
            
            this.bestSolution = default(T);
            this.timeToBest = long.MaxValue;
        }
        
        
        public bool TestAndUpdateBestSolution(T newSolution)
        {
            if (!newSolution.Objective.HasValue)
            {
                return false;
            }
            
            if (this.IsNewObjectiveBetter(newSolution.Objective.Value))
            {
                this.bestSolution = newSolution;
                this.timeToBest = this.timeToBestClock.ElapsedMilliseconds;

                return true;
            }

            return false;
        }

        public bool IsNewObjectiveBetter(int objective)
        {
            return !this.HasSolution || objective < this.bestSolution.Objective.Value;
        }

        public bool HasSolution => this.bestSolution != null && this.bestSolution.Objective.HasValue;

        public T BestSolution => this.bestSolution;
        public TimeSpan TimeToBest => TimeSpan.FromMilliseconds(this.timeToBest);
    }
}
