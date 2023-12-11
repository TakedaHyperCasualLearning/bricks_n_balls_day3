using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab = null;
    private List<BallData> ballList = new List<BallData>();
    private int COUNT_MAX = 100;
    private Vector3 firstPosition = new Vector3(0, -4.5f, 0);
    private Vector2 shotVelocity = new Vector2(0, 0);

    public void Initialize()
    {
        for (int i = 0; i < COUNT_MAX; i++)
        {
            GameObject ball = Instantiate(ballPrefab, firstPosition, Quaternion.identity);
            ballList.Add(ball.GetComponent<BallData>());
        }
    }

    public void Updata()
    {
        // ボールを発射する
        if (Input.GetMouseButtonDown(0))
        {
            ShotBalls();
        }

        // ボールが飛ぶ処理
        ballList.ForEach(BallData =>
        {
            if (BallData.GetIsMoving())
            {
                BallData.transform.Translate(BallData.GetVelocity());
            }
        });
    }

    private void ShotBalls()
    {
        shotVelocity = new Vector2(0.8f, 0.2f).normalized;

        ballList.ForEach(ball =>
        {
            ball.SetVelocity(shotVelocity);
            ball.SetIsMoving(true);
        });

    }
}
