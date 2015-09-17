using UnityEngine;
using System.Collections;
public class CalculatorCtrl : MonoBehaviour {
	public QuizCtrl quiz;
	private int playerAnswer=0;
	public TextMesh answerText;
	public GUIText numField;
	public float speed = 0.1f;
	public float direction = 1.0f;

	// Use this for initialization
	void Start () {
		numField.text = "your answer : 0";
		answerText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (direction*speed*Time.deltaTime, 0, 0);
		if(this.transform.position.x>20 || this.transform.position.x < -20)
			direction = -direction;
	}

	public void addNumber(int num) {
		if(playerAnswer==0 && num!=0)
			playerAnswer = num;
		else
			playerAnswer = playerAnswer*10 + num;
		numField.text = "your answer : " + playerAnswer.ToString ();
	}

	public void enter() {
		bool correct = quiz.testAnswer (playerAnswer);
		if(correct) {
			answerText.text = "Correct!";
		}
		else {
			answerText.text = "Wrong!";
		}

		StartCoroutine (clear ());
	}

	IEnumerator clear() {
		yield return new WaitForSeconds(3.0f);
		answerText.text = "";
		numField.text = "your answer : 0";
		playerAnswer = 0;
	}
}