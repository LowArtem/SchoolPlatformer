using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	void Update () 
	{
		if (PlayerControler.isDeath)
		{
			Invoke("Reanimate", 3f);
			PlayerControler.isDeath = false;
		}
	}

	public void Reanimate()
    {
        SceneManager.LoadScene("Scene3");
    }
}
