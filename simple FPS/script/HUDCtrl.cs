using UnityEngine;
using System.Collections;

public class HUDCtrl : MonoBehaviour {
	public GUIText gt;
	public static int barrels = 9;
	public static int fireCount = 0;
	public static int hitCount = 0;
	public static int point = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		updateText();
	}

	private void updateText() {
		gt.text = "barrels : " + barrels + '\n'
			+ "fire : " + fireCount + '\n'
			+ "hit rate : " + DLLBridge.hitRate(fireCount, hitCount) + '\n'
			+ "point : " + point;
	}
}
