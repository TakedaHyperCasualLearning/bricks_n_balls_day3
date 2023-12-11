using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherManager : MonoBehaviour
{
    [SerializeField] private GameObject dotPointPrefab = null;
    [SerializeField] private GameObject impactPointPrefab = null;
    private LauncherData launcherData = new LauncherData();
    private DottedLineData dottedLineData = new DottedLineData();
    private Vector2 firstPosition = new Vector2(0.0f, -4.5f);
    private Vector2 screenEdge = Vector2.zero;
    private int REFLECTION_DOT_COUNT = 5;

    public void Initialize()
    {
        screenEdge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        launcherData.SetPosition(firstPosition);
        dottedLineData.SetDotInterval(0.3f);
    }

    public void Update()
    {

    }

    public void DrawDottedLine()
    {
        int dotActiveCount = 0;
        Vector2 layoutPosition = launcherData.GetPosition();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - launcherData.GetPosition()).normalized;
        launcherData.SetShotDirection(direction);
        bool loopEnd = false;

        do
        {
            layoutPosition = layoutPosition + direction * dottedLineData.GetDotInterval();

            if (layoutPosition.x < -screenEdge.x || layoutPosition.x > screenEdge.x || layoutPosition.y < -screenEdge.y || layoutPosition.y > screenEdge.y)
            {
                Vector2 reflectionNormal = Vector2.zero;
                if (layoutPosition.x < -screenEdge.x) reflectionNormal += Vector2.right;
                if (layoutPosition.x > screenEdge.x) reflectionNormal += Vector2.left;
                if (layoutPosition.y < -screenEdge.y) reflectionNormal += Vector2.up;
                if (layoutPosition.y > screenEdge.y) reflectionNormal += Vector2.down;

                direction = Vector2.Reflect(direction, reflectionNormal).normalized;

                for (int j = 0; j < REFLECTION_DOT_COUNT; j++)
                {
                    layoutPosition = layoutPosition + direction * dottedLineData.GetDotInterval();

                    if ((dotActiveCount) < dottedLineData.GetDotPointMarkerList().Count)
                    {
                        dottedLineData.GetDotPointMarkerList()[dotActiveCount].transform.position = layoutPosition;
                        dottedLineData.GetDotPointMarkerList()[dotActiveCount].SetActive(true);
                    }
                    else
                    {
                        GameObject dotPoint = Instantiate(dotPointPrefab, layoutPosition, Quaternion.identity);
                        dottedLineData.AddDotPointMarkerList(dotPoint);
                    }
                    dotActiveCount++;
                }

                loopEnd = true;
                break;
            }

            if (dotActiveCount < dottedLineData.GetDotPointMarkerList().Count)
            {
                dottedLineData.GetDotPointMarkerList()[dotActiveCount].transform.position = layoutPosition;
                dottedLineData.GetDotPointMarkerList()[dotActiveCount].SetActive(true);
            }
            else
            {
                GameObject dotPoint = Instantiate(dotPointPrefab, layoutPosition, Quaternion.identity);
                dottedLineData.AddDotPointMarkerList(dotPoint);
            }
            dotActiveCount++;
        } while (!loopEnd);

        for (int i = dotActiveCount; i < dottedLineData.GetDotPointMarkerList().Count; i++)
        {
            dottedLineData.GetDotPointMarkerList()[i].SetActive(false);
        }
    }

    public void ClearDottedLine()
    {
        for (int i = 0; i < dottedLineData.GetDotPointMarkerList().Count; i++)
        {
            dottedLineData.GetDotPointMarkerList()[i].SetActive(false);
        }
    }

    public LauncherData GetLauncherData() { return launcherData; }
}
