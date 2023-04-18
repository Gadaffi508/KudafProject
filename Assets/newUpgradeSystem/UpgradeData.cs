using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade")]
public class UpgradeData : ScriptableObject
{
    public Sprite icon;
    public StatType type;
    public float addAmount;

    public bool isComplete = false;

    public void Upgrade()
    {
        StatSystem.instance.SetStatValue(type, addAmount, out isComplete);
    }
}
