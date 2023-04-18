using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private UpgradeSystem upgradeSystem;

    Button button;

    private UpgradeData currentData;

    public UpgradeData CurrentData
    {
        set 
        {
            currentData = value;

            if(currentData is not null)
            {
                GetComponent<Image>().sprite = currentData.icon;
            }
        }
    }

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(ButtonClick);
    }

    public void ButtonClick()
    {
        currentData.Upgrade();

        if (currentData.isComplete)
        {
            upgradeSystem.AddCompleteList(currentData);
        }

        if(currentData.type == StatType.SwordLevel)
        {
            weaponManager.GetSword().SwordUpdate();
        }
        else if(currentData.type == StatType.RandomGun)
        {
            weaponManager.WeaponChange();
        }
        Time.timeScale = 1;
    }
}
