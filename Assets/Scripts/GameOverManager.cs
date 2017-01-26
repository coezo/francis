using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public Text francisScore;
	public Text jesseScore;
	public Text alexScore;
	public Text sashaScore;

	public GameObject francisStar;
	public GameObject jesseStar;
	public GameObject alexStar;
	public GameObject sashaStar;

	public Menu menuController;

	// Use this for initialization
	void Start () {
		switch (GameManager.Instance.GetChampion ()) {
		case PlayerController8D.Character.Francis:
			francisStar.SetActive (true);
			break;
		case PlayerController8D.Character.Jesse:
			jesseStar.SetActive (true);
			break;
		case PlayerController8D.Character.Alex:
			alexStar.SetActive (true);
			break;
		case PlayerController8D.Character.Sasha:
			sashaStar.SetActive (true);
			break;
		}

		francisScore.text = GameManager.Instance.scoreFrancis.ToString();
		jesseScore.text = GameManager.Instance.scoreJesse.ToString();
		alexScore.text = GameManager.Instance.scoreAlex.ToString();
		sashaScore.text = GameManager.Instance.scoreSasha.ToString();
	}
	
	public void PlayAgain(){
		GameManager.Instance.ResetScore ();
		menuController.StartLevel ();
	}

	public void StartHome(){
		GameManager.Instance.ResetScore ();
		menuController.StartHome ();
	}
}
