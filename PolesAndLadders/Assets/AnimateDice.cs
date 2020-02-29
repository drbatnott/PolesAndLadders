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
		/*if (rolling) {
			Roll ();
		}*/
	}



	public void Roll () {
			int i = Random.Range (1,6);
	
			switch (i) {
			case 1:
				t.rotation = new Quaternion (0.7071f, 0f, 0f, 0.7071f);
				break;
			case 2:
				t.rotation = new Quaternion (0f, -0.7071f, 0f, 0.7071f);
				break;
			case 3:
				t.rotation = new Quaternion (1f, 0f, 0f, 0f);
				break;
			case 4:
				t.rotation = new Quaternion (0f, 0f, 0f, 1f);
				break;
			case 5:
				t.rotation = new Quaternion (0f, 0.7071f, 0f, 0.7071f);
				break;
			case 6:
				t.rotation = new Quaternion (-0.7071f, 0f, 0f, 0.7071f);
				break;
			}
			
		}
	}

