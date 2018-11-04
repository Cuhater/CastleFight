using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventHandler : MonoBehaviour {

    public SpawnHandler spawnHandler;
    public GameObject minion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnMinion()
    {
        spawnHandler.GetComponent<SpawnHandler>();
        Debug.Log("Joho");
    }
    public void Options()
    {

    }
    public void Pause()
    {
        
    }
    public void Resume()
    {

    }
}
