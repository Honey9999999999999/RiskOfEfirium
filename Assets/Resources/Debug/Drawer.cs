using System.Collections.Generic;
using UnityEngine;

public class Drawer
{
    public static void DrawPolyhedralFigure(List<Vector2> points)
    {
        DrawPolyhedralFigure(points, Vector2.zero);
    }
    public static void DrawPolyhedralFigure(List<Vector3> points)
    {
        DrawPolyhedralFigure(points, Vector3.zero);
    }
    public static void DrawPolyhedralFigure(List<Vector2> points, Vector2 offset)
    {
        if (points.Count > 1)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Debug.DrawLine(offset + points[i], offset + points[(i < points.Count - 1) ? i + 1 : 0]);
            }
        }
    }
    public static void DrawPolyhedralFigure(List<Vector3> points, Vector3 offset)
    {
        if (points.Count > 1)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Debug.DrawLine(offset + points[i], offset + points[(i < points.Count - 1) ? i + 1 : 0]);
            }
        }
    }

    public static void DrawCurve(List<Vector2> points, Vector2 offset, Color32 color)
    {
        if (points.Count > 1)
        {
            for (int i = 1; i < points.Count; i++)
            {
                Debug.DrawLine(offset + points[i - 1], offset + points[i], color);
            }
        }
    }
    public static void DrawCurve(List<Vector3> points, Vector3 offset, Color32 color)
    {
        if (points.Count > 1)
        {
            for (int i = 1; i < points.Count; i++)
            {
                Debug.DrawLine(offset + points[i - 1], offset + points[i], color);
            }
        }
    }

    public static void DrawDiamondPoint(Vector3 position, float size, Color32 color)
    {
        Debug.DrawLine(position + Vector3.up * size, position + Vector3.right * size, color);
        Debug.DrawLine(position + Vector3.right * size, position + Vector3.down * size, color);
        Debug.DrawLine(position + Vector3.down * size, position + Vector3.left * size, color);
        Debug.DrawLine(position + Vector3.left * size, position + Vector3.up * size, color);
    }
}
