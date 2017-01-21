using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D> ().AddRelativeForce ( Vector2.right * speed);
	}

}
