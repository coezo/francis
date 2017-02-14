using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AirConsoleController : MonoBehaviour {

	float inputX, inputY;

	// Use this for initialization
	void Awake () {
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onConnect += OnConnect;
		AirConsole.instance.onDisconnect += OnDisconnect;
	}

	private void OnConnect(int deviceId){
		Debug.Log ("AirConsole controle conectado: " + deviceId);
		AirConsole.instance.SetActivePlayers (AirConsole.instance.GetActivePlayerDeviceIds.Count+1);
	}

	private void OnDisconnect(int deviceId){
		Debug.Log ("AirConsole controle desconectado: " + deviceId);
	}

	private void OnMessage(int deviceId, JToken data){
		int activePlayer = AirConsole.instance.ConvertDeviceIdToPlayerNumber (deviceId);
		//Debug.Log ("Mensagem recebida de: " + deviceId + ", player " + activePlayer + ", " + data.ToString());
		if (activePlayer != -1) {
			if (data["shoot"] != null) {
				GameManager.Instance.players [activePlayer].Shoot ();
			}
			if (data["boost"] != null) {
				GameManager.Instance.players [activePlayer].Boost ();
			}
			if (data["joystick-left"] != null) {
				JToken moveData = data ["joystick-left"];
				if ((bool)moveData ["pressed"]) {
					inputX = (float)data ["joystick-left"] ["message"] ["x"];
					inputY = (float)data ["joystick-left"] ["message"] ["y"];
				} else {
					inputX = 0;
					inputY = 0;
				}
				GameManager.Instance.players [activePlayer].SetInputs(inputX, inputY);
			}
		}
	}
}
