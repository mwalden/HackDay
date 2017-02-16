using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private GameObject currentPlatform;
	private Rigidbody2D playerRigidbody;
	private CameraScript cameraScript;

	private Vector3 positionMovingTo;
	private bool moving;

	void Start(){
		playerRigidbody = GetComponent<Rigidbody2D> ();
		cameraScript = Camera.main.GetComponent<CameraScript>();
	}

	public void resetPlayerPosition(){
		Vector3 v = currentPlatform.gameObject.transform.position;
		Vector3 newV = new Vector3 (v.x, v.y + .25f, v.z);
		transform.position = newV;
		playerRigidbody.velocity = new Vector2(0.0f,0.0f);
	}

	public void SetCurrentPlatform(GameObject platform){
		if (currentPlatform != platform) {
			Debug.Log ("setting platform");
			currentPlatform = platform;
			cameraScript.moveCameraToPosition (new Vector3(platform.transform.position.x,platform.transform.position.y,-10f));
		}
	}

	void Update(){
		if (moving) {

			Debug.Log ("In moving");
			float step = cameraScript.speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, positionMovingTo, step);
			moving = transform.position != positionMovingTo;
			if (!moving)
				playerRigidbody.isKinematic = false;
		}
	}

	public void setKinematic(bool value){
		playerRigidbody.isKinematic = value;
	}

	public void moveToPosition(Vector3 position){
		positionMovingTo = position;
		moving = true;
	}
}
