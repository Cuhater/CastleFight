using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour {
    static int  playerKillCounter = 0;
    static int  enemyKillCounter = 0;
    static float playerManaGathered = 0;

    public TextMeshProUGUI enemyKillCounterText;
    public TextMeshProUGUI playerKillCounterText;

    public GameObject manaCrystal;
    public Image manabar;
    public bool fillingUp;
    public float waitTime = 30.0f;
    public Text manaText;
    private bool isFullMana;

    Vector3 startPosition;
    public float currentFill;
    public float manaBarValue;
    /*
    public Image enemyHP;
    public float enemyHPcurrentFill = 1.0f;
    public float enemyHPValue;
    */
    // Use this for initialization
    public float levelTime;
    public TextMeshProUGUI textmeshPro;

    public Image manaCrystalFullMana, manaCrystalMana , manaBarFullMana, manaBarMana;

    public int color;

    void Start () {

        startPosition = manaCrystal.transform.position;
    }

    public static int PlayerKillCounter
    {
        get
        {
            return playerKillCounter;
        }
        set
        {
            playerKillCounter = value;
        }
    }

    public static int EnemyKillCounter
    {
        get
        {
            return enemyKillCounter;
        }
        set
        {
            enemyKillCounter = value;
        }
    }
    public static float PlayerManaGathered
    {
        get
        {
            return playerManaGathered;
        }
        set
        {
            playerManaGathered = value;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {


        // LevelTimer
        levelTime += Time.deltaTime;
        string minutes = Mathf.Floor(levelTime / 60).ToString("00");
        string seconds = (levelTime % 60).ToString("00");
        textmeshPro.SetText(string.Format("{0}:{1}", minutes, seconds));

        color = GameObject.FindGameObjectWithTag("Tower").GetComponent<MidTowerScript>().getColor();

        if(color == 1)
        {
            if(waitTime == 30.00f)
            {
                waitTime = 28.00f;
            }
        }
        else if (color == 2)
        {
            if (waitTime == 28.00f)
            {
                waitTime = 30.00f;
            }

        }


        if (manabar.fillAmount != 1.0f)
        {
            if (manaCrystal.transform.position != startPosition)
            {
                manaCrystal.transform.position = startPosition;
            }

            fillingUp = true;
        }
        else
        {
            fillingUp = false;
        }
        if (fillingUp)
        {

            currentFill = manabar.fillAmount += 1.0f / waitTime * Time.deltaTime;
            manaBarValue = Mathf.Floor(currentFill * 10);
           
            playerManaGathered = Mathf.Floor(currentFill * 10);
            manaText.text = manaBarValue.ToString("0");
        }
        if (manabar.fillAmount == 1.0f)
        {
            isFullMana = true;
            if (isFullMana == true)
            {
                StartCoroutine(FullMana(manaCrystal));
            }

        }
	}

        IEnumerator FullMana(GameObject image)
    {
        Vector3 position = image.transform.position;
        position.y += 0.3f;
        image.transform.position = position;


        yield return new WaitForSeconds(0.5f);
        position.y -= 0.3f;
        image.transform.position = position;

    }
    public void ManaSpawn(float amount)
    {
        currentFill -= amount;
        manaBarValue -= amount * 10;
        manabar.fillAmount -= amount;
    }

    public void increasePlayerKillCounter()
    {
        playerKillCounter++;
        playerKillCounterText.SetText(string.Format("{0}", playerKillCounter));
    }
    public void increaseEnemyKillCounter()
    {
        enemyKillCounter++;
        enemyKillCounterText.SetText(string.Format("{0}", enemyKillCounter));
    }

    public int getPlayerKillCounter()
    {
        return playerKillCounter;
    }
    public int getEnemyKillCounter()
    {
        return enemyKillCounter;
    }
    /*
    public void EnemyHPChange(float amount)
    {
        enemyHPcurrentFill -= amount;
        enemyHPValue -= amount * 10;
        Debug.Log("DA CASTLE GOT HIT OIOIOIOI " + amount);
        enemyHP.fillAmount -= amount;
    }
    */

}
