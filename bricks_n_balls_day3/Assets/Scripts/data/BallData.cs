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
    private float gatherTimer = 0.0f;
    private bool isGathered = false;
    private Vector2 stopPosition = Vector2.zero;

    public void SetVelocity(Vector3 velocity) { this.velocity = velocity; }
    public void SetIsMoving(bool isMoving) { this.isMoving = isMoving; }
    public void SetRadius(float radius) { this.radius = radius; }
    public void SetSpeed(float speed) { this.speed = speed; }
    public void SetGatherTimer(float gatherTimer) { this.gatherTimer = gatherTimer; }
    public void SetIsGathered(bool isGathered) { this.isGathered = isGathered; }
    public void SetStopPosition(Vector2 stopPosition) { this.stopPosition = stopPosition; }
    public Vector3 GetVelocity() { return velocity; }
    public bool GetIsMoving() { return isMoving; }
    public float GetRadius() { return radius; }
    public float GetSpeed() { return speed; }
    public float GetGatherTimer() { return gatherTimer; }
    public bool GetIsGathered() { return isGathered; }
    public Vector2 GetStopPosition() { return stopPosition; }

}
