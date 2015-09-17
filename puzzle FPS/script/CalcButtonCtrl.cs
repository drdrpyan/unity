using UnityEngine;
using System.Collections;

public class CalcButtonCtrl : MonoBehaviour {
	public CalculatorCtrl controller;
	public GameObject expEffect;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll) {
		if(coll.collider.tag == "TeddyBear") {
			Instantiate (expEffect, coll.gameObject.transform.position, Quaternion.identity);
			coll.rigidbody.AddExplosionForce(5.0f, coll.gameObject.transform.position, 1.0f);
			Destroy(coll.gameObject);

			if(this.name == "num0")
				controller.addNumber(0);
			else if(this.name == "num1")
				controller.addNumber(1);
			else if(this.name == "num2")
				controller.addNumber(2);
			else if(this.name == "num3")
				controller.addNumber(3);
			else if(this.name == "num4")
				controller.addNumber(4);
			else if(this.name == "num5")
				controller.addNumber(5);
			else if(this.name == "num6")
				controller.addNumber(6);
			else if(this.name == "num7")
				controller.addNumber(7);
			else if(this.name == "num8")
				controller.addNumber(8);
			else if(this.name == "num9") {
				controller.addNumber(9);
				controller.addNumber(9);
			}

			else if(this.name == "Enter")
				controller.enter();
		}
	}
}
