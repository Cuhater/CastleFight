using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHandler : MonoBehaviour
{

    //public float cooldownTime;
    private bool isCooldown;

    //private GameObject playerSpawnTarget;
    //private GameObject enemySpawnTarget;

    //private Coroutine spawner;

    //public Image imageCooldown;

    void Start()
    {
       // playerSpawnTarget = GameObject.FindGameObjectWithTag("PlayerCastle");
       // enemySpawnTarget = GameObject.FindGameObjectWithTag("EnemyCastle");
    }

    public void Spawn()
    {
       // Vector3 playerSpawnPosition = playerSpawnTarget.transform.position;
       // Vector3 enemySpawnPosition = playerSpawnTarget.transform.position;
        //GameObject.Instantiate(minion, playerSpawnPosition, Quaternion.identity);
        //isCooldown = true;
    }
    public void Update()
    {
        /*
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldownTime * Time.deltaTime;
            if(imageCooldown.fillAmount == 1)
            {
                isCooldown = false;
                imageCooldown.fillAmount = 0;
            }
        } */
    }
}
    