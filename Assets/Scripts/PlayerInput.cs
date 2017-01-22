using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class StartEvent : UnityEvent<int>
{
}

public class PlayerInput : MonoBehaviour {
	
	public enum InputMethod {
			SingleplayerKeyboard,
			SingleplayerMouse,
			mpKeyboard1,
			mpKeyboard2,
			Gamepad1,
			Gamepad2,
			Gamepad3,
			Gamepad4
	}
	
	string hMoveAxis;
	string vMoveAxis;
	string hFireAxis;
	string vFireAxis;
	
	float timeOfAttack;
	
	Transform reticle;
	
	[HideInInspector]
	public Vector3 attackDirection;
	
	[HideInInspector]
	public bool canInput=true;
	
	public InputMethod currentInput;

    
    KeyCode StartButton = KeyCode.Escape;
     KeyCode AButton = KeyCode.C;
	 KeyCode BButton = KeyCode.E;
	 KeyCode CButton = KeyCode.Q;
    

	public StartEvent StartButtonPressed = new StartEvent ();
	public UnityEvent AButtonPressed = new UnityEvent ();
	public UnityEvent BButtonPressed = new UnityEvent ();
	public UnityEvent CButtonPressed = new UnityEvent ();

	public bool StartButtonHeld;
	public bool AButtonHeld;
	public bool BButtonHeld;
	public bool CButtonHeld;

	public float h = 0;
	public float v = 0;
	public float hAttack = 0;
	public float vAttack = 0;

	void Start () {
		SetInput(currentInput);
	}

	public void SetInput(InputMethod newIM)
	{
		currentInput = newIM;
		
		if(reticle)
			Destroy(reticle.gameObject);
		
		switch (currentInput)
		{
			case InputMethod.SingleplayerKeyboard:
					hMoveAxis="HorizontalA";
					vMoveAxis="VerticalA";
					hFireAxis="HorizontalArrow";
					vFireAxis="VerticalArrow";
					StartButton=KeyCode.Escape;
					AButton=KeyCode.C;
					BButton=KeyCode.E;
					CButton=KeyCode.Q;
				break;
			case InputMethod.SingleplayerMouse:
			
				break;
			case InputMethod.mpKeyboard1:
					hMoveAxis="HorizontalA";
					vMoveAxis="VerticalA";
					hFireAxis="HorizontalH";
					vFireAxis="VerticalH";
					StartButton=KeyCode.Escape;
					AButton=KeyCode.Alpha1;
					BButton=KeyCode.Alpha2;
					CButton=KeyCode.Q;
				break;
			case InputMethod.mpKeyboard2:
					hMoveAxis="HorizontalArrow";
					vMoveAxis="VerticalArrow";
					hFireAxis="Horizontal1";
					vFireAxis="Vertical1";
					StartButton=KeyCode.KeypadMinus;
					AButton=KeyCode.K;
					BButton=KeyCode.L;
					CButton=KeyCode.Keypad7;
				break;
			case InputMethod.Gamepad1:
					hMoveAxis="HorizontalAGP1";
					vMoveAxis="VerticalAGP1";
			if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {
						hFireAxis="HorizontalArrowGP1Mac";
						vFireAxis="VerticalArrowGP1Mac";
						StartButton=KeyCode.Joystick1Button9;
						AButton=KeyCode.Joystick1Button3;
						BButton=KeyCode.Joystick1Button1;
						CButton=KeyCode.Joystick1Button18;
					} else {
						hFireAxis="HorizontalArrowGP1";
						vFireAxis="VerticalArrowGP1";
						StartButton=KeyCode.Joystick1Button7;
						AButton=KeyCode.Joystick1Button0;
						BButton=KeyCode.Joystick1Button1;
						CButton=KeyCode.Joystick1Button2;
					}
				break;
			case InputMethod.Gamepad2:
					hMoveAxis="HorizontalGP2";
					vMoveAxis="VerticalGP2";
			if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {
						hFireAxis="HorizontalArrowGP2Mac";
						vFireAxis="VerticalArrowGP2Mac";
						StartButton=KeyCode.Joystick2Button9;
						AButton=KeyCode.Joystick2Button3;
						BButton=KeyCode.Joystick2Button1;
						CButton=KeyCode.Joystick2Button18;
					} else {
						hFireAxis="HorizontalArrowGP2";
						vFireAxis="VerticalArrowGP2";
						StartButton=KeyCode.Joystick2Button7;
						AButton=KeyCode.Joystick2Button0;
						BButton=KeyCode.Joystick2Button1;
						CButton=KeyCode.Joystick2Button2;
					}
				break;
			case InputMethod.Gamepad3:
					hMoveAxis="HorizontalGP3";
					vMoveAxis="VerticalGP3";
			if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {
						hFireAxis="HorizontalArrowGP3Mac";
						vFireAxis="VerticalArrowGP3Mac";
						StartButton=KeyCode.Joystick3Button9;
						AButton=KeyCode.Joystick3Button16;
						BButton=KeyCode.Joystick3Button17;
						CButton=KeyCode.Joystick3Button18;
					} else {
						hFireAxis="HorizontalArrowGP3";
						vFireAxis="VerticalArrowGP3";
						StartButton=KeyCode.Joystick3Button7;
						AButton=KeyCode.Joystick3Button0;
						BButton=KeyCode.Joystick3Button1;
						CButton=KeyCode.Joystick3Button2;
					}
				break;
			case InputMethod.Gamepad4:
					hMoveAxis="HorizontalGP4";
					vMoveAxis="VerticalGP4";
			if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {
						hFireAxis="HorizontalArrowGP4Mac";
						vFireAxis="VerticalArrowGP4Mac";
						StartButton=KeyCode.Joystick4Button9;
						AButton=KeyCode.Joystick4Button16;
						BButton=KeyCode.Joystick4Button17;
						CButton=KeyCode.Joystick4Button18;
					} else {
						hFireAxis="HorizontalArrowGP4";
						vFireAxis="VerticalArrowGP4";
						StartButton=KeyCode.Joystick4Button7;
						AButton=KeyCode.Joystick4Button0;
						BButton=KeyCode.Joystick4Button1;
						CButton=KeyCode.Joystick4Button2;
					}
				break;
		}
	}
	
	void Update () {
		GetInput();
	}
		
	void GetInput() {
		 h = 0;
		 v = 0;
		 hAttack = 0;
		 vAttack = 0;

		if(canInput&&Time.timeScale!=0) {
			h += Input.GetAxisRaw(hMoveAxis);
			v += Input.GetAxisRaw(vMoveAxis);
			
			if(currentInput != InputMethod.SingleplayerMouse) {
				hAttack += Input.GetAxisRaw(hFireAxis);
				vAttack += Input.GetAxisRaw(vFireAxis);
			}
		

			if (Input.GetKeyDown (StartButton)) {
				StartButtonPressed.Invoke ((int)currentInput);
			}

			if (Input.GetKeyDown (AButton)) {
				AButtonPressed.Invoke ();
			}
			
			if (Input.GetKeyDown(BButton))
				BButtonPressed.Invoke ();
        	   
        	if (Input.GetKeyDown(CButton))
				CButtonPressed.Invoke ();

			StartButtonHeld = Input.GetKey (StartButton);
			AButtonHeld = Input.GetKey (AButton);
			BButtonHeld = Input.GetKey (BButton);
			CButtonHeld = Input.GetKey (CButton);
		}

	}

}
