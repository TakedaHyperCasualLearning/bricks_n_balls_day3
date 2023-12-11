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
        dottedLineData.SetImpactPointMarker(Instantiate(impactPointPrefab, Vector2.zero, Quaternion.identity));
        dottedLineData.GetImpactPointMarker().SetActive(false);
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
                float edgeDistance = 0.0f;

                if (layoutPosition.x < -screenEdge.x)
                {
                    edgeDistance = (-screenEdge.x - layoutPosition.x) / direction.x;
                    layoutPosition = layoutPosition + direction * edgeDistance;
                    direction = Vector2.Reflect(direction, Vector2.right).normalized;
                }
                if (layoutPosition.x > screenEdge.x)
                {
                    edgeDistance = (screenEdge.x - layoutPosition.x) / direction.x;
                    layoutPosition = layoutPosition + direction * edgeDistance;
                    direction = Vector2.Reflect(direction, Vector2.left).normalized;
                }
                if (layoutPosition.y < -screenEdge.y)
                {
                    edgeDistance = (-screenEdge.y - layoutPosition.y) / direction.y;
                    layoutPosition = layoutPosition + direction * edgeDistance;
                    direction = Vector2.Reflect(direction, Vector2.up).normalized;
                }
                if (layoutPosition.y > screenEdge.y)
                {
                    edgeDistance = (screenEdge.y - layoutPosition.y) / direction.y;
                    layoutPosition = layoutPosition + direction * edgeDistance;
                    direction = Vector2.Reflect(direction, Vector2.down).normalized;
                }

                dottedLineData.GetImpactPointMarker().SetActive(true);
                dottedLineData.GetImpactPointMarker().transform.position = layoutPosition;

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
        dottedLineData.GetImpactPointMarker().SetActive(false);
    }

    public LauncherData GetLauncherData() { return launcherData; }
}
