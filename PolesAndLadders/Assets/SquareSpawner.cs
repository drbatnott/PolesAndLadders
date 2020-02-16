using UnityEngine;
using System.Collections;

public class SquareSpawner : MonoBehaviour {

	public GameObject protoSquare;
	GameObject [] square1;

	// Use this for initialization
	void Start () {
		square1 = new GameObject[81];
		for (int i = 0; i < 78; i++) {
			square1 [i] = GameObject.Instantiate (protoSquare);
			square1 [i].GetComponent<Square> ().number = i;
		}
		square1[79] = GameObject.Instantiate (protoSquare);
		square1[79].GetComponent<Square> ().number = -2;
		square1[80] = GameObject.Instantiate (protoSquare);
		square1[80].GetComponent<Square> ().number = 85;
		square1[50] = GameObject.Instantiate (protoSquare);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
