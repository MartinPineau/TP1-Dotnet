namespace TP1;

abstract class Tile
{
    public abstract bool IsTraversable { get; }
    public abstract bool Pass();
}