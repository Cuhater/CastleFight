using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHP : MonoBehaviour {



    public float currentFill;
    public TextMeshProUGUI textmeshPro;
    public float enemyHPstart;
    public Image enemyHP;
    public float enemyHPcurrentFill = 1.0f;
    private float enemyHPValue = 100;


    // Use this for initialization
    void Start () {
        enemyHPstart = GetComponent<DamageHandler>().health;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyHPChange(float amount)
    {
        enemyHPValue -= amount * 100 / enemyHPstart;
        enemyHP.fillAmount -= amount / enemyHPstart;
        if(enemyHPValue < 0)
        {
            enemyHPValue = 0;
        }
        textmeshPro.SetText(enemyHPValue.ToString("0") + " %");
    }
}
