using UnityEngine;
using System.Collections;

public class FireCtrl : MonoBehaviour {
	public GameObject bullet;
	public Transform firePos;

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Fire();
		}
	}

	void Fire() {
		HUDCtrl.fireCount++;
		StartCoroutine(this.CreateBullet());
	}

	IEnumerator CreateBullet() {
		Instantiate (bullet, firePos.position, firePos.rotation);
		yield return null;
	}
}