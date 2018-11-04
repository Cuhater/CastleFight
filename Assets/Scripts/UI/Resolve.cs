using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee.UIExtensions;
public class Resolve : MonoBehaviour {

    public float levelTime;
    public float dur;
    public float loc;
    public float waitTime = 0.1f;
	// Use this for initialization
	void Start () {
   
    }
	
	// Update is called once per frame
	void Update () {

        if(gameObject.GetComponent<UIDissolve>().location != 0)
        { 
             gameObject.GetComponent<UIDissolve>().location -= 0.5f * Time.deltaTime;
        }
    }
}
