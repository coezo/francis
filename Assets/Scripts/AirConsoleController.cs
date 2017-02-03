using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AirConsoleController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onConnect += OnConnect;
		AirConsole.instance.onDisconnect += OnDisconnect;
	}
	
	// Update is called once per frame
	void Update () {
		
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
		Debug.Log ("Mensagem recebida de: " + deviceId + ", player " + activePlayer);
		if (activePlayer != -1) {
			GameManager.Instance.players [activePlayer].Shoot ();
		}
	}
}
