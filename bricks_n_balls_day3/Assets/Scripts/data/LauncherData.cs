using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherData : MonoBehaviour
{
    private Vector2 position = Vector2.zero;
    private Vector2 shotDirection = Vector2.zero;


    public void SetPosition(Vector2 position) { this.position = position; }
    public void SetShotDirection(Vector2 shotDirection) { this.shotDirection = shotDirection; }
    public Vector2 GetPosition() { return position; }
    public Vector2 GetShotDirection() { return shotDirection; }
}
