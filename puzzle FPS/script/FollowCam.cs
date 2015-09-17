using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public Transform target;			// 카메라가 추적하는 object의 Transform
	public float dist = 0.1f;			// 카메라와 추적 object 사이의 거리
	public float height = 3.0f;			// 카메라와 추적 object의 사이의 높이

	private Transform tr;				// 카메라 자신의 Transform
	private float horizontal = 0.0f;
	
	void Start () {
		tr = GetComponent<Transform>();
	}

	// LateUpdate()는 update()가 실행된 이후에 호출된다.
	void LateUpdate() {
		if(StaticAttributes.buttonMode) {
			tr.position = new Vector3(0.0f, 2.5f, -10.0f);
			tr.LookAt(new Vector3(0.0f, 2.5f, 0.0f));
		}
		else {
			tr.position = target.position - (target.forward * dist) + (Vector3.up * height);
			tr.RotateAround (target.position, Vector3.left, horizontal);
			horizontal += 300.0f * Input.GetAxis ("Mouse Y") * Time.deltaTime;
			if(horizontal > 70.0f)
				horizontal = 70.0f;
			else if(horizontal < -40.0f)
				horizontal = -40.0f;
			// 카메라가 추적 object를 바라보게 함
			tr.LookAt(target);
		}
	}
}