namespace TP1;

class Room : Tile
{
    internal Room(ICollectable? collectable = null) => Collectable = collectable;
    public ICollectable? Collectable
    {
        get;
        private set;
    }
    public override bool IsTraversable => true;

    public override bool Pass() => true;

    public ICollectable? TakeCollectable()
    {
        var collectable = Collectable;
        Collectable = null;
        return collectable;
    }
}