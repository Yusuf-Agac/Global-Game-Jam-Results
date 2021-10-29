using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void OnClick(string SceneName)
	{
		Cursor.visible = false;
		SceneManager.LoadScene(SceneName);
	}
}
