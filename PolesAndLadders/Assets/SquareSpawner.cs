using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SquareSpawner : MonoBehaviour {
	public GameObject counter;
	public GameObject[] NPC;
	public GameObject protoSquare;
    public GameObject protoLadder;
	GameObject [] square1;
    GameObject [] ladders;
	public GameObject dice;
	public GameObject board;
	public Text thrown;
	int [] start = {0,0,0};
	float timeSinceRolled;
	float timenow;//, timethen;
	bool notOver = true;
	bool rolling;
	bool rolled;
	int whoseGo;
	bool morePlay;
	public Text winner;
	public GameObject playAgain;
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
        NewGame();
	}
    void NewGame()
    {
        ladders = new GameObject[5];
        int j = 11;
        for (int i = 0; i < 5; i++)
        {
            ladders[i] = GameObject.Instantiate(protoLadder);
            int k = Random.Range(j, j + 10);
            Transform lt = ladders[i].GetComponent<Transform>();
            lt.position = square1[k].GetComponent<Transform>().position;
            j += 10;
        }
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
		case 2:
			t = NPC[whoseGoNow-1].GetComponent<Transform> ();
			break;

		}
		//Debug.Log (whoseGoNow);
		int r = Random.Range (1, 6);
		thrown.text = r.ToString();
		dice.GetComponent<AlignTheDice> ().AlignFace (r);
		startThis += r;
		if (startThis < 80) {
			Vector3 where = square1 [startThis].GetComponent<Transform> ().position;
			t.position = where;
		} else {
			if(startThis == 80){
				Vector3 where = square1 [startThis].GetComponent<Transform> ().position;
				t.position = where;
				notOver = false;
				winner.text = "The winner is ";
				if(whoseGoNow == 0){
					winner.text += "you!";
				}
				else{
					winner.text += "player " + whoseGoNow.ToString ();
				}
				playAgain.SetActive (true);
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
							//Debug.Log ("Rolling " + rolling + " Rolled" + rolled);
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
			case 2:
				if (rolling && !rolled) {
					rolled = true;
					timeSinceRolled = 0;
				} else {
					if (rolling) {
						timeSinceRolled += Time.deltaTime;
						this.GetComponent<AnimateDice> ().Roll ();
						if (timeSinceRolled >= 1) {
							Throw (whoseGo);
							rolled = false;
							timeSinceRolled = 0;
							int n = NPC.Length;
							whoseGo++;
							if(whoseGo > n){
								whoseGo = 0;
								rolling = false;
							}
							//Debug.Log ("who " + whoseGo + " Rolling " + rolling + " Rolled" + rolled);
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
