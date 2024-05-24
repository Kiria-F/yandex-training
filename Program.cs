namespace yandex_training;

using System;

class ItemReader {
    private string[] _buffer = Array.Empty<string>();
    private int _index;

    private string? ReadItem() {
        if (_index == _buffer.Length) {
            var input = Console.ReadLine();
            if (input != null) {
                _buffer = input.Split();
                _index = 0;
            } else {
                return null;
            }
        }

        return _buffer[_index++];
    }

    public string? ReadString() => ReadItem();

    public int? ReadInt() => int.TryParse(ReadItem(), out var result) ? result : null;
}

internal static class Program {
    private static ItemReader Reader { get; } = new();

    private static void Train1Class1TaskA() {
        var current = Reader.ReadInt();
        var target = Reader.ReadInt();
        var mode = Reader.ReadString();
        if (mode == "heat" && current < target || mode == "freeze" && current > target || mode == "auto") {
            Console.WriteLine(target);
        } else {
            Console.WriteLine(current);
        }
    }

    public static void Main() {
        Train1Class1TaskA();
    }
}