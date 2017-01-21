using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float speed;

	public void Shoot () {
		this.GetComponent<Rigidbody2D> ().AddForce ( transform.right * speed);
	}

}
