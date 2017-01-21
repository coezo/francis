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

	public void Shoot () {
		this.GetComponent<Rigidbody2D> ().AddForce ( transform.right * speed);
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
