using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject currentPlatform;
	private Rigidbody2D playerRigidbody;
	private CameraScript cameraScript;
	private GameController gameController;
	private ScoreScript scoreScript;
	private Vector3 positionMovingTo;
	private bool moving;


	void Start(){
		playerRigidbody = GetComponent<Rigidbody2D> ();
		cameraScript = Camera.main.GetComponent<CameraScript>();
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		scoreScript = GameObject.FindGameObjectWithTag ("score").GetComponent<ScoreScript> ();
	}

	public void resetPlayerPosition(){
		Vector3 v = currentPlatform.gameObject.transform.position;
		Vector3 newV = new Vector3 (v.x, v.y + .25f, v.z);
		transform.position = newV;
		playerRigidbody.velocity = new Vector2(0.0f,0.0f);
		scoreScript.setScore (-100);
	}

	public void SetCurrentPlatform(GameObject platform){
		if (currentPlatform != platform) {
			if (currentPlatform != null) {
				scoreScript.setScore (100);
				gameController.addPlatformPassed (1);
			}
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
