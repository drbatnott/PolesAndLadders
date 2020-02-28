using UnityEngine;
using System.Collections;

public class AlignTheDice : MonoBehaviour {
	Transform t;

	void Start(){
		t = this.GetComponent<Transform> ();
	}
	public void AlignFace(int i){
		//Debug.Log (t.rotation.x + " " + t.rotation.y + " " + t.rotation.z + " " + t.rotation.w);
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
		//t.rotation = new Quaternion (0f, 90f, 0f, 0f);
		//Debug.Log ("i is " + i);

	}
}
