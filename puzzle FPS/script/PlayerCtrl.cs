using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {
	private float h = 0.0f;		// horizontal 방향
	private float v = 0.0f;		// vertical 방향

	private Transform tr;
	public float moveSpeed = 10.0f;		// 이동 속도
	public float rotSpeed = 500.0f;		// 회전 속도

	// 클래스는 System.Serializable을 명시해야 inspector에 나타난다. 
	[System.Serializable]
	// 애니메이션 클립을 저장한다.
	public class Anim {
		public AnimationClip idle;
		public AnimationClip runForward;
		public AnimationClip runBackward;
		public AnimationClip runRight;
		public AnimationClip runLeft;
	}

	public Anim anim;
	public Animation _animation;

	void Start () {
		// 스크립트 컴포넌트를 할당. 스크립트에서 접근이 가능
		tr = GetComponent<Transform>();
		// 자신의 하위에 있는 컴포넌트를 할당
		_animation = GetComponentInChildren<Animation>();
		_animation.clip = anim.idle;
		_animation.Play ();
	}

	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		// 이동방향 벡터
		Vector3 moveDir = new Vector3(h, 0, v);
		// Translate(이동방향 * time.deltaTme * 속도, 기준 좌표) 
		tr.Translate(moveDir * Time.deltaTime * moveSpeed , Space.Self);
		// Vector3.up 기준으로 회전
		if(!StaticAttributes.buttonMode)
			tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
	
		// v, h를 수치를 이용해 애니메이션을 블렌딩
		if (v >= 0.1f) {
			_animation.CrossFade(anim.runForward.name, 0.3f);
		}
		else if (v <= -0.1f){
			_animation.CrossFade(anim.runBackward.name, 0.3f);
		}
		else if (h >= 0.1f) {
			_animation.CrossFade(anim.runRight.name, 0.3f);
		}
		else if (h <= -0.1f) {
			_animation.CrossFade(anim.runLeft.name, 0.3f);
		}
		else {
			_animation.CrossFade(anim.idle.name, 0.3f);
		}
	}
}