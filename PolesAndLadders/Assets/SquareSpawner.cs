using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SquareSpawner : MonoBehaviour {
	public GameObject counter;
	public GameObject protoSquare;
	GameObject [] square1;
	public GameObject board;
	public Text thrown;
	int start = 0;
	float timenow;//, timethen;
	bool notOver = true;
	// Use this for initialization
	void Start () {
		timenow = 0;
		//timethen = 0;
		float boardLeft = board.GetComponent<BoardLocations> ().left + 0.6f;
		float currentSquareLocX = boardLeft;
		float boardBottom = board.GetComponent<BoardLocations> ().bottom;
		float currentSquareLocY = boardBottom;
		square1 = new GameObject[81];
		square1 [0] = GameObject.Instantiate (protoSquare);
		square1 [0].GetComponent<Square> ().number = 0;
		float mult = 1f;
		Transform t = square1 [0].GetComponent<Transform> ();
		//Initially set location of square 1 to be 0.6 from boardLeft
		t.position = new Vector3 (-7.46f,-3.22f);

		for (int i = 1; i < 81; i++) {
			square1 [i] = GameObject.Instantiate (protoSquare);
			square1 [i].GetComponent<Square> ().number = i;
			t = square1 [i].GetComponent<Transform> ();
			//Initially set location of square 1 to be 0.6 from boardLeft
			t.position = new Vector3 (currentSquareLocX , currentSquareLocY);
			//check visually this is inside the board left square column
			if(i%10 == 1 && i !=1) mult *= -1;
			if(i%10 != 0){
				currentSquareLocX += mult * 1.28f;
				//Debug.Log (i + " " + currentSquareLocX + " " + currentSquareLocY);
			}
			else{
				currentSquareLocY += 1.26f;
				//Debug.Log (i + " in else " + currentSquareLocX + " " + currentSquareLocY);

			}
		}
		/*	square1[79] = GameObject.Instantiate (protoSquare);
		square1[79].GetComponent<Square> ().number = -2;
		square1[80] = GameObject.Instantiate (protoSquare);
		square1[80].GetComponent<Square> ().number = 85;
		Transform t = square1 [1].GetComponent<Transform> ();
		//Initially set location of square 1 to be 0.6 from boardLeft
		t.position = new Vector3 (boardLeft + 0.6f, 1.03f);
		//check visually this is inside the board left square column */
	}

	public void Throw(){
		Transform t = counter.GetComponent<Transform> ();
		int r = Random.Range (1, 6);
		thrown.text = r.ToString();
		start += r;
		if (start < 80) {
			Vector3 where = square1 [start].GetComponent<Transform> ().position;
			t.position = where;
		} else {
			if(start == 80){
				notOver = false;
				Vector3 where = square1 [start].GetComponent<Transform> ().position;
				t.position = where;
			}
			else{
				start -= r;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		timenow += Time.deltaTime;
		//Debug.Log (timenow);
		if (timenow >= 1 && notOver) {
			Throw ();
			timenow = 0;
		}
	}
}
