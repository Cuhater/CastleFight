using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField]
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
		
	}
    void Spawn ()
    {
        Vector3 spawnPoint = new Vector3(-31, -18, 48); 
    }
	
	// Update is called once per frame
	void Update () {
        Instantiate(enemy, spawnPoints[0].position, spawnPoints[0].rotation);
	}
}
