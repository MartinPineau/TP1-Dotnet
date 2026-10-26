namespace TP1;

public sealed class Labyrinth
{
    private readonly Tile[,] _tiles;

    public int Width => _tiles.GetLength(0);

    public int Height => _tiles.GetLength(1);

    public Labyrinth(string map)
    {
        var lines = SplitLines(map);
        _tiles = new Tile[lines[0].Length, lines.Length];

        List<(int X, int Y)> keyRooms = [];
        List<Door> doors = [];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var symbol = lines[y][x];
                if (symbol == 'k')
                {
                    keyRooms.Add((x, y));
                    continue;
                }

                var tile = CreateTile(symbol)
                    ?? throw new ArgumentException($"Unknown symbol '{symbol}' at ({x}, {y}).", nameof(map));
                if (tile is Door door)
                {
                    doors.Add(door);
                }
                _tiles[x, y] = tile;
            }
        }

        if (keyRooms.Count != doors.Count)
        {
            throw new ArgumentException(
                $"Found {keyRooms.Count} key(s) for {doors.Count} door(s).", nameof(map));
        }

        foreach (var (keyRoom, door) in keyRooms.Zip(doors))
        {
            _tiles[keyRoom.X, keyRoom.Y] = new Room(door.HandOverKey());
        }
    }

    private static string[] SplitLines(string map)
    {
        var lines = map.ReplaceLineEndings("\n").TrimEnd('\n').Split('\n');

        if (lines[0].Length == 0)
        {
            throw new ArgumentException("The map must not be empty.", nameof(map));
        }
        if (lines.Any(line => line.Length != lines[0].Length))
        {
            throw new ArgumentException("All lines must have the same length.", nameof(map));
        }
        return lines;
    }

    private static Tile? CreateTile(char symbol) => symbol switch
    {
        '+' or '-' or '|' => new Wall(),
        ' ' => new Room(),
        '/' => new Door(),
        _ => null
    };
}
