using TP1;

var labyrinth = new Labyrinth("""
    +--+--------+
    |  /        |
    |  +--+--+  |
    |     |k    |
    +--+  |  +--+
    |k |        |
    |  +-------/|
    |           |
    +-----------+
    """);

Console.WriteLine($"Labyrinth: {labyrinth.Width} x {labyrinth.Height}");
