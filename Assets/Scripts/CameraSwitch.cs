using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
    public Camera view1;
    public Camera view2;
    public Camera view3;

	// Use this for initialization
	void Start () {
        view1.enabled = true;
        view2.enabled = false;
        view3.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            view1.enabled = true;
            view2.enabled = false;
            view3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            view1.enabled = false;
            view2.enabled = true;
            view3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            view1.enabled = false;
            view2.enabled = false;
            view3.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
    }
}
