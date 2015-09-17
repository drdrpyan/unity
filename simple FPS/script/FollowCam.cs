using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public Transform target;
	public float dist = 5.0f;
	public float height = 3.0f;
	public float dampRotate = 5.0f;

	private Transform tr;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
	}
	
	void LateUpdate() {
		float currYAngle = Mathf.LerpAngle (tr.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);
		//float currXAngle = Mathf.LerpAngle (tr.eulerAngles.x, Input.GetAxis ("Mouse X"), dampRotate * Time.deltaTime);
		Quaternion rot = Quaternion.Euler (0, currYAngle, 0);
		//Quaternion rot2 = Quaternion.Euler (currXAngle, 0, 0);
		tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
		//tr.Translate (Vector3.up * Time.deltaTime * 50.0f * Input.GetAxis ("Mouse Y"));
		//tr.Translate (Vector3.right * Time.deltaTime * -50.0f * Input.GetAxis ("Mouse X"));

		tr.LookAt (target);

	}
}
