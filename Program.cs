// ReSharper disable UnusedMember.Local

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

    public int[] ReadIntArray(int n) {
        var array = new int[n];
        for (var i = 0; i < n; i++) {
            array[i] = ReadInt() ?? 0;
        }

        return array;
    }
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

    private static void Train1Class1TaskB() {
        var sides = Reader.ReadIntArray(3);
        var maxIndex = 0;
        var maxSide = -1;
        for (var i = 0; i < 3; i++) {
            if (sides[i] > maxSide) {
                maxIndex = i;
                maxSide = sides[i];
            }
        }

        var subSidesSum = 0;
        for (var i = 0; i < 3; i++) {
            if (i != maxIndex) {
                subSidesSum += sides[i];
            }
        }

        Console.WriteLine(maxSide < subSidesSum ? "YES" : "NO");
    }

    public static void Main() {
        Train1Class1TaskB();
    }
}