using UnityEngine;
using System.Collections;

public class GUIButtonCtrl : MonoBehaviour {
	public CannonCtrl cannonCtrl;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
			StaticAttributes.buttonMode = !StaticAttributes.buttonMode;
	}

	void OnGUI() {
		if(GUI.RepeatButton (new Rect(65, 15, 50, 50), "△"))
			cannonCtrl.tiltUp();
		else if(GUI.RepeatButton (new Rect(15, 65, 50, 50), "◁"))
			cannonCtrl.panningLeft();
		else if(GUI.RepeatButton (new Rect(65, 65, 50, 50), "▽"))
			cannonCtrl.tiltDown();
		else if(GUI.RepeatButton (new Rect(115, 65, 50, 50), "▷"))
			cannonCtrl.panningRight();

		else if(GUI.Button(new Rect(15, 120, 150, 50), "FIRE"))
			cannonCtrl.fireCannon();

		else if(GUI.Button(new Rect(15, 180, 150, 50), (StaticAttributes.dllMode?"DLL OFF":"DLL ON")))
			StaticAttributes.dllMode = !StaticAttributes.dllMode;
	}
}
