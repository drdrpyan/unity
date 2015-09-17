using UnityEngine;
using System.Collections;

public class BarrelCtrl : MonoBehaviour {
	public GameObject expEffect;
	public Texture[] _textures;
	
	private Transform tr;
	
	private int hitCount = 0;
	
	void Start () {
		tr = GetComponent<Transform> ();
	}
	
	void OnCollisionEnter(Collision coll) {
		if (coll.collider.tag == "BULLET") {
			Destroy(coll.gameObject);
			
			if (++hitCount >= 10) {
				StartCoroutine(this.ExplosionBarrel());
			}
		}
	}
	
	IEnumerator ExplosionBarrel() {
		Instantiate (expEffect, tr.position, Quaternion.identity);
		
		Collider[] colls = Physics.OverlapSphere (tr.position, 10.0f);
		
		foreach (Collider coll in colls) {
			if (coll.rigidbody != null) {
				coll.rigidbody.mass = 5.0f;
				coll.rigidbody.AddExplosionForce(800.0f, tr.position, 10.0f, 300.0f);
			}		
		}
		Destroy (gameObject, 5.0f);
		yield return null;
	}
}
