using UnityEngine;

public static class RectExtensions
{
    public static void SetX(this Rect rect, float x)
    {
        rect.Set(x, rect.y, rect.width, rect.height);
    }
}