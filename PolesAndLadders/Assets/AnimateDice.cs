using UnityEngine;
using System.Collections;

public class AnimateDice : MonoBehaviour {
	public GameObject dice;
	public int sideShowing = 6;
	public bool rolling = false;
	Quaternion q;
	Transform t;
	// Use this for initialization
	void Start () {
		t = dice.GetComponent<Transform> ();
	}
	void Update(){
		if (rolling) {
			Roll ();
		}
	}



	public void Roll () {
			int i = Random.Range (1,3);
			switch (i){
			case 1:
			t.Rotate(new Vector3(10f,0f,0f));
				break;
			case 2:
			t.Rotate(new Vector3(0f,10f,0f));

				break;
			case 3:
			t.Rotate(new Vector3(0f,0f,10f));

				break;
			default:
				break;
			}
		}
	}

