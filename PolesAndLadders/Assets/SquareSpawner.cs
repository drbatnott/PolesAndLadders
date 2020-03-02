using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SquareSpawner : MonoBehaviour {
	public GameObject counter;
	public GameObject NPC;
	public GameObject protoSquare;
	GameObject [] square1;
	public GameObject dice;
	public GameObject board;
	public Text thrown;
	int [] start = {0,0};
	float timeSinceRolled;
	float timenow;//, timethen;
	bool notOver = true;
	bool rolling;
	bool rolled;
	int whoseGo;
	// Use this for initialization
	void Start () {
		//timenow = 0;
		//timethen = 0;
		whoseGo = 0;
		rolling = false;
		rolled = false;
		timeSinceRolled = 0;
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
	public void Roll(){
		rolling = true;
	}
	public void Throw(int whoseGoNow){
		Transform t= counter.GetComponent<Transform> ();
		int startThis = start[whoseGoNow];
		switch (whoseGoNow) {
		case 0:
			 t = counter.GetComponent<Transform> ();
			break;
		case 1:
			t = NPC.GetComponent<Transform> ();
			break;

		}
		Debug.Log (whoseGoNow);
		int r = Random.Range (1, 6);
		thrown.text = r.ToString();
		dice.GetComponent<AlignTheDice> ().AlignFace (r);
		startThis += r;
		if (startThis < 80) {
			Vector3 where = square1 [startThis].GetComponent<Transform> ().position;
			t.position = where;
		} else {
			if(startThis == 80){
				notOver = false;
				Vector3 where = square1 [startThis].GetComponent<Transform> ().position;
				t.position = where;
			}
			else{
				startThis -= r;
			}
		}
		start [whoseGoNow] = startThis;
	}
	// Update is called once per frame
	void Update () {
		if (notOver) {
			Debug.Log (whoseGo);
			Debug.Log ("Rolling " + rolling + " Rolled" + rolled);
			switch (whoseGo) {
			case 0:
				if (rolling && !rolled) {
					rolled = true;
					timeSinceRolled = 0;
				}
				else{
					if (rolling) {
						timeSinceRolled += Time.deltaTime;
						this.GetComponent<AnimateDice> ().Roll ();
						if (timeSinceRolled >= 1) {
							Throw (whoseGo);
							rolling = false;
							rolled = false;
							timeSinceRolled = 0;
							whoseGo = 1;
							rolling = true;
							Debug.Log ("Rolling " + rolling + " Rolled" + rolled);
							//this.GetComponent<AnimateDice> ().rolling = false;
						}
					}
				}
				/*
				if(!rolling && notOver && !rolled){
					whoseGo = 1;
					rolling = true;
					Debug.Log ("Rolling " + rolling + " Rolled" + rolled);
				}*/
				break;
			case 1:
				if (rolling && !rolled) {
					rolled = true;
					timeSinceRolled = 0;
				} else {
					if (rolling) {
						timeSinceRolled += Time.deltaTime;
						this.GetComponent<AnimateDice> ().Roll ();
						if (timeSinceRolled >= 1) {
							Throw (whoseGo);
							rolling = false;
							rolled = false;
							timeSinceRolled = 0;
							whoseGo = 0;
							//this.GetComponent<AnimateDice> ().rolling = false;
						}
					}
				}


				break;

			default:
				break;
			}
		}
		/*
		timenow += Time.deltaTime;
		//Debug.Log (timenow);
		if (timenow >= 1 && notOver) {
			this.GetComponent<AnimateDice> ().rolling = false;
			Throw ();
			timenow = 0;

		}
		*/
	}
}
