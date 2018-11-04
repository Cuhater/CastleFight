using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    static bool tutorial = true;
    public Toggle m_Toggle;

    public void StartGame ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        m_Toggle = GetComponent<Toggle>();
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ToggleValueChanged()
    {
        Debug.Log("BLABLA" + m_Toggle);
        if(tutorial == false)
        {
            tutorial = true;
        }
        else
        {
            tutorial = false;
        }
        Debug.Log("BLABasdasdasdsadasdsadLA" + tutorial);
    }

    public static bool Tutorial
    {
        get
        {
            return tutorial;
        }
        set
        {
            tutorial = value;
        }
    }

}
