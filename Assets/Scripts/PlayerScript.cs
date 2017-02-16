using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private GameObject currentPlatform;
	private Rigidbody2D playerRigidbody;
	void Start(){
		playerRigidbody = GetComponent<Rigidbody2D> ();
	}

	public void resetPlayerPosition(){

		Vector3 v = currentPlatform.gameObject.transform.position;
		Vector3 newV = new Vector3 (v.x, v.y + .25f, v.z);
		transform.position = newV;
		playerRigidbody.velocity = new Vector2(0.0f,0.0f);
		
	}

	public void SetCurrentPlatform(GameObject platform){
		currentPlatform = platform;
	}
}
