using System;
using Godot;
using AxialCoord;
using static HexMapGlobals;

namespace Extensions;

public static class Vector3Extensions
{
    public static Axial ToAxial(this Vector3 vector)
    {
        float q = (MathF.Sqrt(3) / 3 * vector.X - 1f / 3 * vector.Z) / HexSize;
        float r = 2f / 3 * vector.Z / HexSize;

        return new FractionalAxial(q, r).Round();
    }
}