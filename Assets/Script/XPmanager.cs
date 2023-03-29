
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class XPmanager : MonoBehaviour
{
    public static XPmanager xInstance;

    public int level = 1;
    public float experience { get; private set; }
    public Text lvlText;
    public Image exParImage;
    public Animator anim;
    public GameObject upgradePanel;
    UpgradeSystem upgradeSystem;
    public bool zamanbaslat = true;

    private void Awake()
    {
        //Singleton
        if(xInstance == null)
            xInstance = this;
        
        upgradePanel.SetActive(false);

        upgradeSystem = GetComponent<UpgradeSystem>();

    }
    public static int ExpNeedTolvlUP(int currentLevel)
    {
        if (currentLevel==0)
            return 0;


            return (currentLevel*currentLevel+currentLevel)*5;     
        
    }

    private void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.Space))
            SetExperience(50);
    }

    public void SetExperience(float exp)
    {
        experience += exp;
        float expNeeded = ExpNeedTolvlUP(level);
        float previousExperience = ExpNeedTolvlUP(level-1);

        if (experience>= expNeeded)
        {
            LevelUp();
            expNeeded = ExpNeedTolvlUP(level);
            previousExperience = ExpNeedTolvlUP(level-1);
            
        }

        //fill expbar ýmage with exp

        exParImage.fillAmount = (experience-previousExperience)/(expNeeded-previousExperience);

        // reset xpbar

        if (exParImage.fillAmount ==1)
        {
            exParImage.fillAmount = 0;
            
        }
        

    }
    public void LevelUp()
    {
        level++;     
        anim.SetTrigger("nexthurt");      
        lvlText.text = level.ToString("");
        StartCoroutine(Delayaction());

    }
    public void LoadScene()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    IEnumerator Delayaction()
    {
        yield return new WaitForSeconds(1);
        upgradeSystem.SetUpgradeSlot();

        if (upgradeSystem.GetAllListCount() <= 0)
        {
            yield break;
            anim.SetBool("sendbool",false);
        }
            

        upgradePanel.SetActive(true);

        zamanbaslat = false;
        Time.timeScale = 0;
        
    }





}
