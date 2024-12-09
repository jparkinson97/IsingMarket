using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsingMarket.Domain;
public class Grid
{
    /// <summary>
    /// Two-dimensional array of nodes representing the lattice.
    /// </summary>
    private Node[,] nodes;
    private int width;
    private int height;

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
        nodes = new Node[width, height];
        var rand = new Random();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int initialSpin = rand.Next(2) == 0 ? -1 : 1;
                nodes[x, y] = new Node(initialSpin);
            }
        }
    }

    /// <summary>
    /// Retrieves the node at the given coordinates.
    /// Wraps around boundaries to implement periodic boundary conditions.
    /// </summary>
    public Node GetNode(int x, int y)
    {
        int wrappedX = (x + width) % width;
        int wrappedY = (y + height) % height;
        return nodes[wrappedX, wrappedY];
    }

    /// <summary>
    /// Flips the spin of the node at given coordinates.
    /// </summary>
    public void FlipSpin(int x, int y)
    {
        GetNode(x, y).Spin *= -1;
    }

    /// <summary>
    /// Returns the width of the lattice.
    /// </summary>
    public int GetWidth()
    {
        return width;
    }

    /// <summary>
    /// Returns the height of the lattice.
    /// </summary>
    public int GetHeight()
    {
        return height;
    }
}
