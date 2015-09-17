using UnityEngine;
using System.Collections;

public class BulletCtrl : MonoBehaviour {
	public int damage = 20;
	public float speed = 1500.0f;

	void Start () {
		rigidbody.AddForce(transform.forward * speed);	
	}
}