using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptButtonControler : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
		SceneManager.LoadScene("SceneIntro");
    }

    // Update is called once per frame
	public void QuitButton()
    {
		Application.Quit();
		Debug.Log("I quit");
    }
}
