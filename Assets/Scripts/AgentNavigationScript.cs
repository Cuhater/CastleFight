using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavigationScript : MonoBehaviour {

    private NavMeshAgent agent;
   // public float navDistance = .2f;
   // private int navPointCounter = -1;
   // private bool needsNavPoints = true;




	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        //if(needsNavPoints || Vector3.Distance(gameObject.transform.position, NavPoints[]))


        RaycastHit hit;
        if( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
        {
            agent.destination = hit.point;
        }
	}
}
