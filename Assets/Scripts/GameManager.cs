using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public GameObject[] estrelas;

	private int totalEstrelas;

	public int scoreFrancis;
	public int scoreJesse;
	public int scoreAlex;
	public int scoreSasha;

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
		totalEstrelas = estrelas.Length;
	}
	
	public void CountScore(PlayerController8D.Character character){
		switch (character) {
		case PlayerController8D.Character.Francis:
			scoreFrancis++;
			break;
		case PlayerController8D.Character.Jesse:
			scoreJesse++;
			break;
		case PlayerController8D.Character.Alex:
			scoreAlex++;
			break;
		case PlayerController8D.Character.Sasha:
			scoreSasha++;
			break;
		}
		totalEstrelas--;
		UpdateUI ();
	}

	private void UpdateUI(){
		
	}
}
