using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public Collider2D mineCollider;
	public Collider2D explosionTrigger;

	private Animator animator;

	private bool isExploding;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player") && !isExploding) {
			isExploding = true;
			Explode ();
		}
	}

	private void Explode(){
		mineCollider.enabled = false;
		animator.SetTrigger ("explode");
		explosionTrigger.enabled = true;
	}

	public void DestroyMine(){
		Destroy (gameObject);
	}
}
