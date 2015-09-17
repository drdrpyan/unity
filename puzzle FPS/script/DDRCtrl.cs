using UnityEngine;
using System.Collections;

public class DDRCtrl : MonoBehaviour {
	public CannonCtrl cannon;
	private bool pushUp = false;
	private bool pushDown = false;
	private bool pushLeft = false;
	private bool pushRight = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(pushUp)
			cannon.tiltUp();
		else if(pushDown)
			cannon.tiltDown();
		else if(pushLeft)
			cannon.panningLeft();
		else if(pushRight)
			cannon.panningRight();
	}

	void OnCollisionStay(Collision coll) {
		if(coll.collider.tag == "Player") {
			if(this.name == "DDR_Up")
				pushUp = true;
			else if(this.name == "DDR_Down")
				pushDown = true;
			else if(this.name == "DDR_Left")
				pushLeft = true;
			else if(this.name == "DDR_Right")
				pushRight = true;
		}
	}

	void OnCollisionExit(Collision coll) {
		pushUp = pushDown = pushLeft = pushRight = false;
	}
}
