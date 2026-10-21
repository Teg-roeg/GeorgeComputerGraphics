using UnityEngine;

public class OutCode
{
    public bool upIn;
    public bool downIn;
    public bool leftIn;
    public bool rightIn;

    public OutCode(Vector2 point)
    {
        upIn = (point.y > 1);
        downIn = (point.y < -1);
        leftIn = (point.x < -1);
        rightIn = (point.x > 1);
    }

    public OutCode(bool upIn, bool downIn, bool leftIn, bool rightIn)
    {
        this.upIn = upIn;
        this.downIn = downIn;
        this.leftIn = leftIn;
        this.rightIn = rightIn;
    }

    public string DisplayOutCode()
    {
        return (upIn ? "1" : "0") + (downIn ? "1" : "0") + (leftIn ? "1" : "0") + (rightIn ? "1" : "0");
    }

    // Logical AND operator (&)
    public static OutCode operator &(OutCode a, OutCode b)
    {
        return new OutCode(a.upIn && b.upIn, a.downIn && b.downIn, a.leftIn && b.leftIn, a.rightIn && b.rightIn);
    }

    // Logical OR operator (|)
    public static OutCode operator |(OutCode a, OutCode b)
    {
        return new OutCode(a.upIn || b.upIn, a.downIn || b.downIn, a.leftIn || b.leftIn, a.rightIn || b.rightIn);
    }

    // EQUALS operator (==)
    public static bool operator ==(OutCode a, OutCode b)
    {
        return (a.upIn == b.upIn) && (a.downIn == b.downIn) && (a.leftIn == b.leftIn) && (a.rightIn == b.rightIn);
    }

    // NOT EQUAL operator (!=)
    public static bool operator !=(OutCode a, OutCode b)
    {
        return (a.upIn != b.upIn) && (a.downIn != b.downIn) && (a.leftIn != b.leftIn) && (a.rightIn != b.rightIn);
    }

    public override bool Equals(object obj)
    {
        if (obj is OutCode other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return (upIn, downIn, leftIn, rightIn).GetHashCode();
    }
}
