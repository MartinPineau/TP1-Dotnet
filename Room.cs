namespace TP1;

public sealed class Room(ICollectable? collectable = null) : Tile
{
    public ICollectable? Collectable { get; private set; } = collectable;

    public override bool IsTraversable => true;

    public override ICollectable? Pass()
    {
        var collectable = Collectable;
        Collectable = null;
        return collectable;
    }
}