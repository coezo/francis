using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float speed;
	public float fadingTime;

	private Light light;

	void Awake(){
		light = GetComponent<Light> ();
	}

	public void Shoot (Vector3 direction) {
		this.GetComponent<Rigidbody2D> ().AddForce ( direction * speed);
		InvokeRepeating ("Fade", 0, 0.1f * fadingTime);
	}

	private void Fade(){
		light.intensity -= 0.1f;
		if (light.intensity <= 0) {
			CancelInvoke ();
			Destroy (this.gameObject);
		}
	}

}
