using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockData : MonoBehaviour
{
    private int durability = 0;
    private TextMeshProUGUI durabilityText = null;
    private Vector2 size = Vector2.zero;
    private bool isUnbroken = true;


    public void SetDurability(int durability) { this.durability = durability; }
    public void SetDurabilityText(TextMeshProUGUI durabilityText) { this.durabilityText = durabilityText; }
    public void SetSize(Vector2 size) { this.size = size; }
    public void SetIsUnbroken(bool isUnbroken) { this.isUnbroken = isUnbroken; }
    public int GetDurability() { return durability; }
    public TextMeshProUGUI GetDurabilityText() { return durabilityText; }
    public Vector2 GetSize() { return size; }
    public bool GetIsUnbroken() { return isUnbroken; }

}
