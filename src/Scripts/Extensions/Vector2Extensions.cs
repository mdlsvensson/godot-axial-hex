using System;
using Godot;
using AxialCoord;
using static HexMapGlobals;

namespace Extensions;

public static class Vector2Extensions
{
    public static Axial ToAxial(this Vector2 vector)
    {
        float q = (MathF.Sqrt(3) / 3 * vector.X - 1f / 3 * vector.Y) / HexSize;
        float r = 2f / 3 * vector.Y / HexSize;

        return new FractionalAxial(q, r).Round();
    }
}