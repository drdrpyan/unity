using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class QuizCtrl : MonoBehaviour {
	private TextMesh qMesh;
	public GUIText pointText;
	private int answer;
	private int count = 3;
	private int point = 0;


	// Use this for initialization
	void Start () {
		qMesh = GetComponent<TextMesh> ();
		pointText.text = "";
		setQuiz();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool testAnswer(int playerAnswer) {
		bool result = false;

		StartCoroutine(resetQuiz());
		count--;
		if(playerAnswer == answer) {
			point++;
			result = true;
		}
		else
			result = false;

		if(count == 0)
			pointText.text = "point : " + point;

		return result;
	}
	
	IEnumerator resetQuiz() {
		yield return new WaitForSeconds(3.0f);
		setQuiz();
	}

	private void setQuiz() {
		int num1=0;
		int num2=0;
		char op='+';

		if(StaticAttributes.dllMode) {
			//dll 없이 테스트하기 위해 주석 처리
			//int q = question();
			//num1 = q/1000;
			//num2 = (q&1000)/10;
			//op = (q%10 == 0) ? '+' : '*';
		}
		else {
			num1 = (int) UnityEngine.Random.Range(0, 100.0f);
			num2 = (int) UnityEngine.Random.Range(0, 100.0f);
			op = (UnityEngine.Random.Range (0, 10.0f) < 5) ? '+' : '*';
		}
		qMesh.text = "" + num1 + op + num2;
		answer = (op=='+') ? num1+num2 : num1*num2;
	}

	private void showPoint() {
		pointText.text = "point : " + point;
	}

	[DllImport ("PA3Win")]
	public static extern int question();
}
