using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    static float enemyManaGathered = 0;
    static float enemyManaSpent = 0;

    static int enemyBasicMinionSpawnCounter = 0;
    static int enemyRangedMinionSpawnCounter = 0;
    static int enemyTankMinionSpawnCounter = 0;
    static int enemyDamageMinionSpawnCounter = 0;

    public GameObject playerCastle;
    public GameObject enemyCastle;

    public GameObject SpawnEffect;
    public GameObject MinionToSpawn;
    public GameObject MinionToSpawn2;
    public GameObject MinionToSpawn3;
    public GameObject MinionToSpawn4;

    public Vector3 center;
    public Vector3 size;
    public float checkSpawnFrequence = 6f;
    public float currentFill;
    public float waitTime = 30.0f;
    public float currentMana;

    private float twoMana = 0.2f;
    private float threeMana = 0.3f;
    private float fourMana = 0.4f;
    private float fiveMana = 0.5f;
    private float sixMana = 0.6f;
    private float sevenMana = 0.7f;
    private float eightMana = 0.8f;
    private float nineMana = 0.9f;
    private float tenMana = 1.0f;


    private int color = 0;
    bool check;
    bool victory;
    bool isFullMana;

    public PauseMenu pm;
    // Use this for initialization
    void Start () {
        InvokeRepeating("CheckSpawn", 0f, checkSpawnFrequence);

        playerCastle = GameObject.FindGameObjectWithTag("PlayerCastle");
        enemyCastle = GameObject.FindGameObjectWithTag("EnemyCastle");
        pm = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenu>();
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        color = GameObject.FindGameObjectWithTag("Tower").GetComponent<MidTowerScript>().getColor();

        if (color == 2)
        {
            if (waitTime == 30.00f)
            {
                waitTime = 28.00f;
                Debug.Log(" KI GOT DA POWER");
            }

        }
        else if (color == 1)
        {
            if (waitTime == 28.00f)
            {
                waitTime = 30.00f;
                Debug.Log(" YOU GOT DA POWER");
            }

        }
        if (enemyCastle != null)
        {
            if (enemyCastle.transform.tag == "Dead")
            {
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                    CancelInvoke();

            }      
        }
        else
        {
            pm.VictoryScreen();
        }
        if (playerCastle != null)
        {
            if (playerCastle.transform.tag == "Dead")
            {
                Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
                CancelInvoke(); 
            }
        }
        else
        {
            pm.DefeatScreen();
        }
        


        if (playerCastle == null || enemyCastle == null)
        {
            Debug.Log("CASLTE DOWN! :O");
            victory = true;
            CancelInvoke();
        }

        if (!victory)
        { 
            if (currentFill >= 0.5f && !check)
            {
                checkSpawnFrequence = 2f;
               // Debug.Log("SCHNELL CHECKER");
                check = true;
            }
            else if (currentFill <= 0.5f && check)
            {
                checkSpawnFrequence = 6f;
                //Debug.Log("SLOWEST CHECKER");
                check = false;
            }
            /*
            {
                checkSpawnFrequence = 7f;
                Debug.Log("EH KEIN MANA SCHÖN 7 sek checkertime");
            }
            */
            if (currentFill <= 1.0f)
            {
                currentFill = currentMana += 1.0f / waitTime * Time.deltaTime;
                enemyManaGathered = Mathf.Floor(currentFill * 10);
            }
            else
            {
                isFullMana = true;
                if (isFullMana)
                {
                    SpawnRandomMinion();
                    isFullMana = false;
                }
            }
        }
    }

    void CheckSpawn()
    {
        if (enemyCastle.tag == "Dead" || enemyCastle == null)
        {
            Debug.Log("PLAYER WOOOOOOOOOOOOONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN");
        }
        else
        { 
            Debug.Log("CheckSpawn YO");
            int rnd = Random.Range(1, 5);
            Debug.Log("RANDOM" + rnd);



            // ########## RND = 1 ##########
            if (rnd == 1)
            {
                    if(currentFill >= eightMana)
                    {
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnBasicMinion();
                    }
                    else if (currentFill >= sixMana)
                    {
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnRangedMinion();
                        Debug.Log("RANGED AND NORMAL ARMEE");
                        return;
                    }
                    else if(currentFill >= fourMana)
                    {
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnBasicMinion();
                        Debug.Log("ZWEIMANN ARMEE");
                        return;
                    }
                    else if (currentFill >= twoMana)
                    {
                        SpawnBasicMinion();
                        Debug.Log("ARG SPAWN BASIC AIAIAI");
                        return;
                    }



                // ########## RND = 2 ##########
                if (rnd == 2)
                {
                    if(currentFill >= sixMana)
                    {
                        if(GameObject.Find("Enemy Tank Minion(Clone)") == null)
                        {
                            SpawnTankMinion();
                        }
                        else
                        {
                            SpawnRangedMinion();
                            WaitFor1Second();
                            SpawnBasicMinion();
                        }
                    }
                    else if(currentFill >= eightMana)
                    {
                        if (GameObject.Find("Enemy Damage Minion(Clone)") == null)
                        {
                            SpawnDamageMinion();
                        }
                        else if (GameObject.Find("Enemy Tank Minion(Clone)") == null)
                        {
                            SpawnTankMinion();
                        }
                        else
                        {
                            SpawnRangedMinion();
                            WaitFor1Second();
                            SpawnRangedMinion();
                        }

                    }
                    else if (currentFill >= fourMana)
                    {
                        SpawnRangedMinion();
                        Debug.Log("Raaaanged");
                    }

                }

                // ########## RND = 3 ##########
                if (rnd == 3)
                {
                    if (GameObject.Find("Enemy Tank Minion(Clone)") != null)
                    {
                        if (currentFill >= eightMana)
                        {
                            SpawnDamageMinion();
                        }
                        else if (currentFill >= sixMana)
                        {
                            if(GameObject.Find("Enemy Tank Minion(Clone)") != null)
                            {
                                SpawnRangedMinion();
                                WaitFor1Second();
                                SpawnBasicMinion();
                            }
                        }
                    }
                    else
                    {
                        SpawnTankMinion();
                        Debug.Log("Tanki manki");
                    }

                }

                // ########## RND = 4 ##########
                if (rnd == 4 && currentFill >= eightMana)
                {
                    if (GameObject.Find("Enemy Damage Minion(Clone)") != null)
                    {
                        SpawnRangedMinion();
                        WaitFor1Second();
                        SpawnRangedMinion();
                    }
                    else
                    {
                        SpawnDamageMinion();
                        Debug.Log("Rasur");
                    }

                }
            }
        }
    }

    private void SpawnBasicMinion()
    {
        enemyBasicMinionSpawnCounter++;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(MinionToSpawn, pos, Quaternion.identity);
        Instantiate(SpawnEffect, pos, Quaternion.identity);
        currentMana -= twoMana;
        currentFill -= twoMana;
        enemyManaSpent += 2;
    }
    private void SpawnRangedMinion()
    {
        enemyRangedMinionSpawnCounter++;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(MinionToSpawn2, pos, Quaternion.identity);
        Instantiate(SpawnEffect, pos, Quaternion.identity);
        currentMana -= fourMana;
        currentFill -= fourMana;
        enemyManaSpent += 4;
    }
    private void SpawnTankMinion()
    {
        enemyTankMinionSpawnCounter++;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(MinionToSpawn3, pos, Quaternion.identity);
        Instantiate(SpawnEffect, pos, Quaternion.identity);
        currentMana -= sixMana;
        currentFill -= sixMana;
        enemyManaSpent += 6;

    }
    private void SpawnDamageMinion()
    {
        enemyDamageMinionSpawnCounter++;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(MinionToSpawn4, pos, Quaternion.identity);
        Instantiate(SpawnEffect, pos, Quaternion.identity);
        currentMana -= eightMana;
        currentFill -= eightMana;
        enemyManaSpent += 8;
    }
    private void SpawnRandomMinion()
    {
        if (isFullMana)
        {
            int rnd = Random.Range(1, 5);

            if (isFullMana)
            {
                isFullMana = false;
                if (rnd == 1)
                {
                    isFullMana = false;
                    SpawnBasicMinion();
                    WaitFor1Second();
                    SpawnBasicMinion();
                    WaitFor1Second();
                    SpawnBasicMinion();
                    WaitFor1Second();
                    SpawnBasicMinion();
                    WaitFor1Second();
                    SpawnBasicMinion();


                }
                if (rnd == 2)
                {
                    isFullMana = false;
                    SpawnRangedMinion();
                    WaitFor1Second();
                    SpawnRangedMinion();
                    WaitFor1Second();
                    SpawnBasicMinion();
                }
                if (rnd == 3)
                {
                    if (GameObject.Find("Enemy Tank Minion(Clone)") == null)
                    {
                        isFullMana = false;
                        SpawnTankMinion();
                        WaitFor1Second();
                        SpawnRangedMinion();
                    }
                    else
                    {
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnBasicMinion();
                        WaitFor1Second();
                        SpawnRangedMinion();
                    }

                }
                if (rnd == 4)
                {
                    isFullMana = false;
                    SpawnDamageMinion();
                    WaitFor1Second();
                    SpawnBasicMinion();

                }
            }
        }

    }
    IEnumerator WaitFor1Second()
    {
        yield return new WaitForSeconds(1f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(center, size);
    }

    public static int EnemyBasicMinionSpawnCounter
    {
        get
        {
            return enemyBasicMinionSpawnCounter;
        }
        set
        {
            enemyBasicMinionSpawnCounter = value;
        }
    }

    public static int EnemyRangedMinionSpawnCounter
    {
        get
        {
            return enemyRangedMinionSpawnCounter;
        }
        set
        {
            enemyRangedMinionSpawnCounter = value;
        }
    }

    public static int EnemyTankMinionSpawnCounter
    {
        get
        {
            return enemyTankMinionSpawnCounter;
        }
        set
        {
            enemyTankMinionSpawnCounter = value;
        }
    }

    public static int EnemyDamageMinionSpawnCounter
    {
        get
        {
            return enemyDamageMinionSpawnCounter;
        }
        set
        {
            enemyDamageMinionSpawnCounter = value;
        }
    }

    public static float EnemyManaGathered
    {
        get
        {
            return enemyManaGathered;
        }
        set
        {
            enemyManaGathered = value;
        }
    }
    public static float EnemyManaSpent
    {
        get
        {
            return enemyManaSpent;
        }
        set
        {
            enemyManaSpent = value;
        }
    }
}
