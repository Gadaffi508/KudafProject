using System.Collections.Generic;
using UnityEngine;

public enum StatType { MoveSpeed, Bouncess, SwordLevel,GunStrong,BulletSpeed,PlayerHealth,RandomGun }

public class StatSystem : MonoBehaviour
{
    public static StatSystem instance;

    private void Awake()
    {
        instance = this;


        statGroup = new StatGroup();
    }

    public StatGroup statGroup;


    public void SetStatValue(StatType type, float value, out bool isComplete)
    {
        statGroup.SetValue(type, value, out isComplete);
    }

    public float GetStatValue(StatType type)
    {
        return statGroup.GetValue(type);
    }
}

[System.Serializable]
public class StatGroup
{
    public List<Stat> statsGroup = new List<Stat>();

    public StatGroup()
    {
        statsGroup.Add(new Stat(StatType.MoveSpeed, 3, 8));
        statsGroup.Add(new Stat(StatType.Bouncess, 0, 1));
        statsGroup.Add(new Stat(StatType.SwordLevel, 0, 1));
        statsGroup.Add(new Stat(StatType.GunStrong, 0, 5));
        statsGroup.Add(new Stat(StatType.BulletSpeed, 0, 4));
        statsGroup.Add(new Stat(StatType.PlayerHealth, 0, 5));
        statsGroup.Add(new Stat(StatType.RandomGun, 0, 1));
    }

    public void SetValue(StatType type, float _value, out bool isComplete)
    {
        statsGroup[(int)type].value += _value;

        if (statsGroup[(int)type].value >= statsGroup[(int)type].maxValue)
        {
            isComplete = true;
        }
        else isComplete = false;

    }

    public float GetValue(StatType type)
    {
        return statsGroup[(int)type].value;
    }

}

[System.Serializable]
public class Stat
{
    public StatType type;
    public float value;
    public float maxValue;

    public Stat(StatType type, float value, float maxValue)
    {
        this.type = type;
        this.value = value;
        this.maxValue = maxValue;
    }
}
