using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidTowerScript : MonoBehaviour {

    public Material[] material;
    public Renderer rend;
    public int currentColor;
    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        rend.sharedMaterials[1].color = material[0].color;
        rend.sharedMaterials[2].color = material[0].color;

    }
	
    public void ChangeColorBlue()
    {
        Debug.Log("PLEASE CHANGE CLOLOR DUDE");
            rend.sharedMaterials[1].color = material[1].color;
            rend.sharedMaterials[2].color = material[1].color;
            currentColor = 1;
    }

    public void ChangeColorRed() { 
        Debug.Log("PLEASE CHANGE CLOLOR DUDE");
        rend.sharedMaterials[1].color = material[2].color;
        rend.sharedMaterials[2].color = material[2].color;
        currentColor = 2;
    }

    public int getColor()
    {
        return currentColor;
    }
}
