using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public CompoundButton button;
    
	void Update ()
    {
        button.OnButtonClicked += Clicked;
    }

    void Clicked(GameObject go)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
