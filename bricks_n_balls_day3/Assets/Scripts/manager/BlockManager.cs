using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab = null;
    [SerializeField] private GameObject durabilityTextPrefab = null;
    [SerializeField] private Canvas canvas = null;

    private List<BlockData> blockList = new List<BlockData>();
    private int COUNT_MAX = 5;

    public void Initialize()
    {
        for (int i = 0; i < COUNT_MAX; i++)
        {
            GameObject block = Instantiate(blockPrefab, new Vector3(-2.0f + i, 0, 0), Quaternion.identity);
            BlockData tempBlock = block.GetComponent<BlockData>();
            tempBlock.SetSize(block.transform.localScale / 2.0f);
            tempBlock.SetDurability(1);
            GameObject durabilityText = Instantiate(durabilityTextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            durabilityText.transform.SetParent(canvas.transform);
            durabilityText.transform.localScale = new Vector3(1, 1, 1);
            tempBlock.SetDurabilityText(durabilityText.GetComponent<TMPro.TextMeshProUGUI>());
            tempBlock.GetDurabilityText().text = tempBlock.GetDurability().ToString();
            tempBlock.GetDurabilityText().transform.position = block.transform.position;
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
        if (blockList[index].GetDurability() <= 0)
        {
            Break(index);
            return;
        }
        blockList[index].GetDurabilityText().text = blockList[index].GetDurability().ToString();
    }

    public void Break(int index)
    {
        blockList[index].SetIsUnbroken(false);
        blockList[index].gameObject.SetActive(false);
        blockList[index].GetDurabilityText().gameObject.SetActive(false);
    }

    public List<BlockData> GetBlockDataList()
    {
        return blockList;
    }
}
