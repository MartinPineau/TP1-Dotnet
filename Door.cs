namespace TP1;

public sealed class Door : Tile
{
    private readonly Key _key = new();
    private bool _isKeyHandedOver;

    public bool IsOpen { get; private set; }

    public override bool IsTraversable => IsOpen;

    public override ICollectable? Pass()
    {
        return IsOpen ? null : throw new InvalidOperationException("A closed door cannot be passed through.");
    }

    public Key HandOverKey()
    {
        if (_isKeyHandedOver)
        {
            throw new InvalidOperationException("The key has already been handed over.");
        }
        _isKeyHandedOver = true;
        return _key;
    }

    public bool TryOpen(Key key) => TryUseKey(key, open: true);

    public bool TryClose(Key key) => TryUseKey(key, open: false);

    private bool TryUseKey(Key key, bool open)
    {
        if (key != _key)
        {
            return false;
        }
        IsOpen = open;
        return true;
    }
}
