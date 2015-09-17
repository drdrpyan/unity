using UnityEngine;
using System.Collections;

public class TeddyBearCtrl : MonoBehaviour {
	public Transform pivot;
	private Transform tr;
	public float xRotSpeed = 10.0f;
	public float yRotSpeed = 20.0f;
	public float zRotSpeed = 30.0f;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		tr.RotateAround (pivot.position, pivot.up, yRotSpeed);
		tr.RotateAround (pivot.position, pivot.right, xRotSpeed);
		tr.RotateAround (pivot.position, pivot.forward, zRotSpeed);
	}
}
