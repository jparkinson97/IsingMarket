namespace IsingMarket.Domain;

public class Node
{
    /// <summary>
    /// Represents the spin state of this node, often +1 or -1.
    /// </summary>
    public int StockLevel { get; set; }
    public int MaxStockLevel { get; set; }
    public int MinStockLevel { get; set; }
    public int BuyValue { get; set; }
    public int SellValue { get; set; }
    public int Cash {  get; set; }

    public Node(int stock, int buyValue, int sellValue)
    {
        StockLevel = stock;
        BuyValue = buyValue;
        SellValue = sellValue;
    }
}

