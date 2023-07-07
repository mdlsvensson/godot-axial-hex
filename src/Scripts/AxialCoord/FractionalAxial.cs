using System;

namespace AxialCoord;

public struct FractionalAxial
{
    public FractionalAxial(float q, float r)
    {
        if (q + r + (-q - r) != 0) throw new ArgumentException("q + r + s must be 0");

        Q = q;
        R = r;
    }

    public float Q { get; }
    public float R { get; }

    public readonly Axial Round()
    {
        float q = MathF.Round(Q), r = MathF.Round(R);
        float q_diff = Q - q, r_diff = R - r;

        if (MathF.Abs(q_diff) >= MathF.Abs(r_diff))
        {
            return new Axial((int)(q + MathF.Round(q_diff + 0.5f * r_diff)), (int)r);
        }

        return new Axial((int)q, (int)(r + MathF.Round(r_diff + 0.5f * q_diff)));
    }
}