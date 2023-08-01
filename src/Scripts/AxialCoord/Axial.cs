using Godot;
using System;
using static HexMapGlobals;

namespace AxialCoord;

public struct Axial
{
    public Axial(int q, int r)
    {
        if (q + r + (-q - r) != 0) throw new ArgumentException("q + r + s must be 0");

        Q = q;
        R = r;
    }

    public enum Direction
    {
        East, SouthEast, SouthWest, West, NorthWest, NorthEast
    }

    public enum Diagonal
    {
        NorthEast, North, NorthWest, SouthWest, South, SouthEast
    }

    public static Axial[] Directions = new Axial[]
    {
        new(+1, 0), new(+1, -1), new(0, -1),
        new(-1, 0), new(-1, +1), new(0, +1),
    };

    public static Axial[] Diagonals = new Axial[]
    {
        new(+2, -1), new(+1, -2), new(-1, -1),
        new(-2, +1), new(-1, +2), new(+1, +1)
    };

    public int Q { get; }
    public int R { get; }

    public static Axial operator +(Axial a, Axial b)
    {
        return new Axial(a.Q + b.Q, a.R + b.R);
    }

    public static Axial operator -(Axial a, Axial b)
    {
        return new Axial(a.Q - b.Q, a.R - b.R);
    }

    public static Axial operator *(Axial axial, int factor)
    {
        return new Axial(axial.Q * factor, axial.R * factor);
    }

    public readonly Axial RotateLeft() => new(-(-Q - R), -Q);

    public readonly Axial RotateRight() => new(-R, -(-Q - R));

    public readonly int Length() => (Math.Abs(Q) + Math.Abs(R) + Math.Abs(-Q - R)) / 2;

    public readonly int DistanceTo(Axial to) => (this - to).Length();

    public readonly Vector3 ToPos3D()
    {
        float x = HexSize * (MathF.Sqrt(3) * Q + MathF.Sqrt(3) / 2 * R);
        float z = HexSize * (3f / 2 * R);

        return new Vector3(x, 0, z);
    }

    public readonly Vector2 ToPos2D()
    {
        float x = HexSize * (MathF.Sqrt(3) * Q + MathF.Sqrt(3) / 2 * R);
        float y = HexSize * (3f / 2 * R);

        return new Vector2(x, y);
    }
}