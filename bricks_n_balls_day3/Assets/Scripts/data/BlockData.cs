using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockData : MonoBehaviour
{
    private int durability = 0;
    private TextMeshProUGUI durabilityText = null;


    public void SetDurability(int durability) { this.durability = durability; }
    public void SetDurabilityText(TextMeshProUGUI durabilityText) { this.durabilityText = durabilityText; }
    public int GetDurability() { return durability; }
    public TextMeshProUGUI GetDurabilityText() { return durabilityText; }

}
