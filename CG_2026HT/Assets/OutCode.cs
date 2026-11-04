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

    public OutCode()
    {
        upIn = false;
        downIn = false;
        leftIn = false;
        rightIn = false;

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

    // OR operator (+)
    public static OutCode operator +(OutCode a, OutCode b)
    {
        return new OutCode(a.upIn || b.upIn, a.downIn || b.downIn, a.leftIn || b.leftIn, a.rightIn || b.rightIn);
    }

    // AND operator (*)
    public static OutCode operator *(OutCode a, OutCode b)
    {
        return new OutCode(a.upIn && b.upIn, a.downIn && b.downIn, a.leftIn && b.leftIn, a.rightIn && b.rightIn);
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

    public bool LineClip(ref Vector2 start, ref Vector2 end) { 
        OutCode O_Start = new OutCode(start);
        OutCode O_End = new OutCode(end);
        OutCode InViewPort = new OutCode();

        if ((O_Start + O_End) == InViewPort)
        { 
            return true;
        }

        if ((O_Start * O_End) != InViewPort)
        { 
            return false;
        }

        if (O_Start == InViewPort)
        {
            return LineClip(ref end, ref start);
        }

        // Note: if x0 = x1 (vertical line segment) or y0 = y1 (horizontal line Segment)
        // these calculations will give a division be zero error,
        // so these cases need to be dealt with.

        float dy = end.y - start.y;
        float dx = end.x - start.x;

        if (Mathf.Abs(dx) < 0.0001f) // Vertical Line (x0 == x1)
        {
            if (O_Start.upIn)
            {
                start = new Vector2(start.x, 1f);
            }
            else if (O_Start.downIn)
            {
                start = new Vector2(start.x, -1f);
            }
        }
        else if (Mathf.Abs(dy) < 0.0001f) // Horizontal Line (y0 == y1)
        {
            if (O_Start.leftIn)
            {
                start = new Vector2(-1f, start.y);
            }
            else if (O_Start.rightIn)
            {
                start = new Vector2(1f, start.y);
            }
        }

        else 
        {

            float m = dy / dx;

            // Line Clipping

            // Top
            if (O_Start.upIn == true)
            {
                float x = start.x + (1 / m) * (1 - start.y);
                start = new Vector2(x, 1);
            }

            // Bottom
            if (O_Start.downIn == true)
            {
                float x = start.x + (1 / m) * (-1 - start.y);
                start = new Vector2(x, -1);
            }

            // Left
            if (O_Start.leftIn == true)
            {
                float y = start.y + m * (-1 - start.x);
                start = new Vector2(-1, y);
            }

            // Right
            if (O_Start.rightIn == true)
            {
                float y = start.y + m * (1 - start.x);
                start = new Vector2(1, y);
            }

        }

        return LineClip(ref start, ref end);
    }


}
