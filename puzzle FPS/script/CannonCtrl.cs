using UnityEngine;
using System.Collections;

public class CannonCtrl : MonoBehaviour {
	public GameObject teddyBear;
	public Transform firePos;
	public AudioClip shotSound;

	private Transform cannon;
	public float rotateSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		cannon = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)) {
			fireCannon();
		}
	}

	public void tiltUp() {
		cannon.Rotate (Vector3.left, rotateSpeed, Space.World);
	}

	public void tiltDown() {
		cannon.Rotate (Vector3.left, -rotateSpeed, Space.World);
	}

	public void panningLeft() {
		cannon.Rotate (Vector3.up, -rotateSpeed, Space.World);
	}

	public void panningRight() {
		cannon.Rotate (Vector3.up, rotateSpeed, Space.World);
	}

	public void fireCannon() {
		StartCoroutine(this.CreateTeddyBear());
		StartCoroutine(this.playSfx(shotSound));
	}

	private IEnumerator CreateTeddyBear() {
		Instantiate (teddyBear, firePos.position, firePos.rotation);
		yield return null;
	}

	IEnumerator playSfx(AudioClip aClip) {
		audio.PlayOneShot (aClip, 1.0f);
		yield return null;
	}
}
