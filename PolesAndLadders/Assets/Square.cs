using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	public int number;
	public int type;
	public int end;
	// Use this for initialization

	void Start () {
		if (number < 0 || number > 80) {
			number = -1;
		}
		//Debug.Log (number);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
