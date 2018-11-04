using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnOLD : MonoBehaviour {

    /*
    public GameObject Minion;
    public float cooldownTime;

    private bool isCooldown;
    private GameObject target;
    private Coroutine spawner;
    public Image imageCooldown;
    [SerializeField]
    private Stats mana;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Castle");
        Debug.Log(mana);
        mana.Initialize(0, 10);
    }

    public void Minion1()
    {


            Vector3 spawnPosition = target.transform.position;
            GameObject.Instantiate(Minion, spawnPosition, Quaternion.identity);
            isCooldown = true;
            mana.MyCurrentValue -= 2f;





    }
    public void Update()
    {
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldownTime * Time.deltaTime;
            if(imageCooldown.fillAmount == 1)
            {
                isCooldown = false;
                imageCooldown.fillAmount = 0;
            }
        }
    }
    */
}
