using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Vector2 screenEdge = new Vector2(0, 0);

    public void Initialize()
    {
        screenEdge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public Vector2 CheckCircleToBox(Vector2 circlePosition, Vector2 boxPosition, float radius, Vector2 size)
    {
        Vector2 vector = Vector2.zero;

        if (circlePosition.x + radius < boxPosition.x - size.x) return vector.normalized;
        if (circlePosition.x - radius > boxPosition.x + size.x) return vector.normalized;
        if (circlePosition.y + radius < boxPosition.y - size.y) return vector.normalized;
        if (circlePosition.y - radius > boxPosition.y + size.y) return vector.normalized;

        if (circlePosition.x > boxPosition.x + size.x) vector += Vector2.left;
        if (circlePosition.x < boxPosition.x - size.x) vector += Vector2.right;
        if (circlePosition.y > boxPosition.y + size.y) vector += Vector2.down;
        if (circlePosition.y < boxPosition.y - size.y) vector += Vector2.up;

        return vector.normalized;
    }

    public Vector2 CheckFieldEdge(Vector2 position, float radius)
    {
        Vector2 vector = Vector2.zero;

        if (position.x - radius < -screenEdge.x) vector += Vector2.right;
        if (position.x + radius > screenEdge.x) vector += Vector2.left;
        if (position.y - radius < -screenEdge.y) vector += Vector2.up;
        if (position.y + radius > screenEdge.y) vector += Vector2.down;

        return vector.normalized;
    }
}
