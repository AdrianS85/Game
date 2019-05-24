using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroControl : MonoBehaviour
{
	string first = "In the year 200X...";
	string second = "... begins the greatest adventure of our time...";
	string third = "behold... FLYING FUCKERNAUTS VERSUS THE ASTROBASTARDS";
	GameObject go;
	Text tx;

	private IEnumerator SomeCoroutine()
	{
		tx.text = first;
		yield return new WaitForSeconds (3);
		tx.text = second;
		yield return new WaitForSeconds (3);
		tx.text = third;
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene("SceneVillage");
	}

// Start is called before the first frame update
    void Start()
    {
		tx = GetComponent<Text>();
		StartCoroutine(SomeCoroutine());
	}

	void Update()
	{
		if (Input.anyKey) {
			SceneManager.LoadScene("SceneVillage");
		}
	}
	
}
