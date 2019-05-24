using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndChangeScene : MonoBehaviour
{
    
	void cor()
	{
		SceneManager.LoadScene("SceneStartScreen");
	}

	// Start is called before the first frame update
    void Start()
    {
		Invoke("cor", 7);

    }

	void Update()
	{
		if (Input.anyKey) 
		{
			SceneManager.LoadScene("SceneStartScreen");
		}
	}

}
