using UnityEngine;
using System.Collections;

public class BarrelCtrl : MonoBehaviour {
	public GameObject expEffect;
	public Texture[] _textures;

	private Transform tr;

	private int hitCount = 0;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
	}
	
	void OnCollisionEnter(Collision coll) {
		if(coll.collider.tag == "BULLET") {
			Destroy(coll.gameObject);
			HUDCtrl.hitCount++;

			if(this.tag == "BLUE")
				HUDCtrl.point += DLLBridge.point('b');
			else if(this.tag == "YELLOW")
				HUDCtrl.point += DLLBridge.point('y');
			else if(this.tag == "RED")
				HUDCtrl.point += DLLBridge.point('r');

			if(++hitCount >= 10) {
				StartCoroutine(this.ExplosionBarrel());
			}
		}
	}

	IEnumerator ExplosionBarrel() {
		HUDCtrl.barrels--;

		Instantiate (expEffect, tr.position, Quaternion.identity);

		Collider[] colls = Physics.OverlapSphere (tr.position, 10.0f);

		foreach (Collider coll in colls) {
			if(coll.rigidbody != null) {
				coll.rigidbody.mass = 5.0f;
				coll.rigidbody.AddExplosionForce(500.0f, tr.position, 10.0f, 300.0f);
			}
		}
		Destroy (gameObject, 5.0f);
		yield return null;
	}
}
