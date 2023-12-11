using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab = null;

    private List<BlockData> blockList = new List<BlockData>();
    private int COUNT_MAX = 50;

    public void Initialize()
    {
        for (int i = 0; i < COUNT_MAX; i++)
        {
            GameObject block = Instantiate(blockPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            blockList.Add(block.GetComponent<BlockData>());
        }
    }

    public void Update()
    {

    }
}
