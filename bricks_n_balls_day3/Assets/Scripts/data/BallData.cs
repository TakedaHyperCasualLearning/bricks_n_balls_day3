using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallData : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private bool isMoving = false;
    private float radius = 0.0f;
    private float speed = 0.0f;

    public void SetVelocity(Vector3 velocity) { this.velocity = velocity; }
    public void SetIsMoving(bool isMoving) { this.isMoving = isMoving; }
    public void SetRadius(float radius) { this.radius = radius; }
    public void SetSpeed(float speed) { this.speed = speed; }
    public Vector3 GetVelocity() { return velocity; }
    public bool GetIsMoving() { return isMoving; }
    public float GetRadius() { return radius; }
    public float GetSpeed() { return speed; }

}
