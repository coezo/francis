using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartTutorial() {

		SceneManager.LoadScene ("Setup");

	}

	public void StartCredits() {

		SceneManager.LoadScene ("Credits");

	}

	public void StartHome() {

		SceneManager.LoadScene ("Home");

	}

	public void StartLevel() {

		SceneManager.LoadScene ("Cave");

	}


}

