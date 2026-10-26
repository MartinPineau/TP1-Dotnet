namespace TP1;

public sealed class Wall : Tile
{
    public override bool IsTraversable => false;

    public override ICollectable? Pass() =>
        throw new InvalidOperationException("A wall cannot be passed through.");
}
