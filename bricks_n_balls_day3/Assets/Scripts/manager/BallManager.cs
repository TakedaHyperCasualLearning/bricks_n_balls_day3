using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab = null;
    private List<BallData> ballList = new List<BallData>();
    private int COUNT_MAX = 50;
    private Vector3 firstPosition = new Vector3(0, -4.5f, 0);
    private float shotTimer = 0.0f;
    private float SHOT_INTERVAL = 0.1f;
    private bool isShitStart = false;
    private int shotCount = 0;

    public void Initialize()
    {
        for (int i = 0; i < COUNT_MAX; i++)
        {
            GameObject ball = Instantiate(ballPrefab, firstPosition, Quaternion.identity);
            BallData tempBall = ball.GetComponent<BallData>();
            tempBall.SetRadius(ball.transform.localScale.x / 2.0f);
            tempBall.SetSpeed(0.04f);
            // tempBall.SetSpeed(5.0f);
            ballList.Add(tempBall);
        }
    }

    public void Update()
    {
        // ボールが飛ぶ処理
        for (int i = 0; i < ballList.Count; i++)
        {
            if (i > shotCount || !ballList[i].GetIsMoving()) break;
            ballList[i].transform.Translate(ballList[i].GetVelocity() * ballList[i].GetSpeed());
        }

        if (!isShitStart) return;
        shotTimer += Time.deltaTime;
        if (shotTimer < SHOT_INTERVAL) return;
        shotTimer = 0.0f;
        if (shotCount >= ballList.Count) return;
        shotCount++;
    }

    public void ShotBalls(Vector2 velocity)
    {
        isShitStart = true;

        ballList.ForEach(ball =>
        {
            ball.SetVelocity(velocity);
            ball.SetIsMoving(true);
        });
    }

    public void HitCollision(int index, Vector2 direction)
    {
        ballList[index].SetVelocity(Vector2.Reflect(ballList[index].GetVelocity(), direction));
    }

    public List<BallData> GetBallDataList()
    {
        return ballList;
    }
}
