using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour {


    public Material Texture;

    // Use this for initialization
    void Start () {

        gameObject.GetComponent<Renderer>().material = Texture;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
