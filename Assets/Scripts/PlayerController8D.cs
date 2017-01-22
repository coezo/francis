using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController8D : MonoBehaviour {

	public enum Character {Francis, Jesse, Alex, Sasha};

	public Character personagem;

	public float speed;             //Floating point variable to store the player's movement speed.

	public Controle controle;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private WaveShooter waveShooter;
	private PlayerInput playerInput;

	private float inputX, inputY;
	private Vector3 movement = new Vector3(0,0,0);

	private Vector3 facingDirection = new Vector3(1, 0, 0);

	private bool isStunned;
	public float stunDuration;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		waveShooter = GetComponent<WaveShooter> ();
		playerInput = GetComponent<PlayerInput> ();
	}

	void Update(){
		Move ();
	}

	void FixedUpdate(){
		GetComponent<Rigidbody2D>().velocity = movement * speed;
	}

	private void Move(){
		if(!isStunned){
			inputX = playerInput.h;//Input.GetAxisRaw (controle.horizontalAxis);
			inputY = playerInput.v;//Input.GetAxisRaw (controle.verticalAxis);

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

	public void Shoot(){
		if (!isStunned) {
			waveShooter.Shoot (facingDirection);
		}
	}

	public void Boost(){
		if(!isStunned){
			// Implementar
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Mine")) {
			isStunned = true;
			StartCoroutine ("FlashSprite");
			Invoke ("StopStun", stunDuration);
		} else if (other.CompareTag ("Star")) {
			GameManager.Instance.CountScore (personagem);
			Destroy (other.gameObject);
		}
	}

	private void StopStun(){
		StopCoroutine ("FlashSprite");
		isStunned = false;
	}

	private IEnumerator FlashSprite(){
		while (true) {
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds (0.1f);
			spriteRenderer.enabled = true;
			yield return new WaitForSeconds (0.1f);
		}
	}

}
