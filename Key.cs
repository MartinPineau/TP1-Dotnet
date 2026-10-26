using System.Runtime.CompilerServices;

namespace TP1;

public sealed record Key : ICollectable
{
    internal Key() { }

    public bool Equals(Key? other) => ReferenceEquals(this, other);

    public override int GetHashCode() => RuntimeHelpers.GetHashCode(this);
}
