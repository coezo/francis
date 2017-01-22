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
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player") && !isExploding) {
			isExploding = true;
			Invoke ("Explode", 1.0f);
		}
	}

	private void Explode(){
		mineCollider.enabled = false;
		//animator.SetTrigger ("explode");
		explosionTrigger.enabled = true;
		Invoke("DestroyMine", 0.3f); //Transferir para o fim da animacao quando estiver pronta
	}

	public void DestroyMine(){
		Destroy (gameObject);
	}
}
