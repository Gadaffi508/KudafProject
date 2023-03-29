using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public GameObject upgradeCanvas;
    public UpgradeButton[] upgradeButtons;

    public List<UpgradeData> globalUpgradeList = new List<UpgradeData>();
    public List<UpgradeData> weaponUpgradeList = new List<UpgradeData>();

    public List <UpgradeData> allUpgradeList = new List<UpgradeData>();

    private List<UpgradeData> completedList = new List<UpgradeData>();

    List<int> randomList = new List<int>();

    WeaponManager weaponManager;


    private void Start()
    {
        weaponManager = GetComponent<WeaponManager>();

        UpgradeListUpdate();


        for (int i = 0; i < allUpgradeList.Count; i++)
        {
            allUpgradeList[i].isComplete = false;
        }
    }
    public void SetUpgradeSlot()
    {
        UpgradeListUpdate();

        randomList.Clear();

        int c = 0;
        for (int i = 0; i < allUpgradeList.Count; i++)
        {
            if (i >= upgradeButtons.Length) break;
            upgradeButtons[i].gameObject.SetActive(true);
            c++;
        }

        for (int i = 0; i < c; i++)
        {   
            int rndm = UnityEngine.Random.Range(0, allUpgradeList.Count);

            while (randomList.Contains(rndm))
            {
                rndm = UnityEngine.Random.Range(0, allUpgradeList.Count);
            }
            randomList.Add(rndm);

            upgradeButtons[i].CurrentData = allUpgradeList[rndm];
        }
    }

    public void CloseCanvas()
    {
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
        upgradeCanvas.SetActive(false);
    }

    public void AddCompleteList(UpgradeData data)
    {
        completedList.Add(data);
    }

    public int GetAllListCount()
    {
        return allUpgradeList.Count;
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        foreach (UpgradeData data in completedList)
        {
            data.isComplete = false;
        }
    }
#endif


    public void UpgradeListUpdate()
    {
        allUpgradeList.Clear();
        weaponUpgradeList.Clear();

        for (int i = 0; i < globalUpgradeList.Count; i++)
        {
            if (!globalUpgradeList[i].isComplete)
            {
                allUpgradeList.Add(globalUpgradeList[i]);
            }
        }

        for (int i = 0; i < weaponManager.GetCurrentWeaponUpgrades().Count; i++)
        {
            weaponUpgradeList.Add(weaponManager.GetCurrentWeaponUpgrades()[i]);
        }

        for (int i = 0; i < weaponUpgradeList.Count; i++)
        {
            if (!weaponUpgradeList[i].isComplete)
            {
                allUpgradeList.Add(weaponUpgradeList[i]);
            }
        }

    }
}
