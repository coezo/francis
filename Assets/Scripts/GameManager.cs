using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public GameObject[] estrelas;

	private int totalEstrelas;

	public int scoreFrancis;
	public int scoreJesse;
	public int scoreAlex;
	public int scoreSasha;

	public Text scoreFrancisText;
	public Text scoreJesseText;
	public Text scoreAlexText;
	public Text scoreSashaText;

	void Awake(){
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		ResetScore ();
	}
	
	public void CountScore(PlayerController8D.Character character){
		switch (character) {
		case PlayerController8D.Character.Francis:
			scoreFrancis++;
			scoreFrancisText.text = scoreFrancis.ToString();
			break;
		case PlayerController8D.Character.Jesse:
			scoreJesse++;
			scoreJesseText.text = scoreJesse.ToString();
			break;
		case PlayerController8D.Character.Alex:
			scoreAlex++;
			scoreAlexText.text = scoreAlex.ToString();
			break;
		case PlayerController8D.Character.Sasha:
			scoreSasha++;
			scoreSashaText.text = scoreSasha.ToString();
			break;
		}
		totalEstrelas--;
		if(totalEstrelas == 0){
			SceneManager.LoadScene ("GameOver");
		}
	}

	private void ResetScore(){
		totalEstrelas = estrelas.Length;
		scoreFrancis = 0;
		scoreJesse = 0;
		scoreAlex = 0;
		scoreSasha = 0;
	}
}
