using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab = null;
    [SerializeField] private TextMeshProUGUI ballCountText = null;
    private List<BallData> ballList = new List<BallData>();
    private int COUNT_MAX = 100;
    private Vector2 firstPosition = new Vector3(0, -4.5f);
    private float shotTimer = 0.0f;
    private float SHOT_INTERVAL = 0.1f;
    private bool isShotStart = false;
    private int shotCount = 0;
    private int firstStopIndex = 0;
    private float stopPositionOffset = 0.1f;
    private bool isAllStop = true;
    private float GATHER_TIME = 0.5f;
    private float countTextOffset = 0.5f;

    public void Initialize()
    {
        for (int i = 0; i < COUNT_MAX; i++)
        {
            GameObject ball = Instantiate(ballPrefab, firstPosition, Quaternion.identity);
            BallData tempBall = ball.GetComponent<BallData>();
            tempBall.SetRadius(ball.transform.localScale.x / 2.0f);
            tempBall.SetSpeed(0.03f);
            // tempBall.SetSpeed(5.0f);
            ballList.Add(tempBall);
        }

        ballCountText.text = "×" + ballList.Count.ToString();
        ballCountText.transform.position = firstPosition + new Vector2(0, countTextOffset);
    }

    public void Update()
    {
        if (!isShotStart) return;

        int gatherCount = 0;

        // ボールが飛ぶ処理
        for (int i = 0; i < ballList.Count; i++)
        {
            if (i > shotCount) continue;
            if (ballList[i].GetIsMoving())
            {
                ballList[i].transform.Translate(ballList[i].GetVelocity() * ballList[i].GetSpeed());
            }
            else
            {
                if (i == firstStopIndex || ballList[i].GetIsGathered())
                {
                    gatherCount++;
                    continue;
                }
                ballList[i].SetGatherTimer(ballList[i].GetGatherTimer() + Time.deltaTime);
                ballList[i].transform.position = Vector2.Lerp(ballList[i].GetStopPosition(), firstPosition, ballList[i].GetGatherTimer() / GATHER_TIME);
                if (ballList[i].GetGatherTimer() >= GATHER_TIME)
                {
                    ballList[i].SetIsGathered(true);
                    ballList[i].SetGatherTimer(0.0f);
                }
            }
        }

        ballCountText.text = "×" + gatherCount.ToString();

        if (gatherCount == ballList.Count)
        {
            isShotStart = false;
            isAllStop = true;
            firstStopIndex = 0;
            return;
        }


        CheckStop();

        if (shotCount >= ballList.Count) return;
        shotTimer += Time.deltaTime;
        if (shotTimer < SHOT_INTERVAL) return;
        shotTimer = 0.0f;
        shotCount++;
    }

    public void ShotBalls(Vector2 velocity)
    {
        if (isShotStart) return;

        shotCount = 0;
        isShotStart = true;
        isAllStop = false;

        ballList.ForEach(ball =>
        {
            ball.SetVelocity(velocity);
            ball.SetIsMoving(true);
            ball.SetIsGathered(false);
        });
    }

    public void HitCollision(int index, Vector2 direction)
    {
        ballList[index].SetVelocity(Vector2.Reflect(ballList[index].GetVelocity(), direction));
    }

    public void HitUnderSide(int index)
    {
        ballList[index].transform.position = new Vector2(ballList[index].transform.position.x, ballList[index].transform.position.y + stopPositionOffset);
        ballList[index].SetStopPosition(ballList[index].transform.position);
        ballList[index].SetVelocity(Vector2.zero);
        ballList[index].SetIsMoving(false);
    }


    public void CheckStop()
    {
        List<int> stopIndexList = new List<int>();

        for (int i = 0; i < ballList.Count; i++)
        {
            if (ballList[i].GetIsMoving()) continue;
            stopIndexList.Add(i);
        }

        if (stopIndexList.Count == 0) return;
        if (stopIndexList.Count == 1)
        {
            firstStopIndex = stopIndexList[0];
            firstPosition = ballList[firstStopIndex].transform.position;
            ballCountText.transform.position = firstPosition + new Vector2(0, countTextOffset);
            return;
        }
    }

    public Vector2 GetFirstPosition()
    {
        return firstPosition;
    }

    public bool GetIsAllStop()
    {
        return isAllStop;
    }

    public List<BallData> GetBallDataList()
    {
        return ballList;
    }
}
