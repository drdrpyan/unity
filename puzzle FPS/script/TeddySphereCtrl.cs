using UnityEngine;
using System.Collections;

public class TeddySphereCtrl : MonoBehaviour {
	public GameObject teddyBear;
	private Transform tr;
	private TeddyBearCtrl tbc;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		tbc = teddyBear.GetComponent<TeddyBearCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		tr.RotateAround (tbc.pivot.position, teddyBear.transform.up, tbc.yRotSpeed * 2.0f);
	}
}
