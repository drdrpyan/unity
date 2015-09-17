using UnityEngine;
using System.Collections;

public class TeddyCtrl : MonoBehaviour {
	public float bound = 25.0f;
	public float speed = 1000.0f;
	public GameObject explosionEffect;
	private Transform tr;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		rigidbody.AddForce (transform.forward * speed);
	}
	
	// Update is called once per frame
	void Update () {
		if(tr.position.x>bound || tr.position.x<(-bound)
		   || tr.position.y>bound || tr.position.y<(-bound)
		   || tr.position.z>bound || tr.position.z<(-bound) )
			Destroy(this.gameObject);
	}
}
