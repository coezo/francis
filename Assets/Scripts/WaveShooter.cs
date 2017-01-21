using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MonoBehaviour {

	//public GameObject wave;

	private GameObject wave1, wave2, wave3;

	// Use this for initialization
	void Start () {
		wave1 = Resources.Load ("Prefabs/Wave") as GameObject;
		wave2 = Resources.Load ("Prefabs/Wave") as GameObject;
		wave3 = Resources.Load ("Prefabs/Wave") as GameObject;

		wave2.transform.Rotate (Vector3.forward * 45f);
		wave3.transform.Rotate (Vector3.forward * -45f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot ();
		}
	}

	private void Shoot(){
		Instantiate (wave1, transform.position, wave1.transform.rotation);
		Instantiate (wave2, transform.position, wave2.transform.rotation);
		Instantiate (wave3, transform.position, wave3.transform.rotation);
	}
}
