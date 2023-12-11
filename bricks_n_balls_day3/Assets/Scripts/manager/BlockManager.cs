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
            BlockData tempBlock = block.GetComponent<BlockData>();
            tempBlock.SetSize(block.transform.localScale / 2.0f);
            tempBlock.SetDurability(1);
            blockList.Add(tempBlock);
        }
    }

    public void Update()
    {

    }

    public void HitCollision(int index)
    {
        Damage(index);
    }

    public void Damage(int index)
    {
        blockList[index].SetDurability(blockList[index].GetDurability() - 1);
        blockList[index].GetDurabilityText().text = blockList[index].GetDurability().ToString();
    }

    public List<BlockData> GetBlockDataList()
    {
        return blockList;
    }
}
