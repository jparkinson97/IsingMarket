namespace IsingMarket.Domain;

public class Node
{
    /// <summary>
    /// Represents the spin state of this node, often +1 or -1.
    /// </summary>
    public int Spin { get; set; }

    public Node(int initialSpin)
    {
        Spin = initialSpin;
    }
}

