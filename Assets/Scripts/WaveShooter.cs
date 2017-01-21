using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MonoBehaviour {

	private GameObject wave1, wave2, wave3;

	public void Shoot(Vector3 direction){
		Vector3 depth = new Vector3 (transform.position.x, transform.position.y, -1);

		wave1 = Instantiate (Resources.Load ("Prefabs/Wave"), depth, transform.rotation) as GameObject;
		wave2 = Instantiate (Resources.Load ("Prefabs/Wave"), depth, transform.rotation) as GameObject;
		wave3 = Instantiate (Resources.Load ("Prefabs/Wave"), depth, transform.rotation) as GameObject;

		wave2.transform.Rotate (Vector3.forward * 45);
		wave3.transform.Rotate (Vector3.forward * -45);

		wave1.GetComponent<Wave> ().Shoot (direction);
		wave2.GetComponent<Wave> ().Shoot (direction);
		wave3.GetComponent<Wave> ().Shoot (direction);
	}
}
