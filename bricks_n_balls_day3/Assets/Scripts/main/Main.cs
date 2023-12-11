using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private BallManager ballManager = null;
    [SerializeField] private BlockManager blockManager = null;
    [SerializeField] private CollisionManager collisionManager = null;

    void Start()
    {
        ballManager.Initialize();
        blockManager.Initialize();
        collisionManager.Initialize();
    }

    void Update()
    {
        ballManager.Update();
        blockManager.Update();

        for (int i = 0; i < ballManager.GetBallDataList().Count; i++)
        {
            if (!ballManager.GetBallDataList()[i].GetIsMoving()) continue;

            Vector2 direction = collisionManager.CheckFieldEdge(ballManager.GetBallDataList()[i].transform.position, ballManager.GetBallDataList()[i].GetRadius()); // ボールが画面外に出たかどうかをチェック

            if (direction != Vector2.zero)
            {
                ballManager.HitCollision(i, direction);
                continue;
            }

            // ブロックとの当たり判定
            for (int j = 0; j < blockManager.GetBlockDataList().Count; j++)
            {
                if (!blockManager.GetBlockDataList()[j].GetIsUnbroken()) continue;

                direction = collisionManager.CheckCircleToBox(ballManager.GetBallDataList()[i].transform.position, blockManager.GetBlockDataList()[j].transform.position, ballManager.GetBallDataList()[i].GetRadius(), blockManager.GetBlockDataList()[j].GetSize()); // ボールとブロックが衝突したかどうかをチェック

                if (direction != Vector2.zero)
                {
                    ballManager.HitCollision(i, direction);
                    blockManager.HitCollision(j);
                    break;
                }
            }
        }
    }
}
