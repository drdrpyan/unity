using UnityEngine;
using System.Collections;

public class FireCtrl : MonoBehaviour {
	public GameObject bullet;
	public Transform firePos;

	void Update() {
		if (!StaticAttributes.buttonMode && Input.GetMouseButtonDown(0)){
			Fire ();
		}
	}

	void Fire() {
		StartCoroutine(this.CreateBullet());
	}

	IEnumerator CreateBullet() {
		Instantiate (bullet, firePos.position, firePos.rotation);
		yield return null;		
	}
}
