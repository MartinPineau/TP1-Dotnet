namespace TP1;

class Wall : Tile
{
    public override bool IsTraversable => false;

    public override bool Pass() => false;
}
