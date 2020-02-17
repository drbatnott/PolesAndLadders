using UnityEngine;
using System.Collections;

public class SquareSpawner : MonoBehaviour {

	public GameObject protoSquare;
	GameObject [] square1;
	public GameObject board;
	// Use this for initialization
	void Start () {
		float boardLeft = board.GetComponent<BoardLocations> ().left;
		square1 = new GameObject[81];
		for (int i = 0; i < 78; i++) {
			square1 [i] = GameObject.Instantiate (protoSquare);
			square1 [i].GetComponent<Square> ().number = i;
		}
		square1[79] = GameObject.Instantiate (protoSquare);
		square1[79].GetComponent<Square> ().number = -2;
		square1[80] = GameObject.Instantiate (protoSquare);
		square1[80].GetComponent<Square> ().number = 85;
		Transform t = square1 [1].GetComponent<Transform> ();
		//Initially set location of square 1 to be 0.5 square width from boardLeft
		t.position = new Vector3 (boardLeft + 0.5f, 1.03f);
		//check visually this is inside the board left square column
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
