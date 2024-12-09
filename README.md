# Modelling trading market as an ising model/ hopfield network 

- Each member of a market is connected to other members.
- Items sold have an expiration date: the longer you hold an asset the less valuable it becomes.
- If a neighbour has a low price, they will buy as much from them as possible and sell at a price that maximises profit.
- This will be a mean field model
- User can configure the size of the market, the strategy used by a market participant and press on a player to make then overproduce/ need product by changing price

## Done so far
Boolean ising model and display/ input

## Todo

convert from bool to bid/ ask prices
add pricing strategy
