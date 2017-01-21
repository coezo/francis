using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MonoBehaviour {

	//public GameObject wave;

	private GameObject wave1, wave2, wave3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot ();
		}
	}

	private void Shoot(){
		Vector3 depth = new Vector3 (transform.position.x, transform.position.y, -1);

		wave1 = Instantiate (Resources.Load ("Prefabs/Wave"), depth, transform.rotation) as GameObject;
		wave2 = Instantiate (Resources.Load ("Prefabs/Wave"), depth, transform.rotation) as GameObject;
		wave3 = Instantiate (Resources.Load ("Prefabs/Wave"), depth, transform.rotation) as GameObject;

		wave2.transform.Rotate (Vector3.forward * 45);
		wave3.transform.Rotate (Vector3.forward * -45);

		wave1.GetComponent<Wave> ().Shoot ();
		wave2.GetComponent<Wave> ().Shoot ();
		wave3.GetComponent<Wave> ().Shoot ();
	}
}
