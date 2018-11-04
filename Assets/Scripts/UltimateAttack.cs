using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltimateAttack : MonoBehaviour {

    bool check;
    int ekcOld;
    int pkcOld;
    public int eKillCounter = 0;
    public int pKillCounter = 0;
    private Transform target;
    public GameObject ultimate;
    public Image ultimateWall;
    public int ultimateCount = 0;
    public GameObject gameMaster;
    public GameObject projectilePrefab;
    public float duration = 5;
    public TextMeshProUGUI textmeshPro;
    public GameObject errorImage;


    private bool isUsed;
	// Use this for initialization
	void Start () {
        gameMaster = GameObject.Find("GameMaster");
        InvokeRepeating("UpdateKillCounter", 0f, 1f);
    }
    // Update is called once per frame
    void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.T))
        {
            FireUltimate();
        }
        if (isUsed)
        {
            duration -= Time.deltaTime;
        }
        if (ultimateCount < 1)
        {
            ultimate.gameObject.SetActive(false);
            //ultimateWall.gameObject.SetActive(false);
        }
        else
        {
            ultimate.gameObject.SetActive(true);
            textmeshPro.SetText(string.Format("{0} use left", ultimateCount));
            //ultimateWall.gameObject.SetActive(true);
            if (ultimateCount > 1)
            {
                textmeshPro.SetText(string.Format("{0} uses left", ultimateCount));
            }

        }
    }
    void UpdateKillCounter()
    {
        ekcOld = eKillCounter;
        pkcOld = pKillCounter;
        eKillCounter = gameMaster.GetComponent<Stats>().getEnemyKillCounter();
        pKillCounter = gameMaster.GetComponent<Stats>().getPlayerKillCounter();


        if(pkcOld < pKillCounter)
        {
            check = false;
        }
        if (!check)
        {
            int result = pKillCounter % 5;
            if (result == 0 && pKillCounter != 0)
            {
                ultimateCount ++;
                check = true;
            }
        }        
        
    }
    public void FireUltimate()
    {
        if(ultimateCount > 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length > 0)
            {
                isUsed = true;
                foreach (GameObject enemy in enemies)
                {
                    if (enemy.tag != "Dead")
                    {
                        Debug.Log("FIRE PROJECTILE UHHHHHHH");
                        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
                        Projectile projectile = projectileGO.GetComponent<Projectile>();
                        projectile.Seek(enemy.transform);
                        WaitFor5Second();
                        enemy.gameObject.GetComponent<DamageHandler>().TakeDamage(10);

                    }
                }
                ultimateCount--;
            }
            else
            {
                StartCoroutine(ShowError());
            }
        }
    }
    IEnumerator WaitFor5Second()
    {
        yield return new WaitForSeconds(5f);
    }
    IEnumerator ShowError()
    {
        errorImage.SetActive(true);

        yield return new WaitForSeconds(2);

        errorImage.SetActive(false);
    }

    public void Damage()
    {

    }
}
