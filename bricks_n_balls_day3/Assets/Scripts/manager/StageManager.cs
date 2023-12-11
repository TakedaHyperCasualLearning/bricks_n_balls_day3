using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int STAGE_X = 5;
    private int STAGE_Y = 4;
    private float INTERVAL = 1.0f;
    private Vector2 stageSize = Vector2.zero;
    private Vector2 offsetPosition = new Vector2(0.75f, 0.0f);

    public void Initialize()
    {
        stageSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log(stageSize);
    }

    public Vector2 GetBlockPosition(int index)
    {
        int x = index % STAGE_X;
        int y = index / STAGE_X;
        return new Vector2(x * INTERVAL - stageSize.x + offsetPosition.x, y * INTERVAL);
    }

    public int GetBlockDurability()
    {
        return Random.Range(40, 90);
    }
}
