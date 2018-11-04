using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsOLD : MonoBehaviour {

    private Image content;

    private float currentFill;

    public float MyMaxValue { get; set; }

    [SerializeField]
    private float timeToGetMana = 10f;



    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            // Make sure that currentvalue never over maxvalue
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if(value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
            currentFill = currentValue / MyMaxValue;
        }
    }

    private float currentValue;


    // Use this for initialization
    void Start () {
        content = GetComponent<Image>();
        
	}
	
	// Update is called once per frame
	void Update () {
        currentFill += 1 / timeToGetMana * Time.deltaTime;
        //timeToGetMana -= Time.deltaTime;
        if (timeToGetMana < 0 )
        {
            currentFill += 0.1f;
        }
        content.fillAmount = currentFill;
		
	}
    public void Initialize(float currentValue, float maxValue)  {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
