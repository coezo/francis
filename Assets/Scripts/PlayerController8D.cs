using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController8D : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.

	private Animator animator;

	private float inputX, inputY;
	private Vector3 movement = new Vector3(0,0,0);

	private Vector3 facingDirection = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start()
	{
		animator = GetComponentInChildren<Animator> ();
	}

	void Update(){
		Move ();
	}

	void FixedUpdate(){
		GetComponent<Rigidbody2D>().velocity = movement * speed;
	}

	private void Move(){
		inputX = Input.GetAxisRaw ("Horizontal");
		inputY = Input.GetAxisRaw ("Vertical");

		if (inputX != 0 || inputY != 0) {
			animator.SetBool ("Swimming", true);
			if (inputX > 0) {
				animator.SetFloat ("LastMoveX", 1f);
			} else if (inputX < 0){
				animator.SetFloat ("LastMoveX", -1f);
			} else {
				animator.SetFloat ("LastMoveX", 0f);
			}

			if (inputY > 0) {
				animator.SetFloat ("LastMoveY", 1f);
			} else if (inputY < 0) {
				animator.SetFloat ("LastMoveY", -1f);
			} else {
				animator.SetFloat ("LastMoveY", 0f);
			}
			facingDirection = new Vector3(inputX, inputY, 0);
		} else {
			animator.SetBool ("Swimming", false);
		}

		animator.SetFloat ("SpeedX", inputX);
		animator.SetFloat ("SpeedY", inputY);

		movement = new Vector3(inputX, inputY, 0);
		//transform.Translate(movement * speed * Time.deltaTime);
	}

}
