using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallData : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private bool isMoving = false;

    public void SetVelocity(Vector3 velocity) { this.velocity = velocity; }
    public void SetIsMoving(bool isMoving) { this.isMoving = isMoving; }
    public Vector3 GetVelocity() { return velocity; }
    public bool GetIsMoving() { return isMoving; }

}
