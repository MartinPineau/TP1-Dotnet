namespace TP1;

class Door : Tile
{
    internal Key Key { get; } = new Key();
    public bool IsOpen { get; private set; } = false;
    public override bool IsTraversable => IsOpen;
    public override bool Pass() => IsOpen;
    private bool UseKey(Key key, bool open)
    {
        if (!ReferenceEquals(key, Key))
        {
            return false;
        }
        IsOpen = open;
        return true;
    }

    public bool Open(Key key) => UseKey(key, true);
    public bool Close(Key key) => UseKey(key, false);
}