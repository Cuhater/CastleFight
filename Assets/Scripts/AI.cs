using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public GameObject projectilePrefab;
    public Transform firePoint;

    public GameObject defaultTarget;
    public Transform target;
    private DamageHandler targetEnemy;


    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown;
    public int damage = 10;
    public int attackRange = 5;

    public bool victory = false;
    private bool setAttack = false;
    Animator anim;
    //public Transform minionRotation;
    //public float turnSpeed = 10f;

    private NavMeshAgent agent;

    [Header("EnemyOptions")]
    public string enemyTag = "Enemy";
    public string castle = "EnemyCastle";

    public bool attackCastle = false;

	// Use this for initialization
	void Start () {
        fireCountdown = 1f / fireRate;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        defaultTarget = GameObject.FindGameObjectWithTag(castle);
        InvokeRepeating("UpdateTarget", 0f, 0.5f);


 
    }
	
    public bool getVictory()
    {
        return victory;
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "MidTower")
        {
            if (gameObject.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Tower").GetComponent<MidTowerScript>().ChangeColorBlue();
            }
            if (gameObject.tag =="Enemy")
            {
                GameObject.FindGameObjectWithTag("Tower").GetComponent<MidTowerScript>().ChangeColorRed();
            }
        }
    }
   void OnTriggerEnter(Collision collision)
    {


    }

    void UpdateTarget()
    {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }

                if (nearestEnemy != null && shortestDistance <= range)
                {
                    target = nearestEnemy.transform;
                    agent.updatePosition = true;
                    if (agent.isOnNavMesh)
                    {
                        if(!attackCastle)
                    { 
                        agent.SetDestination(target.transform.position);
                    }
                }


                    // targetEnemy = nearestEnemy.GetComponent<DamageHandler>();

                }
                else
                {
                    target = null;
                }
            }
    }
    void Shoot()
    {
        if (target != null)
        {
            if (target.tag != "Dead")
            {
                if (!attackCastle)
                {
                    GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                    Projectile projectile = projectileGO.GetComponent<Projectile>();
                    projectile.Seek(target);
                }
            }
        }
     

    }
    void Attack()
    {

            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            agent.stoppingDistance = attackRange;
        //agent.enabled = false;
        if (!attackCastle)
        {
            if (target != null)
            {

                    int rnd = Random.Range(1, 3);
                    if (rnd == 1 && setAttack == true)
                    {
                        isAttack1();
                    }
                    else if (rnd == 2 && setAttack == true)
                    {

                        isAttack2();
                    }
                    else
                    {
                        setAttack = false;
                    }
                    target.gameObject.GetComponent<DamageHandler>().TakeDamage(damage);
                // Debug.Log("DEAD");
                //Destroy(target.gameObject);
            }
        }
        else if (defaultTarget != null)
        {
            int rnd = Random.Range(1, 3);
            if (rnd == 1 && setAttack == true)
            {
                isAttack1();
            }
            else if (rnd == 2 && setAttack == true)
            {
                isAttack2();
            }
            else
            {
                setAttack = false;
            }
            defaultTarget.GetComponent<DamageHandler>().TakeDamage(damage);
            defaultTarget.GetComponent<EnemyHP>().EnemyHPChange(damage);



            // Debug.Log("DEAD");
            //Destroy(target.gameObject);
        }

        else
        {
        }


    }
	// Update is called once per frame
	void FixedUpdate () {

            if (target == null && defaultTarget == null)
            {
            victory = true;
            if (victory)
            {
                //Debug.Log("VICTORY YEAIII");
                isVictory();
                agent.isStopped = true;
                victory = false;
            }

        }
        else if (target == null || target.tag == "Dead" || attackCastle == true)
        {
            if (defaultTarget != null)
            {
                //agent.enabled = true;
                if (Vector3.Distance(gameObject.transform.position, defaultTarget.transform.position) <= attackRange)
                {
                    attackCastle = true;
                    anim.SetBool("isWalking", false);
                    //agent.updatePosition = false;
                    //agent.enabled = false;

                    //agent.stoppingDistance = attackRange;

                    if (!setAttack)
                    {
                        setAttack = true;
                        //Debug.Log("|||||||||||||||||||||| GUTEN TEST BESTANDEN YEAI!");
                    }
                    if (fireCountdown <= 0f)
                    {
                        Attack();
                        fireCountdown = 1f / fireRate;

                    }

                    else if (defaultTarget == null)
                    {
                        isIdle();
                    }


                    fireCountdown -= Time.deltaTime;
                }
                else if (target == null || target.tag == "Dead")
                {
                    agent.updatePosition = true;
                    agent.SetDestination(defaultTarget.transform.position);
                    setAttack = false;
                    isWalking();
                }
            }
        }

        else
            {
            if(attackCastle == false)
            { 
                if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
                {
                    anim.SetBool("isWalking", false);
                    agent.transform.LookAt(target);
                    agent.stoppingDistance = attackRange;
                    if (target.tag == "Dead" && !setAttack)
                    {
                        target = null;
                    }

                    if (fireCountdown <= 0f)
                    {
                        setAttack = true;
                        //agent.isStopped = true;

                        Attack();
                        fireCountdown = 1f / fireRate;

                    }
                    fireCountdown -= Time.deltaTime;
                }
            else
                {
                
                    if(target == null || target.tag == "Dead")
                    {
                        if (agent.updatePosition == false)
                        {
                            agent.updatePosition = true;
                            agent.SetDestination(defaultTarget.transform.position);
                        }
                        setAttack = false;
                        //agent.isStopped = false;
                        //agent.SetDestination(defaultTarget.transform.position);
                        UpdateTarget();
                        if (target != null)
                        {
                            //agent.SetDestination(target.transform.position);
                            Attack();
                        }
                        isWalking();
                    }

                }
            }
        }
    }


    // Animation Methods

    private void isIdle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isWalking", false);
    }
    private void isWalking()
    {
        anim.SetBool("isAttack1", false);
        anim.SetBool("isAttack2", false);

        anim.SetBool("isIdle", true);

        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", true);
        anim.SetBool("isWalking", false);
        anim.SetBool("isWalking", true);

    }
    private void isAttack1()
    {
        anim.SetBool("isAttack1", true);
        anim.SetBool("isAttack2", false);
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", false);

        if (projectilePrefab != null)
        {
            Shoot();
        }
        Invoke("setFalse", 1);
    }
    private void isAttack2()
    {
        anim.SetBool("isAttack2", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttack1", false);
        anim.SetBool("isWalking", false);

        if (projectilePrefab != null)
        {
            Shoot();
        }
        Invoke("setFalse", 1);
    }
    private void isVictory()
    {
        anim.SetBool("isVictory", true);
        anim.SetBool("isAttack2", false);
        anim.SetBool("isAttack1", false);
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", false);
        setAttack = false;
    }
    private void setFalse()
    {
        setAttack = false;
        Debug.Log("SET ATTACK STEHT AUF ::::" + setAttack);
    }
    IEnumerator AttackPlayed()
    {
        yield return new WaitForSeconds(0.5f);
        setAttack = false;
        Debug.Log("SET ATTACK STEHT AUF ::::" + setAttack);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
