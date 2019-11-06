using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timedelay : MonoBehaviour {

    public float delaytime;
    private float Elapsedtime;
    public string Scene;

	
	// Update is called once per frame
	void Update () {
        Elapsedtime += Time.deltaTime;
        if(Elapsedtime>delaytime)
        {
            SceneManager.LoadScene(Scene);
        }
	}
}
