using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageHandler : MonoBehaviour {

    //private Transform target;
    public GameObject gameMaster;
    public float health = 100;
    private float startHealth;
    Animator anim;
    AI ai;
    public Stats stats;
    public Image minionHealthBar;
    public GameObject minionHealthBarUI;
    private bool check;
    public bool isWon;
    Quaternion startPosition;
    private GameObject go;
    private GameObject childGo;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        startHealth = health;
        if(minionHealthBar != null)
        { 
        startPosition = minionHealthBarUI.transform.rotation;
            go = gameObject;
        }
    }



    public void TakeDamage(float amount)
    {
        health -= amount;
        if (minionHealthBar != null)
        {
            if (health != startHealth)
            {
                if (!check)
                {
                    minionHealthBarUI.SetActive(true);
                    check = true;
                }
            }
            minionHealthBar.fillAmount = health / startHealth;
        }
        //enemeyHP.EnemyHPChange(amount);

        //Debug.Log("Health IS " + health);
        if (health <= 0)
        {
            if (gameObject.tag == "PlayerCastle")
            {
                Destroy(GameObject.FindGameObjectWithTag("PlayerCastleTower"));
                Invoke("Die1", 8);
                Invoke("Sink1", 4);
            }
            if (gameObject.tag == "EnemyCastle")
            {
                Destroy(GameObject.FindGameObjectWithTag("EnemyCastleTower"));
            }
            //CancelInvoke();
            if (gameObject.transform.tag == "Player")
            {

                GameObject.Find("GameMaster").GetComponent<Stats>().increaseEnemyKillCounter();
                //enemyKillCounterText.SetText(string.Format("{0}", enemyKillCounter));
            }
            if (gameObject.transform.tag == "Enemy")
            {

                GameObject.Find("GameMaster").GetComponent<Stats>().increasePlayerKillCounter();
                //playerKillCounterText.SetText(string.Format("{0}", playerKillCounter));
            }

            gameObject.transform.tag = "Dead";
            if (gameObject.GetComponent("AI") != null)
            {
                GetComponent<AI>().enabled = false;
            }
            if (gameObject.GetComponent("NavMeshAgent") != null)
            {
                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            }
            if (gameObject.GetComponent("BoxCollider") != null)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            Debug.Log("IS DEAD Yoooo --!! :)");
            if (gameObject.GetComponent("Animator") != null)
            {
                anim.SetBool("isAttack2", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttack1", false);
                anim.SetBool("isDead", true);
            }
            if (minionHealthBar != null)
            {
                if(gameObject != null) { 
                minionHealthBarUI.SetActive(false);
                }
            }
            Invoke("Die",8);
            Invoke("Sink", 4);

        }
    }
    private void Sink()
    {
        StartCoroutine(MoveDown());
    }
    private void Sink1()
    {
        StartCoroutine(MoveDown());
    }
    IEnumerator MoveDown()
    {
        while (true) {
        yield return new WaitForSeconds(0.05f);
        Vector3 position = gameObject.transform.position;
        position.y -= 0.05f;
        gameObject.transform.position = position;
        }
    }

    IEnumerator MoveDown1()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            Vector3 position = gameObject.transform.GetChild(0).transform.position;
            position.y -= 0.05f;
            gameObject.transform.GetChild(0).transform.position = position;
        }
    }
    void Die1()
    {
        Destroy(gameObject.transform.GetChild(0));

    }
    void Die()
    {
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
    }
}
