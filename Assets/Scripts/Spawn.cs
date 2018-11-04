using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    static float playerManaSpent = 0;

    static int basicMinionSpawnCounter = 0;
    static int rangedMinionSpawnCounter = 0;
    static int tankMinionSpawnCounter = 0;
    static int damageMinionSpawnCounter = 0;

    public Sprite manaBarNoMana, manaBarMana, manaCrystalNoMana, manaCrystalMana;
    public GameObject SpawnEffect;
    public GameObject MinionToSpawn;
    public GameObject MinionToSpawn2;
    public GameObject MinionToSpawn3;
    public GameObject MinionToSpawn4;

    public Vector3 center;
    public Vector3 size;
    Stats mana;
    Renderer rend;

    public GameObject errorImage;

    [Header("Set Minion Mana")]
    public float minion1ManaNeed = 2;
    public float minion2ManaNeed = 4;
    public float minion3ManaNeed = 6;
    public float minion4ManaNeed = 8;
    // Use this for initialization
    void Start() {
        mana = GetComponent<Stats>();
    }
    public void SpawnMinion1()
    {
        if (mana.manaBarValue >= minion1ManaNeed)
        {
            basicMinionSpawnCounter += 1;
            playerManaSpent += 2;
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
            Instantiate(MinionToSpawn, pos, Quaternion.identity);
            Instantiate(SpawnEffect, pos, Quaternion.identity);

            float manaValue = minion1ManaNeed / 10;

            mana.ManaSpawn(manaValue);
        }
        else
        {
            StartCoroutine(ShowError());
        }

    }

    IEnumerator ShowError()
    {
        mana.manaCrystal.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = manaCrystalNoMana;
        mana.manabar.sprite = manaBarNoMana;
        errorImage.SetActive(true);

        yield return new WaitForSeconds(2);

        mana.manabar.sprite = manaBarMana;
        mana.manaCrystal.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = manaCrystalMana;
        errorImage.SetActive(false);
    }

    public void SpawnMinion2()
    {
        if (mana.manaBarValue >= minion2ManaNeed)
        {
            rangedMinionSpawnCounter += 1;
            playerManaSpent += 4;
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
            Instantiate(MinionToSpawn2, pos, Quaternion.identity);
            Instantiate(SpawnEffect, pos, Quaternion.identity);

            float manaValue = minion2ManaNeed / 10;
            mana.ManaSpawn(manaValue);
        }
        else
        {
            StartCoroutine(ShowError());
        }
    }
    public void SpawnMinion3()
    {
        if (mana.manaBarValue >= minion3ManaNeed)
        {
            tankMinionSpawnCounter += 1;
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
            Instantiate(MinionToSpawn3, pos, Quaternion.identity);
            Instantiate(SpawnEffect, pos, Quaternion.identity);

            float manaValue = minion3ManaNeed / 10;
            playerManaSpent += 6;
            mana.ManaSpawn(manaValue);
        }
        else
        {
            StartCoroutine(ShowError());
        }
    }
    public void SpawnMinion4()
    {
        if (mana.manaBarValue >= minion4ManaNeed)
        {
            damageMinionSpawnCounter += 1;
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
            Instantiate(MinionToSpawn4, pos, Quaternion.identity);
            Instantiate(SpawnEffect, pos, Quaternion.identity);

            float manaValue = minion4ManaNeed / 10;
            playerManaSpent += 8;
            mana.ManaSpawn(manaValue);
        }
        else
        {
            StartCoroutine(ShowError());
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {

            SpawnMinion1();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {

            SpawnMinion2();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            SpawnMinion3();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            SpawnMinion4();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(center, size);
    }

    public static int BasicMinionSpawnCounter
    {
        get
        {
            return basicMinionSpawnCounter;
        }
        set
        {
            basicMinionSpawnCounter = value;
        }
    }

    public static int RangedMinionSpawnCounter
    {
        get
        {
            return rangedMinionSpawnCounter;
        }
        set
        {
            rangedMinionSpawnCounter = value;
        }
    }

    public static int TankMinionSpawnCounter
    {
        get
        {
            return tankMinionSpawnCounter;
        }
        set
        {
            tankMinionSpawnCounter = value;
        }
    }

    public static int DamageMinionSpawnCounter
    {
        get
        {
            return damageMinionSpawnCounter;
        }
        set
        {
            damageMinionSpawnCounter = value;
        }
    }

    public static float PlayerManaSpent
    {
        get
        {
            return playerManaSpent;
        }
        set
        {
            playerManaSpent = value;
        }
    }
}
