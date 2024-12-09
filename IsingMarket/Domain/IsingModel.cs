using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsingMarket.Domain;

using System;

public class IsingModel
{
    /// <summary>
    /// Grid representing the lattice of spins.
    /// temperature: a parameter controlling the probability of flipping spins.
    /// couplingConstant: usually denoted J in the Ising model.
    /// </summary>
    private Grid grid;
    private double temperature;
    private double couplingConstant;
    private Random rand;

    public IsingModel(int width, int height, double temperature, double couplingConstant)
    {
        this.grid = new Grid(width, height);
        this.temperature = temperature;
        this.couplingConstant = couplingConstant;
        rand = new Random();
    }

    /// <summary>
    /// Executes a single Monte Carlo step by attempting to flip a randomly selected spin.
    /// Uses the Metropolis criterion based on the energy difference.
    /// </summary>
    public void Step()
    {
        int x = rand.Next(grid.GetWidth());
        int y = rand.Next(grid.GetHeight());
        int currentSpin = grid.GetNode(x, y).Spin;

        int sumNeighbourSpins =
            grid.GetNode(x + 1, y).Spin +
            grid.GetNode(x - 1, y).Spin +
            grid.GetNode(x, y + 1).Spin +
            grid.GetNode(x, y - 1).Spin;

        double deltaE = 2 * couplingConstant * currentSpin * sumNeighbourSpins;
        if (deltaE < 0)
        {
            grid.FlipSpin(x, y);
        }
        else
        {
            double probability = Math.Exp(-deltaE / temperature);
            if (rand.NextDouble() < probability)
            {
                grid.FlipSpin(x, y);
            }
        }
    }

    /// <summary>
    /// Runs the simulation for a given number of steps.
    /// </summary>
    public void Run(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            Step();
        }
    }

    /// <summary>
    /// Retrieves the current grid to examine or display spins.
    /// </summary>
    public Grid GetGrid()
    {
        return grid;
    }
}
