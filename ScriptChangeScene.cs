using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptChangeScene : MonoBehaviour
{
	public void M_ChangeScene(string changeSceneTo)
	{
		SceneManager.LoadScene(changeSceneTo);
	}
}
