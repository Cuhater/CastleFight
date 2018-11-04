using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private Vector3 initPosition;
    private Transform target;
    private ParticleSystem ps;
    public float speed = 70f;
    GameObject GO;
    public float distanceToTarget;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
        initPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            distanceToTarget = Vector3.Distance(initPosition, target.position);
        }
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        dir.y += 2;

        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Destroy(gameObject);
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //GO = gameObject;
        //GO.GetComponent<ParticleHit>().startSpeed = distanceToTarget;
    }
    public void Kill()
    {
        Destroy(gameObject);
    }
    void HitTarget()
    {
        Destroy(gameObject);
        Debug.Log("HIT");
    }
}
